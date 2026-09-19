# Althea Vallejos: MVC Portfolio

An ASP.NET Core MVC (.NET 8) portfolio that lists my GitHub projects with thumbnails,
a table of contents, a detail page per project, and a comment section on every project.

## 🔐 Login credentials (hardcoded)

| Field    | Value            |
|----------|------------------|
| Username | `admin`          |
| Password | `Portfolio@2026` |

The credentials are defined in `Services/AuthService.cs`. Every page requires login.

## Run locally

```bash
dotnet restore
dotnet run --launch-profile https
```
Open the URL shown in the terminal (e.g. https://localhost:7xxx). The SQLite database
(`portfolio.db`) is created automatically on first run.

## Features
- Table of contents grouped by Prelim, Midterm, Prefinal, Group Projects and General
- Thumbnail card and GitHub link for each project
- Detail page per project with previous/next navigation
- Comment section per project (add and delete), stored in SQLite
- Responsive layout with automatic light/dark mode

## Security measures
- Site-wide authentication (cookie is HttpOnly, SameSite=Lax, 30-minute sliding expiry)
- Constant-time credential comparison, plus lockout after 5 failed attempts (5 minutes)
- Anti-forgery (CSRF) token validated on every POST
- Razor output encoding (XSS), input length validation, and separate input models (no over-posting)
- EF Core parameterised queries (SQL injection)
- Open-redirect protection on login `returnUrl`
- Security headers: CSP, X-Frame-Options, X-Content-Type-Options, Referrer-Policy
- External links use `rel="noopener noreferrer"`

## Project structure
```
Controllers/  Home, Account, Projects
Models/       Project, Comment, view models
Data/         PortfolioContext (EF Core), ProjectCatalog (project list)
Services/     AuthService (hardcoded login + lockout)
Views/        Home, Projects, Account, Shared
wwwroot/      css, js, images/projects
```
