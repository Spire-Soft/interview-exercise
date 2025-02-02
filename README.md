# Interview Exercise

## Overview
This exercise consists of building a **Minimal API Backend** using .NET and a **Angular** front end project. The goal is to focus on **quality, reusability, and scalability** rather than just finishing the tasks.

---

## Backend
### **Requirements**
Implement APIs for the following functionalities:

1. **Add a new ticket** to an existing project.
2. **Add subtasks** to an existing ticket.
3. **Assign projects** to existing users.
4. **Assign tickets** to existing users.
5. **Assign subtasks** to existing users.
6. **List Tickets** to show list of all assigned ticket which need to .

### **Project Structure**
The backend follows a **modular structure**:

```
/ticketapi
│── /Modules         # Modules register endpoints and services
│── /Services        # Handles data extraction and logic
│── /Models          # Data models for the ticket database
│── /Data/TicketDbContext.cs  # Entity Framework Core DbContext
│── Program.cs       # Application entry point
│── appsettings.json # Configuration settings
```

### **Setting Up the Backend**
#### 1. **Install Dependencies**
Ensure you have `.NET 7+` installed. Run the following command to install dependencies:
```bash
dotnet restore
```

#### 2. **Run Database Migrations**
To create the SQLite database and apply migrations:
```bash
dotnet ef migrations add SampleMigration --output-dir Data/Migrations
dotnet ef database update
```

#### 3. **Run the API**
Start the backend:
```bash
dotnet run
```
By default, the API will be available at `http://localhost:5000/swagger` (if Swagger is enabled).

---

## Frontend
### **Requirements**
Implement a UI with the following features:

1. A **list view** displaying **projects and users**.
2. A **card** showing the total **count of projects and tickets**.
3. A **data table** displaying **users and their assigned tickets**.

### **Project Structure**
The frontend follows a **component-based structure**:

```
/ticketui
│── /src
│   ├── /features      # Standalone components grouped by feature
│   ├── /services      # API calls and data fetching
│── package.json       # Project dependencies
```

### **Setting Up the Frontend**
#### 1. **Install Dependencies**
Ensure you have `Node.js 16+` installed. Run the following command:
```bash
npm install
```

#### 2. **Run the Development Server**
To start the frontend:
```bash
npm run start
```

---

### **Soruce code process**
- **Create a seperate branch**.
- **Raise a PR when done**.
- **Send an email with the PR link**.
- **Branch Name should be your firstName-frontend or firstName-backend. Example if your firstname is James then valid branch name will be James-Frontend**.

---


### **Guidelines**
- **Use standalone components** inside `/features`.
- **Use signals if possible** for state management (optional, but recommended).
- **Use SCSS** for styling instead of plain CSS.
- **Follow best practices** for reusability and maintainability.

---

## Notes
- Prioritize **quality, reusability, and scalability** over merely completing tasks.
- Ensure modular design principles for **both backend and frontend**.
- Use **best practices** for database interactions and API structuring.

Happy coding! 🚀
