# Money Burned: mb-dotnet-lib

This repository is one of several reference implementations of the "Money Burned" application to illustrate the use of a specific development technology/platform. To learn more about it, check out the [organization profile](https://github.com/Money-Burned).  

This is just a software component that contains general business logic and can be used by other applications that use the same software development framework. It is a dependency for the following projects:  

- [mb-dotnet-console](https://github.com/Money-Burned/mb-dotnet-console)

## Quick facts

- Application type: **Library**
- Available for: **Cross-Platform (Windows/Linux/Mac)**
- Framwork/Technology used: **Dotnet**
- Programming Language used: **C#**
- User interaction: none

> Degree of difficulty: **moderate**

## Getting started

### Prerequisites

- Download and Install Dotnet SDK
- Clone this repository
- Get a Dotnet project OR write your own Dotnet project that is using this library
- Compile/build your project that is referencing the library

### How to run

It is not possible to run the library independently in a meaningful way.

### How to develop

For information about the development process of this appliacation please refer to the [development approach documentation](./doc/dev-approach.md).  

## Usage

If you want to use the library in one of your Dotnet projects, you'll need to add it as a dependency reference. You can use the Dotnet CLI by adding a reference to the library.  
Lets assume the cloned repository of the library is located two directory levels below your current location, from the project you like to add the reference to:  

```dotnetcli
dotnet add reference ..\..\mb-dotnet-lib\src\mb-dotnet-lib.csproj
```
