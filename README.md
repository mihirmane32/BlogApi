# Blog API

A REST API for a simple blog (posts and comments) built with ASP.NET Core (.NET 10). This is a self-directed learning project focused on understanding how real backends are designed, not just making endpoints respond.

## What's working right now

- `GET /posts`: list all posts
- `GET /posts/{id}`: fetch one post, or return `404` if it does not exist

## Design notes

- No secrets or connection strings are stored in the repository. Any sensitive values should come from environment variables.

## Testing it

Run the project, then open `BlogApi.http` in Visual Studio and send the requests.

## Status

In progress. Next up: creating posts (`POST`), validation, and then update/delete operations.