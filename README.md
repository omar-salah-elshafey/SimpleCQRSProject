# Simple CQRS Project

This project demonstrates the implementation of the CQRS (Command Query Responsibility Segregation) pattern using ASP.NET Core 7, MediatR, and Entity Framework Core.

## Overview

CQRS is an architectural pattern that separates read and write operations for a data store. This project showcases how to apply CQRS to build a simple product catalog API.

**Key features:**

- **Commands:** Create, Update, Delete products.
- **Queries:** Get product by ID, List all products.
- **MediatR:** Used for handling commands and queries.
- **Entity Framework Core:** Used for database persistence.
- **ASP.NET Core 7:** Provides the RESTful API framework.
- **Error Handling:** Includes basic exception handling and returns informative error messages.

**API Endpoints:**
**The following API endpoints are available:**

- **GET /api/products:** Retrieves a list of all products.
- **GET /api/products/{id}:** Retrieves a product with the specified ID.
- **POST /api/products:** Creates a new product. Send a JSON payload in the request body with the product's Name, Description, and Price.
- **PUT /api/products/{id}:** Updates the product with the specified ID. Send a JSON payload with the updated Name, Description, and Price.
- **DELETE /api/products/{id}:** Deletes the product with the specified ID.
