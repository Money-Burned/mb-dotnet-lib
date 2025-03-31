# Money Burned: mb-dotnet-lib

This repository is one of several reference implementations of the "Money Burned" application to illustrate the use of a specific development technology/platform. To learn more about it, check out the [organization profile](https://github.com/Money-Burned).  

The library _mb-dotnet-lib_ is just a [.NET](https://dotnet.microsoft.com/en-us/learn/dotnet/what-is-dotnet) (pronounced "Dotnet") based software component that contains general business logic and can be used by other applications that use the same software development framework. It is a dependency for the following projects:  

- [mb-dotnet-console](https://github.com/Money-Burned/mb-dotnet-console)
- [mb-dotnet-winapp](https://github.com/Money-Burned/mb-dotnet-winapp)

---

The project maintains two separate branch lines (two each for the main and develop lines) to differentiate between the completeness of the features. Requirements define a [minimum](https://github.com/Money-Burned/.github/blob/main/doc/requirements.md#minimum-requirements) and an [optional set of requirements](https://github.com/Money-Burned/.github/blob/main/doc/requirements.md#optional-requirements), which this distinction is intended to take into account.  
You can recognize it by whether the suffix `-min` is present or absent from the two main branch lines.  

To make sure you are using the optional/maximum feature set, please use the branches without the `-min` suffix  both here and in the dependent projects.  

Your are here [**minimum set of requirements**](https://github.com/Money-Burned/mb-dotnet-lib/tree/main-min).  

## Quick facts

- Application type: **Library**
- Available for: **Cross-Platform** (Windows/Linux/Mac)
- Framework/Technology used: **[.NET 9.0](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)**
- Programming Language used: **C#**
- User interaction: none

> Degree of difficulty: **moderate**

## Getting started

### Prerequisites

- [Download](https://git-scm.com/downloads) and install a current version of Git
- [Download](https://dotnet.microsoft.com/en-us/download) and Install .NET SDK (at least Version 9.0)
- Clone this [repository](https://github.com/Money-Burned/mb-dotnet-lib)
- Compile/build your project that is referencing the library
- Get a .NET project OR write your own .NET project that is using this library

If you are working on Windows, you can use the following PowerShell commands to get started:  

```powershell
winget install Git.Git -e
winget install Microsoft.DotNet.SDK.9 -e
md ~\Money-Burned
cd ~\Money-Burned
git clone https://github.com/Money-Burned/mb-dotnet-lib.git
cd ~\Money-Burned\mb-dotnet-lib\src
dotnet build
ls
```

### How to run

It is not possible to run the library independently in a meaningful way.

### How to develop

For information about the development process of this appliacation please refer to the [development approach documentation](./doc/dev-approach.md).  

## Usage

If you want to use the library in one of your .NET projects, you'll need to add it as a dependency reference. You can [use the .NET CLI by adding a reference](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-add-reference) to the project, pointing to the library.  
Lets assume the cloned repository of the library is located two directory levels below your current location, from the project you like to add the reference to:  

```dotnetcli
dotnet add reference ..\..\mb-dotnet-lib\src\mb-dotnet-lib.csproj
```

The more state-of-the-art way to make dotnet program logic available for use in other people's software is to create a [NuGet](https://learn.microsoft.com/en-us/nuget/what-is-nuget) package and publish it to a central registry. Then you would [use the .NET CLI to add that package](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-add-package) to the project:  

```dotnetcli
dotnet add package MoneyBurned.Dotnet.Lib
```

Anyway - due to the nature of this collection of tutorials, it is fine to do it this way for now.  

Generally speaking, most modern software development platforms offer [centralized options for providing software packages](https://en.wikipedia.org/wiki/Category:Free_package_management_systems), such as libraries.  
