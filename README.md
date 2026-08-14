# Job Application Tracker

A full-stack portfolio project for tracking job applications throughout the recruitment process.

The backend is built with ASP.NET Core and provides a REST API for creating, viewing, updating and deleting job applications. Data is persisted locally using Entity Framework Core and SQLite.

The project is being developed incrementally, with an Angular frontend, validation and automated tests planned as the next steps.

## Tech stack

### Backend
- C#
- ASP.NET Core Web API
- Entity Framework Core
- SQLite
- Swagger / OpenAPI

### Frontend
- Angular + TypeScript *(planned)*
- Bootstrap *(planned)*

## Current features

- List all job applications
- Get a job application by ID
- Create a new job application
- Update an existing job application
- Delete a job application
- Persistent storage with SQLite
- Interactive API documentation and testing with Swagger

## API endpoints

| Method |         Endpoint			   | Description			  |
|--------|-----------------------------|--------------------------|
| GET	 | `/api/JobApplications`	   | Get all applications	  |
| GET	 | `/api/JobApplications/{id}` | Get an application by ID |
| POST	 | `/api/JobApplications`	   | Create a new application |
| PUT	 | `/api/JobApplications/{id}` | Update an application	  |
| DELETE | `/api/JobApplications/{id}` | Delete an application	  |

## Run locally

### Requirements

- .NET 9 SDK

### Start the application

```bash
dotnet restore
dotnet run
```

Then open the Swagger URL printed by the application, typically:

https://localhost:7188/swagger
http://localhost:5188/swagger

The SQLite database (jobtracker.db) is created automatically on first run and is excluded from version control.

## Example request

```json
{
  "company": "Evosoft",
  "position": "Test Script Developer",
  "appliedAt": "2026-08-13T10:00:00Z",
  "status": "Interview",
  "notes": "Phone screening completed."
}
```
## Purpose

This project is designed as a practical learning project for building a modern full-stack application while keeping the architecture understandable and extending it step by step.

## Learning goals

This project is intentionally small so the architecture is easy to understand before adding:
- DTOs and validation
- service layer
- migrations
- unit/integration tests
- Angular + TypeScript frontend
- Bootstrap UI
