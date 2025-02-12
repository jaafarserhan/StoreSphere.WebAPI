# StoreSphere WebAPI

StoreSphere is a .NET Core WebAPI project that provides a robust backend for managing users, stores, brands, products, and addresses. It includes features like user authentication, CRUD operations, and email confirmation.

---

## Features

1. **User Management**:
   - User registration with email confirmation.
   - Password management (change/reset).
   - JWT-based authentication and authorization.

2. **Store Management**:
   - CRUD operations for stores.
   - Validation for store name and brand uniqueness.
   - Management of store addresses.

3. **Brand Management**:
   - CRUD operations for brands.
   - Validation for brand name uniqueness.

4. **Product Management**:
   - CRUD operations for products.
   - Soft delete and recovery of products.
   - Validation to ensure products belong to valid stores and brands.

5. **Bonus Features**:
   - JWT binding to HTTP context.
   - Swagger API documentation.
   - In-memory caching for frequently accessed data.

---

## Project Structure
StoreSphere.WebAPI/
├── Controllers/
│ ├── UserController.cs
│ ├── StoreController.cs
│ ├── BrandController.cs
│ ├── ProductController.cs
├── Services/
│ ├── UserService.cs
│ ├── StoreService.cs
│ ├── BrandService.cs
│ ├── ProductService.cs
├── Repositories/
│ ├── UserRepository.cs
│ ├── StoreRepository.cs
│ ├── BrandRepository.cs
│ ├── ProductRepository.cs
├── Interfaces/
│ ├── Repositories/
│ │ ├── IUserRepository.cs
│ │ ├── IStoreRepository.cs
│ │ ├── IBrandRepository.cs
│ │ ├── IProductRepository.cs
│ ├── Services/
│ │ ├── IUserService.cs
│ │ ├── IStoreService.cs
│ │ ├── IBrandService.cs
│ │ ├── IProductService.cs
├── Models/
│ ├── User.cs
│ ├── Store.cs
│ ├── Brand.cs
│ ├── Product.cs
│ ├── Address.cs
├── DTOs/
│ ├── UserDTOs/
│ │ ├── UserRegistrationDto.cs
│ │ ├── LoginDto.cs
│ │ ├── ChangePasswordDto.cs
│ ├── StoreDTOs/
│ │ ├── StoreCreationDto.cs
│ │ ├── StoreUpdateDto.cs
│ ├── BrandDTOs/
│ │ ├── BrandCreationDto.cs
│ │ ├── BrandUpdateDto.cs
│ ├── ProductDTOs/
│ │ ├── ProductCreationDto.cs
│ │ ├── ProductUpdateDto.cs
├── Middleware/
│ ├── JwtMiddleware.cs
├── Extensions/
│ ├── ServiceExtensions.cs
├── appsettings.json
├── Program.cs
├── README.md

---
**Database Diagram:**
![StoreSphereDB Diagram](https://github.com/user-attachments/assets/93726474-f469-4374-b52b-39ada86ce064)

---

## Technologies Used

- **Backend**: .NET Core 8.0
- **Database**: Microsoft SQL Server
- **ORM**: Entity Framework Core
- **Authentication**: JWT (JSON Web Tokens)
- **Email**: SMTP (Outlook) or SendGrid
- **Caching**: In-memory caching
- **API Documentation**: Swagger

---

## Setup Instructions

### Prerequisites

1. **.NET SDK 8.0**: Install the latest .NET SDK from [here](https://dotnet.microsoft.com/download).
2. **SQL Server**: Install SQL Server or use a cloud-based SQL Server instance.
3. **SMTP or SendGrid**: Set up an SMTP server (e.g., Outlook) or create a SendGrid account for email functionality.

### Steps to Run the Project

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/your-username/StoreSphere.WebAPI.git
   cd StoreSphere.WebAPI




**Configure the Database:**
**Update the connection string in appsettings.json:
**
"ConnectionStrings": {
  "DefaultConnection": "Server=your_server;Database=StoreSphereDB;User Id=your_user;Password=your_password;TrustServerCertificate=True;"
}


**Run EF Core migrations to create the database:**
**PM> ** dotnet ef migrations add InitialCreate
**PM> ** dotnet ef database update
![CodeFirst Commands](https://github.com/user-attachments/assets/f5efbb6c-3bae-4d72-b3a8-fbc254192610)

**Configure JWT:**
Add the JWT settings to appsettings.json:**
**
"Jwt": {
  "Key": "your_super_secret_key_here",
  "Issuer": "StoreSphere.WebAPI",
  "Audience": "StoreSphere.WebAPI",
  "ExpiryInMinutes": 30
}
Configure Email:

For SMTP (Outlook):

json
Copy
"SmtpSettings": {
  "Server": "smtp.office365.com",
  "Port": 587,
  "Username": "jaafar.serhan@outlook.com",
  "Password": "your_email_password",
  "FromEmail": "jaafar.serhan@outlook.com",
  "FromName": "StoreSphere",
  "EnableSsl": true
}
For SendGrid:

json
Copy
"SendGrid": {
  "ApiKey": "your_sendgrid_api_key",
  "FromEmail": "jaafar.serhan@outlook.com",
  "FromName": "StoreSphere"
}

--------------------------------------------------------------------
**API Endpoints**
**User Management**
Register User: POST /api/user/register
Login: POST /api/user/login
Change Password: POST /api/user/change-password

**Store Management
**Create Store: POST /api/store
Update Store: PUT /api/store/{id}
Delete Store: DELETE /api/store/{id}

**Brand Management
**Create Brand: POST /api/brand
Update Brand: PUT /api/brand/{id}
Delete Brand: DELETE /api/brand/{id}

**Product Management**
Create Product: POST /api/product
Update Product: PUT /api/product/{id}
Delete Product: DELETE /api/product/{id}
Recover Product: POST /api/product/{id}/recover

Caching
In-memory caching is implemented for frequently accessed data, such as user information or product listings. Example:

[HttpGet("cached-products")]
public async Task<IActionResult> GetCachedProducts()
{
    const string cacheKey = "products";
    if (!_cache.TryGetValue(cacheKey, out List<Product> products))
    {
        products = await _context.Products.ToListAsync();
        _cache.Set(cacheKey, products, TimeSpan.FromMinutes(10));
    }

    return Ok(products);
}


**Swagger Documentation**
Swagger is used for API documentation. Access it at:
https://localhost:5001/swagger (or http://localhost:5000/swagger).

**Contributing
**Fork the repository.
Create a new branch (git checkout -b feature/YourFeatureName).
Commit your changes (git commit -m 'Add some feature').
Push to the branch (git push origin feature/YourFeatureName).
Open a pull request.

**License**
This project is licensed under the MIT License. See the LICENSE file for details.

**Acknowledgements**
**.NET Core:** For providing a robust framework for building APIs.
**Entity Framework Core:** For simplifying database operations.
**JWT:** For secure authentication.
**Swagger:** For API documentation.

**Contact**
For questions or feedback, feel free to reach out:
Name: Jaafar Serhan
Email: jaafar.serhan@outlook.com

---

### **How to Use This README**

1. Copy the content above.
2. Create a file named `README.md` in the root of your project.
3. Paste the content into the file.
4. Commit and push the changes to your GitHub repository.

