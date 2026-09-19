using Portfolio.Models;

namespace Portfolio.Data;

public static class ProjectCatalog
{
    public static readonly string[] Categories =
        ["Prelim", "Midterm", "Prefinal", "Group Projects", "General"];

    public static Project? Find(string slug) => All.FirstOrDefault(p => p.Slug == slug);

    private static Project P(string slug, string title, string category,
                             string summary, string repo, string? description = null) => new()
                             {
                                 Slug = slug,
                                 Title = title,
                                 Category = category,
                                 Summary = summary,
                                 Description = description ?? summary,
                                 RepoUrl = repo,
                                 Tags = [category, category == "Group Projects" ? "Team" : "Solo"]
                             };

    private const string Me = "https://github.com/vallejos09/";
    private const string Team = "https://github.com/AlbanoRavenPOGI/";

    public static readonly IReadOnlyList<Project> All =
    [
        // Prelim 
        P("prelim-assignment-1", "Prelim Assignment 1", "Prelim",
          "First assignment of the Prelim period for IT Elective 2.",
          Me + "ite-two-prelim-assignment-one"),
        P("prelim-assignment-2", "Prelim Assignment 2", "Prelim",
          "Second assignment of the Prelim period.",
          Me + "BSIT31E3_PRELIM_A2_VALLEJOS_ALTHEA"),
        P("prelim-assignment-3", "Prelim Assignment 3", "Prelim",
          "Third assignment of the Prelim period.",
          Me + "BSIT31E2_A3_PRELIM_VALLEJOS_ALTHEA"),
        P("prelim-hands-on-1", "Prelim Hands-on 1", "Prelim",
          "Hands-on exercise 1 from the Prelim period.",
          Me + "BSIT31E3_PRELIM_H1_VALLEJOS_ALTHEA"),
        P("prelim-hands-on-2", "Prelim Hands-on 2", "Prelim",
          "Hands-on exercise 2 from the Prelim period.",
          Me + "BSIT31E3_PRELIM_H2_Vallejos_Althea"),
        P("prelim-quiz-1", "Prelim Quiz 1", "Prelim",
          "Practical quiz project from the Prelim period.",
          Me + "BSIT_31A3_PRELIM_Q1_Vallejos_Althea"),

        // Midterm
        P("midterm-assignment-1", "Midterm Assignment 1", "Midterm",
          "First assignment of the Midterm period.",
          Me + "IT_ELECTIVE_2_Midterm_A1_Vallejos_Althea"),
        P("midterm-exam-9", "Midterm Exam #9", "Midterm",
          "Midterm examination project for IT Elective 2.",
          Me + "IT_ELECTIVE_2_MIDTERM_EXAM_9_Vallejos_Althea"),
        P("midterm-quiz-2", "Midterm Quiz 2", "Midterm",
          "Practical quiz 2 of the Midterm period.",
          Me + "IT_ELECTIVE_2_MIDTERM_Q2_Vallejos_Althea"),
        P("midterm-quiz-3", "Midterm Quiz 3", "Midterm",
          "Practical quiz 3 of the Midterm period.",
          Me + "IT_ELECTIVE_2_MIDTERM_Q3_Vallejos_Althea"),
        P("midterm-hands-on-1-3", "Midterm Hands-on 1–3", "Midterm",
          "Three hands-on exercises from the Midterm period, combined in one repository.",
          Me + "IT_ELECTIVE_2_MIDTERM_H1_H2_H3_Vallejos_Althea"),

        // Prefinal
        P("prefinals-activity-1", "Prefinals Activity 1", "Prefinal",
          "First activity of the Prefinals period.",
          Me + "IT_ELECTIVE_2_PREFINALS_ACT1_Vallejos_Althea"),
        P("prefinal-exam", "Prefinal Exam", "Prefinal",
          "Prefinal examination project for IT Elective 2 (BSIT 31E2).",
          Me + "IT_ELECTIVE_2_BSIT_31E2_PREFINAL_EXAM_Vallejos_Althea"),

        // Group Projects
        P("prefinals-group-project", "Prefinals Group Project", "Group Projects",
          "Team project for the Prefinals period, built with Albano.",
          Team + "IT_ELECTIVE_2_PREFINALS_PROJECT_Albano_Vallejos"),
        P("midterm-hackathon", "Midterm Hackathon", "Group Projects",
          "Hackathon project built as a team of three (Albano, Vallejos, Abadilla).",
          Team + "31E2_MIDTERM_IT_ELECTIVE_2_Hackathon_Albano_Vallejos_Abadilla"),

        // General
        P("it-elective-31e2", "IT Elective: BSIT 31E2", "General",
          "General IT Elective coursework repository for section BSIT 31E2.",
          Me + "IT_ELECTIVE_BSIT_31E2_Vallejos_Althea"),
    ];
}