using CrossUI.Objects;

namespace CrossUI.TestSample
 {
     internal static unsafe class Program
     {
         private static Window window;
         private static void Main(string[] args)
         {
             window = new Window("MainWindow");

             window.Run();
         }
     }
 }