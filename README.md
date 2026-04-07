# Angular ASP.NET Application

## Description

This project is a full-stack web application built with **Angular (frontend)** and **ASP.NET Core (backend)**. It demonstrates a modern client-server architecture with authentication, API-driven data access, and a structured separation between UI, business logic, and persistence.

The application is designed as a learning and reference implementation for building scalable web systems using Angular and .NET, with a focus on clean layering, API design, and practical integration patterns.

---

## Features

- Angular SPA with modular structure and routing
- ASP.NET Core Web API with RESTful endpoints
- Token-based authentication (JWT)
- Entity Framework Core for data access
- SQLite database for local development
- Image upload integration (Cloudinary)
- Form handling and validation in Angular
- HTTP client abstraction for API communication
- Role-based authorization patterns

---

## Interesting Techniques

### 1. Reactive HTTP Communication (Angular)

The frontend uses Angular’s HttpClient with observable streams for API calls.

- Uses RxJS operators for async handling and transformation
- Encourages separation of concerns via service layers

MDN reference for async patterns:  
https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Promise

---

### 2. Form Handling with Angular Forms

The app leverages Angular’s reactive forms system for validation and state management.

- Declarative validation rules  
- Real-time form state tracking  
- Strong typing for form models  

MDN reference for form concepts:  
https://developer.mozilla.org/en-US/docs/Web/API/HTMLFormElement

---

### 3. JWT Authentication Flow

The backend issues JWT tokens and the frontend attaches them to requests.

- Stateless authentication  
- Authorization headers managed centrally  
- Secure API access patterns  

MDN reference:  
https://developer.mozilla.org/en-US/docs/Web/HTTP/Authentication

---

### 4. Entity Framework Core Data Modeling

The backend uses EF Core for ORM-based data access.

- Code-first migrations  
- DbContext abstraction  
- LINQ queries mapped to SQL  

---

### 5. Separation of Concerns (Service + Controller Layers)

Backend architecture separates:

- Controllers → HTTP interface  
- Services (implicit pattern) → business logic  
- Data layer → EF Core  

This keeps the API maintainable and testable.

---

### 6. Environment-Based Configuration

The app uses environment-specific configuration for:

- API URLs  
- Database connections  
- Third-party integrations  

---

### 7. File Upload Integration (Cloudinary)

Images are uploaded via backend integration with Cloudinary.

- Offloads storage responsibility  
- Provides CDN delivery  
- Simplifies image management  

Cloudinary docs:  
https://cloudinary.com/documentation

---

## Notable Technologies & Libraries

### Frontend

- Angular  
  https://angular.io/

- RxJS  
  https://rxjs.dev/

- Tailwind CSS  
  https://tailwindcss.com/

- Angular Router  

---

### Backend

- ASP.NET Core  
  https://learn.microsoft.com/en-us/aspnet/core/

- Entity Framework Core  
  https://learn.microsoft.com/en-us/ef/core/

- ASP.NET Identity Core  

---

### Database

- SQLite  
  https://www.sqlite.org/index.html  

---

### External Services

- Cloudinary  
  https://cloudinary.com/

---

### Tooling

- Angular CLI  
- npm  
- Visual Studio / VS Code  

---

## Project Structure

```plaintext
/ (root)
├── API/
├── client/
├── .gitignore
├── README.md
