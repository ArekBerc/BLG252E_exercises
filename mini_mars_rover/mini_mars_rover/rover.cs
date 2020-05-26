using System;
using System.Collections.Generic;
using System.Text;

namespace mini_mars_rover
{
    class ways // circular doubly linked list for North East West South 
    {
        public dLinkList Orientation = new dLinkList();

        public ways()
        {
            Orientation.addB("N");
            Orientation.addB("E");
            Orientation.addB("S");
            Orientation.addB("W");

        }

    }
    class rover : ways
    {


        public int[] poss = { 0, 0}; // position of the rover



        public int[] area; // area of the place that rover landed 

        public rover(int x, int y, string orientation,int[] area)
        {

            if (!(area[0] < x || x < 0 || area[1] < y || y < 0))
                {
                Orientation.setCurrent(orientation);
                this.poss[0] = x;
                this.poss[1] = y;
                this.area = area;
            }
            else
            {
                throw new Exception();
            }

            

        }

        public void moveForward(List<rover> rovers)  // moving forward according to the orientation of the rover
        {
            switch (Orientation.current.data)
            {
                case "N":
                    poss[1]++;
                    break;
                case "S":
                    poss[1]--;
                    break;
                case "W":
                    poss[0]--;
                    break;
                case "E":
                    poss[0]++;
                    break;

            }
            for (int j = 0; j < rovers.Count-1; j++)
            {

                if (poss[0] == rovers[j].poss[0] && poss[1] == rovers[j].poss[1])// cannot collide to the other one
                {
                    
                    switch (Orientation.current.data)
                    {
                        case "N":
                            poss[1]--;
                            break;
                        case "S":
                            poss[1]++;
                            break;
                        case "W":
                            poss[0]++;
                            break;
                        case "E":
                            poss[0]--;
                            break;
                    }
                    Console.WriteLine($"Rover is now at ({poss[0]},{poss[1]}) and trying to collide another rover at ({rovers[j].poss[0]},{rovers[j].poss[1]}). Enter another pattern!");
                    throw new Exception();
                }
            }
        }
        public void changeOrientation(string data)  // changing orientation according to the input
        {
            switch (data)
            {
                case "R":
                    Orientation.moveCurr2Next(); // next direction for example if current is north then current will be east
                    break;
                case "L":
                    Orientation.moveCurr2Prev(); // previous direction for example if current is north then current will be WEST
                    break;
                default:
                    Console.WriteLine("Invalid");
                    break;
            }
        }

        public void takeAction(string[] pattern, List<rover> rovers)
        {

           for (int i = 1; i < pattern.Length - 1; i++)
           {
                
                


                if (pattern[i] == "M")
                {
                    // if rover is not exceeding the landed area
                    if ((!(Orientation.current.data == "N" && poss[1] >= (area[1]-1))) && (!(Orientation.current.data == "S" && poss[1] <= 0)) && (!(Orientation.current.data == "E" && poss[0] >= (area[0])-1)) && (!(Orientation.current.data == "W" && poss[0] <= 0)))
                    {

                        moveForward(rovers);
                    }

                    else
                    {

                        Console.WriteLine($"Rover is now at ({poss[0]},{poss[1]}) and trying to exceed the area. Enter another movement pattern!");
                        throw new Exception();
                    }
                    
                }
                // changing the orientation
                else if (pattern[i] == "L" || pattern[i] == "R")
                {
                    changeOrientation(pattern[i]);
                }


               
            }
        }
        public void report() // sending the current position and orientation data
        {
            Console.WriteLine($"Movement report: Now rover is at {poss[0]} {poss[1]} {Orientation.current.data}");
        }
    }
}

