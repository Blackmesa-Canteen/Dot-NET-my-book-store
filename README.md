# Dot-NET-my-book-store
An online web application system for a bookstore using ASP.NET MVC (C#). 

# Features
- List all books in the bookstore.

- Allow customer to search books in the bookstore.

- Allow customer to reserve a book in the store. It will generate a booking number once the book reservation has been made.

- Allow to reserve a book that has been reserved by other customer.

- CQRS pattern for data access layer.

- JWT authentication.


# Requirements
- .NET 5.0
- MySQL 8

# Database Migration
1. Install MySQL 8+ on the local machine;
2. Configure db connection at `MyBookStore/appsettings.json`;
3. Create MySQL schema `my_book_store`;
4. Restore the database schema with the dumped sql file located at `MyBookStore.DAL/Migration`. 

# Backend API Exports
The system supports API access. JSON export files of Postman is provided for further development.

See: `doc/MyBookStore.postman_collection.json`.

