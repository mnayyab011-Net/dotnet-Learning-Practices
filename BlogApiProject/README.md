# Blog API
A simple and secure **Blog Management REST API** built with **ASP.NET Core Web API**. The project allows users to register and log in, create and manage blog posts, organize posts into categories, and test APIs through Swagger.
## Project Overview
**BlogApiProject** is a backend project developed to practice and demonstrate important concepts of ASP.NET Core Web API, Entity Framework Core, SQL Server, JWT Authentication, and RESTful API development.
The project also includes a simple frontend for interacting with the blog system.
## Technologies Used
* ASP.NET Core Web API
* C#
* Entity Framework Core
* SQL Server LocalDB
* JWT Authentication
* Swagger / OpenAPI
* HTML
* CSS
* JavaScript
* Visual Studio Code
## Main Features
* User Registration and Login
* JWT-based Authentication
* Create, Read, Update, and Delete Blog Posts
* Create and manage Categories
* Post image support through Image URLs
* Protected API endpoints
* Input validation
* Entity Framework Core database integration
* Swagger API documentation and testing
* Simple frontend and admin dashboard
## Project Structure
BlogApiProject
├── Controllers
│   ├── AuthController.cs
│   ├── PostController.cs
│   └── CategoryController.cs
├── Models
│   ├── User.cs
│   ├── Post.cs
│   └── Category.cs
├── DTOs
│   ├── LoginDto.cs
│   ├── RegisterDto.cs
│   └── PostResponseDto.cs
├── Data
│   └── AppDbContext.cs
├── Migrations
├── Program.cs
├── appsettings.json
└── Frontend
    ├── index.html
    ├── login.html
    ├── admin.html
    ├── style.css
    └── JavaScript files
## Database
The project uses **SQL Server LocalDB** with Entity Framework Core.
The main database entities are:
* **Users** – stores registered user information.
* **Posts** – stores blog posts and their details.
* **Categories** – organizes posts into different categories.
Posts are connected to users and categories through relationships and foreign keys.
## Authentication
The API uses **JWT (JSON Web Token)** authentication.
Users can register and log in to receive an authentication token. Protected endpoints require this token in the request header.
## API Endpoints
### Authentication
POST /api/Auth/register
POST /api/Auth/login
### Posts
GET    /api/Post
GET    /api/Post/{id}
POST   /api/Post
PUT    /api/Post/{id}
DELETE /api/Post/{id}
### Categories
GET    /api/Category
POST   /api/Category
PUT    /api/Category/{id}
DELETE /api/Category/{id}
> Some endpoints require JWT authentication.
## Running the Project
After this, open the project in **Visual Studio Code**, make sure the SQL Server LocalDB connection and configuration are correct, and apply the required migrations if needed.
Run the API using:
dotnet run
After the API starts, open **Swagger** in your browser to test the available endpoints.
For the frontend, start the project using a local web server such as **Live Server** in Visual Studio Code.
## Database Migrations
If the database needs to be updated, run:
dotnet ef database update
To create a new migration:
dotnet ef migrations add MigrationName
## Swagger
Swagger is included in the project for API documentation and testing.
Through Swagger, you can:
* View available endpoints
* Register and log in users
* Authorize using JWT
* Create and manage posts
* Test categories
* Check API responses
## Frontend
The project includes a simple frontend connected to the ASP.NET Core API.
The frontend provides:
* Login page
* Blog posts display
* Admin dashboard
* Create post
* Edit post
* Delete post
* Category selection
* Post image display
## Author
**Nayyab Mazhar**