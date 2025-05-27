
# 🙌 Contributing to ByteCart Admin Portal

Thanks for your interest in contributing! 🎉 Whether you’re here to report a bug, suggest a feature, or submit a pull request, you're welcome. This document outlines how to do that.

---

## 🧰 Tech Stack

This project is built with:

- **.NET 9**
- **Blazor Server (SSR)**
- **Clean Architecture**
- **EF Core**
- **MediatR**

---

## 📌 Before You Start

1. **Search existing issues** to avoid duplicates.
2. **Read the README.md** to understand the architecture.
3. **Use a descriptive branch name**, e.g.:
   - `feature/add-product-search`
   - `bugfix/fix-stock-quantity-validation`

---

## 🐛 Reporting Bugs

Please include:

- Steps to reproduce the issue
- Expected vs. actual behavior
- Screenshots or error logs (if applicable)
- Browser & environment info

Create the issue under the **"Bug"** label.

---

## 🚀 Suggesting Enhancements

Include:

- Problem description
- Proposed solution or approach
- Alternatives considered

Use the **"Feature Request"** label.

---

## 💻 Submitting a Pull Request

1. Fork the repo and create your branch from `main`.
2. Ensure your code is well-formatted (`dotnet format`).
3. Run and pass all tests: `dotnet test`.
4. Include relevant unit/integration tests.
5. Reference related issue number(s) in your PR.
6. Write a clear, concise PR title and description.

---

## ✅ Code Guidelines

- Use `async/await` where appropriate
- Follow SOLID principles and Clean Architecture boundaries
- No hardcoded strings — use constants or resources
- Use Dependency Injection (DI) for services

---

## 🧪 Testing

Use **xUnit**, **Moq**, and **FluentAssertions**.

- Place tests under `ByteCart.Admin.Tests/`
- Mirror the structure of the projects to handle respective tests. eg. `ByteCart.Admin.Tests.Application.csproj`, `ByteCart.Admin.Tests.Domain.csproj` etc

---

## 🗂️ Project Structure

```
ByteCart.AdminPortal/
├── Domain/
├── Application/
├── Infrastructure/
├── Presentation/
└── Tests/
```

---

## 💬 Questions?

Open an issue or start a discussion. Happy to help!

Thanks for contributing ❤️  