# Collective Project – UBB

This repository contains the **Collective Project** developed at **UBB (Universitatea Babeș-Bolyai)**.  
It’s a **web application** designed to improve the current **school schedule website** used at the university.

---

## 🧠 Overview

The project follows a **modern, clean, and maintainable architecture** with:
- **SQL Server** as the database
- **.NET** for the backend
- **Angular** for the frontend

Our goal is to build a well-structured, scalable, and developer-friendly solution that can easily evolve over time.

---

## ⚙️ Architecture

### 🖥 Backend
- Built with **.NET 8**
- Follows the **CQRS (Command Query Responsibility Segregation)** pattern — a clean, efficient, and scalable architecture for APIs
- Designed with **separation of concerns** and **readability** in mind
- SQL Server integration for data storage

### 💻 Frontend
- Built with **Angular**
- Uses **standalone components** and the **latest Angular features**
- Emphasizes **component reusability** and **clean separation of UI logic**

---

## 🧩 Development Guidelines

We want our codebase to feel like it was written by a single person — clean, consistent, and easy to maintain.  
Below are the rules and principles every developer should follow.

---

### 🧩 Collaboration & Git Workflow Rules

* **No one commits directly to the `main` branch.**
  All changes must go through a **Pull Request (PR)** that is **reviewed and approved by at least two other colleagues** before merging.

* **Initial setup exception:**
  Only the project lead may make direct commits early on (for setup and README adjustments).

* **Branch per task:**
  Every task or issue must be handled in its **own dedicated branch**.
  Each branch should solve **only one issue or feature**.

* **Bug reporting:**
  If you find a bug while working on another feature, **do not fix it in the same branch**.
  Instead, report it as a **separate issue** and address it in a **new branch** later.
  → This keeps debugging easier and progress more traceable.

* **Commit messages:**

  * Commit messages should be **clear and descriptive**, explaining what was done.
  * Small, isolated commits are fine for small changes, but generally aim for **meaningful, informative commit messages**.
  * Avoid commits that modify **dozens or hundreds of files at once**.
  * Make **incremental commits** as you achieve small milestones — this helps with code reviews and rollback safety.

---

### 🗄️ Database & Migration Rules

* We are using **multiple databases**:

  * A **main (production-like)** database — only **migrations from the `main` branch** will be applied here.
  * **Individual developer databases** — each developer must use their own DB when working on new features that involve schema changes.

* **Never apply test or experimental migrations** to the main database.

* When working on a feature that includes database changes:

  * Run migrations only in **your local/test database**.
  * Make sure your migration files are **clean and ordered** before creating a Pull Request.

* If multiple developers are creating migrations at the same time:

  * Keep track of the **migration order** to avoid conflicts.
  * Example:
    If `Migration_1` and `Migration_2` are already in the `main` branch, and two developers create migrations in parallel:

    * Before submitting a PR, check if **new migrations** were merged into `main`.
    * If there are new migrations after yours, **recreate your migration** so that the migration sequence stays correct and conflict-free.

* Always **verify your migration history** before merging:

  * Run `dotnet ef migrations list` to check the current order.
  * Apply and test your migrations locally before submitting a PR.

* The goal is to maintain a **stable, synchronized migration chain** across all environments.
  
---

### 🔁 General Project Rules
- Follow the **DRY (Don’t Repeat Yourself)** principle — avoid code repetition everywhere.
- Write **clean, readable, and maintainable** code.
- Use **camelCase** consistently across the entire project.
- Use **suggestive names** for variables, methods, and classes.  
  ❌ `var x = something;`  
  ✅ `var studentSchedule = something;`
- Follow **best practices** at all times.

---

### 🧱 Backend Rules (.NET)
- Class variable declarations:
  - Start with a **small letter** (e.g., `private string name;`)
  - Declare **private fields first**, then **public fields**
- Method ordering:
  - **Public methods first**, then **private methods**
- Method names start with a **capital letter**
- Always use var, no need to specify the type. If you are not sure about the type, hover over the variable, and you'll see it.
- Always use `{}` after `if`, `for`, `while`, even for single-line statements
- Bracket style:
  ```csharp
  if ()
  {
      // code
  }


### 🌐 Frontend Rules (Angular / TypeScript)

* **No `any` types** — strictly typed TypeScript only.
* Apply the **DRY** principle; extract reusable HTML or logic into **shared components**.
* Class structure:

  * **Private variables first**, then **public variables**
  * **Public methods first**, then **private methods**
* Always **specify variable and method types** unless the type is clearly inferred.

  ```typescript
  public name: string;
  public count = 0; // clear type inference
  ```
* Always use `let` or `const`, **never `var`**.
* Variable and method names always start with a **small letter**.

---

