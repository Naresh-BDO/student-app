# Contributing to Student Management Application

Thank you for your interest in contributing to the Student Management Application! This document provides guidelines and instructions for contributing to this project.

## Table of Contents

- [Code of Conduct](#code-of-conduct)
- [Getting Started](#getting-started)
- [Development Setup](#development-setup)
- [Git Workflow](#git-workflow)
- [Coding Standards](#coding-standards)
- [Commit Guidelines](#commit-guidelines)
- [Pull Request Process](#pull-request-process)
- [Testing](#testing)
- [Security](#security)

## Code of Conduct

- Be respectful and inclusive to all contributors
- Provide constructive feedback and criticism
- Focus on what is best for the community
- Report unacceptable behavior to the project maintainers

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or SQL Server Express
- [Node.js](https://nodejs.org/) (for Angular frontend)
- [Git](https://git-scm.com/)

### Fork and Clone

1. Fork the repository on GitHub
2. Clone your fork locally:
   ```bash
   git clone https://github.com/YOUR-USERNAME/student-app.git
   cd student-app
   ```
3. Add upstream remote:
   ```bash
   git remote add upstream https://github.com/Naresh-BDO/student-app.git
   ```

## Development Setup

### Backend Setup (.NET 8)

1. Navigate to the project directory:
   ```bash
   cd pratices_angular_CURD
   ```

2. Restore NuGet packages:
   ```bash
   dotnet restore
   ```

3. Update database connection string in `appsettings.Development.json`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=YOUR-SERVER;Database=AngularStdDb;Trusted_Connection=True;TrustServerCertificate=True;"
     }
   }
   ```

4. Apply migrations:
   ```bash
   dotnet ef database update
   ```

5. Run the backend:
   ```bash
   dotnet run
   ```

The API will be available at `https://localhost:5001` or as configured.

### Frontend Setup (Angular)

1. Navigate to the Angular project directory:
   ```bash
   cd angular-frontend  # adjust path as needed
   ```

2. Install dependencies:
   ```bash
   npm install
   ```

3. Run the development server:
   ```bash
   ng serve
   ```

The frontend will be available at `http://localhost:4200`

## Git Workflow

### Creating a Branch

1. Keep your `master` branch in sync:
   ```bash
   git checkout master
   git pull upstream master
   ```

2. Create a feature branch with descriptive name:
   ```bash
   git checkout -b feature/add-student-validation
   git checkout -b fix/login-token-expiry
   git checkout -b docs/update-api-documentation
   ```

### Branch Naming Convention

- `feature/` - for new features
- `fix/` - for bug fixes
- `docs/` - for documentation updates
- `refactor/` - for code refactoring
- `test/` - for test additions/updates

## Coding Standards

### C# / .NET 8 Standards

- Follow [Microsoft C# Coding Conventions](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- Use PascalCase for class names and public members
- Use camelCase for private members and local variables
- Always use `async/await` for I/O operations
- Add XML documentation comments for public methods:

```csharp
/// <summary>
/// Retrieves all students from the database.
/// </summary>
/// <returns>A list of Student entities</returns>
[HttpGet]
public async Task<IActionResult> GetAllStudents()
{
    // implementation
}
```

### File Structure

```
Controllers/       - API endpoints
Data/             - DbContext and data configurations
Dtos/             - Data Transfer Objects
Models/           - Entity models
Services/         - Business logic
Enums/            - Enum definitions
Migrations/       - EF Core migrations (tracked in git)
```

### Security Best Practices

- Never commit sensitive information (connection strings, API keys, JWT secrets)
- Use `appsettings.Development.json` (in `.gitignore`) for local configuration
- Always validate and sanitize user input
- Use parameterized queries to prevent SQL injection
- Implement proper authorization checks on all endpoints

## Commit Guidelines

### Commit Message Format

Follow a clear, descriptive format:

```
<type>(<scope>): <subject>

<body>

<footer>
```

### Example

```
feat(auth): add JWT token refresh endpoint

- Implement refresh token validation
- Add new RefreshTokenAsync method to JwtService
- Update AuthController with new refresh endpoint

Closes #123
```

### Types

- `feat:` - A new feature
- `fix:` - A bug fix
- `docs:` - Documentation only changes
- `style:` - Changes that don't affect code meaning (formatting, semicolons, etc.)
- `refactor:` - Code change that neither fixes a bug nor adds a feature
- `perf:` - Code change that improves performance
- `test:` - Adding or updating tests
- `chore:` - Changes to build process, dependencies, or tooling

### Commit Guidelines

- Write clear, descriptive commit messages
- Use imperative mood ("add" not "added" or "adds")
- Reference issues and pull requests when applicable
- Keep commits atomic - one logical change per commit
- Avoid mixing refactoring with feature changes

## Pull Request Process

1. **Update your branch:**
   ```bash
   git fetch upstream
   git rebase upstream/master
   ```

2. **Push your branch:**
   ```bash
   git push origin feature/your-feature-name
   ```

3. **Create a Pull Request** on GitHub with:
   - Clear title describing the changes
   - Reference to related issues (e.g., "Closes #123")
   - Description of changes made
   - Screenshots (if UI changes)
   - Testing performed

4. **PR Description Template:**
   ```markdown
   ## Description
   Brief description of what this PR does.

   ## Related Issue
   Closes #(issue number)

   ## Type of Change
   - [ ] Bug fix
   - [ ] New feature
   - [ ] Breaking change
   - [ ] Documentation update

   ## How Has This Been Tested?
   - [ ] Unit tests
   - [ ] Integration tests
   - [ ] Manual testing

   ## Screenshots (if applicable)
   Add screenshots here.

   ## Checklist
   - [ ] Code follows style guidelines
   - [ ] No new warnings generated
   - [ ] Added/updated tests
   - [ ] Updated documentation
   - [ ] Tested locally
   ```

5. **Review Process:**
   - Address feedback from reviewers
   - Update PR with fixes if needed
   - Rebase if necessary: `git rebase upstream/master`

## Testing

### Adding Tests

- Write unit tests for new business logic
- Aim for at least 80% code coverage
- Test both success and failure scenarios

### Running Tests

```bash
dotnet test
```

### Test Naming Convention

```csharp
// Format: MethodName_ScenarioBeingTested_ExpectedBehavior
[Test]
public void GetStudentById_WithValidId_ReturnsStudent()
{
    // Arrange, Act, Assert
}
```

## Security

### Reporting Security Issues

**Do not** create public GitHub issues for security vulnerabilities. Instead:

1. Email security concerns to the project maintainer
2. Include details of the vulnerability
3. Allow time for a fix before public disclosure

### Security Checklist

- [ ] No hardcoded secrets or credentials
- [ ] Input validation on all endpoints
- [ ] Proper authentication/authorization checks
- [ ] No SQL injection vulnerabilities
- [ ] Sensitive data is encrypted at rest and in transit

## Additional Resources

- [Microsoft .NET Documentation](https://learn.microsoft.com/en-us/dotnet/)
- [Entity Framework Core Documentation](https://learn.microsoft.com/en-us/ef/core/)
- [ASP.NET Core Security](https://learn.microsoft.com/en-us/aspnet/core/security/)
- [Angular Documentation](https://angular.io/docs)

## Questions?

Feel free to open an issue or reach out to the project maintainers for clarification.

---

Thank you for contributing! Your efforts help improve this project for everyone. ??
