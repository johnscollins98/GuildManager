# Guild Manager

Guild Wars 2 / Discord Guild Manager created using ASP.NET 6 and React.

# Technologies Used

* .NET Core 6
* Node.js v16
* React 
* Bootstrap 5
* *Recommended: Visual Studio Code*
* [Discord Oauth Client](https://discord.com/developers/docs/topics/oauth2)

# Required Config

To get the application running you'll need to setup the following secrets/env variables for the ASP.NET API:

* `Discord:ClientId` - Discord OAuth Client Id
* `Discord:ClientSecret` - Discord OAuth Client Secret 
* `Discord:BotToken` - token for bot to make Discord API calls.

# Getting Started

* [Install Node.js v16](https://nodejs.org/en/)
* [Install .NET 6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
* [*Recommended: Install Visual Studio Code*](https://code.visualstudio.com/Download)
  * [And the C# extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)
* Run `dotnet restore` to grab NuGET packages.
* Running using CLI:
  * Run `yarn install` in `clientapp` to grab npm dependencies
  * Run `yarn build` in `clientapp` for a production build of the front end.
  * Run `yarn start` in `clientapp` to launch a dev server for the front end
  * Run `dotnet run` to launch the API project.
    * This will launch the React project if it isn't already running.
* Using VSCode:
  * Press <kbd>F5</kbd> to launch the ASP.NET application which will launch the React application also.
* You will be able to access the application at https://localhost:5000
