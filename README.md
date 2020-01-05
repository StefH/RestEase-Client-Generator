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

### General
| Name | Description |
| - | - |
| Array Type | Array type to use. The default is Array 'T[]'.
| Fail on OpenApi Errors | Don't generate the file if errors are detected when parsing the specification file. The default value is 'False'.
| Use DateTimeOffset | Use DateTimeOffset instead of DateTime. The default value is 'False'.
| Namespace for the Api | Append this namespace for the Api. The default value is 'Api'.
| Namespace for the Models | Append this namespace for the Models. The default value is 'Models'.

### Interface
| Name | Description |
| - | - |
| Append Async | Append Async postfix to all methods. The default value is 'True'.
| Add Authorization header | Add an Authorization header to the generated interface. The default value is 'False'.
| Method ReturnType | The ReturnType to use for the methods. The default value is 'Type'. For more details see https://github.com/canton7/RestEase#return-types.
| Type for multipart/form-data | The MultipartFormData FileType to use. The default value is 'byte[]'.
| Type for application/octet-stream | The ApplicationOctetStream Type to use. The default value is 'byte[]'.
| Generate MultipartFormData Extension methods | Generate Extension methods for MultipartFormData methods. The default value is 'True'.
| Generate FormUrlEncoded Extension methods | Generate Extension methods for FormUrlEncoded methods. The default value is 'True'.
| Generate ApplicationOctetStream Extension methods | Generate Extension methods for ApplicationOctetStream methods. The default value is 'True'.
| Return Object from Method | Return Object from Method when Response is defined but no Model is specified. The default value is 'False'.
| Preferred Content-Type | Preferred Content-Type to use when both 'application/json' and 'application/xml' are defined. The default value is 'application/json'.
| Force Content-Type to 'application/json' | Always use Content-Type 'application/json', also when multiple Content-Types are are defined. The default value is 'False'.

### Screenshot
![Settings](https://github.com/StefH/RestEase-Client-Generator/raw/master/resources/settings.png)


## Credits
- Project source code is based on [REST API Client Code Generator](https://github.com/christianhelle/apiclientcodegen)
- Code used from https://raw.githubusercontent.com/andeart/CaseConversions/master/CaseConversions/CaseConversion.cs
- Code used from https://www.codeproject.com/articles/6294/description-enum-typeconverter
