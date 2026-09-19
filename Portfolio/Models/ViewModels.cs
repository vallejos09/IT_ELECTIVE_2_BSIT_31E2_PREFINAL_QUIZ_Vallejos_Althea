using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models;

public class LoginViewModel
{
    [Required, StringLength(50)]
    public string Username { get; set; } = string.Empty;

    [Required, StringLength(100), DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    public string? ReturnUrl { get; set; }
}

public class CommentInput
{
    [Display(Name = "Your name")]
    [Required(ErrorMessage = "Please enter your name.")]
    [StringLength(40, MinimumLength = 2, ErrorMessage = "Name must be 2–40 characters.")]
    public string Name { get; set; } = string.Empty;

    [Display(Name = "Comment")]
    [Required(ErrorMessage = "Please write a comment.")]
    [StringLength(500, MinimumLength = 2, ErrorMessage = "Comment must be 2–500 characters.")]
    public string Message { get; set; } = string.Empty;
}

public class ProjectDetailsViewModel
{
    public required Project Project { get; init; }
    public required IReadOnlyList<Comment> Comments { get; init; }
    public CommentInput NewComment { get; init; } = new();
    public Project? Previous { get; init; }
    public Project? Next { get; init; }
}