# Country Explorer

## Country Explorer BE
Use these instructions to get the project up and running.

### Prerequisites
You will need the following tools:

* [Visual Studio 2022](https://visualstudio.microsoft.com/downloads/)
* [.Net Core 6.0 or later](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
* [Visual Studio Code](https://code.visualstudio.com/download)
* [Angular CLI](https://angular.io/cli)
* [NodeJS](https://nodejs.org/en/download/)

### Installing
Follow these steps to get your development environment set up:
1. Clone the repository
2. At the root directory, restore required packages by running:
```csharp
dotnet restore
```
3. Next, build the solution by running:
```csharp
dotnet build
```
4. Next, within the CountryExplorerBE directory, launch the back end by running:
```csharp
dotnet run
```
5. Launch https://localhost:7203/ in your browser to view the Web UI.

If you have **Visual Studio** after cloning Open solution with your IDE, CountryExplorer should be the start-up project. Directly run this project on Visual Studio with **F5 or Ctrl+F5**. You will see the swagger page in your browser.

## Country Explorer FE

Open CountryExplorerApp

Run `npm install` for installing required node modules. 

Run `npm start` to run web server. Navigate to `http://localhost:4200/`. The application will automatically reload if you change any of the source files.


## Build

Run `ng build` to build the project. The build artifacts will be stored in the `dist/` directory.


## Environment

Open `src\environments\environment.ts` and update `apiUrl` property if there is a necessity to change environment api url.