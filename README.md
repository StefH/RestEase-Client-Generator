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

### Add new specification and generate client code
![Add from OpenAPI Specification](https://github.com/StefH/RestEase-Client-Generator/raw/master/resources/add-new.png)
![Enter URL to OpenAPI Specification](https://github.com/StefH/RestEase-Client-Generator/raw/master/resources/openurl.png)

### Generate client code for existing .json, .yml or .yaml file
![Solution Explorer Context Menus](https://github.com/StefH/RestEase-Client-Generator/raw/master/resources/generate.png)

## Options

### General
| Name | Description |
| - | - |
| ArrayType | Array type to use. The default is Array '[]'.
| Fail on OpenApi Errors | Don't generate the file if errors are detected when parsing the specification file. The default value is 'false'.
| Use DateTimeOffset | Use DateTimeOffset instead of DateTime. The default value is 'false'.

### Interface
| Name | Description |
| - | - |
| Append Async | Append Async postfix to all methods. The default value is 'true'.
| Add Authorization header | Add an Authorization header to the generated interface. The default value is 'false'.
| Method ReturnType | The ReturnType to use for the methods. The default value is 'Type'. For more details see https://github.com/canton7/RestEase#return-types.

### Screenshot
![Settings](https://github.com/StefH/RestEase-Client-Generator/raw/master/resources/settings.png)


## Credits
- Project source code is based on [REST API Client Code Generator](https://github.com/christianhelle/apiclientcodegen)
- Code used from https://raw.githubusercontent.com/andeart/CaseConversions/master/CaseConversions/CaseConversion.cs