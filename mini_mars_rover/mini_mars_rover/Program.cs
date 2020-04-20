using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace mini_mars_rover
{
    class Program
    {
        static public int[] getArea() 
        {
            var marsArea = Console.ReadLine().Split(' ');
            var intArray = new int[2];
            for (var i = 0; i < 2; i++)
            {
                intArray[i] = int.Parse(marsArea[i]); // line 17
            }

            return intArray;
        }
        static public string[] getPosition()
        {
            var pos = Console.ReadLine().Split(' ');
            try
            {
                if (int.TryParse(pos[0], out _) && int.TryParse(pos[1], out _) && (pos[2] == "N" || pos[2] == "W" || pos[2] == "S" || pos[2] == "E"))
                {
                    return pos;
                }
                else
                {
                    Console.WriteLine("Invalid input");
                    return null;
                }
            }
            catch
            {
                Console.WriteLine("Invalid input");

                throw new Exception();
            }
        }

        static public string[] getPattern()
        {
            string[] test = Regex.Split(Console.ReadLine(), string.Empty);
            for (int i=1; i < test.Length-1; i++)
            {
                if (test[i] != "M" && test[i] != "R" && test[i] != "L")
                {
                    Console.WriteLine("Invalid input");
                    return null;
                }
            }
            return test;

        }
 

        static void Main(string[] args)
        { 
            int i = 0;
            List<rover> rovers = new List<rover>();
            int[] marsArea = getArea();
            while (true) {
                try
                {
                    string[] position = getPosition();
                    if(i > 0)// if there is more than one rover 
                    {
                        for (int j = 0; j < i; j++)
                        {
                            if (Int32.Parse(position[0]) == rovers[j].poss[0] && Int32.Parse(position[1]) == rovers[j].poss[1])// cannot land on the other one
                            {
                                throw new Exception();
                            }
                        }
                    }
                    rovers.Add(new rover(Int32.Parse(position[0]), Int32.Parse(position[1]), position[2], marsArea));
                    string[] patt = getPattern();

                    rovers[i].takeAction(patt);
                    rovers[i].report();
                    i++;


                }
                catch
                {
                    Console.WriteLine("Invalid data entered "); 
         
                }




            }






        }
    }
}
