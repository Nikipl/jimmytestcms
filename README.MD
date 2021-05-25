# CMS for JimmyTec

##Project structure

This project using Mediatr to implement the CQRS approach.

 - JimmyTestCMS.Api - controllers and asp.net core 5 initialization
 - JimmyTestCMS.Services - commands and queries handlers
 - JimmyTestCMS.Data - database model, ef core
 - JimmyTestCMS.Common - code shared across the solution
 - JimmyTestCMS.DbUpdater - a utility to run ef core migrations in the Docker container
 - JimmyTestCMD.Tests - unit tests using NUnit

## Run

To start a project locally, run `docker-compose up` in the root directory. To create or update database,
run `docker exec jimmytestcms_app_1 /app/updater/JimmyTestCMS.DbUpdater`

## API

### Get all articles

`GET - /api/v1/articles`

#### optional query parameters

- `limit: number` - the number of records to return
- `offset: number` - offset from the first record
- `sort_by: string` - the name of a field to sort by, may be on of: `Id`, `Title`, `CreatedOn`, `UpdatedOn`
- `sort_desc: boolean`, case-sensitive

#### returns

```
[
  {
    "id": number,
    "title": string,
    "body": string,
    "createdOn": datetime,
    "modifiedOn": datetime
  }
]
```

### Get specific article

`GET - /api/v1/article/{id}`

#### returns

```
{
  "id": number,
  "title": string,
  "body": string,
  "createdOn": datetime,
  "modifiedOn": datetime
}
```

### Create article

`POST - /api/v1/article`

#### payload

```
{
  "title": string,
  "body": string
}
```

### Update article

`PATCH - /api/v1/artcile`

#### payload

```
{
  "id": number,
  "title": string,
  "body": string
}
```

### Remove article

`DELETE - /api/v1/article/{id}`

### Notes

- All dates are in UTC. 
 
## Things to improve
 - Request validation
 - Descriptive error messages
 - Authentication
