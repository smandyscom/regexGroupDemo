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

            String __patternUnnamed = "Model:[\\w]+[\\s]+Coordinates:[\\s]+(X([-+]?[0-9]*\\.?[0-9]+)[\\s]*Y([-+]?[0-9]*\\.?[0-9]+)[\\s]*)+";
            String __patternNamed = "Model:[\\w]+[\\s]+Coordinates:[\\s]+(?<coord>X(?<X>[-+]?[0-9]*\\.?[0-9]+)[\\s]*Y(?<Y>[-+]?[0-9]*\\.?[0-9]+)[\\s]*)+";
            List<float[]> __coords = new List<float[]>();

            Match __matchUnnamed = Regex.Match(__input,__patternUnnamed);
            Match __matchNamed = Regex.Match(__input,__patternNamed);

            //-----------------------------------
            //  Unnamed
            //-----------------------------------
            __coords.Clear();
            for (int i = 0; i < __matchUnnamed.Groups[1].Captures.Count;i++)
            {
                // use X,Y group restore each coordinates
                float[] eachCoord = new float[]{0,0}; 
               eachCoord[0] = float.Parse(__matchUnnamed.Groups[2].Captures[i].Value);
               eachCoord[1] = float.Parse(__matchUnnamed.Groups[3].Captures[i].Value);
               __coords.Add(eachCoord);
            }
            //check all coordinates
            Console.WriteLine("Unnamed");
            foreach (float[] item in __coords)
            {
                Console.WriteLine(String.Format("{0},{1}",
                item[0],
                item[1]));
            }
            //-----------------------------------
            //  Named
            //-----------------------------------
            //now we get the "coord" group
            __coords.Clear();
            for (int i = 0; i < __matchNamed.Groups["coord"].Captures.Count; i++)
            {
                // use X,Y group restore each coordinates
                float[] eachCoord = new float[]{0,0}; 
               eachCoord[0] = float.Parse(__matchNamed.Groups["X"].Captures[i].Value);
               eachCoord[1] = float.Parse(__matchNamed.Groups["Y"].Captures[i].Value);
               __coords.Add(eachCoord);
            }
            //check all coordinates
            Console.WriteLine("Named");
            foreach (float[] item in __coords)
            {
                Console.WriteLine(String.Format("{0},{1}",
                item[0],
                item[1]));
            }
        }//main
    }//program
}//namespace
