using System.Collections.Generic;
using System.IO;

namespace RestEaseClientGenerator.Models
{
    internal class RestEaseMultipartFormDataMethod
    {
        public Stream Stream { get; set; }

        public RestEaseInterfaceMethodDetails MethodDetails { get; set; }
    }
}