# Blog API

A REST API for a simple blog (posts and comments) built with ASP.NET Core (.NET 10). This is a self-directed learning project focused on understanding how real backends are designed, not just making endpoints respond.

## What's working right now

- `GET /posts`: list all posts
- `GET /posts/{id}`: fetch one post, or return `404` if it does not exist
- `POST /posts`: create a post, returns `201 Created`, or `400 Bad Request` if the title or content is missing or the title is too long
- `PUT /posts/{id}`: replace a post's title and content, returns `200`, `404` or `400`
- `DELETE /posts/{id}`: remove a post, returns `204 No Content` or `404`
- `GET posts/{postId}/comments`: list a post's comments, or `404` if the post doesn't exist
- `POST posts/{postId}/comments`: add a comment, returns `201`, `404`, or `400`
- Unexpected errors return a consistent JSON `500` response; details are logged server-side and never sent to the client
- `PostService` and `CommentService` holds the logic and storage, so the controller only deals with HTTP

## Design notes

- Controllers handle HTTP (status codes, routing); the service handles the actual work.
- Clients send a DTO (`CreatePostRequest`, `UpdatePostRequest`) rather than the `Post` model itself, so they can't set server-controlled fields like `Id` or `CreatedAt`.
- The create and update DTOs are identical for now but keptseparate on purpose, since their rules are likely to diverge.
- Validation is declared with attributes on the DTO, and ASP.NET returns `400` automatically.
- Comments live under their post (`/posts/{postId}/comments`) because a comment can't exist without one.
- Deleting a post also deletes its comments, so no orphaned data is left behind.
- Error handling lives in one place (`GlobalExceptionHandler`) instead of try/catch in every action. It logs the full exception and returns only a generic message, because stack traces expose internals.
- Dependencies come through constructor injection, using ASP.NET's built container.
- No secrets or connection strings are stored in the repository. Any sensitive (like a future JWT signing key) will come from user-secrets or environment variables.

## Known gaps

- Posts and comments live in memory and are lost when the app restarts.
- Anyone can create, edit, or delete posts (no authentication yet).

## Testing it

Run the project, then open `BlogApi.http` in Visual Studio and send the requests.

## Status

In progress. Next up: JWT authentication.