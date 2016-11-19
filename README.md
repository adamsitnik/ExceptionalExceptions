# ExceptionalExceptions

Code for my talk http://dotnext-moscow.ru/talks/sitnik/

# Caution!

This repository contains examples for both classic .NET and the new .NET Core. More examples are available for classic .NET, due to the fact that some APIs has not been ported to .NET Core yet (`Thread.Abort`, CERs).

# Building

The following elements are required for building the source code:

* [Visual Studio 2015 Update **3**](http://go.microsoft.com/fwlink/?LinkId=691129)
* [.NET Core SDK](https://go.microsoft.com/fwlink/?LinkID=809122)
* [.NET Core Tooling Preview 2 for Visual Studio 2015](https://go.microsoft.com/fwlink/?LinkId=817245)
* Internet connection and disk space to download all the required packages

# Running from Visual Studio

* Set `Demo` as StartUp Project
* Choose desired target framework and Run/Debug the app!

![click on arrow next to SetUp project name and pick the framework from the list](https://s21.postimg.org/nd9xj064n/how_To_Run.png)

# Running from console

* .NET Core: `dotnet run -c Release -f netcoreapp10`
* .NET 4.5: `dotnet run -c Release -f net45`
