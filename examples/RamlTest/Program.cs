using System;
using System.IO;

namespace RamlTest
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var doc = new Converter().Map(File.OpenRead("helloworld.raml"));

            int y = 0;
        }
    }
}