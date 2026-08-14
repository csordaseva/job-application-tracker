# Job Application Tracker API

A small ASP.NET Core Web API for tracking job applications.

## Tech stack

- C#
- ASP.NET Core Web API
- Entity Framework Core
- SQLite
- Swagger / OpenAPI

## Current features

- List all job applications
- Get one application by id
- Create a new application
- Update an existing application
- Delete an application

## Run locally

Requirements:
- .NET 9 SDK

Commands:

```bash
dotnet restore
dotnet run
```

Then open the Swagger URL printed by the application, typically:

- https://localhost:7188/swagger
- http://localhost:5188/swagger

The SQLite database file (`jobtracker.db`) is created automatically on first run.

## Example request body

```json
{
  "company": "Evosoft",
  "position": "Test Script Developer",
  "appliedAt": "2026-08-13T10:00:00Z",
  "status": "Interview",
  "notes": "Phone screening completed."
}
```

## Learning goals

This project is intentionally small so the architecture is easy to understand before adding:
- DTOs and validation
- service layer
- migrations
- unit/integration tests
- Angular + TypeScript frontend
- Bootstrap UI
