# EyeCue Lab Summer 2023 Internship: Partner Dashboard (Name Pending)
## Authors 

- [Brishna Bakshev](https://github.com/bbakshev)
- [Stephen Zook](https://github.com/Zookerman3)
- [Justin Lee](https://github.com/JustinUrf)
- [Eliot Gronstal](https://github.com/elgrons)
- [Erin Timlin](https://github.com/erintimli01)
- EyeCue Lab Mentors

## 📂 Table Of Contents

- [Description](#description)

- [Technologies Used](#technologies-used)

- [Project Setup](#project-setup)
  - [Scripts](#scripts)

- [Known Issues](#known-issues)

- [MVP](#mvp)

- [Stretch Goals](#stretch-goals)

## Description <a id="description"></a> 

(Name Pending) is a web application built with React and Typescript while using (Tech stack pending for database, backend API's etc)... The app aims to allow partners to visualize scrum point systems in order to understand progress made by developers on their projects. This is done using Chat GPT to summarize git hub commit messages and translate those messages into release logs for the product. Furthermore, this project looks to add real-time communication libraries to enable users and admins to work at the same time as well as authorization for admins to only see projects that are they are assocaited with.

## Technologies Used <a id="technologies-used"></a>

TBD

## Project Setup <a id="project-setup"></a>


0. Create .env file in the `customer-portal` directory and add the following code:
 ```
 GOOGLE_CLIENT_ID = [YOUR-GOOGLE-CLIENT-ID] 
 GOOGLE_CLIENT_SECRET = [YOUR-GOOGLE-SECRET] 
 NEXTAUTH_URL = http://localhost:3000/ 
 JWT_SECRET = [YOUR-JWT-SECRET] 
 ``` 
 Create appsettings.Development.json in the `WebApi` root folder with the following contents: 
 ```
 {
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "PostgreSqlConnectionString": "Server=localhost;Port=5432;Database=ClientPortal1;User Id=[YOUR-ID];Password=[YOUR-PASSWORD];",
    "Authentication": {
      "Google": {
        "ClientId": ["YOUR-CLIENT-ID"],
        "ClientSecret": ["YOUR-CLIENT-SECRET"]
      }
  }
}
```

1. Clone this repo into your desktop.
2. Navigate to the project directory `customer-portal` and run `$ npm install`.
3. Use `npm run dev` in order to run locally on `localhost:3000`.
4. Navigate to webapi/WebApi and run `dotnet restore`. 
5. NOTE: Must have PostgresQL installed to successfully create the database. Create Entity Framework database migrations by running `dotnet ef migrations add initial` to build schema. Then, run the command `dotnet ef database update`. 
6. Use `dotnet watch run` in order to run the backend API. This can be viewed through the Swagger.ui at `localhost:7243`.

### Swagger Documentation

To view the Swagger documentation for the WebApi, launch the project using `dotnet watch run` using Terminal or Powershell, then input the following URL into your browser: `https://localhost:7243/swagger/index.html`

![swaggerendpoints](WebApi/wwwroot/img/swaggerendpoints.png)

### Creating a New Instance in Postman or Swagger

- To utilize the POST request and generate a new POST request where applicable, the following information structure is required, while the actual information input can vary.

Register a User with the following .json data:
```
  {
    "Email": "user4@example.com",
}
```

Entity .json examples:
```
[
  {
    "entityId": "1",
    "companyName": "EyeCue"
  },
  {
    "entityId": "2",
    "companyName": "Google"
  },
  {
    "entityId": "3",
    "companyName": "Amazon"
  }
]
```

## Scripts <a id="scripts"></a>

TBD

## Known Issues <a id="known-issues"></a>

Application is still in the ideation phase and is a WIP. This is apart of EyeCue Labs 7 Week Summer Internship and is subject to change.

## MVP <a id="mvp"></a>

TBD

## Stretch Goals <a id="stretch-goals"></a>

TBD

## License
Copyright (c) 2023 Brishna Bakshev, Stephen Zook, Justin Lee, Eliot Gronstal, and Erin Timlin _[MIT](https://choosealicense.com/licenses/mit/)_