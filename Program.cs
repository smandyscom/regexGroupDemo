using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace regexDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            String __input = 
            "Model:M1 Coordinates: X1.62 Y1.01 X9.53 Y2.3 X4.94 Y2.1 X8.55 Y3.15 X2.56 Y1.25 X5.57 Y2.72 ";

            String __pattern = "Model:[\\w]+[\\s]+Coordinates:[\\s]+(?<coord>X(?<X>[-+]?[0-9]*\\.?[0-9]+)[\\s]*Y(?<Y>[-+]?[0-9]*\\.?[0-9]+)[\\s]*)+";
            List<float[]> __coords = new List<float[]>();

            Match __match = Regex.Match(__input,
            __pattern);

            //now we get the "coord" group
            for (int i = 0; i < __match.Groups["coord"].Captures.Count; i++)
            {
                // use X,Y group restore each coordinates
                float[] eachCoord = new float[]{0,0}; 
               eachCoord[0] = float.Parse(__match.Groups["X"].Captures[i].Value);
               eachCoord[1] = float.Parse(__match.Groups["Y"].Captures[i].Value);
               __coords.Add(eachCoord);
            }
            //check all coordinates
            foreach (float[] item in __coords)
            {
                Console.WriteLine(String.Format("{0},{1}",
                item[0],
                item[1]));
            }
        }
    }
}
