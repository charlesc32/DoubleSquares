using System.IO;
using System.Collections.Generic;
using System;

class Program
{
    static void Main(string[] args)
    {
        int count = 0;
        using (StreamReader reader = File.OpenText(args[0]))
        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine();
            if (null == line || count == 0)
            {
                count++;
                continue;
            }

            uint input = 0;
            if (uint.TryParse(line, out input))
            {
                Console.WriteLine(FindDoubleSquares(input));
            }
        }
    }

    private static int FindDoubleSquares(uint input)
    {
        int numSquares = Convert.ToInt32(Math.Floor(Math.Sqrt(input)));
        int numCombos = 0;
        
        for (int i = 0; i <= numSquares; i++)        
        {
            uint square = Convert.ToUInt32(i*i);
            uint numToTest = (input - square);
            if (square > numToTest) continue;
            if (Math.Sqrt(numToTest) % 1 == 0) numCombos++;
        }

        return numCombos;
    }
}