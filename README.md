# ADO.NET Technical Lab 🧪

This repository is a professional technical laboratory dedicated to mastering **ADO.NET** and database connectivity within the .NET ecosystem. It covers both **Connected** and **Disconnected** architectures, focusing on performance, security, and scalable data access patterns.  

## 🚀 Key Modules & Implementations
The lab is organized into modular projects, each demonstrating a core ADO.NET competency:

### 🔒 Data Security & Commands
- **Parameterized Queries:** Implementation of secure SQL execution to prevent **SQL Injection** attacks.
- **ExecuteScalar & ExecuteNonQuery:** Efficient handling of single-value retrievals and data modifications (Insert/Update/Delete).
- **Auto-Number Retrieval:** Techniques for capturing identity values post-insertion.

### 📑 Disconnected Architecture (Offline Data)
- **DataTable & DataSet:** Managing complex in-memory data structures.
- **DataView:** Implementation of advanced filtering, sorting, and data presentation logic.
- **DataAdapter:** Bridging the gap between the database and memory for seamless synchronization.

### 🏛️ Architectural Patterns
- **3-Tier Design:** Clear separation between **Data Access Layer (DAL)** and **Business Logic**.
- **Contact Management System:** A practical application of CRUD operations and complex retrievals.

## 🛠️ Tech Stack
- **Language:** C# 10.0+
- **Database:** Microsoft SQL Server
- **Framework:** .NET Framework / .NET Core
- **Tools:** Visual Studio 2022

## 📦 Database Setup
The repository includes a `ContactsDB.bak` file. 
1. Restore the backup to your local **SQL Server Instance**.
2. Update the connection string in the projects to point to your local server.

## ⚖️ License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
