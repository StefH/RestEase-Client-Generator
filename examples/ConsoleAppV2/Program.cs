using RestEaseClientGenerator.Types;
using RestEaseClientGeneratorV2;

var g2 = new GeneratorV2();
//var petStoreJsonSettings = new GeneratorSettings
//{
//    SingleFile = true,
//    ArrayType = ArrayType.IEnumerable,
//    Namespace = "RestEaseClientGeneratorConsoleApp.Examples.PetStoreJson",
//    ApiName = "PetStoreJson",
//    UseDateTimeOffset = true,
//    MethodReturnType = MethodReturnType.Type,
//    MultipartFormDataFileType = MultipartFormDataFileType.Stream,
//    ApiNamespace = "Test123",
//    ModelsNamespace = "Models"
//};

g2.Map("Examples\\pitane.json");