# StoreSphere WebAPI

StoreSphere is a **.NET Core WebAPI** project that provides a robust backend for managing users, stores, brands, products, and addresses. It includes features like user authentication, CRUD operations, and email confirmation.

---

## ✨ Features

### 1. **User Management**
- User registration with email confirmation.
- Password management (change/reset).
- JWT-based authentication and authorization.

### 2. **Store Management**
- CRUD operations for stores.
- Validation for store name and brand uniqueness.
- Management of store addresses.

### 3. **Brand Management**
- CRUD operations for brands.
- Validation for brand name uniqueness.

### 4. **Product Management**
- CRUD operations for products.
- Soft delete and recovery of products.
- Validation to ensure products belong to valid stores and brands.

### 5. **Bonus Features**
- JWT binding to HTTP context.
- Swagger API documentation.
- In-memory caching for frequently accessed data.

---

## 🗂️ Project Structure
![image](https://github.com/user-attachments/assets/60ac1aed-863a-4b1b-b16b-794f27b7b153)


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

---

# StoreSphere Configuration Guide

This guide will walk you through the necessary steps to configure the database, JWT, and email settings for the StoreSphere application. Follow the instructions below to set up your environment.

---


![image](https://github.com/user-attachments/assets/bc34cbaf-45b7-46cb-9a33-22d764b71e91)





