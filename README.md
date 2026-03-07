# CRUD-.NET

A simple CRUD (Create, Read, Update, Delete) application built with C#, console interface, and SQLite database. Developed as a hands-on learning project for Object-Oriented Programming (OOP) concepts.

---

##  Technologies

- C# (.NET)
- SQLite (`Microsoft.Data.Sqlite`)
- Visual Studio 2022

---

##  Project Structure

```
CrudProdutos/
├── Models/
│   └── Produto.cs              # Product entity model
├── Data/
│   └── Database.cs             # Database connection and initialization
├── Repositories/
│   └── ProdutoRepository.cs    # CRUD operations
└── Program.cs                  # Main menu and user interaction
```

---

##  Getting Started

1. Clone the repository:
   ```bash
   git clone https://github.com/GabrielCesnikk/CRUD-.NET.git
   ```

2. Open the project in **Visual Studio 2022**

3. Install the dependency via NuGet:
   - Right-click the project → **Manage NuGet Packages**
   - Search for `Microsoft.Data.Sqlite` and install it

4. Run the project with `F5`

> The `produtos.db` file will be created automatically on the first run.

---

##  Features

- [x] List all products
- [x] Add a new product
- [x] Update an existing product
- [x] Remove a product

---

##  Concepts Practiced

- Object-Oriented Programming (OOP)
- Separation of concerns (Models, Data, Repositories)
- SQLite database connection
- SQL commands (SELECT, INSERT, UPDATE, DELETE)
- Parameterized queries for SQL Injection prevention

---

##  Author

**Gabriel Cesnik**  
Project developed for learning purposes.
