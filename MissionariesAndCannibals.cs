using System;

namespace MissionariesAndCannibals
{
    class Program
    {
        static int missionariesLeft = 3;
        static int cannibalsLeft = 3;
        static int missionariesRight = 0;
        static int cannibalsRight = 0;
        static bool isBoatOnLeft = true;

        static void Main(string[] args)
        {
            Console.WriteLine("Missionaries and Cannibals problem");
            Console.WriteLine("Start with 3 Missionaries and 3 Cannibals on left bank");
            Console.WriteLine("Boat capacity: 2");
            Console.WriteLine("Enter the number of Missionaries and Cannibals to move (e.g. 2 0 means 2 Missionaries and 0 Cannibals)");
            Console.WriteLine("Enter 'q' to quit");

            while (missionariesLeft + missionariesRight > 0 || cannibalsLeft + cannibalsRight > 0)
            {
                Console.WriteLine("\nLeft bank: {0} Missionaries, {1} Cannibals", missionariesLeft, cannibalsLeft);
                Console.WriteLine("Right bank: {0} Missionaries, {1} Cannibals", missionariesRight, cannibalsRight);
                Console.WriteLine("Boat on {0} bank", isBoatOnLeft ? "left" : "right");

                Console.Write("Move: ");
                string input = Console.ReadLine();
                if (input == "q")
                {
                    break;
                }

                //check if the input is valid
                string[] move = input.Split(' ');
                int numMissionaries = int.Parse(move[0]);
                int numCannibals = int.Parse(move[1]);
                if (numMissionaries < 0 || numMissionaries > 2 || numCannibals < 0 || numCannibals > 2 || numMissionaries + numCannibals > 2)
                {
                    Console.WriteLine("Invalid move");
                    continue;
                }

                //check if the input number is enough to be in the boat
                if (isBoatOnLeft)
                {
                    if (missionariesLeft < numMissionaries || cannibalsLeft < numCannibals)
                    {
                        Console.WriteLine("Not enough people on left bank");
                        continue;
                    }

                    missionariesLeft -= numMissionaries;
                    cannibalsLeft -= numCannibals;
                    missionariesRight += numMissionaries;
                    cannibalsRight += numCannibals;
                }

                else
                {
                    if (missionariesRight < numMissionaries || cannibalsRight < numCannibals)
                    {
                        Console.WriteLine("Not enough people on right bank");
                        continue;
                    }

                    missionariesRight -= numMissionaries;
                    cannibalsRight -= numCannibals;
                    missionariesLeft += numMissionaries;
                    cannibalsLeft += numCannibals;
                }

                //true on the left false in the right
                isBoatOnLeft = !isBoatOnLeft;

                
                if ((missionariesLeft < cannibalsLeft && missionariesLeft > 0) || (missionariesRight < cannibalsRight && missionariesRight > 0))
                {
                    Console.WriteLine("Cannibals ate the missionaries");
                    break;
                }
            }

        }
    }
}