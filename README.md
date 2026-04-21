# InfoTrack App

A solicitor search application with an Angular frontend and .NET 10 backend API.

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [Node.js](https://nodejs.org/) (v18+) and npm
- [Angular CLI](https://angular.dev/installation) 21.2.7

Verify your installations:

```bash
dotnet --version   # should be 10.x.x
node --version     # should be v18 or higher
npm --version
ng --version       # should be 21.2.7
```

## Running the App

Both the API and client need to run simultaneously in separate terminals.

### 1. Start the API (Terminal 1)
Ensure nuget packages are configured before running:
```bash
cd InfoTrackApp.API
dotnet restore
dotnet run
```

The API will be available at `https://localhost:5187`.

### 2. Start the Client (Terminal 2)

```bash
cd InfoTrackApp.Client/info-track-app
npm install
npm start
```

The app will be available at `http://localhost:4200`.
