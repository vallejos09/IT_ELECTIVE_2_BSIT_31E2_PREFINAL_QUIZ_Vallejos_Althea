using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Models;

namespace Portfolio.Controllers;

public class ProjectsController(PortfolioContext db) : Controller
{
    [HttpGet("projects/{slug}")]
    public async Task<IActionResult> Details(string slug)
    {
        var project = ProjectCatalog.Find(slug);
        if (project is null) return NotFound();
        return View(await BuildModel(project, new CommentInput()));
    }

    [HttpPost("projects/{slug}/comments")]
    public async Task<IActionResult> AddComment(
        string slug, [Bind(Prefix = nameof(ProjectDetailsViewModel.NewComment))] CommentInput input)
    {
        var project = ProjectCatalog.Find(slug);
        if (project is null) return NotFound();

        if (!ModelState.IsValid)
            return View(nameof(Details), await BuildModel(project, input));

        db.Comments.Add(new Comment
        {
            ProjectSlug = project.Slug,
            Name = input.Name.Trim(),
            Message = input.Message.Trim()
        });
        await db.SaveChangesAsync();

        TempData["Flash"] = "Your comment was posted.";
        return RedirectToAction(nameof(Details), "Projects", new { slug }, "comments");
    }

    [HttpPost("projects/{slug}/comments/{id:int}/delete")]
    public async Task<IActionResult> DeleteComment(string slug, int id)
    {
        if (ProjectCatalog.Find(slug) is null) return NotFound();

        await db.Comments.Where(c => c.Id == id && c.ProjectSlug == slug).ExecuteDeleteAsync();
        return RedirectToAction(nameof(Details), "Projects", new { slug }, "comments");
    }

    private async Task<ProjectDetailsViewModel> BuildModel(Project project, CommentInput input)
    {
        var all = ProjectCatalog.All;
        var i = all.ToList().FindIndex(p => p.Slug == project.Slug);

        return new ProjectDetailsViewModel
        {
            Project = project,
            NewComment = input,
            Previous = i > 0 ? all[i - 1] : null,
            Next = i < all.Count - 1 ? all[i + 1] : null,
            Comments = await db.Comments.AsNoTracking()
                .Where(c => c.ProjectSlug == project.Slug)
                .OrderByDescending(c => c.CreatedAt)
                .ToListAsync()
        };
    }
}