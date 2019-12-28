using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using CliWrap;

namespace CrossUI.Viewer
{
    public class Compiler
    {
        public Compiler(string projectPath)
        {
            this.projectPath = projectPath;
            buildCommand = Cli.Wrap("cmd.exe").EnableExitCodeValidation(false)
                .SetArguments($"/C cd {this.projectPath} & dotnet build  --no-restore --no-dependencies");
        }

        private Assembly currentCompiledAssembly;
        private readonly string projectPath;
        private AssemblyLoadContext loadContext;

        private readonly ICli buildCommand;

        public void Build()
        {
            try
            {
                var stopwatch = Stopwatch.StartNew();

                loadContext = new AssemblyLoadContext("Compiler Context", true);
                
                var result = buildCommand.Execute();
                
                Console.WriteLine(result.StandardOutput);

                var path = @"F:\Projects\CrossUI\CrossUI.TestSample\bin\Debug\netcoreapp3.1\CrossUI.TestSample.dll";

                var fileStream = File.Open(path, FileMode.Open, FileAccess.Read);
                currentCompiledAssembly = loadContext.LoadFromStream(fileStream);
                fileStream.Close();
                fileStream.Dispose();

                var program = currentCompiledAssembly.GetTypes().FirstOrDefault(x => x.Name == "Program");
                
                Program.Window.DeleteAllChildren();

                if (program != null)
                {
                    var configure = program.GetMethod("Configure");
                    if (configure != null) configure.Invoke(null, new object?[] {Program.Window});
                }
                
                Program.Window.ForceUpdate();

                Console.WriteLine($"Finished Compiling in {stopwatch.ElapsedMilliseconds}MS");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void DisableDraw()
        {
            loadContext.Unload();
            currentCompiledAssembly = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        
    }
}