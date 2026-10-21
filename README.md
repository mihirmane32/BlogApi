# Blog API

A REST API for a simple blog (posts and comments) built with ASP.NET Core (.NET 10). This is a self-directed learning project focused on understanding how real backends are designed, not just making endpoints respond.

## What's working right now

- `GET /posts`: list all posts
- `GET /posts/{id}`: fetch one post, or return `404` if it does not exist
- `POST /posts`: create a post, returns `201 Created`, or `400 Bad Request` if the title or content is missing or the title is too long
- `PUT /posts/{id}`: replace a post's title and content, returns `200`, `404` or `400`
- `DELETE /posts/{id}`: remove a post, returns `204 No Content` or `404`
- `PostService` holds the logic and storage, so the controller only deals with HTTP

## Design notes

- Controllers handle HTTP (status codes, routing); the service handles the actual work.
- Clients send a DTO (`CreatePostRequest`, `UpdatePostRequest`) rather than the `Post` model itself, so they can't set server-controlled fields like `Id` or `CreatedAt`.
- The create and update DTOs are identical for now but keptseparate on purpose, since their rules are likely to diverge.
- Validation is declared with attributes on the DTO, and ASP.NET returns `400` automatically.
- Dependencies come through constructor injection, using ASP.NET's built container.
- No secrets or connection strings are stored in the repository. Any sensitive (like a future JWT signing key) will come from user-secrets or environment variables.

## Known gaps

- Posts live in memory and are lost when the app restarts.

## Testing it

Run the project, then open `BlogApi.http` in Visual Studio and send the requests.

## Status

In progress. Next up: comments on post, then global error handling, then JWT authentication.