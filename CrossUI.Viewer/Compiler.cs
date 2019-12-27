using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Threading.Tasks;
using CliWrap;
using CrossUI.Objects;
using SFML.Graphics;

namespace CrossUI.Viewer
{
    public static class Compiler
    {
        public static Assembly CurrentCompiledAssembly;
        public static string ProjectPath;
        public static AssemblyLoadContext LoadContext;

        private static CrossWindow crossWindow;

        public static void Build()
        {
            try
            {
                LoadContext = new AssemblyLoadContext("Compiler Context", true);

                var stahp = Stopwatch.StartNew();
                var result = Cli.Wrap("cmd.exe").EnableExitCodeValidation(false)
                    .SetArguments($"/C cd {ProjectPath} & dotnet build  --no-restore --no-dependencies").Execute();
                
                Console.WriteLine(result.StandardOutput);

                var path = @"F:\Projects\CrossUI\CrossUI.TestSample\bin\Debug\netcoreapp3.1\CrossUI.TestSample.dll";

                var fileStream = File.Open(path, FileMode.Open, FileAccess.Read);
                CurrentCompiledAssembly = LoadContext.LoadFromStream(fileStream);
                fileStream.Close();
                fileStream.Dispose();

                var program = CurrentCompiledAssembly.GetTypes().FirstOrDefault(x => x.Name == "Program");
                
                Program.Window.DeleteAllChildren();
                
                var configure = program.GetMethod("Configure");
                configure.Invoke(null, new object?[]{Program.Window} );
                
                Console.WriteLine($"Finished Compiling in {stahp.ElapsedMilliseconds}MS");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void DisableDraw()
        {
            LoadContext.Unload();
            CurrentCompiledAssembly = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        
    }
}