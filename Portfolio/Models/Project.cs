namespace Portfolio.Models;

public class Project
{
    public required string Slug { get; init; }
    public required string Title { get; init; }
    public required string Category { get; init; }
    public required string Summary { get; init; }
    public required string Description { get; init; }
    public required string RepoUrl { get; init; }
    public string[] Tags { get; init; } = [];
    public string Owner => RepoUrl.TrimEnd('/').Split('/')[^2];
    public string RepoName => RepoUrl.TrimEnd('/').Split('/')[^1];
}