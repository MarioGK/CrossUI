using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CrossUI.Utilities.NativeFunctionGen
{
    class Program
    {
        private static Regex regex = new Regex(@"(?<=[^int][^\w])\w+|[A-Za-z][A-Za-z][A-Za-z][A-Za-z]\w\w\w\w\w+");
        static void Main(string[] args)
        {
            var text = TextCopy.Clipboard.GetText();

            var matches = regex.Matches(text).ToList();

            var functionNameMath = matches.First();
            matches.Remove(functionNameMath);
            var functionName = functionNameMath.Value;
            
            var arguments = new StringBuilder();
            var parameters = new StringBuilder();

            for (var i = 0; i < matches.Count; i++)
            {
                var match = matches[i];
                arguments.Append(match.Value);
                //Odd
                if (i % 2 != 0)
                {
                    parameters.Append(match.Value);
                    
                    if (i != matches.Count - 1)
                    {
                        parameters.Append(", ");
                        arguments.Append(",");
                    }
                }
                else
                {
                    //If it is not the last match
                    if (i != matches.Count - 1)
                    {
                        arguments.Append(" ");
                    }
                }
                

            }
            
            var sb = new StringBuilder();
            sb.AppendLine("[UnmanagedFunctionPointer(CallingConvention.Cdecl)]");
            sb.AppendLine($"private delegate void SDL_{functionName}_t({arguments});");
            sb.AppendLine($"private static SDL_{functionName}_t s_{functionName.ToLower()} = LoadFunction<SDL_{functionName}_t>(\"SDL_{functionName}\");");
            sb.AppendLine($"public static void SDL_{functionName}({arguments}) => s_{functionName.ToLower()}({parameters});");

            Console.WriteLine(sb);
        }
    }
}