# Movify

A modern **Movie Discovery Platform** built with a clean architecture, featuring a .NET 8 Backend-for-Frontend (BFF) and a React TypeScript frontend.

## ✨ Features

- **Movie Search** – Search movies by title, year, and type
- **Detailed Movie Information** – Rich data from OMDB API including ratings, plot, cast, and posters
- **Modern UI** – Built with React, TypeScript, and Ant Design
- **Docker Ready** – Fully containerized with multi-stage builds
- **Clean Architecture** – Well-structured .NET BFF with proper separation of concerns

## 🚀 Quick Start

### Using Docker (Recommended)

```bash
# Clone the repository
git clone https://github.com/K41Z0/movify.git
cd movify

# Start both frontend and backend
docker compose up --build -d
```

The application will be available at:

- **Frontend**: http://localhost:3000
- **Backend API**: http://localhost:5000

### Development

```bash
# Backend
cd movify_bff
dotnet run --project RestApi/RestApi.csproj

# Frontend (in another terminal)
cd movify_web
npm install
npm start
```

## 🐳 Docker Services

| Service     | Port (Host) | Description                          |
|-------------|-------------|--------------------------------------|
| `movify-web` | 3000        | React + TypeScript + Nginx frontend  |
| `movify-bff` | 5000        | .NET 8 Backend-for-Frontend API      |

## 🛠 Tech Stack

**Backend:**
- .NET 8
- Clean Architecture
- OMDB API integration
- Fluent Validation

**Frontend:**
- React 18 + TypeScript
- Create React App
- Ant Design (AntD)
- React Router DOM

**DevOps:**
- Docker + Docker Compose
- Multi-stage builds
- Nginx as reverse proxy

## 📁 Project Structure

```
movify/
├── docker-compose.yml
├── movify_bff/          # .NET 8 BFF
│   ├── RestApi/         # Main API project
│   ├── Domain/          # Business logic & DTOs
│   └── Infrastructure/  # External services & repositories
├── movify_web/          # React frontend
│   ├── src/
│   ├── public/
│   └── Dockerfile
├── .gitignore
└── README.md
```

## 🤝 API Endpoints

- `GET /api/movies/search?title=Inception` – Search movies
- `GET /api/movies/{imdbId}` – Get movie details by IMDb ID

## 📄 License

This project was created as a technical assessment for a **Senior Full Stack Software Engineer** position.

---

**Made with ❤️ using Docker, .NET 8, and React**