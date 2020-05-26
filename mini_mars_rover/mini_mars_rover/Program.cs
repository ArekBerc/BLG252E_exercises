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
                intArray[i] = int.Parse(marsArea[i]); 
            }

            return intArray;
        }
        static public string[] getPosition(int[] area)
        {
            var pos = Console.ReadLine().Split(' ');

            if (int.TryParse(pos[0], out _) && int.TryParse(pos[1], out _) && (pos[2] == "N" || pos[2] == "W" || pos[2] == "S" || pos[2] == "E") && (Int32.Parse(pos[1]) < (area[1])) && (Int32.Parse(pos[0]) < (area[0]))&& (Int32.Parse(pos[0]) >= 0)&& (Int32.Parse(pos[1]) >= 0))
            {
                return pos;
            }
            else if (pos[0] == "q" && pos.Length==1)
            {
                return pos;
            }
            else
            {
                Console.WriteLine("Invalid input");
                return null;

            }


        }
        
        static public string[] getPattern()
        {
            string[] test = Regex.Split(Console.ReadLine(), string.Empty);
            if (test[1] == "q" && test.Length==3)
            {
                return test;
            }
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
        static void reportAll(List<rover> rovers) 
        {
            Console.WriteLine("\n\n\nPosition report of the all rovers in the area:");
            for (int i = 0; i < rovers.Count; i++)
            {
                Console.WriteLine($"Rover {i + 1} Position: ({rovers[i].poss[0]}, {rovers[i].poss[1]})\n\tOrientation: {rovers[i].Orientation.current.data}");
            }
        }

        static void Main(string[] args)
        { 
            int i = 0;
            List<rover> rovers = new List<rover>();
            int[] marsArea = getArea();
            while (true) {
                try
                {
                    string[] position = getPosition(marsArea);
                    if (position[0] == "q")
                    {
                        break;
                    }
                    if(i > 0)// if there is more than one rover 
                    {
                        for (int j = 0; j < i; j++)
                        {
                            if (Int32.Parse(position[0]) == rovers[j].poss[0] && Int32.Parse(position[1]) == rovers[j].poss[1])// cannot land on the other one
                            {
                                Console.WriteLine($"Rover is trying to land on another rover at ({rovers[j].poss[0]},{rovers[j].poss[1]})");
                                throw new Exception();
                                
                            }
                        }
                    }
                    rovers.Add(new rover(Int32.Parse(position[0]), Int32.Parse(position[1]), position[2], marsArea));
                    while (true)
                    {
                        try
                        {
                            string[] patt = getPattern();
                            if (patt[0] == "q")
                            {
                                return;
                            }

                            rovers[i].takeAction(patt, rovers);
                        }
                        catch
                        {

                            continue;
                        }
                        break;
                    }

                    rovers[i].report();
                    i++;




                }
                catch
                {
                    continue;
         
                }




            }


            reportAll(rovers);



        }
    }
}
