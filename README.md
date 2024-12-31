# AuthAPI - ASP.NET Core Web API

AuthAPI is an authentication service built with ASP.NET Core Web API. It provides functionalities for user registration, login, and logout using JWT tokens for secure authentication.

## Features

- 🛡️ **JWT Token Authentication**: Secure and stateless authentication mechanism.
- 🛡️ **User Registration**: Allows new users to register with username/email and password.
- 🛡️ **Login**: Allows users to authenticate and receive a JWT token.
- 🛡️ **Logout**: Endpoint for logging out (invalidates the user's JWT token).
- 🛡️ **Secure Routes**: Authenticated routes requiring a valid JWT token.

### Prerequisites

- 🛠️ .NET SDK 6.0 or later
- 🗄️ MS SQL Server
- 🖥️ Visual Studio or any preferred code editor

### Installation

1. 🌀 Clone the repository:
   ```bash
   git clone https://github.com/MahammadPiriyev/InternIntelligence_UserLoginFunctionality.git
   ```

2. 📂 Navigate to the project directory:
   ```bash
   cd AuthAPI
   ```

3. 🔧 Restore the required packages:
   ```bash
   dotnet restore
   ```

4. 📝 Update the connection string in `appsettings.json`:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=SchoolManagement;Trusted_Connection=True;"
   }
   ```

5. 📦 Apply migrations and seed the database:
   ```bash
   dotnet ef database update
   ```

6. ▶️ Run the application:
   ```bash
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

- ⚙️ **ASP.NET Core 6.0** (or higher)
- 🔧 **Entity Framework Core** (for database interactions)
- 🛡️ **JWT Authentication**
- 🗄️ **SQL Server** (for user data storage)
- 🗂️ **Version Control**: Git

## 👤 Author  

**Mahammad Piriyev**  

- LinkedIn: [My LinkedIn Profile](https://linkedin.com/in/mahammadpiriyev)  
- Portfolio: [My Portfolio Website](https://mahammadpiriyev.onrender.com/)
