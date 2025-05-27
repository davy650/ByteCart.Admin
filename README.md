# ByteCart Admin Portal 🛒

A **Blazor Server** application using **.NET 9**, **Server-Side Rendering (SSR)**, and **Clean Architecture** principles. This admin portal powers the internal management system of ByteCart, including product, category, and supplier management.

---

## 🧱 Architecture Overview

The solution follows Clean Architecture with the following project structure:

```
ByteCart.AdminPortal/
│
├── ByteCart.Admin.Domain/         → Core domain models and enums
├── ByteCart.Admin.Application/    → Use cases, CQRS handlers, DTOs
├── ByteCart.Admin.Infrastructure/ → EF Core, Repositories, external services
└── ByteCart.Admin.Web/            → Blazor UI, pages, components, DI setup
```

---

## 🚀 Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com)
- PostgreSQL or SQL Server (local or remote)
- Visual Studio 2022+ or VS Code

### Running the App

```bash
# Navigate to the presentation layer
cd ByteCart.Admin.Web

# Run the Blazor Server app
dotnet run
```

Browse to `https://localhost:5260`.

---

## 🔨 Build Steps

### 1. Clone the Repo

```bash
git clone https://github.com/davy650/ByteCart.Admin.git
cd ByteCart.AdminPortal
```

### 2. Apply EF Core Migrations

```bash
dotnet ef migrations add InitialCreate --project ByteCart.Admin.Infrastructure --startup-project ByteCart.Admin.Web
dotnet ef database update --project ByteCart.Admin.Infrastructure --startup-project ByteCart.Admin.Web
```

### 3. Sample Configuration

In `appsettings.json` (within `ByteCart.Admin.Web`), ensure your connection string is correct:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=ByteCartDb;Trusted_Connection=True;"
}
```

---

## 🧠 How It Works

- **Domain Layer** defines core models / entities like `Product`, `Category`, `Supplier`.
- **Application Layer** uses MediatR for CQRS. Includes `Commands`, `Handlers`, `Queries`, and `DTOs`.
- **Infrastructure Layer** uses Entity Framework Core for persistence.
- **Web Layer** is a Blazor Server app with component-based UI.

---

## 📦 Adding New Features

1. Create a DTO in `Application/DTOs`.
2. Add `Command/Query` + `Handler` via MediatR.
3. Update `DbContext` and repositories in `Infrastructure`.
4. Add UI in `Pages` or `Components` in `Web`.

---

## 🧪 Testing

*(Optional section if testing is added)*

- Use `xUnit` for unit testing.

---

## 📄 License

MIT License

---

## 🙋‍♂️ Need Help?

Raise an issue or contact me at [david.ambuka@gmail.com].
