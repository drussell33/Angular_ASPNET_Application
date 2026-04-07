# 🚀 Angular ASP.NET Application

> A full-stack learning project that pairs an Angular 21 single-page application with an ASP.NET Core 9 API, SQLite persistence, JWT authentication, and SignalR-powered presence. It is structured like a real production-style app, with separated frontend and backend projects under a shared solution, making it a strong reference project for developers learning modern .NET + Angular integration.

---

## Badges

![Repo Size](https://img.shields.io/github/repo-size/drussell33/Angular_ASPNET_Application?style=for-the-badge)
![Languages](https://img.shields.io/github/languages/count/drussell33/Angular_ASPNET_Application?style=for-the-badge)
![Top Language](https://img.shields.io/github/languages/top/drussell33/Angular_ASPNET_Application?style=for-the-badge)
![Last Commit](https://img.shields.io/github/last-commit/drussell33/Angular_ASPNET_Application?style=for-the-badge)
![License](https://img.shields.io/badge/license-no%20license-lightgrey?style=for-the-badge)

> **Note:** This repository does not currently include a `LICENSE` file.

---

## Key Features

- Angular 21 frontend built as a standalone application
- ASP.NET Core 9 backend organized into controllers, services, entities, DTOs, helpers, middleware, and SignalR hubs
- User registration and login flows backed by ASP.NET Core Identity
- JWT-based authentication with role extraction on the client
- Secure refresh-token flow using **HttpOnly**, **Secure**, **SameSite=Strict** cookies
- Route protection using an Angular auth guard for authenticated sections
- Member, lists, and messages feature areas in the frontend routing structure
- SignalR presence hub for real-time online/offline user status
- SQLite-backed persistence configured through Entity Framework Core
- App bootstrap initializer for session restoration via refresh token
- Angular view transitions and zoneless change detection configuration
- Tailwind CSS + DaisyUI for frontend styling
- Vitest configured for frontend unit testing

---

## Built With

### Backend
- **C# / .NET 9**
- **ASP.NET Core Web API**
- **ASP.NET Core Identity**
- **Entity Framework Core**
- **SQLite**
- **JWT Bearer Authentication**
- **SignalR**

### Frontend
- **Angular 21**
- **TypeScript**
- **RxJS**
- **Tailwind CSS 4**
- **DaisyUI**

### Tooling
- **Angular CLI 21**
- **npm 11**
- **Vitest**
- **Prettier**

---

## Architecture Overview

This repository contains a solution-level application inside the [`DatingApp/`](./DatingApp) folder.

- The **backend** lives in [`DatingApp/API/`](./DatingApp/API) and exposes REST endpoints under `api/[controller]` using a shared base controller.
- The **frontend** lives in [`DatingApp/client/`](./DatingApp/client) and communicates with the API through Angular services and `HttpClient`.
- Authentication is split between **JWT access tokens** and **refresh tokens stored in secure cookies**.
- Real-time user presence is handled through a SignalR hub in [`DatingApp/API/SignalR/`](./DatingApp/API/SignalR).
- The frontend app is structured into **core**, **features**, **layout**, **shared**, and **types** areas for separation of concerns.

---

## Project Structure

```text
Angular_ASPNET_Application/
├── .gitignore
├── README.md
└── DatingApp/
    ├── DatingApp.sln                 # Solution file tying backend and frontend together
    ├── API/                          # ASP.NET Core backend
    │   ├── Controllers/              # API endpoints
    │   ├── DTOs/                     # Request/response contracts
    │   ├── Data/                     # DbContext, seeding, migrations, data access
    │   ├── Entities/                 # Domain and identity models
    │   ├── Errors/                   # Error payload models
    │   ├── Extensions/               # Extension methods and setup helpers
    │   ├── Helpers/                  # Cross-cutting backend helpers
    │   ├── Interfaces/               # Service abstractions
    │   ├── Middleware/               # Custom middleware
    │   ├── Properties/               # Launch settings
    │   ├── Services/                 # Application services such as token creation
    │   ├── SignalR/                  # Real-time hubs and tracking
    │   ├── API.csproj                # Backend project file
    │   ├── Program.cs                # Dependency injection and HTTP pipeline setup
    │   └── WeatherForecast.cs        # Default template artifact / sample file
    └── client/                       # Angular frontend
        ├── public/                   # Public static assets
        ├── src/
        │   ├── app/                  # Root application shell and route config
        │   ├── core/                 # Guards and singleton services
        │   ├── environments/         # Environment settings
        │   ├── features/             # Feature pages/components
        │   ├── layout/               # Layout-level UI structure
        │   ├── shared/               # Reusable UI pieces
        │   ├── types/                # Shared TypeScript models/types
        │   ├── index.html            # HTML entry point
        │   ├── main.ts               # Angular bootstrap entry
        │   └── styles.css            # Global styles
        ├── angular.json              # Angular workspace configuration
        ├── package.json              # Frontend dependencies and scripts
        ├── tsconfig.json             # TypeScript config
        └── README.md                 # Angular CLI-generated README
```

---

## Screenshot / Demo

> _Add a screenshot, short GIF, or deployed demo link here._

Example:

```md
![App Screenshot](./docs/screenshot.png)
```

---

## Getting Started

### Prerequisites

Install the following before running the project:

- [.NET 9 SDK](https://dotnet.microsoft.com/)
- [Node.js](https://nodejs.org/)
- npm
- [Angular CLI](https://angular.dev/tools/cli)

Install Angular CLI globally if needed:

```bash
npm install -g @angular/cli
```

### Installation

Clone the repository:

```bash
git clone https://github.com/drussell33/Angular_ASPNET_Application.git
cd Angular_ASPNET_Application
```

Restore and build the backend:

```bash
cd DatingApp/API
dotnet restore
dotnet build
```

Install frontend dependencies:

```bash
cd ../client
npm install
```

### Usage

Run the backend API:

```bash
cd DatingApp/API
dotnet run
```

The included launch settings configure the API for:

```text
https://localhost:5001/
```

Run the Angular frontend in a second terminal:

```bash
cd DatingApp/client
ng serve
```

Open the frontend at:

```text
http://localhost:4200/
```

### Development Notes

- The backend CORS configuration explicitly allows `http://localhost:4200` and `https://localhost:4200`.
- The frontend environment is configured with relative API and hub URLs:

```ts
export const environment = {
  production: true,
  apiUrl: 'api/',
  hubUrl: 'hubs/'
};
```

Depending on how you run the application in development, you may want to add or adjust a proxy/dev-server configuration.

---

## Observed Routes and Application Areas

From the current Angular route configuration, the app includes these top-level experiences:

- `/` — home page
- `/members` — member list
- `/members/:id` — member details
- `/lists` — lists view
- `/messages` — messages view

Authenticated routes are wrapped behind an Angular auth guard.

---

## Authentication Flow

This repository currently implements a more advanced auth setup than a basic demo app:

1. A user registers or logs in through the API.
2. The backend issues an access token and also sets a refresh token cookie.
3. The frontend stores the current user in an Angular signal.
4. On app startup, an initializer attempts to refresh the session automatically.
5. A timed refresh keeps the session alive while the user remains active.
6. Logout clears the refresh token server-side and removes client state.

---

## Roadmap

### Current Status
- [x] Angular frontend and ASP.NET Core backend in one solution
- [x] JWT authentication
- [x] Refresh token cookie flow
- [x] Route guarding for authenticated pages
- [x] SignalR presence tracking
- [x] SQLite + Entity Framework setup
- [x] Tailwind CSS integration
- [x] Vitest test runner configuration

### Potential Next Improvements
- [ ] Add a root-level architecture diagram
- [ ] Add API endpoint documentation
- [ ] Add seed/setup instructions for development data
- [ ] Add backend integration tests
- [ ] Add frontend unit test examples
- [ ] Add Docker support
- [ ] Add CI workflow for build and test validation
- [ ] Add deployment instructions
- [ ] Add screenshots and demo media
- [ ] Add a repository license file

---

## Contributing

Contributions are welcome.

1. Fork the repository
2. Create a feature branch
   ```bash
   git checkout -b feature/your-feature
   ```
3. Make your changes
4. Run the relevant build/test commands
5. Commit your work
   ```bash
   git commit -m "Add your feature"
   ```
6. Push the branch
   ```bash
   git push origin feature/your-feature
   ```
7. Open a Pull Request

A good contribution for this repository would include:

- clear commit messages
- focused changes
- updated documentation when behavior changes
- screenshots for UI-related improvements

---

## License

No `LICENSE` file is currently present in the repository, so this project is **not currently licensed for open-source reuse by default**. If you plan to share or accept contributions publicly, adding a license file would be a strong next step.

---

## Contact / Support

**Maintainer:** Derek Russell  
**GitHub:** [@drussell33](https://github.com/drussell33)

You can also add:

- LinkedIn profile
- portfolio site
- email address
- project discussion or issue templates

---

## Acknowledgments

- Angular CLI for the frontend scaffold
- ASP.NET Core for the backend foundation
- Tailwind CSS and DaisyUI for styling utilities and components
- SignalR for real-time presence updates

