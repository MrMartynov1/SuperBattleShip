using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperBattleship
{
    class Program
    {
        private static char[] Board2 = new char[150];
        private static char[] Board1 = new char[150];
        private static char[] Hit1 = new char[150];
        private static char[] Hit2 = new char[150];
        
        static void Main(string[] args)
        {
            initializeVariables();
            introduction();
            askData();
            while (HasNtWon == true || AIHasNtWon == true)
            {
                sinkShips(1);
                drawBoard("H2");

                //drawBoard("P2"); //ONLY FOR DEBUGGING
                Console.Clear();
                sinkShips(2);
                drawBoard("P1");
                Console.Clear();
                if (!Board2.Contains('D'))
                {
                    HasNtWon = false;
                }
                else if (!Board1.Contains('D') && !Board1.Contains('S') && !Board1.Contains('C') && !Board1.Contains('B') && !Board1.Contains('A'))
                {
                    AIHasNtWon = false;
                }
            }
            drawBoard("P2");
            if (HasNtWon == false) { goodbye(); }
            if (AIHasNtWon == false) { Gameover(); }

        }
        
        private static readonly Random getrandom = new Random(Guid.NewGuid().GetHashCode());
        public static int GetRandomNumber(int min, int max)
        {
            lock (getrandom)
            {
                return getrandom.Next(1, 10);
            }
        }


        static Boolean HasNtWon = true;
        static Boolean AIHasNtWon = true;

        static void initializeVariables()
        {
            for (int i = 0; i < 100; i++)
            {
                Board2[i] = '#';
                Board1[i] = '#';
                Hit1[i] = '#';
                Hit2[i] = '#';
            }
        }
        
        static void introduction()
        {
            Console.Title = "SuperBattleship";

            Console.WriteLine("");
            Console.WriteLine("                            ]");
            Console.WriteLine("                   ``      ./. ");
            Console.WriteLine("                    `.`/ +` -++==");
            Console.WriteLine("  ``       ---:::`..+/-/=/:/++.-.]] :::---");
            Console.WriteLine(" [-::/==----=/==/--++/++++Z+/---/==/===:::---..........-/`");
            Console.WriteLine("  [====================================================/");
            Console.WriteLine(" ===-----------------------------------------------====---- ");
            Console.WriteLine("");


            Console.WriteLine("Welcome to SuperBattleship.\n\nPress any key to continue.");
            Console.ReadLine();
        }
        
        static void goodbye()
        {
            Console.Clear();
            Console.WriteLine("Thanks for playing");
            Console.WriteLine("Winner is: Player 1");
            Console.WriteLine("");
            Console.WriteLine("\nThanks for playing");
            Console.ReadKey();
        }
        
        static void Gameover()
        {
            Console.Clear();
            Console.WriteLine("Thanks for playing");
            Console.WriteLine("Winner is: The AI");
            Console.WriteLine("");
            Console.WriteLine("\nThanks for playing");
            Console.ReadKey();
        }

        static void sinkShips(int playerTurn)
        {

            if (playerTurn == 1)
            {
                int x/*= Convert.ToInt32(Console.ReadLine())*/;
                Console.Write("Select a cell to shell \nX: ");
                string inputx = Console.ReadLine();
                Int32.TryParse(inputx, out x);
                /*try
                {
                    x = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("That's not a location!");
                }*/

                //
                if (x > 10 | x < 1)
                {
                    Console.WriteLine("That's not a location!");
                }
                else
                {
                    //x = Convert.ToInt32(Console.ReadLine());

                }
                //

                int y/* = Convert.ToInt32(Console.ReadLine())*/;
                Console.Write("Y: ");
                string inputy = Console.ReadLine();
                Int32.TryParse(inputy, out y);
                //try
                //{
                //    Console.Write("Y: ");
                //    y = Convert.ToInt32(Console.ReadLine());
                //}
                //catch
                //{
                //    Console.WriteLine("That's not a location!");
                //}
                if (y > 10 | y < 1)
                {
                    Console.WriteLine("That's not a location!");
                }
                else
                {
                    //y = Convert.ToInt32(Console.ReadLine());
                }

                try
                {
                    //if ((x > 10 | x < 1) && (y > 10 | y < 1))
                    //{
                        HitNotify();
                        HitShip(x, y, 1, 'X');
                    //}
                    //if ("DX".Contains(Board2[(x + y) * 1])) // (x + y) * 1(?)
                    //{
                    //    HitNotify();
                    //    HitShip(x, y, 1, 'X');
                    //}
                    //else
                    //{
                    //    Console.WriteLine("ERROR");
                    //    HitShip(x, y, 1, 'O');
                    //}
                }
                catch
                {
                    sinkShips(playerTurn);
                }
            }

            else
            {
                int x = getrandom.Next(1, 10);
                int y = getrandom.Next(1, 10);

                try
                {
                    //if ((x > 10 | x < 1) && (y > 10 | y < 1))
                    //{
                        HitNotify();
                        HitShip(x, y, 2, 'X');
                    //}
                }
                catch
                {
                    sinkShips(playerTurn);
                }
                //if ("dDcCbBsSaAxX".Contains(Board1[x + y * 1]))
                //{
                //    HitShip(x, y, 2, 'X');
                //    HitNotify();
                //}
                //else
                //{
                //    HitShip(x, y, 2, 'O');
                //    Console.WriteLine("ERROR");
                //}

            }

        }
        
        static void placeShip(int x, int y, int length, int direction, int board, char shipType)
        {
            int DirectionX = 0;
            int DirectionY = 0;

            switch (direction)
            {
                case 1:
                    DirectionX = 1;
                    break;
                case 2:
                    DirectionY = 1;
                    break;
            }

            for (int i = 0; i < length; i++)
            {
                if (board == 1)
                {
                    Board1[(y + i * DirectionY) * 10 + x + i * DirectionX] = shipType;
                }
                else
                {
                    Board2[(y + i * DirectionY) * 10 + x + i * DirectionX] = shipType;
                }
            }
        }
        
        static void HitShip(int x, int y, int board, char Option)
        {

            if (board == 1)
            {
                try
                {
                    Hit2[(y - 1) * 10 + x - 1] = Option;
                    Board2[(y - 1) * 10 + x - 1] = Option;
                }
                catch
                {
                    Console.WriteLine("That's not a location!");
                    //sinkShips(1);
                }
            }
            else
            {
                try
                {
                    Hit1[(y - 1) * 10 + x - 1] = Option;
                    Board1[(y - 1) * 10 + x - 1] = Option;
                }
                catch
                {
                    Console.WriteLine("That's not a location!");
                    //sinkShips(2);
                }
            }
        }
        
        static bool overBoardCheck(int x, int y, int direction, int length)
        {
            if (x > 10 || (x + length > 10 && direction == 1))
            {
                Console.WriteLine("Man overboard! Try again, you utter noob!");
                Console.ReadKey();
            }
            else if (y > 10 || (y + length > 10 && direction == 2))
            {
                Console.WriteLine("Man overboard! Try again, you utter noob!");
                Console.ReadKey();
            }
            else if (direction > 2 || direction < 1)
            {
                Console.WriteLine("Wrong direction.... Are you even trying...");
                Console.ReadKey();
            }
            else
            {
                return true;
            }
            return false;
        }
        
        static void HitNotify()
        {
            Console.Write("The shells have landed!");
        }
        
        static void askData()
        {
            inputShipLocationP1();
            inputShipLocationP2();
            Console.Clear();
        }
        
        static void inputShipLocationP1()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.Clear();
                Console.WriteLine("Player 1's turn. Press any key.");
                Console.ReadLine();
                Console.Clear();
                drawBoard("P1");
                bool[] selected = new bool[] { false, false, false, false, false, false };
                int shipLength = 0;
                char shipName = ' ';
                int shipType = 0;
                int x = 0;
                int y = 0;
                int direction = 0;


                Console.WriteLine("Select ship 1, 2, 3, 4 or 5: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        shipType = 1;
                        break;
                    case "2":
                        shipType = 2;
                        break;
                    case "3":
                        shipType = 3;
                        break;
                    case "4":
                        shipType = 4;
                        break;
                    case "5":
                        shipType = 5;
                        break;
                    default:
                        Console.WriteLine("That's not a ship!");
                        //inputShipLocationP1();
                        break;
                }


                Console.Write("Select ship location \nX: ");
                try
                {
                    x = Convert.ToInt32(Console.ReadLine()) - 1;
                }
                catch
                {
                    Console.WriteLine("That's not a location!");
                    //inputShipLocationP1();
                }


                Console.Write("Y: ");
                try
                {
                    y = Convert.ToInt32(Console.ReadLine()) - 1;
                }
                catch
                {
                    Console.WriteLine("That's not a location!");
                    //inputShipLocationP1();
                }


                Console.Write("Direction: 1 [Horizontal], 2 [Vertical]: ");
                try
                {
                    direction = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("That's not an option!");
                    //inputShipLocationP1();
                }

                switch (shipType)
                {
                    case 1:
                        if (overBoardCheck(x, y, direction, shipType) && !selected[shipType])
                        {
                            shipLength = shipType;
                            shipName = 'D';
                            selected[shipType] = true;
                            i++;
                        }
                        else if (selected[shipType])
                        {
                            Console.WriteLine("Ship is already selected");
                        }
                        break;
                    case 2:
                        if (overBoardCheck(x, y, direction, shipType) && !selected[shipType])
                        {
                            shipLength = shipType;
                            shipName = 'S';
                            selected[shipType] = true;
                            i++;
                        }
                        else if (selected[shipType])
                        {
                            Console.WriteLine("Ship is already selected");
                        }
                        break;
                    case 3:
                        if (overBoardCheck(x, y, direction, shipType) && !selected[shipType])
                        {
                            shipLength = shipType;
                            shipName = 'C';
                            selected[shipType] = true;
                            i++;
                        }
                        else if (selected[shipType])
                        {
                            Console.WriteLine("Ship is already selected");
                        }
                        break;
                    case 4:
                        if (overBoardCheck(x, y, direction, shipType) && !selected[shipType])
                        {
                            shipLength = shipType;
                            shipName = 'B';
                            selected[shipType] = true;
                            i++;
                        }
                        else if (selected[shipType])
                        {
                            Console.WriteLine("Ship is already selected");
                        }
                        break;
                    case 5:
                        if (overBoardCheck(x, y, direction, shipType) && !selected[shipType])
                        {
                            shipLength = shipType;
                            shipName = 'A';
                            selected[shipType] = true;
                            i++;
                        }
                        else if (selected[shipType])
                        {
                            Console.WriteLine("Ship is already selected");
                        }
                        break;
                    default:
                        Console.WriteLine("That's not a ship!");
                        Console.ReadKey();
                        break;
                }

                placeShip(x, y, shipLength, direction, 1, shipName);

                
                Console.Clear();
                Console.WriteLine("Ship placed");
                drawBoard("P1");
            }
        }
        
        static void inputShipLocationP2()
        {
            int rngx;
            int rngy;
            int rngdirection;

            Random rng = new Random();
            for (int j = 1; j <= 5; j++)
            {
                rngx = rng.Next(0, 10);
                rngy = rng.Next(0, 10);

                
                rngdirection = rng.Next(1, 2);
                Console.Clear();
                Console.WriteLine("Ships placed");
                if (overBoardCheck(rngx, rngy, rngdirection, j))
                {
                    placeShip(rngx, rngy, j, rngdirection, 2, 'D');
                }
                else
                {
                    j--; 
                }
            }
            //drawBoard("P2"); //ONLY FOR DEBUGGING
            
        }
        
        static void drawBoard(String selection)
        {
            for (int y = 10; y >= 0; y--)
            {
                for (int x = 0; x < 10; x++)
                {
                    switch (selection)
                    {
                        case "P1":
                            Console.Write(Board1[y * 10 + x]);
                            break;
                        case "P2":
                            Console.Write(Board2[y * 10 + x]);
                            break;
                      case "H1":
                            Console.Write(Hit1[y*10 + x]);
                            break;
                      case "H2":
                            Console.Write(Hit2[y*10 + x]);
                            break;
                    }
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }

    }
}