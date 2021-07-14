[![Version](https://vsmarketplacebadge.apphb.com/version/StefHeyenrath.RestEaseClientGenerator.svg)](https://marketplace.visualstudio.com/items?itemName=StefHeyenrath.RestEaseClientGenerator) 
[![Installs](https://vsmarketplacebadge.apphb.com/downloads-short/StefHeyenrath.RestEaseClientGenerator.svg)](https://marketplace.visualstudio.com/items?itemName=StefHeyenrath.RestEaseClientGenerator) 
[![Rating](https://vsmarketplacebadge.apphb.com/rating-star/StefHeyenrath.RestEaseClientGenerator.svg)](https://marketplace.visualstudio.com/items?itemName=StefHeyenrath.RestEaseClientGenerator)

# RestEase Client Generator
A Visual Studio Extension to generate a [RestEase](https://github.com/canton7/RestEase) compatible client (Interface & Models) based on a [Swagger / OpenApi](https://swagger.io/specification/) or [RAML](https://raml.org/) specification.

# Demo
[Blazor WebAssembly Demo](https://stefh.github.io/RestEase-Client-Generator/)

## Features
- Supports Visual Studio 2017 and 2019
- Add New RestEase API Client to a project from an OpenAPI specification URL (e.g https://petstore.swagger.io/v2/swagger.json)
- Define custom namespace for the generated file
- Auto-updating of generated code file when changes are made to the specification file (.json, .yml, .yaml, .raml)


### Custom Tools
- RestClientCodeGenerator - Generates a single file C# RestEase Client **Interface** and **Models**.


### Dependencies
This Visual Studio Extension will automatically add the required nuget packages that the generated code depends on.


## Example

### Input Yaml file 'PetStore.yaml'
Excerpt...
``` yml
paths:
  /pet:
    post:
      tags:
        - pet
      summary: Add a new pet to the store
      description: ''
      operationId: addPet
      consumes:
        - application/json
        - application/xml
      produces:
        - application/xml
        - application/json
      parameters:
        - in: body
          name: body
          description: Pet object that needs to be added to the store
          required: true
          schema:
            $ref: '#/definitions/Pet'
```
([Full example](https://github.com/StefH/RestEase-Client-Generator/blob/master/examples/RestEaseClientGeneratorConsoleApp/petstore.yaml)).

### Generate file 'PetStore.cs'
Excerpt...
``` c#
namespace RestEaseClientGeneratorConsoleApp.PetStoreJson.Api
{
    public interface IPetStoreApi
    {
        /// <summary>
        /// Add a new pet to the store
        /// </summary>
        /// <param name="pet">A pet for sale in the pet store</param>
        [Post("/pet")]
        Task AddPetAsync([Body] Pet pet);

        // More methods ...
    }
}

namespace RestEaseClientGeneratorConsoleApp.PetStoreJson.Models
{
    public class Pet
    {
        public long Id { get; set; }

        // More properties ...
    }
}
```
([Full example](https://github.com/StefH/RestEase-Client-Generator/blob/master/examples/RestEaseClientGeneratorConsoleApp/PetStoreJson/PetStoreJson.cs)).

### Create a Client and call methods
``` c#
var petStoreApi = RestClient.For<IPetStoreApi>("https://petstore.swagger.io/v2");

var findPetsByTags = await petStoreApi.FindPetsByTagsAsync(new[] { "cat" });
```

## Screenshots

### Add new specification and generate client code
![Add from OpenAPI Specification](https://github.com/StefH/RestEase-Client-Generator/raw/master/resources/add-new.png)
![Enter URL to OpenAPI Specification](https://github.com/StefH/RestEase-Client-Generator/raw/master/resources/openurl.png)

### Generate client code for existing .json, .yml or .yaml file
![Solution Explorer Context Menus](https://github.com/StefH/RestEase-Client-Generator/raw/master/resources/generate.png)

## Options

See https://github.com/StefH/RestEase-Client-Generator/wiki/Options

## Credits
- Project source code is based on [REST API Client Code Generator](https://github.com/christianhelle/apiclientcodegen)
- Code used from https://raw.githubusercontent.com/andeart/CaseConversions/master/CaseConversions/CaseConversion.cs
- Code used from https://www.codeproject.com/articles/6294/description-enum-typeconverter
