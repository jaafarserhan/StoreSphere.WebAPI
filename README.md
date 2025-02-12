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
