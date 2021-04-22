# Playground-Angular
Playground app for Angular

## Prerequisites
- [dotnet core 5](https://dotnet.microsoft.com/download)
- [NodeJS](https://nodejs.org/en/) 
- [Angular CLI](https://angular.io/guide/setup-local#install-the-angular-cli)

## Run the Apps Locally
This app is better run with [Visual Studio 2019](https://visualstudio.microsoft.com/downloads/), which would only require you to hit F5. 

If you somehow can't use it (or just prefer not to), please follow the step below:

Go to the `ClientApp` folder and run the command:
```
npm install
```

After all dependencies have been installed, go to the  `Web` folder and run the command:
```
dotnet run
```

Finally, you can open the URL shown in the command prompt.

## Code Structure
The application is generated using `dotnet new angular` command. It created the angular app with the ASP.NET Core as the server side API.

The `API` folder is where we put the backend API for each module. It includes:
- the Controller that the can be acceses by angular app through REST API
- Service class to access the database
- Entity class as the Domain class
- DTO class

The `Data` folder provide the database setup for the server. It currently use In Memory database as the storage, so you don't need to install additional database. When adding a new module, you would need to register the Service and Repository of the module in `ApplicationServiceSetup.cs` and `DataRepositorySetup.cs` respectively.

The `ClientApp` folder is a standard Angular CLI application. If you open a command prompt in that directory, you can run any `ng` command (e.g. `ng test`, or use `npm` to install extra packages to it)
