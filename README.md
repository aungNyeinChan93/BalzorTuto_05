# BlazorBlog

A layered Blazor Server blog application demonstrating clean separation between presentation, application, infrastructure and domain layers.

Projects
- `BlazorBlog.Server` — Blazor Server UI (pages, components and layouts).
- `BlazorBlog.Application` — application services and business logic.
- `BlazorBlog.Infrastructure` — EF Core data access, repositories and DI wiring.
- `BlazerBlog.Domain` — domain entities and value objects.

Technologies
- .NET 10
- Blazor Server
- Entity Framework Core
- SQL Server (connection strings in `BlazorBlog.Server/appsettings.json`)

Quick start

1. Prerequisites
   - .NET 10 SDK
   - SQL Server instance
   - Optional: Visual Studio 2022/2026 or VS Code

2. Configure database
   - Edit `BlazorBlog.Server/appsettings.json`
   - Update connection strings (keys used by the projects):
     - `AppDbContext2Context`
     - `defaultConnection`

3. Run EF Core migrations
   - From the solution root (adjust project names if needed):
     - `dotnet ef migrations add Initial -p BlazorBlog.Infrastructure -s BlazorBlog.Server`
     - `dotnet ef database update -p BlazorBlog.Infrastructure -s BlazorBlog.Server`

4. Build and run
   - CLI:
     - `dotnet build`
     - `dotnet run --project BlazorBlog.Server`
   - Or open the solution in Visual Studio and set `BlazorBlog.Server` as the startup project.

Development notes
- UI pages and components are in `BlazorBlog.Server/Components/Pages` and `BlazorBlog.Server/Components/Layout`.
- Application services are in `BlazorBlog.Application` (e.g., `ArticleService`).
- Repository implementations are in `BlazorBlog.Infrastructure/Repositries` and are registered via DI (see `DependencyInjection.cs` files).
- Domain entities live in `BlazerBlog.Domain` (e.g., `Articles/Article.cs`).

Testing
- If test projects exist, run tests with `dotnet test` from the solution root.

Contributing
- Fork the repository, create a feature branch, add focused commits and submit a pull request.
- Follow existing naming and style conventions and include tests for behavior changes.

License
- Add a `LICENSE` file to the repository root to declare the project license.

Contact
- For setup or developer questions, inspect:
  - `BlazorBlog.Server/appsettings.json`
  - `BlazorBlog.Infrastructure/DependencyInjection.cs`
  - `BlazorBlog.Application/DependencyInjection.cs`

Notes
- This README is concise; add more details (architecture diagram, CI, API contract) as the project matures.

API

Overview
- The server project (`BlazorBlog.Server`) exposes a small REST API used by the Blazor UI and third‑party clients. Endpoints are organized by resource (articles, categories) under the `/api` path. If Swagger is enabled you can browse the API at `/swagger` when the app is running.

Common endpoints

Articles
- `GET /api/articles` — list articles (supports query params: `page`, `pageSize`, `categoryId`, `search`).
- `GET /api/articles/{id}` — get a single article by id.
- `POST /api/articles` — create an article. Accepts `ArticleCreateDto` in the request body.
- `PUT /api/articles/{id}` — update an article. Accepts `ArticleUpdateDto`.
- `DELETE /api/articles/{id}` — delete an article.

Categories
- `GET /api/categories` — list categories.
- `GET /api/categories/{id}` — get a single category.
- `POST /api/categories` — create a category.
- `PUT /api/categories/{id}` — update a category.
- `DELETE /api/categories/{id}` — delete a category.

Sample DTOs (JSON)
- `ArticleCreateDto` (request)

  {
    "title": "My article title",
    "summary": "Short summary",
    "content": "Full article content",
    "categoryId": 1,
    "published": true
  }

- `ArticleDto` (response)

  {
    "id": 123,
    "title": "My article title",
    "summary": "Short summary",
    "content": "Full article content",
    "author": "Author Name",
    "category": { "id": 1, "name": "General" },
    "createdAt": "2026-04-01T12:00:00Z",
    "updatedAt": "2026-04-02T08:30:00Z",
    "published": true
  }

Authentication & Authorization
- Depending on the solution configuration the API may be public or protected. If authentication is required, the project typically wires authentication in `Program.cs`/`Startup.cs` and protects controller/routes with `[Authorize]`. For token based APIs, use JWT; for browser based scenarios the Blazor Server cookie scheme may be used.

Examples
- Get articles (public):

  `curl -s http://localhost:5000/api/articles`

- Create an article (JSON body):

  `curl -X POST http://localhost:5000/api/articles -H "Content-Type: application/json" -d '{"title":"New","summary":"S","content":"C","categoryId":1,"published":false}'`

Extending the API
- Add a new controller under `BlazorBlog.Server/Controllers`, create request/response DTOs in `BlazorBlog.Application` (or a shared DTO project), and register services/repositories in the existing DI registration files:
  - `BlazorBlog.Application/DependencyInjection.cs`
  - `BlazorBlog.Infrastructure/DependencyInjection.cs`

Notes
- Keep API contracts stable; add versioning if you expect breaking changes (e.g. `/api/v1/articles`).
