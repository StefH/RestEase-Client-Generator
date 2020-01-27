using System;
using Microsoft.ClearScript;
using Microsoft.ClearScript.JavaScript;
using Microsoft.ClearScript.V8;

namespace MicrosoftClearScriptTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var engine = new V8ScriptEngine())
            {

                // expose a host type

                engine.AddHostType("Console", typeof(Console));

              
                // examine a script object

                engine.Execute("person = { name: 'Fred', age: 5 }");

                Console.WriteLine(engine.Script.person.name);

                // read a JavaScript typed array

                //engine.Execute("values = new Int32Array([1, 2, 3, 4, 5])");

                engine.Execute("x = 8");

                var x = (int) engine.Script.x;

                Console.WriteLine(x);

            }
        }
    }
}
