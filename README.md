# Guild Manager

Guild Wars 2 / Discord Guild Manager created using ASP.NET 6 and React.

# Requirements

* .NET Core 6
* Node.js
* [Discord Oauth Client](https://discord.com/developers/docs/topics/oauth2)

# Required Config

To get the application running you'll need to setup the following secrets/env variables for the ASP.NET API:

* `Discord:ClientId` - Discord OAuth Client Id
* `Discord:ClientSecret` - Discord OAuth Client Secret 
* `Discord:BotToken` - token for bot to make Discord API calls.
