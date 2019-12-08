using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperBattleship
{
    /*
    Implement this:

    British Empire
DD - HMS Pathfinder
SS - HMS Alliance
CA - HMS Edinburgh
BB - HMS Hood
CV - HMS Victorious

USA
DD - USS Allen M. Sumner
SS - USS Grenadier
CA - USS St. Louis
BB - USS Iowa
CV - USS Intrepid

China
DD - Fuzhou
SS - Type 03
CA - Chung King
BB - Mao Zedong
CV - Liaoning

Russia
DD - Minsk
SS - Kursk
CA - Kirov
BB - Sevastopol
CV - Admiral Kuznetsov

Italy
DD - Alfredo Oriani
SS - Acciaio
CA - Zara
BB - Vittorio Veneto
CV - Aquila

Japan
DD - Kagerō
SS - I-16
CA - Suzuya
BB - IJN Yamato
CV - IJN Hiryū

France
DD - Le Fantasque
SS - Surcouf
CA - Foch
BB - Richelieu
CV - Clemenceau

Germany
DD - Lütjens
SS - U-11
CA - Admiral Hipper
BB - Bismarck
CV - Graf Zeppelin

Finland
DD - Hamina
SS - Vetehinen
CA - Ilmarinen
BB - Finlandia
CV - Fennoskandia
    
    */
    class Program
    {
        static string[] board1 = new string[100];
        static string[] board2 = new string[100];

        static string[] hit1 = new string[100];
        static string[] hit2 = new string[100];

        static int hitcounter1 = 0;
        static int hitcounter2 = 0;

        static Boolean HasWon = false;

        static void initializeVariables()
        {
            for (int i = 0; i < 100; i++)
            {
                board1[i] = " ";
                board2[i] = " ";
                hit1[i] = " ";
                hit2[i] = " ";
            }
        }
        static void Main(string[] args)
        {
            initializeVariables();
            introduction();
            askData();
            goodbye();
            
        }

        static void goodbye()
        {
            Console.Clear();
            Console.WriteLine("Thanks for playing");
            Console.WriteLine("Winner is: ");
            if (hitcounter1 == 26)
                Console.WriteLine("Player 1");
            else
                Console.WriteLine("Player 2");
            Console.WriteLine("\nThanks for playing");
            Console.ReadKey();

        }

        static void inputShipLocation()
        {
            //N
            //W S(E)
            //S

            Console.Clear();
            Console.WriteLine("Player 1's turn. Player 2 inactive. Press any key.");
            Console.ReadLine();
            Console.Clear();
            /*if (selection.equals("N"))
            board2[i] && board2[i +- 10]*/
            Console.WriteLine("Please select the location of a DESTROYER based on the box #");
            drawBoard("P1");
            int selection = Convert.ToInt32(Console.ReadLine());
            //09 -> 10
            //19 -> 20 ERROR!
            //29 -> 30 ERROR!

            //0 | 1 | 2 | 3
            //  S| S | S | S |
            board2[selection] = "S";
            board2[selection + 1] = "S";

            //---------------------------------------

            Console.WriteLine("Please select the location of a SUBMARINE based on the box #");
            drawBoard("P1");
            selection = Convert.ToInt32(Console.ReadLine());
            
            board2[selection] = "S";
            board2[selection + 1] = "S";
            board2[selection + 2] = "S";

            //---------------------------------------

            Console.WriteLine("Please select the location of a CRUISER based on the box #");
            drawBoard("P1");
            selection = Convert.ToInt32(Console.ReadLine());
            
            board2[selection] = "S";
            board2[selection + 1] = "S";
            board2[selection + 2] = "S";
            board2[selection + 3] = "S";

            //---------------------------------------

            Console.WriteLine("Please select the location of a BATTLESHIP based on the box #");
            drawBoard("P1");
            selection = Convert.ToInt32(Console.ReadLine());
            
            board2[selection] = "S";
            board2[selection + 1] = "S";
            board2[selection + 2] = "S";
            board2[selection + 3] = "S";
            board2[selection + 4] = "S";

            //---------------------------------------

            Console.WriteLine("Please select the location of a AIRCRAFT CARRIER based on the box #");
            drawBoard("P1");
            selection = Convert.ToInt32(Console.ReadLine());
            
            board2[selection] = "S";
            board2[selection + 1] = "S";
            board2[selection + 2] = "S";
            board2[selection + 3] = "S";
            board2[selection + 4] = "S";
            board2[selection + 5] = "S";

            //---------------------------
            //---

            Console.Clear();
            Console.WriteLine("Player 1's turn. Player 2 inactive. Press any key.");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Please select the location of a DESTROYER based on the box #");
            drawBoard("P1");
            selection = Convert.ToInt32(Console.ReadLine());
            
            board2[selection] = "S";

            //---------------------------------------

            Console.WriteLine("Please select the location of a SUBMARINE based on the box #");
            drawBoard("P1");
            selection = Convert.ToInt32(Console.ReadLine());
            
            board2[selection] = "S";
            board2[selection + 1] = "S";

            //---------------------------------------

            Console.WriteLine("Please select the location of a CRUISER based on the box #");
            drawBoard("P1");
            selection = Convert.ToInt32(Console.ReadLine());
            
            board2[selection] = "S";
            board2[selection + 1] = "S";
            board2[selection + 2] = "S";

            //---------------------------------------

            Console.WriteLine("Please select the location of a BATTLESHIP based on the box #");
            drawBoard("P1");
            selection = Convert.ToInt32(Console.ReadLine());
            
            board2[selection] = "S";
            board2[selection + 1] = "S";
            board2[selection + 2] = "S";
            board2[selection + 3] = "S";

            //---------------------------------------

            Console.WriteLine("Please select the location of a AIRCRAFT CARRIER based on the box #");
            drawBoard("P1");
            selection = Convert.ToInt32(Console.ReadLine());
            
            board2[selection] = "S";
            board2[selection + 1] = "S";
            board2[selection + 2] = "S";
            board2[selection + 3] = "S";
            board2[selection + 4] = "S";
            board2[selection + 5] = "S";

            //---------------------------
            //---
        }

        static void HitNotify()
        {
            Console.Clear();
            Console.WriteLine("Player 1's turn. Select a cell to shell.");
            drawBoard("hit1");
            int selection = Convert.ToInt32(Console.ReadLine());
            if (board1[selection] != "")
            {
                Console.WriteLine("HIT!");
                hit1[selection] = "H";
                hitcounter1++;
                if (hitcounter1 == 21)
                    HasWon = true;
            }
            else
            {
                Console.WriteLine("MISS!");
                hit1[selection] = "M";
            }

            Console.WriteLine("\nPress any key to continue.");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Player 2's turn. Select a cell to shell.");
            drawBoard("hit2");
            selection = Convert.ToInt32(Console.ReadLine());
            if (board2[selection] != "")
            {
                Console.WriteLine("HIT!");
                hit2[selection] = "H";
                hitcounter2++;
                if (hitcounter2 == 21)
                    HasWon = true;
            }
            else
            {
                Console.WriteLine("MISS!");
                hit2[selection] = "M";
            }
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadLine();


        }

        static void askData()
        {
            inputShipLocation();
            while (HasWon)
            {
                HitNotify();

            }
            
        }

        static void drawBoard(String selection)
        {
            if (selection.Equals("P1"))
            {
                for (int x = 0; x < 10; x++)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Console.Write(board2[i + x] + "|");
                    }
                    Console.WriteLine();
                }
            }
            else if (selection.Equals("P2"))
            {
                for (int x = 0; x < 10; x++)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Console.Write(board1[i + x] + "|");
                    }
                    Console.WriteLine();
                }
            }
            else if (selection.Equals("hit1"))
            {
                for (int x = 0; x < 10; x++)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Console.Write(hit1[i + x] + "|");
                    }
                    Console.WriteLine();
                }
            }
            else
            {

                for (int x = 0; x < 10; x++)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Console.Write(hit2[i + x] + "|");
                    }
                    Console.WriteLine();
                }

            }

            /*int redo = 0;
            int sides = 20;
            ConsoleKeyInfo A;
            do
            {
                A = Console.ReadKey(true);
                Console.Clear();

                switch (A.Key)
                {
                    case ConsoleKey.RightArrow:
                        sides++;
                        Console.SetCursorPosition(sides, 10);
                        Console.Write("#");
                        break;
                    case ConsoleKey.LeftArrow:
                        sides--;
                        Console.SetCursorPosition(sides, 10);
                        Console.Write("#");
                        break;
                    case ConsoleKey.UpArrow:
                        sides++;
                        Console.SetCursorPosition([10, sides]);
                        Console.Write("#");
                        break;
                    case ConsoleKey.DownArrow:
                        sides--;
                        Console.SetCursorPosition([10, sides]);
                        Console.Write("#");
                        break;
                }


            } while (redo == 0);*/

            Console.ReadLine();

        }

        static void introduction()
        {
            Console.Title = "Battleship";

            Console.WriteLine("Welcome to Battleship.\n\nPress any key to continue.");
            Console.ReadLine();
        }
        
    }
}
