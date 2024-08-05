<div align="center">

<img src="assets/BuberBreakfastUiUx.png" alt="drawing" width="1000"/>

 [![GitHub Stars](https://img.shields.io/github/stars/aidbar/buber-breakfast-aidbar.svg)](https://github.com/aidbar/buber-breakfast-aidbar/stargazers) [![GitHub license](https://img.shields.io/github/license/aidbar/buber-breakfast-aidbar)](https://github.com/aidbar/buber-breakfast-aidbar/blob/main/LICENSE)

---

### This repository is based on the source code of the [CRUD REST API from scratch using .NET 6 tutorial](https://youtu.be/PmDJIooZjBE) by [amantinband](https://github.com/amantinband)

</div>

- [Give it a star ⭐!](#give-it-a-star-)
- [Overview](#overview)
- [Service Architecture](#service-architecture)
- [Technologies](#technologies)
- [Architecture](#architecture)
- [Usage](#usage)
- [API Definition](#api-definition)
  - [Create Breakfast](#create-breakfast)
    - [Create Breakfast Request](#create-breakfast-request)
    - [Create Breakfast Response](#create-breakfast-response)
  - [Get Breakfast](#get-breakfast)
    - [Get Breakfast Request](#get-breakfast-request)
    - [Get Breakfast Response](#get-breakfast-response)
  - [Get All Breakfasts](#get-all-breakfasts)
    - [Get All Breakfasts Request](#get-all-breakfasts-request)
    - [Get All Breakfasts Response](#get-all-breakfasts-response)
  - [Update Breakfast](#update-breakfast)
    - [Update Breakfast Request](#update-breakfast-request)
    - [Update Breakfast Response](#update-breakfast-response)
  - [Rename Breakfast](#rename-breakfast)
    - [Rename Breakfast Request](#rename-breakfast-request)
    - [Rename Breakfast Response](#rename-breakfast-response)
  - [Search Breakfasts](#search-breakfasts)
    - [Search Breakfasts Request](#search-breakfasts-request)
    - [Search Breakfasts Response](#search-breakfasts-response)
  - [Delete Breakfast](#delete-breakfast)
    - [Delete Breakfast Request](#delete-breakfast-request)
    - [Delete Breakfast Response](#delete-breakfast-response)
- [Credits](#credits)
- [VSCode Extensions](#vscode-extensions)
- [Disclaimer](#disclaimer)
- [License](#license)

---

# Give it a star ⭐!

Loving it? Show your support by giving this project a star!

# Overview

This project is based on the [.NET 6 CRUD REST API tutorial](https://youtu.be/PmDJIooZjBE) by [amantinband](https://github.com/amantinband) and the original repository can be found [here](https://github.com/amantinband/buber-breakfast). In addition to the `Create Breakfast` (HTTP POST), `Get Breakfast` (HTTP GET), `Update Breakfast` (HTTP PUT) and `Delete Breakfast` (HTTP DELETE) API endpoints presented in the tutorial, this project also contains `Get All Breakfasts` (HTTP GET), `Search Breakfasts` (HTTP GET) and `Rename Breakfast` (HTTP PATCH) endpoints. In addition, this project contains other minor code modifications, such as additional error definitions in `ServiceErrors/Errors.Breakfast.cs`.

# Service Architecture

<div align="center">

<img src="assets/BackendServiceArchitecture.png" alt="drawing" width="700px"/>

</div>

# Technologies

<div align="center">

<img src="assets/Technologies.png" alt="drawing" width="700px"/>

</div>

# Architecture

<div align="center">

<img src="assets/Architecture.png" alt="drawing" width="700px"/>

</div>

# Usage

Simply `git clone https://github.com/aidbar/buber-breakfast-aidbar` and `dotnet run --project BuberBreakfast`.

# API Definition

## Create Breakfast

### Create Breakfast Request

```js
POST /breakfasts
```

```json
{
    "name": "Vegan Sunshine",
    "description": "Vegan everything! Join us for a healthy breakfast..",
    "startDateTime": "2022-04-08T08:00:00",
    "endDateTime": "2022-04-08T11:00:00",
    "savory": [
        "Oatmeal",
        "Avocado Toast",
        "Omelette",
        "Salad"
    ],
    "Sweet": [
        "Cookie"
    ]
}
```

### Create Breakfast Response

```js
201 Created
```

```yml
Location: {{host}}/Breakfasts/{{id}}
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "name": "Vegan Sunshine",
    "description": "Vegan everything! Join us for a healthy breakfast..",
    "startDateTime": "2022-04-08T08:00:00",
    "endDateTime": "2022-04-08T11:00:00",
    "lastModifiedDateTime": "2022-04-06T12:00:00",
    "savory": [
        "Oatmeal",
        "Avocado Toast",
        "Omelette",
        "Salad"
    ],
    "Sweet": [
        "Cookie"
    ]
}
```

## Get Breakfast
### Get Breakfast Request

```js
GET /breakfasts/{{id}}
```

### Get Breakfast Response

```js
200 Ok
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "name": "Vegan Sunshine",
    "description": "Vegan everything! Join us for a healthy breakfast..",
    "startDateTime": "2022-04-08T08:00:00",
    "endDateTime": "2022-04-08T11:00:00",
    "lastModifiedDateTime": "2022-04-06T12:00:00",
    "savory": [
        "Oatmeal",
        "Avocado Toast",
        "Omelette",
        "Salad"
    ],
    "Sweet": [
        "Cookie"
    ]
}
```

## Get All Breakfasts
### Get All Breakfasts Request
```js
GET /breakfasts/all
```
### Get All Breakfasts Response
```json
[
  {
    "id": "76c09d83-4556-4b3c-a7ce-f555d33b5044",
    "name": "Vegan Sunshine 2: Electric Boogaloo",
    "description": "A cozy cafe with a variety of breakfast options and a bakery.",
    "startDateTime": "2022-04-08T08:00:00",
    "endDateTime": "2022-04-08T11:00:00",
    "lastModifiedDateTime": "2024-08-01T14:31:45.3427281Z",
    "savory": [
      "Oatmeal",
      "Avocado Toast",
      "Omelette",
      "Salad"
    ],
    "sweet": [
      "Cookie"
    ]
  },
  {
    "id": "68cbf0f7-b5e0-4195-b7c1-9231869ef8e0",
    "name": "eeeeeee",
    "description": "A cozy cafe with a variety of breakfast options and a bakery.",
    "startDateTime": "2022-04-08T08:00:00",
    "endDateTime": "2022-04-08T11:00:00",
    "lastModifiedDateTime": "2024-08-01T15:15:10.1079259Z",
    "savory": [
      "Oatmeal",
      "Avocado Toast",
      "Omelette",
      "Salad"
    ],
    "sweet": [
      "Cookie"
    ]
  },
  {
    "id": "ba26da11-fdec-41a5-abe8-c2bcc3becfbc",
    "name": "eeeeeee",
    "description": "A cozy cafe with a variety of breakfast options and a bakery.",
    "startDateTime": "2022-04-08T08:00:00",
    "endDateTime": "2022-04-08T11:00:00",
    "lastModifiedDateTime": "2024-08-01T15:15:18.1055275Z",
    "savory": [
      "Oatmeal",
      "Avocado Toast",
      "Omelette",
      "Salad"
    ],
    "sweet": [
      "Cookie"
    ]
  }
]
```

## Update Breakfast

### Update Breakfast Request

```js
PUT /breakfasts/{{id}}
```

```json
{
    "name": "Vegan Sunshine",
    "description": "Vegan everything! Join us for a healthy breakfast..",
    "startDateTime": "2022-04-08T08:00:00",
    "endDateTime": "2022-04-08T11:00:00",
    "savory": [
        "Oatmeal",
        "Avocado Toast",
        "Omelette",
        "Salad"
    ],
    "Sweet": [
        "Cookie"
    ]
}
```

### Update Breakfast Response

```js
204 No Content
```

or

```js
201 Created
```

```yml
Location: {{host}}/Breakfasts/{{id}}
```

## Rename Breakfast
### Rename Breakfast Request
```js
PATCH /breakfasts/{{id}}
```
```js
{
    "name":"New breakfast name"
}
```

### Rename Breakfast Response
```js
204 No Content
```

## Search Breakfasts
### Search Breakfasts Request
```js
GET /breakfasts/search?query=bc
```

### Search Breakfasts Response
```json
[
  {
    "id": "76d6becb-3e7f-458a-a8f5-1d59c9276065",
    "name": "abc",
    "description": "A cozy cafe with a variety of breakfast options and a bakery.",
    "startDateTime": "2022-04-08T08:00:00",
    "endDateTime": "2022-04-08T11:00:00",
    "lastModifiedDateTime": "2024-08-05T15:56:27.1477421Z",
    "savory": [
      "Oatmeal",
      "Avocado Toast",
      "Omelette",
      "Salad"
    ],
    "sweet": [
      "Cookie"
    ]
  },
  {
    "id": "ce5217ab-6df4-48b7-859f-3debd8e76d7c",
    "name": "bcd",
    "description": "A cozy cafe with a variety of breakfast options and a bakery.",
    "startDateTime": "2022-04-08T08:00:00",
    "endDateTime": "2022-04-08T11:00:00",
    "lastModifiedDateTime": "2024-08-05T15:56:35.9981575Z",
    "savory": [
      "Oatmeal",
      "Avocado Toast",
      "Omelette",
      "Salad"
    ],
    "sweet": [
      "Cookie"
    ]
  },
  {
    "id": "55ae3e99-2a10-4e75-8a1e-9a4e56a9798f",
    "name": "bce",
    "description": "A cozy cafe with a variety of breakfast options and a bakery.",
    "startDateTime": "2022-04-08T08:00:00",
    "endDateTime": "2022-04-08T11:00:00",
    "lastModifiedDateTime": "2024-08-05T15:56:47.8728027Z",
    "savory": [
      "Oatmeal",
      "Avocado Toast",
      "Omelette",
      "Salad"
    ],
    "sweet": [
      "Cookie"
    ]
  }
]
```

## Delete Breakfast

### Delete Breakfast Request

```js
DELETE /breakfasts/{{id}}
```

### Delete Breakfast Response

```js
204 No Content
```

# Credits

- [ErrorOr](https://github.com/amantinband/error-or) - A simple, fluent discriminated union of an error or a result.

# VSCode Extensions

- [VSCode Rest Client](https://github.com/Huachao/vscode-restclient) - REST Client allows you to send HTTP request and view the response in Visual Studio Code directly.

- [VSCode Markdown Preview Enhanced](https://github.com/shd101wyy/vscode-markdown-preview-enhanced) - Markdown Preview Enhanced is an extension that provides you with many useful functionalities for previewing markdown files.

# Disclaimer

This is an educational project. The source code is licensed under the MIT license.

# License

This project is licensed under the terms of the [MIT](https://github.com/aidbar/buber-breakfast-aidbar/blob/main/LICENSE) license.
