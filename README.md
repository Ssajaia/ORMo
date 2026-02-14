# ORMo – Minimal ORM in C# with SQLite

ORMo is a custom Object-Relational Mapper (ORM) built from scratch in **C# (.NET 8)** using **SQLite**.  
This project demonstrates the fundamentals of ORM design: mapping classes to database tables, attribute-based metadata, and basic data management.

---

## Features

- **Attribute-based entity mapping**  
  - `[Table]` – specify table name  
  - `[Column]` – specify column name  
  - `[Key]` – mark primary key

- **Entity metadata reflection**  
  - Automatically reads class properties and attributes  
  - Detects primary key and column names  
  - Caches metadata for performance

- **Property mapping**  
  - Handles type information and primary key flags  
  - Supports default column naming if `[Column]` is missing

- **Demonstration**  
  - Display entity metadata  
  - Test cache retrieval  
  - List all properties with types and PK info

---


## Demo Output

ORMo - Attributes and Metadata Layer Demo

Entity Metadata:
Entity Type: User
Table Name: Users
Primary Key: Id (Column: user_id)

Properties:

Property: Id -> Column: user_id (Type: Int32, IsPK: True)

Property: UserName -> Column: user_name (Type: String, IsPK: False)

Property: Email -> Column: email_address (Type: String, IsPK: False)

Property: Age -> Column: Age (Type: Int32, IsPK: False)

Property: TempData -> Column: TempData (Type: String, IsPK: False)

Metadata retrieved from cache: True
Available entity types in cache:

User


---

## Getting Started

1. Clone the repository:

```bash
git clone <repository_url>
cd ORMo
```

-  Open in Visual Studio or your preferred IDE.

- Restore NuGet packages:

- dotnet restore
### Run the console app:
```
dotnet run
Next Steps / Planned Features
Implement DbContext and DbSet for add/update/delete operations
```

Support querying and change tracking

Add entity relationships (1:1, 1:N, N:N)

Implement migrations for schema management

Technologies
C# 11 / .NET 8

SQLite (via Microsoft.Data.Sqlite)

License
MIT License – feel free to use and modify.
