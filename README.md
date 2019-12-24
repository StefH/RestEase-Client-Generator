[![Version](https://vsmarketplacebadge.apphb.com/version/StefHeyenrath.RestEaseClientGenerator.svg)](https://marketplace.visualstudio.com/items?itemName=StefHeyenrath.RestEaseClientGenerator) 
[![Installs](https://vsmarketplacebadge.apphb.com/downloads-short/StefHeyenrath.RestEaseClientGenerator.svg)](https://marketplace.visualstudio.com/items?itemName=StefHeyenrath.RestEaseClientGenerator) 
[![Rating](https://vsmarketplacebadge.apphb.com/rating-star/StefHeyenrath.RestEaseClientGenerator.svg)](https://marketplace.visualstudio.com/items?itemName=StefHeyenrath.RestEaseClientGenerator)

# RestEase Client Generator
A Visual Studio Extension to generate a [RestEase](https://github.com/canton7/RestEase) compatible client (Interface & Models) based on a [Swagger / OpenApi](https://swagger.io/specification/) specification.


## Features
- Supports Visual Studio 2017 and 2019
- Add New RestEase API Client to a project from an OpenAPI specification URL (e.g https://petstore.swagger.io/v2/swagger.json)
- Define custom namespace for the generated file
- Auto-updating of generated code file when changes are made to the specification file (.json, .yml or .yaml)


### Custom Tools
- RestClientCodeGenerator - Generates a single file C# RestEase Client **Interface** and **Models**.


### Dependencies
This Visual Studio Extension will automatically add the required nuget packages that the generated code depends on.


## Screenshots
TODO

## Settings
TODO

## Credits
- Project source code is based on [REST API Client Code Generator](https://github.com/christianhelle/apiclientcodegen)
- Code used from https://raw.githubusercontent.com/andeart/CaseConversions/master/CaseConversions/CaseConversion.cs