# AuthAPI - ASP.NET Core Web API

AuthAPI is an authentication service built with ASP.NET Core Web API. It provides functionalities for user registration, login, and logout using JWT tokens for secure authentication.

## Features

- **JWT Token Authentication**: Secure and stateless authentication mechanism.
- **User Registration**: Allows new users to register with username/email and password.
- **Login**: Allows users to authenticate and receive a JWT token.
- **Logout**: Endpoint for logging out (invalidates the user's JWT token).
- **Secure Routes**: Authenticated routes requiring a valid JWT token.

## Requirements

- [.NET 6.0](https://dotnet.microsoft.com/download/dotnet) or higher
- An SQL Server instance for storing user credentials

## Setup and Installation

1. **Clone the repository**:
```
git clone https://github.com/MahammadPiriyev/InternIntelligence_UserLoginFunctionality.git
```
2. **Install dependencies**:

Open the solution in Visual Studio or use the .NET CLI to restore the required NuGet packages.
```
dotnet restore
```
3. **Configure the Database**:

- Set up the SQL Server database by configuring your connection string in `appsettings.json`.
- Run the database migrations (if applicable) to create the required tables.
```
dotnet ef database update
```
4. **Run the API**:
```
dotnet run
```

## API Endpoints

### 1. **POST /api/auth/register**
- Register a new user.
- Request body:
  ```
  {
    "username": "exampleuser",
    "email": "example@example.com",
    "password": "YourPassword123"
  }
  ```

### 2. **POST /api/auth/login**
- Login an existing user and receive a JWT token.
- Request body:
  ```
  {
    "username": "exampleuser",
    "password": "YourPassword123"
  }
  ```

- Response body:
  ```
  {
    "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
  }
  ```

### 3. **POST /api/auth/logout**
- Logout the authenticated user and invalidate the JWT token.
- Requires a valid JWT token in the Authorization header.


## Technologies Used

- **ASP.NET Core 6.0** (or higher)
- **Entity Framework Core** (for database interactions)
- **JWT Authentication**
- **SQL Server** (for user data storage)

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
