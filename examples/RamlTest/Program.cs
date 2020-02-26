using System;
using System.IO;
using RamlToOpenApiConverter;

namespace RamlTest
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var doc = new RamlConverter().ConvertToOpenApiDocument("MediaWiki.raml");

            int y = 0;
        }
    }
}