# Dot-NET-my-book-store
An online web application system for a bookstore using ASP.NET MVC (C#). 

# Features
- List all books in the bookstore.

- Allow customer to search books in the bookstore.

- Allow customer to reserve a book in the store. It will generate a booking number once the book reservation has been made.

- Allow to reserve a book that has been reserved by other customer.

- MySQL support.

- CQRS pattern for data access layer.

- JWT authentication.

- Server-side password encryption.


# Requirements
- .NET 5.0
- MySQL 8

# Project structure

- **MyBookStore**: Startup entry point; MVC web application;
- **MyBookStore/BLL**: Class library, business logic layer;
- **MyBookStore/DAL**: Class library, data access layer;
- **MyBookStore/Domain**: Class library, system domain objects;
- **MyBookStore/Common**: Class library, common dependencies, utilities and so on.

# Database Migration
1. Install MySQL 8+ on the local machine;
2. Configure db connection at `MyBookStore/appsettings.json`;
3. Create MySQL schema `my_book_store`;
4. Restore the database schema with the dumped sql file located at `MyBookStore.DAL/Migration`. 

# Backend API Exports
The system supports API access. JSON export files of Postman is provided for further development.

See: `doc/MyBookStore.postman_collection.json`.

# License
```
MIT License

Copyright (c) 2023 996Worker

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
```