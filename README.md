 **Blog API**
A Blog Management REST API built with ASP.NET Core Web API, Entity Framework Core, SQL Server, and JWT Authentication.
This project demonstrates authentication, CRUD operations, entity relationships, validation, error handling, logging, Swagger documentation, and API testing.
**Features**
•	User Registration & Login
•	JWT Authentication & Authorization
•	Complete CRUD for Posts
•	Complete CRUD for Categories
•	User → Posts relationship
•	Category → Posts relationship
•	Input Validation
•	Error Handling & Logging
•	Swagger / OpenAPI Documentation
•	Postman API Testing
**Technologies**
•	C#
•	ASP.NET Core Web API
•	Entity Framework Core
•	SQL Server
•	JWT Authentication
•	Swagger / OpenAPI
•	Postman
•	Git & GitHub
**Project Structure**
BlogApiProject/
│
├── Controllers/
├── Data/
├── DTOs/
├── Models/
├── Migrations/
├── Program.cs
├── appsettings.json
└── README.mdAuthentication
The API uses JWT Bearer Authentication.
Register → Login → JWT Token → Authorized Requests
Use the token for protected endpoints:
Authorization: Bearer YOUR_JWT_TOKEN
API Endpoints
Authentication
Method	Endpoint	Description
POST	/api/Auth/register	Register User
POST	/api/Auth/login	Login User
**Posts**
Method	Endpoint	Description
GET	/api/Post	Get All Posts
GET	/api/Post/{id}	Get Post
POST	/api/Post	Create Post
PUT	/api/Post/{id}	Update Post
DELETE	/api/Post/{id}	Delete Post
**Categories**
Method	Endpoint	Description
GET	/api/Category	Get Categories
GET	/api/Category/{id}	Get Category
POST	/api/Category	Create Category
PUT	/api/Category/{id}	Update Category
DELETE	/api/Category/{id}	Delete Category
**Database**
The project uses SQL Server with Entity Framework Core.
dotnet ef database update
 Run the Project
dotnet restore
dotnet build
dotnet run
After running the API, open the Swagger URL shown in the terminal.
**Testing**
The API was tested using:
•	Swagger
•	PostmanProject Status
Completed
•	Users
•	Posts
•	Categories
•	CRUD Operations
•	JWT Authentication
•	Validation
•	Error Handling
•	Logging
•	Swagger Documentation
•	Database Integration
 Author
Nayyab Mazhar
BS Information Technology
ASP.NET Core | C# | Web API | SQL Server

