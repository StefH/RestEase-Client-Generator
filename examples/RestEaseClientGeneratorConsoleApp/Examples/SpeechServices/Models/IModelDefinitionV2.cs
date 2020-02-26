using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.SpeechServices.Models
{
    public class IModelDefinitionV2
    {
        public string Text { get; set; }

        public ModelIdentity BaseModel { get; set; }

        public DatasetIdentity[] Datasets { get; set; }

        public ModelKind ModelKind { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public object Properties { get; set; }

        public string Locale { get; set; }
    }
}
