using System;
using System.Text.RegularExpressions;

namespace regexDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            String __input = "Model:M1 Coordinates: X9.2 Y5.2 X5.1 Y4.3 ";
            String __pattern = "Model:[\\w]+[\\s]+Coordinates:[\\s]+(?<coord>X(?<X>[-+]?[0-9]*\\.?[0-9]+)[\\s]*Y(?<Y>[-+]?[0-9]*\\.?[0-9]+)[\\s]*)+";

            Match __match = Regex.Match(__input,
            __pattern);

            //now we get the "coord" group
            foreach (Capture item in __match.Groups["coord"].Captures)
            {
                Console.WriteLine(item.Value);
            }
            
            Console.WriteLine("Hello World!");
        }
    }
}
