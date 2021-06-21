using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Treasure_Hunt
{
    class Program
    {
        static void Main(string[] args)
        {
            ///////////////////CREATING MENU ////////////////////   
            int q;
            menu:
            Console.Clear();
            Console.WriteLine("1) Play 1D Game");
            Console.WriteLine("2) Play 2D Game");
            Console.WriteLine("3) Rules");
            q = Convert.ToInt16(Console.ReadLine());
            if (q == 3)


            //// DESCRIPTION OF RULE
            {
                Console.Clear();
                Console.WriteLine(" * Initially players have one life each. If a player loses all hhis lifes , other player wins");
                Console.WriteLine(" * In 1D board, the moves by throwing dice are always to the right.In 2D board, the moves by throwing dice are to the right or down randomly");
                Console.WriteLine(" * If the player comes to a reward/penalty square, and this reward/penalty sends the player to another reward/penalty, all the subsequent reward/penalties are applied(max. 20 rewards/penalties)");
                Console.WriteLine(" * In the case of exceeding the board limits, the player cannot move and stays in his/her place, other player's turn begins");
                Console.WriteLine(" * If the players meet on the same square, the newcomer sends the other player to the starting point");
                Console.WriteLine(" * Press enter to back menu");
                Console.ReadLine();
                goto menu;
            }
            if (q == 1)
            {



                //////////////////////START///////////////////////
                Console.Clear();
                
                int pdice = 0, cdice = 0, place = 0, plife = 1, clife = 1, T = 0, Pdice = 0, Cdice = 0, round = 0, wait = 0, wait2 = 0;
                // ALL RANDOM INTEGERS
                Random rnd3 = new Random();
                Random rnd4 = new Random();
                Random rnd2 = new Random();
                Random rnd = new Random();




                char[] rewards = { '@', '#', '>', '<', '*', 'L', 'X', 'N' }; // ALL REWARDS AND PENALTIES
                int[] places = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 }; // ALL COORDINATES
                int[] places2 = new int[8]; // REWARDS PLACES SAVED 
                int[] places3 = new int[8];
                char[] x = { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', 'T' };
                for (int i = 0; i < rewards.Length; i++) // REWARDS AND PENALTIES COORDINATES
                {

                    place = rnd3.Next(1, 24);
                    while (places2[0] == places[place] || places2[1] == places[place] || places2[2] == places[place] || places2[3] == places[place] // IS COORDINATE EMPTY OR NOT ? CHECKING SYSTEM
                        || places2[4] == places[place] || places2[5] == places[place] || places2[6] == places[place]
                        || places2[7] == places[place])
                    {
                        place = rnd3.Next(1, 24);
                    }
                    places2[i] = places[place];
                }
                for (int k = 0; k < places3.Length; k++) // COPYING THE REWARDS AND PENALTIES COORDINATES
                {
                    places3[k] = places2[k];
                }
                Console.SetCursorPosition(1, 4);
                Console.Write("P");
                Console.SetCursorPosition(3, 4);
                Console.Write("C");
                /*
                  for (int i = 0; i < rewards.Length; i++)
                {
                    x[places2[i]] = rewards[i];
                }
                */
                /////////////////// DRAWING GAME SCREEN /////////////////////
                Console.SetCursorPosition(0, 1);
                Console.Write("Starting");
                Console.SetCursorPosition(0, 2);
                Console.Write("Lounge");
                Console.SetCursorPosition(0, 3);
                Console.Write("+---+");
                Console.SetCursorPosition(0, 4);
                Console.Write("|");
                Console.SetCursorPosition(4, 4);
                Console.Write("|");
                Console.SetCursorPosition(2, 4);
                Console.Write("|");
                Console.SetCursorPosition(0, 5);
                Console.Write("+---+");
                Console.SetCursorPosition(12, 0);
                Console.Write("---------------------- " + "Round " + round + " ----------------------");
                Console.SetCursorPosition(14, 2);
                Console.Write("1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5");
                Console.SetCursorPosition(12, 3);
                Console.Write("+ - - - - - - - - - - - - - - - - - - - - - - - - - +");
                Console.SetCursorPosition(12, 4);
                Console.Write("|");
                for (int i = 0; i < rewards.Length; i++)
                {
                    x[places2[i]] = rewards[i];
                }
                Console.SetCursorPosition(14, 4);
                // GAME BOARD
                /////////////////////////// BEGINNING OF THE ALL P MOVEMENTS /////////////////////
                Console.Write(x[1] + " " + x[2] + " " + x[3] + " " + x[4] + " " + x[5] + " " + x[6] + " " + x[7] + " " + x[8] + " "
                    + x[9] + " " + x[10] + " " + x[11] + " " + x[12] + " " + x[13] + " " + x[14] + " " + x[15] + " " + x[16] + " " + x[17] + " " + x[18] + " " +
                    x[19] + " " + x[20] + " " + x[21] + " " + x[22] + " " + x[23] + " " + x[24] + " " + x[25]);

                // MORE GAME SCREEN
                Console.SetCursorPosition(64, 4);
                Console.Write("|");
                Console.SetCursorPosition(12, 5);
                Console.Write("+ - - - - - - - - - - - - - - - - - - - - - - - - - +");
                Console.SetCursorPosition(70, 1);
                Console.Write("Turn: ");
                Console.SetCursorPosition(70, 2);
                Console.Write("Dice: ");
                Console.SetCursorPosition(70, 3);
                Console.Write("Life of C: " + clife);
                Console.SetCursorPosition(70, 4);
                Console.Write("Life of P: " + plife);

                // STARTS THE LOOP THAT GAME MOVEMENTS
                while (T == 0)
                {
                    //// STARTS WITH P MOVEMENTS AFTER C MOVEMENTS WILL START


                    int k = 0;


                    Console.SetCursorPosition(70, 1); //P LOUNGE
                    Console.Write("Turn: " + "P");
                    // WAIT FOR STARTING 
                    if (wait == -1)
                    {
                        wait = 0;
                        k++;
                    }
                    else
                    {
                        pdice = rnd.Next(1, 7);
                        Pdice = Pdice + pdice;
                        if (Pdice > 25)
                        {
                            Pdice = Pdice - pdice;
                        }
                        x[Pdice] = 'P';
                        Console.SetCursorPosition(70, 2);
                        Console.Write("Dice: " + pdice);
                    }
                    Console.ReadLine();
                    if (x[Pdice - pdice] == 'P')
                    {
                        x[Pdice - pdice] = '.';
                    }



                    if (Pdice == places3[0])
                    {
                        x[Pdice] = '@';
                        Pdice = 0;
                        if (Pdice == 0)
                        {
                            Console.SetCursorPosition(1, 4);
                            Console.Write("P");
                        }
                        else
                        {
                            Console.SetCursorPosition(1, 4);
                            Console.Write(" ");
                        }
                    }

                    else if (Pdice == places3[1])
                    {
                        x[Pdice] = '#';
                        wait = -1;

                        if (k == 1)
                        {
                            wait = 0;
                            k = 0;
                        }

                    }
                    else if (Pdice == places3[2])
                    {
                        x[Pdice] = '>';
                        Pdice = Pdice + 3;
                        if (Pdice > 25)
                        {
                            Pdice = Pdice - pdice;
                        }
                        if (Pdice == places3[0])
                        {
                            x[Pdice] = '@';
                            Pdice = 0;
                            if (Pdice == 0)
                            {
                                Console.SetCursorPosition(1, 4);
                                Console.Write("P");
                            }
                            else
                            {
                                Console.SetCursorPosition(1, 4);
                                Console.Write(" ");
                            }
                        }

                        else if (Pdice == places3[1])
                        {
                            x[Pdice] = '#';
                            wait = -1;

                            if (k == 1)
                            {
                                wait = 0;
                                k = 0;
                            }

                        }
                        else if (Pdice == places3[3])
                        {
                            x[Pdice] = '<';
                            Pdice = Pdice - 3;
                            if (Pdice <= 0)
                            {
                                Pdice = 0;
                            }
                            x[Pdice] = 'P';

                        }
                        else if (Pdice == places3[4])
                        {
                            x[Pdice] = '*';
                            Pdice = Pdice + pdice;
                            if (Pdice > 25)
                            {
                                Pdice = Pdice - pdice;
                            }
                            x[Pdice] = 'P';

                        }
                        else if (Pdice == places3[5])
                        {
                            x[Pdice] = 'L';
                            plife += 1;
                            Console.SetCursorPosition(70, 4);
                            Console.Write("Life of P: " + plife);
                        }



                        else if (Pdice == places3[6])
                        {
                            x[Pdice] = 'X';
                            plife -= 1;
                            if (plife == 0)
                            {
                                T = 1;
                                Console.SetCursorPosition(70, 4);
                                Console.Write("Life of P: " + plife);
                                Console.SetCursorPosition(70, 6);
                                Console.Write("CONGRATULATIONS! C WINS THE GAME");
                            }
                        }
                        x[Pdice] = 'P';

                    }
                    else if (Pdice == places3[3])
                    {
                        x[Pdice] = '<';
                        Pdice = Pdice - 3;
                        if (Pdice <= 0)
                        {
                            Pdice = 0;
                        }
                        if (Pdice == places3[0])
                        {
                            x[Pdice] = '@';
                            Pdice = 0;
                            if (Pdice == 0)
                            {
                                Console.SetCursorPosition(1, 4);
                                Console.Write("P");
                            }
                            else
                            {
                                Console.SetCursorPosition(1, 4);
                                Console.Write(" ");
                            }
                        }

                        else if (Pdice == places3[1])
                        {
                            x[Pdice] = '#';
                            wait = -1;

                            if (k == 1)
                            {
                                wait = 0;
                                k = 0;
                            }

                        }
                        else if (Pdice == places3[2])
                        {
                            x[Pdice] = '>';
                            Pdice = Pdice + 3;
                            if (Pdice > 25)
                            {
                                Pdice = Pdice - pdice;
                            }
                            x[Pdice] = 'P';

                        }
                        else if (Pdice == places3[4])
                        {
                            x[Pdice] = '*';
                            Pdice = Pdice + pdice;
                            if (Pdice > 25)
                            {
                                Pdice = Pdice - pdice;
                            }
                            x[Pdice] = 'P';

                        }
                        else if (Pdice == places3[5])
                        {
                            x[Pdice] = 'L';
                            plife += 1;
                            Console.SetCursorPosition(70, 4);
                            Console.Write("Life of P: " + plife);
                        }



                        else if (Pdice == places3[6])
                        {
                            x[Pdice] = 'X';
                            plife -= 1;
                            if (plife == 0)
                            {
                                T = 1;
                                Console.SetCursorPosition(70, 4);
                                Console.Write("Life of P: " + plife);
                                Console.SetCursorPosition(70, 6);
                                Console.Write("CONGRATULATIONS! C WINS THE GAME");
                            }
                        }
                        x[Pdice] = 'P';

                    }
                    else if (Pdice == places3[4])
                    {
                        x[Pdice] = '*';
                        Pdice = Pdice + pdice;
                        if (Pdice > 25)
                        {
                            Pdice = Pdice - pdice;
                        }
                        if (Pdice == places3[0])
                        {
                            x[Pdice] = '@';
                            Pdice = 0;
                            if (Pdice == 0)
                            {
                                Console.SetCursorPosition(1, 4);
                                Console.Write("P");
                            }
                            else
                            {
                                Console.SetCursorPosition(1, 4);
                                Console.Write(" ");
                            }
                        }

                        else if (Pdice == places3[1])
                        {
                            x[Pdice] = '#';
                            wait = -1;

                            if (k == 1)
                            {
                                wait = 0;
                                k = 0;
                            }

                        }
                        else if (Pdice == places3[2])
                        {
                            x[Pdice] = '>';
                            Pdice = Pdice + 3;
                            if (Pdice > 25)
                            {
                                Pdice = Pdice - pdice;
                            }
                            x[Pdice] = 'P';

                        }
                        else if (Pdice == places3[3])
                        {
                            x[Pdice] = '<';
                            Pdice = Pdice - 3;
                            if (Pdice <= 0)
                            {
                                Pdice = 0;
                            }
                            x[Pdice] = 'P';

                        }
                        else if (Pdice == places3[5])
                        {
                            x[Pdice] = 'L';
                            plife += 1;
                            Console.SetCursorPosition(70, 4);
                            Console.Write("Life of P: " + plife);
                        }



                        else if (Pdice == places3[6])
                        {
                            x[Pdice] = 'X';
                            plife -= 1;
                            if (plife == 0)
                            {
                                T = 1;
                                Console.SetCursorPosition(70, 4);
                                Console.Write("Life of P: " + plife);
                                Console.SetCursorPosition(70, 6);
                                Console.Write("CONGRATULATIONS! C WINS THE GAME");
                            }
                        }
                        x[Pdice] = 'P';

                    }
                    else if (Pdice == places3[5])
                    {
                        x[Pdice] = 'L';
                        plife += 1;
                        Console.SetCursorPosition(70, 4);
                        Console.Write("Life of P: " + plife);
                    }



                    else if (Pdice == places3[6])
                    {
                        x[Pdice] = 'X';
                        plife -= 1;
                        if (plife == 0)
                        {
                            T = 1;
                            Console.SetCursorPosition(70, 4);
                            Console.Write("Life of P: " + plife);
                            Console.SetCursorPosition(70, 6);
                            Console.Write("CONGRATULATIONS! C WINS THE GAME");
                        }
                    }
                    else if (Pdice == places3[7])
                    {
                        int temp, temp2 = 0, min = 90, min2 = 90;
                        x[Pdice] = 'N';
                        for (int i = 0; i < 8; i++)
                        {
                            temp = Pdice - places3[i];
                            if (temp < 0)
                            {
                                temp2 = Math.Abs(temp);
                                if (min > temp2)
                                {
                                    min = temp2;
                                }
                            }
                        }
                        for (int i = 0; i < 8; i++)
                        {
                            temp = Pdice - places3[i];
                            if (temp > 0)
                            {
                                if (min2 > temp)
                                {
                                    min2 = temp;
                                }
                            }
                        }

                        if (min >= min2)
                        {
                            Pdice = Pdice - min2;
                        }
                        else if (min2 > min)
                        {
                            Pdice = Pdice + min;
                        }

                        if (Pdice == places3[0])
                        {
                            x[Pdice] = '@';
                            Pdice = 0;
                            if (Pdice == 0)
                            {
                                Console.SetCursorPosition(1, 4);
                                Console.Write("P");
                            }
                            else
                            {
                                Console.SetCursorPosition(1, 4);
                                Console.Write(" ");
                            }
                        }

                        else if (Pdice == places3[1])
                        {
                            x[Pdice] = '#';
                            wait = -1;

                            if (k == 1)
                            {
                                wait = 0;
                                k = 0;
                            }

                        }
                        else if (Pdice == places3[2])
                        {
                            x[Pdice] = '>';
                            Pdice = Pdice + 3;
                            if (Pdice > 25)
                            {
                                Pdice = Pdice - pdice;
                            }
                            x[Pdice] = 'P';

                        }
                        else if (Pdice == places3[3])
                        {
                            x[Pdice] = '<';
                            Pdice = Pdice - 3;
                            if (Pdice <= 0)
                            {
                                Pdice = 0;
                            }
                            x[Pdice] = 'P';

                        }
                        else if (Pdice == places3[4])
                        {
                            x[Pdice] = '*';
                            Pdice = Pdice + pdice;
                            if (Pdice > 25)
                            {
                                Pdice = Pdice - pdice;
                            }
                            x[Pdice] = 'P';

                        }
                        else if (Pdice == places3[5])
                        {
                            x[Pdice] = 'L';
                            plife += 1;
                            Console.SetCursorPosition(70, 4);
                            Console.Write("Life of P: " + plife);
                        }



                        else if (Pdice == places3[6])
                        {
                            x[Pdice] = 'X';
                            plife -= 1;
                            if (plife == 0)
                            {
                                T = 1;
                                Console.SetCursorPosition(70, 4);
                                Console.Write("Life of P: " + plife);
                                Console.SetCursorPosition(70, 6);
                                Console.Write("CONGRATULATIONS! C WINS THE GAME");
                            }
                        }
                    }
                    x[Pdice] = 'P';
                    while (Pdice == 25)
                    {
                        x[Pdice - pdice] = '.';
                        T = 1;
                        Console.SetCursorPosition(70, 6);
                        Console.Write("CONGRATULATIONS! P WINS THE GAME");
                        x[25] = 'P';
                        Console.SetCursorPosition(14, 4);
                        Console.Write(x[1] + " " + x[2] + " " + x[3] + " " + x[4] + " " + x[5] + " " + x[6] + " " + x[7] + " " + x[8] + " "
                        + x[9] + " " + x[10] + " " + x[11] + " " + x[12] + " " + x[13] + " " + x[14] + " " + x[15] + " " + x[16] + " " + x[17] + " " + x[18] + " " +
                        x[19] + " " + x[20] + " " + x[21] + " " + x[22] + " " + x[23] + " " + x[24] + " " + x[25]);
                        Console.ReadLine();

                    }

                    if (Cdice == Pdice)
                    {
                        Cdice = 0;
                        if (Cdice == 0)
                        {
                            Console.SetCursorPosition(3, 4);
                            Console.Write("C");
                            x[Cdice] = 'P';
                        }
                        else
                        {
                            Console.SetCursorPosition(1, 4);
                            Console.Write(" ");
                        }
                    }
                    for (int i = 0; i < rewards.Length; i++)
                    {
                        x[places2[i]] = rewards[i];
                    }
                    x[Pdice] = 'P';
                    x[Cdice] = 'C';
                    
                    /////////////////////////// BEGINNING OF THE ALL C MOVEMENTS /////////////////////

                    Console.SetCursorPosition(14, 4);
                    Console.Write(x[1] + " " + x[2] + " " + x[3] + " " + x[4] + " " + x[5] + " " + x[6] + " " + x[7] + " " + x[8] + " "
                        + x[9] + " " + x[10] + " " + x[11] + " " + x[12] + " " + x[13] + " " + x[14] + " " + x[15] + " " + x[16] + " " + x[17] + " " + x[18] + " " +
                        x[19] + " " + x[20] + " " + x[21] + " " + x[22] + " " + x[23] + " " + x[24] + " " + x[25]);

                    if (Pdice == 0)
                    {
                        Console.SetCursorPosition(1, 4);
                        Console.Write("P");
                    }
                    else
                    {
                        Console.SetCursorPosition(1, 4);
                        Console.Write(" ");
                    }


                    int h = 0;

                    Console.SetCursorPosition(70, 1);
                    Console.Write("Turn: " + "C");

                    if (wait2 == -1)
                    {
                        wait2 = 0;
                        h++;
                    }
                    else
                    {

                        cdice = rnd.Next(1, 7);
                        Cdice = Cdice + cdice;
                        if (Cdice > 25)
                        {
                            Cdice = Cdice - cdice;
                        }
                        x[Cdice] = 'C';
                        Console.SetCursorPosition(70, 2);
                        Console.Write("Dice: " + cdice);
                    }

                    Console.ReadLine();
                    if (x[Cdice - cdice] == 'C')
                    {
                        x[Cdice - cdice] = '.';
                    }

                    if (Cdice == places3[0])
                    {
                        x[Cdice] = '@';
                        Cdice = 0;
                        if (Cdice == 0)
                        {
                            Console.SetCursorPosition(3, 4);
                            Console.Write("C");
                        }
                        else
                        {
                            Console.SetCursorPosition(3, 4);
                            Console.Write(" ");
                        }

                    }
                    else if (Cdice == places3[1])
                    {
                        x[Cdice] = '#';
                        wait2 = -1;
                        if (h == 1)
                        {
                            wait2 = 0;
                            h = 0;
                        }
                    }
                    else if (Cdice == places3[2])
                    {
                        x[Cdice] = '>';
                        Cdice = Cdice + 3;
                        if (Cdice > 25)
                        {
                            Cdice = Cdice - cdice;
                        }
                        if (Cdice == places3[0])
                        {
                            x[Cdice] = '@';
                            Cdice = 0;
                            if (Cdice == 0)
                            {
                                Console.SetCursorPosition(3, 4);
                                Console.Write("C");
                            }
                            else
                            {
                                Console.SetCursorPosition(3, 4);
                                Console.Write(" ");
                            }

                        }
                        else if (Cdice == places3[1])
                        {
                            x[Cdice] = '#';
                            wait2 = -1;
                            if (h == 1)
                            {
                                wait2 = 0;
                                h = 0;
                            }
                        }

                        else if (Cdice == places3[3])
                        {
                            x[Cdice] = '<';
                            Cdice = Cdice - 3;
                            if (Cdice <= 0)
                            {
                                Cdice = 0;
                            }
                            x[Cdice] = 'C';

                        }
                        else if (Cdice == places3[4])
                        {
                            x[Cdice] = '*';
                            Cdice = Cdice + cdice;
                            if (Cdice > 25)
                            {
                                Cdice = Cdice - cdice;
                            }
                            x[Cdice] = 'C';

                        }
                        else if (Cdice == places3[5])
                        {
                            x[Cdice] = 'L';
                            clife += 1;
                            Console.SetCursorPosition(70, 3);
                            Console.Write("Life of C: " + clife);
                        }
                        else if (Cdice == places3[6])
                        {
                            x[Cdice] = 'X';
                            clife -= 1;
                            if (clife == 0)
                            {
                                T = 1;
                                Console.SetCursorPosition(70, 3);
                                Console.Write("Life of C: " + clife);
                                Console.SetCursorPosition(70, 6);
                                Console.Write("CONGRATULATIONS! P WINS THE GAME");
                            }
                        }
                        x[Cdice] = 'C';

                    }
                    else if (Cdice == places3[3])
                    {
                        x[Cdice] = '<';
                        Cdice = Cdice - 3;
                        if (Cdice <= 0)
                        {
                            Cdice = 0;
                        }
                        if (Cdice == places3[0])
                        {
                            x[Cdice] = '@';
                            Cdice = 0;
                            if (Cdice == 0)
                            {
                                Console.SetCursorPosition(3, 4);
                                Console.Write("C");
                            }
                            else
                            {
                                Console.SetCursorPosition(3, 4);
                                Console.Write(" ");
                            }

                        }
                        else if (Cdice == places3[1])
                        {
                            x[Cdice] = '#';
                            wait2 = -1;
                            if (h == 1)
                            {
                                wait2 = 0;
                                h = 0;
                            }
                        }
                        else if (Cdice == places3[2])
                        {
                            x[Cdice] = '>';
                            Cdice = Cdice + 3;
                            if (Cdice > 25)
                            {
                                Cdice = Cdice - cdice;
                            }
                            x[Cdice] = 'C';

                        }

                        else if (Cdice == places3[4])
                        {
                            x[Cdice] = '*';
                            Cdice = Cdice + cdice;
                            if (Cdice > 25)
                            {
                                Cdice = Cdice - cdice;
                            }
                            x[Cdice] = 'C';

                        }
                        else if (Cdice == places3[5])
                        {
                            x[Cdice] = 'L';
                            clife += 1;
                            Console.SetCursorPosition(70, 3);
                            Console.Write("Life of C: " + clife);
                        }
                        else if (Cdice == places3[6])
                        {
                            x[Cdice] = 'X';
                            clife -= 1;
                            if (clife == 0)
                            {
                                T = 1;
                                Console.SetCursorPosition(70, 3);
                                Console.Write("Life of C: " + clife);
                                Console.SetCursorPosition(70, 6);
                                Console.Write("CONGRATULATIONS! P WINS THE GAME");
                            }
                        }
                        x[Cdice] = 'C';

                    }
                    else if (Cdice == places3[4])
                    {
                        x[Cdice] = '*';
                        Cdice = Cdice + cdice;
                        if (Cdice > 25)
                        {
                            Cdice = Cdice - cdice;
                        }
                        if (Cdice == places3[0])
                        {
                            x[Cdice] = '@';
                            Cdice = 0;
                            if (Cdice == 0)
                            {
                                Console.SetCursorPosition(3, 4);
                                Console.Write("C");
                            }
                            else
                            {
                                Console.SetCursorPosition(3, 4);
                                Console.Write(" ");
                            }

                        }
                        else if (Cdice == places3[1])
                        {
                            x[Cdice] = '#';
                            wait2 = -1;
                            if (h == 1)
                            {
                                wait2 = 0;
                                h = 0;
                            }
                        }
                        else if (Cdice == places3[2])
                        {
                            x[Cdice] = '>';
                            Cdice = Cdice + 3;
                            if (Cdice > 25)
                            {
                                Cdice = Cdice - cdice;
                            }
                            x[Cdice] = 'C';

                        }
                        else if (Cdice == places3[3])
                        {
                            x[Cdice] = '<';
                            Cdice = Cdice - 3;
                            if (Cdice <= 0)
                            {
                                Cdice = 0;
                            }
                            x[Cdice] = 'C';

                        }

                        else if (Cdice == places3[5])
                        {
                            x[Cdice] = 'L';
                            clife += 1;
                            Console.SetCursorPosition(70, 3);
                            Console.Write("Life of C: " + clife);
                        }
                        else if (Cdice == places3[6])
                        {
                            x[Cdice] = 'X';
                            clife -= 1;
                            if (clife == 0)
                            {
                                T = 1;
                                Console.SetCursorPosition(70, 3);
                                Console.Write("Life of C: " + clife);
                                Console.SetCursorPosition(70, 6);
                                Console.Write("CONGRATULATIONS! P WINS THE GAME");
                            }
                        }
                        x[Cdice] = 'C';

                    }
                    else if (Cdice == places3[5])
                    {
                        x[Cdice] = 'L';
                        clife += 1;
                        Console.SetCursorPosition(70, 3);
                        Console.Write("Life of C: " + clife);
                    }
                    else if (Cdice == places3[6])
                    {
                        x[Cdice] = 'X';
                        clife -= 1;
                        if (clife == 0)
                        {
                            T = 1;
                            Console.SetCursorPosition(70, 3);
                            Console.Write("Life of C: " + clife);
                            Console.SetCursorPosition(70, 6);
                            Console.Write("CONGRATULATIONS! P WINS THE GAME");
                        }
                    }
                    else if (Cdice == places3[7])
                    {
                        int temp, temp2 = 99999, min = 90, min2 = 90;
                        x[Cdice] = 'N';
                        for (int i = 0; i < 8; i++)
                        {
                            temp = Cdice - places3[i];
                            if (temp < 0)
                            {
                                temp2 = Math.Abs(temp);
                                if (min > temp2)
                                {
                                    min = temp2;
                                }
                            }
                        }
                        for (int i = 0; i < 8; i++)
                        {
                            temp = Cdice - places3[i];
                            if (temp > 0)
                            {
                                if (min2 > temp)
                                {
                                    min2 = temp;
                                }
                            }
                        }

                        if (min >= min2)
                        {
                            Cdice = Cdice - min2;
                        }
                        else if (min2 > min)
                        {
                            Cdice = Cdice + min;
                        }
                        if (Cdice == places3[0])
                        {
                            x[Cdice] = '@';
                            Cdice = 0;
                            if (Cdice == 0)
                            {
                                Console.SetCursorPosition(3, 4);
                                Console.Write("C");
                            }
                            else
                            {
                                Console.SetCursorPosition(3, 4);
                                Console.Write(" ");
                            }

                        }
                        else if (Cdice == places3[1])
                        {
                            x[Cdice] = '#';
                            wait2 = -1;
                            if (h == 1)
                            {
                                wait2 = 0;
                                h = 0;
                            }
                        }
                        else if (Cdice == places3[2])
                        {
                            x[Cdice] = '>';
                            Cdice = Cdice + 3;
                            if (Cdice > 25)
                            {
                                Cdice = Cdice - cdice;
                            }
                            x[Cdice] = 'C';

                        }
                        else if (Cdice == places3[3])
                        {
                            x[Cdice] = '<';
                            Cdice = Cdice - 3;
                            if (Cdice <= 0)
                            {
                                Cdice = 0;
                            }
                            x[Cdice] = 'C';

                        }
                        else if (Cdice == places3[4])
                        {
                            x[Cdice] = '*';
                            Cdice = Cdice + cdice;
                            if (Cdice > 25)
                            {
                                Cdice = Cdice - cdice;
                            }
                            x[Cdice] = 'C';

                        }
                        else if (Cdice == places3[5])
                        {
                            x[Cdice] = 'L';
                            clife += 1;
                            Console.SetCursorPosition(70, 3);
                            Console.Write("Life of C: " + clife);
                        }
                        else if (Cdice == places3[6])
                        {
                            x[Cdice] = 'X';
                            clife -= 1;
                            if (clife == 0)
                            {
                                T = 1;
                                Console.SetCursorPosition(70, 3);
                                Console.Write("Life of C: " + clife);
                                Console.SetCursorPosition(70, 6);
                                Console.Write("CONGRATULATIONS! P WINS THE GAME");
                            }
                        }
                    }
                    x[Cdice] = 'C';
                    if (Pdice == Cdice)
                    {
                        Pdice = 0;
                        if (Pdice == 0)
                        {
                            Console.SetCursorPosition(1, 4);
                            Console.Write("P");
                            x[Pdice] = 'C';
                        }
                        else
                        {
                            Console.SetCursorPosition(3, 4);
                            Console.Write(" ");
                        }
                    }

                    if (Cdice == 0)
                    {
                        Console.SetCursorPosition(3, 4);
                        Console.Write("C");
                    }
                    else
                    {
                        Console.SetCursorPosition(3, 4);
                        Console.Write(" ");
                    }


                    while (Cdice == 25)
                    {
                        x[Cdice - cdice] = '.';
                        T = 1;
                        Console.SetCursorPosition(70, 6);
                        Console.Write("CONGRATULATIONS! C WINS THE GAME");
                        x[25] = 'C';
                        Console.SetCursorPosition(14, 4);
                        Console.Write(x[1] + " " + x[2] + " " + x[3] + " " + x[4] + " " + x[5] + " " + x[6] + " " + x[7] + " " + x[8] + " "
                        + x[9] + " " + x[10] + " " + x[11] + " " + x[12] + " " + x[13] + " " + x[14] + " " + x[15] + " " + x[16] + " " + x[17] + " " + x[18] + " " +
                        x[19] + " " + x[20] + " " + x[21] + " " + x[22] + " " + x[23] + " " + x[24] + " " + x[25]);
                        Console.ReadLine();


                    }
                    round += 1;
                    Console.SetCursorPosition(12, 0);
                    Console.Write("---------------------- " + "Round " + round + " ----------------------");
                    for (int i = 0; i < rewards.Length; i++)
                    {
                        x[places2[i]] = rewards[i];
                    }
                    x[Cdice] = 'C';
                    x[Pdice] = 'P';
                    Console.SetCursorPosition(14, 4);
                    Console.Write(x[1] + " " + x[2] + " " + x[3] + " " + x[4] + " " + x[5] + " " + x[6] + " " + x[7] + " " + x[8] + " "
                        + x[9] + " " + x[10] + " " + x[11] + " " + x[12] + " " + x[13] + " " + x[14] + " " + x[15] + " " + x[16] + " " + x[17] + " " + x[18] + " " +
                        x[19] + " " + x[20] + " " + x[21] + " " + x[22] + " " + x[23] + " " + x[24] + " " + x[25]);
                }
            }

            ////////////////// 2D BEGINNING OF THE 2D GAME SCREEN //////////////////////////////
            if (q == 2)
            {
                Console.Clear();
                // 2d game all randoms
                Random rnd4 = new Random();
                Random rnd3 = new Random();
                Random rnd2 = new Random();
                Random rnd = new Random();
                int pdice = 0, cdice = 0, place = 0, place2 = 0, plife = 1,
                clife = 1, T = 0, round = 0, direction = 0, direction2 = 0, row = -1, column = -1, row2 = -1, column2 = -1, wait = 0, wait2 = 0;
                char[,] places = new char[12, 12];

                char[] rewards = { '@', '#', '>', '<', '*', 'L', 'X', 'N', '^', 'v' }; // shapes of rewards and penalties 
                char[] rewards2 = new char[40]; // rewards and penalties saving this array
                char[] rewards3 = new char[40]; // copying rewards and penalties for proccesing
                int[] places2 = new int[40]; // game area coordinates , in the beggining this area stars as a dot
                int[] places3 = new int[40]; // copying " " for proccesing 
                int[] x = new int[12]; // xcoordinates for movements
                int[] y = new int[12]; // ycoordinates for movements


                /// game screen
                Console.SetCursorPosition(1, 4);
                Console.Write("P");
                Console.SetCursorPosition(3, 4);
                Console.Write("C");
                Console.SetCursorPosition(0, 1);
                Console.Write("Starting");
                Console.SetCursorPosition(0, 2);
                Console.Write("Lounge");
                Console.SetCursorPosition(0, 3);
                Console.Write("+---+");
                Console.SetCursorPosition(0, 4);
                Console.Write("|");
                Console.SetCursorPosition(4, 4);
                Console.Write("|");
                Console.SetCursorPosition(2, 4);
                Console.Write("|");
                Console.SetCursorPosition(0, 5);
                Console.Write("+---+");
                Console.SetCursorPosition(12, 0);
                Console.Write("--------- Round " + round + " ---------");
                Console.SetCursorPosition(14, 2);
                Console.Write("1 2 3 4 5 6 7 8 9 0 1 2");
                Console.SetCursorPosition(12, 3);
                Console.Write("+ - - - - - - - - - - - - +");
                Console.SetCursorPosition(12, 16);
                Console.Write("+ - - - - - - - - - - - - +");
                Console.SetCursorPosition(70, 3);
                Console.Write("Direction: ");
                Console.SetCursorPosition(70, 4);
                Console.Write("Life of C: " + clife);
                Console.SetCursorPosition(70, 5);
                Console.Write("Life of P: " + plife);
                for (int h = 0; h < 12; h++) 
                {
                    Console.SetCursorPosition(12, 4 + h);
                    Console.Write("|");
                }
                for (int h = 0; h < 12; h++)
                {
                    Console.SetCursorPosition(38, 4 + h);
                    Console.Write("|");
                }
                int z = 1;
                for (int h = 0; h < 12; h++)
                {
                    if (h == 9)
                    {
                        z = 0;
                    }
                    Console.SetCursorPosition(11, 4 + h);
                    Console.Write(z);
                    z++;


                }
                // game screen finish

                int k1 = 0;
                for (int i = 1; i < rewards2.Length + 1; i++) // putting the rewards on game coordinates
                {
                    rewards2[i - 1] = rewards[k1];
                    if (i % 4 == 0)
                    {
                        k1++;
                    }
                }


                for (int i = 0; i < places.GetLength(0); i++) // all movements places recognize as a dot
                {
                    Console.SetCursorPosition(14, 4 + i);
                    for (int j = 0; j < places.GetLength(1); j++)
                    {
                        places[i, j] = '.';

                        Console.Write(places[i, j] + " ");
                    }
                }

                for (int j = 0; j < rewards2.Length; j++)
                {
                    place = rnd.Next(0, 12); // random xcoordinate
                    place2 = rnd.Next(0, 12); // random ycoordinate

                    if (x[place] == 4) // for max 4 column and row
                    {
                        for (int n = 0; n < 12; n++)
                        {
                            if (x[n] < 4)
                            {
                                place = n;
                            }
                        }
                    }

                    if (y[place2] == 4) // for max 4 column and row
                    {
                        for (int n = 0; n < 12; n++)
                        {
                            if (y[n] < 4) 
                            {
                                place2 = n;
                            }
                        }
                    }
                    if ((place == 11) && (place2 == 11)) // because x=11 y=11 coordinates is for over the game
                    {
                        place = rnd.Next(0, 12);
                        place2 = rnd.Next(0, 12);

                        if ((place == 11) && (place2 == 11))
                        {
                            place = rnd.Next(0, 12);
                            place2 = rnd.Next(0, 12);
                        }
                    }
                    for (int k = 0; k < rewards3.Count() - 1; k++)
                    {
                        if (rewards3[k] == places[place, place2])
                        {
                            if (x[place] == 4)
                            {
                                for (int n = 0; n < 12; n++)
                                {
                                    if (x[n] < 4)
                                    {
                                        place = n;
                                    }
                                }
                            }

                            if (y[place2] == 4)
                            {
                                for (int n = 0; n < 12; n++)
                                {
                                    if (y[n] < 4)
                                    {
                                        place2 = n;
                                    }
                                }
                            }
                            place = rnd.Next(0, 12);
                            place2 = rnd.Next(0, 12);

                        }

                    }

                    rewards3[j] = rewards2[j];
                    places[place, place2] = rewards3[j];
                    places2[j] = place;
                    places3[j] = place2;
                    x[place]++;
                    y[place2]++;
                }


                for (int i = 0; i < places.GetLength(0); i++)
                {
                    Console.SetCursorPosition(14, 4 + i);
                    for (int j = 0; j < places.GetLength(1); j++)
                    {
                        Console.Write(places[i, j] + " ");
                    }
                    places[11, 11] = 'T'; //finish letter
                }


                while (T == 0)
                {
                    pdice = rnd2.Next(1, 7);
                    Console.SetCursorPosition(70, 2);
                    Console.Write("Dice: " + pdice);
                    Console.SetCursorPosition(70, 1);
                    Console.Write("Turn: " + "P");
                    direction = rnd3.Next(0, 2);
                    int h = 0;
                    //Horizontal movements
                    if (direction == 0)
                    {
                        if (wait == -1)
                        {
                            wait = 0;
                            h++;
                        }
                        else
                        {
                            if (column == -1)
                            {
                                column = column + pdice;
                                row = 0;
                                places[row, column] = 'P';
                                places[row, column + 1 - pdice] = '.';
                            }
                            else
                            {
                                column = column + pdice;
                                if (column > 11 || column < 0)
                                {
                                    column = column - pdice;
                                }

                                places[row, column] = 'P';
                                places[row, column - pdice] = '.';
                            }
                        }
                        Console.SetCursorPosition(70, 3);
                        Console.Write("Direction: >");



                        Console.SetCursorPosition(65, 10);
                        Console.Write("column=" + (column + 1));
                    }

                    //Vertical movements
                    else if (direction == 1)
                    {
                        if (wait == -1)
                        {
                            wait = 0;
                            h++;
                        }
                        else
                        {
                            if (row == -1)
                            {
                                row = row + pdice;
                                column = 0;
                                places[row, column] = 'P';
                                places[row + 1 - pdice, column] = '.';
                            }
                            else
                            {
                                row = row + pdice;
                                if (row > 11 || row < 0)
                                {
                                    row = row - pdice;
                                }

                                places[row, column] = 'P';
                                places[row - pdice, column] = '.';
                            }
                        }
                        Console.SetCursorPosition(70, 3);
                        Console.Write("Direction: v");



                        Console.SetCursorPosition(65, 11);
                        Console.Write("row=" + (row + 1));
                    }

                    Console.ReadLine();



                    if (row == 11 && column == 11) // game finish coordinates
                    {
                        T = 1;
                        places[11, 11] = 'P';
                        Console.SetCursorPosition(70, 6);
                        Console.Write("CONGRATULATIONS! P WON THE GAME");
                        for (int k = 0; k < places.GetLength(0); k++)
                        {
                            Console.SetCursorPosition(14, 4 + k);
                            for (int j = 0; j < places.GetLength(1); j++)
                            {
                                Console.Write(places[k, j] + " ");
                            }

                        }
                        Console.ReadLine();
                    }
                    if (row2 == row && column2 == column)
                    {
                        row2 = -1;
                        column2 = -1;
                        if (row2 == -1 && column2 == -1)
                        {
                            Console.SetCursorPosition(3, 4);
                            Console.Write("C");
                        }
                        else
                        {
                            Console.SetCursorPosition(1, 4);
                            Console.Write(" ");
                        }
                    }
                    for (int i = 0; i < rewards3.Length; i++)
                    {
                        places[places2[i], places3[i]] = rewards3[i];
                    }

                    for (int k = 0; k < places.GetLength(0); k++)
                    {
                        Console.SetCursorPosition(14, 4 + k);
                        for (int j = 0; j < places.GetLength(1); j++)
                        {
                            Console.Write(places[k, j] + " ");
                        }

                    }
                    if (places[row, column] == '@')
                    {
                        places[row, column] = 'P';
                        column = -1;
                        row = -1;
                        if (column == -1 && row == -1)
                        {
                            Console.SetCursorPosition(1, 4);
                            Console.Write("P");
                        }
                        else
                        {
                            Console.SetCursorPosition(1, 4);
                            Console.Write(" ");
                        }
                    }
                    else if (places[row, column] == '#')
                    {
                        places[row, column] = 'P';
                        wait = -1;
                        if (h == 1)
                        {
                            wait = 0;
                            h = 0;
                        }
                    }
                    else if (places[row, column] == '>')
                    {
                        places[row, column] = 'P';
                        column = column + 3;
                        if (column > 11)
                        {
                            column = column - pdice;
                        }
                        places[row, column] = 'P';
                    }
                    else if (places[row, column] == '<')
                    {
                        places[row, column] = 'P';
                        column = column - 3;
                        if (column < 0)
                        {
                            column = 0;
                        }
                        places[row, column] = 'P';
                    }


                    else if (places[row, column] == '*')
                    {
                        places[row, column] = 'P';
                        column = column + pdice;
                        if (column > 11)
                        {
                            column = 11;
                        }
                        places[row, column] = 'P';
                    }




                    else if (places[row, column] == 'L')
                    {
                        places[row, column] = 'P';
                        plife = plife + 1;
                        Console.SetCursorPosition(70, 5);
                        Console.Write("Life of P: " + plife);
                    }
                    else if (places[row, column] == 'X')
                    {
                        places[row, column] = 'P';
                        plife = plife - 1;
                        if (plife == 0)
                        {
                            T = 1;
                            places[row2, column2] = 'C';
                            places[row, column] = 'P';
                            Console.SetCursorPosition(70, 5);
                            Console.Write("Life of P: " + plife);
                            Console.SetCursorPosition(70, 6);
                            Console.Write("CONGRATULATIONS! C WON THE GAME");
                            for (int k = 0; k < places.GetLength(0); k++)
                            {
                                Console.SetCursorPosition(14, 4 + k);
                                for (int j = 0; j < places.GetLength(1); j++)
                                {
                                    Console.Write(places[k, j] + " ");
                                }

                            }
                            Console.ReadLine();
                        }
                    }
                    else if (places[row, column] == 'N')
                    {
                        places[row, column] = 'P';
                    }
                    else if (places[row, column] == 'v')
                    {
                        places[row, column] = 'P';
                        row = row + 3;
                        if (row == 12)
                        {
                            row = row - 1;
                        }
                        else if (row == 13)
                        {
                            row = row - 2;
                        }
                        else if (row == 14)
                        {
                            row = row - 3;
                        }
                        places[row, column] = 'P';
                    }
                    else if (places[row, column] == '^')
                    {
                        places[row, column] = 'P';
                        row = row - 3;
                        if (row == -1)
                        {
                            row = row + 1;
                        }
                        else if (row == -2)
                        {
                            row = row + 2;
                        }
                        else if (row == -3)
                        {
                            row = row + 3;
                        }
                        places[row, column] = 'P';
                    }
                    places[row, column] = 'P';
                    for (int w = 0; w < rewards3.Length; w++)
                    {
                        places[places2[w], places3[w]] = rewards3[w];
                    }

                    places[row, column] = 'P';
                    if (row2 == -1 && column2 == -1)
                    {

                    }
                    else
                    {
                        places[row2, column2] = 'C';

                    }
                    for (int k = 0; k < places.GetLength(0); k++)
                    {
                        Console.SetCursorPosition(14, 4 + k);
                        for (int j = 0; j < places.GetLength(1); j++)
                        {
                            Console.Write(places[k, j] + " ");
                        }

                    }
                    if (row == -1 && column == -1)
                    {
                        Console.SetCursorPosition(1, 4);
                        Console.Write("P");
                    }
                    else
                    {
                        Console.SetCursorPosition(1, 4);
                        Console.Write(" ");
                    }
                    int g = 0;
                    cdice = rnd.Next(1, 7);
                    Console.SetCursorPosition(70, 2);
                    Console.Write("Dice: " + cdice);
                    Console.SetCursorPosition(70, 1);
                    Console.Write("Turn: " + "C");
                    direction2 = rnd4.Next(0, 2);
                    //Horizontal
                    if (direction2 == 0)
                    {
                        if (wait2 == -1)
                        {
                            wait2 = 0;
                            g++;
                        }
                        else
                        {
                            if (column2 == -1)
                            {
                                column2 = column2 + cdice;
                                row2 = 0;
                                places[row2, column2] = 'C';
                                places[row2, column2 + 1 - cdice] = '.';
                            }
                            else
                            {
                                column2 = column2 + cdice;
                                if (column2 > 11 || column2 < 0)
                                {
                                    column2 = column2 - cdice;
                                }

                                places[row2, column2] = 'C';
                                places[row2, column2 - cdice] = '.';
                            }
                        }
                        Console.SetCursorPosition(70, 3);
                        Console.Write("Direction: >");
                        Console.SetCursorPosition(80, 10);
                        Console.Write("column2=" + (column2 + 1));
                    }
                    //Vertical
                    else if (direction2 == 1)
                    {
                        if (wait2 == -1)
                        {
                            wait2 = 0;
                            g++;
                        }
                        else
                        {
                            if (row2 == -1)
                            {
                                row2 = row2 + cdice;
                                column2 = 0;
                                places[row2, column2] = 'C';
                                places[row2 + 1 - cdice, column2] = '.';
                            }
                            else
                            {
                                row2 = row2 + cdice;
                                if (row2 > 11 || row2 < 0)
                                {
                                    row2 = row2 - cdice;
                                }

                                places[row2, column2] = 'C';
                                places[row2 - cdice, column2] = '.';
                            }
                        }
                        Console.SetCursorPosition(70, 3);
                        Console.Write("Direction: v");



                        Console.SetCursorPosition(75, 11);
                        Console.Write("row2=" + (row2 + 1));

                    }
                    Console.ReadLine();

                    if (row == row2 && column == column2)
                    {
                        row = -1;
                        column = -1;
                        if (row == -1 && column == -1)
                        {
                            Console.SetCursorPosition(1, 4);
                            Console.Write("P");
                        }
                        else
                        {
                            Console.SetCursorPosition(3, 4);
                            Console.Write(" ");
                        }
                    }
                    if (row2 == 11 && column2 == 11)
                    {
                        T = 1;
                        places[11, 11] = 'C';
                        Console.SetCursorPosition(70, 6);
                        Console.Write("CONGRATULATIONS! C WON THE GAME");
                        for (int k = 0; k < places.GetLength(0); k++)
                        {
                            Console.SetCursorPosition(14, 4 + k);
                            for (int j = 0; j < places.GetLength(1); j++)
                            {
                                Console.Write(places[k, j] + " ");
                            }

                        }
                        Console.ReadLine();
                    }

                    if (row2 == 0 && column2 == 0)
                    {
                        Console.SetCursorPosition(3, 4);
                        Console.Write("C");
                    }
                    else
                    {
                        Console.SetCursorPosition(3, 4);
                        Console.Write(" ");
                    }

                    Console.SetCursorPosition(12, 0);
                    Console.Write("--------- Round " + round + " ---------");

                    for (int i = 0; i < rewards3.Length; i++)
                    {
                        places[places2[i], places3[i]] = rewards3[i];
                    }

                    for (int k = 0; k < places.GetLength(0); k++)
                    {
                        Console.SetCursorPosition(14, 4 + k);
                        for (int j = 0; j < places.GetLength(1); j++)
                        {
                            Console.Write(places[k, j] + " ");
                        }

                    }
                    if (places[row2, column2] == '@')
                    {
                        places[row2, column2] = 'C';
                        column2 = -1;
                        row2 = -1;
                        if (column2 == -1 && row2 == -1)
                        {
                            Console.SetCursorPosition(3, 4);
                            Console.Write("C");
                        }
                        else
                        {
                            Console.SetCursorPosition(3, 4);
                            Console.Write(" ");
                        }
                    }
                    else if (places[row2, column2] == '#')
                    {
                        places[row2, column2] = 'C';
                        wait2 = -1;
                        if (g == 1)
                        {
                            wait2 = 0;
                            g = 0;
                        }
                    }
                    else if (places[row2, column2] == '>')
                    {
                        places[row2, column2] = 'C';
                        column2 = column2 + 3;
                        if (column2 > 11)
                        {
                            column2 = column2 - cdice;
                        }
                        places[row2, column2] = 'C';
                    }
                    else if (places[row2, column2] == '<')
                    {
                        places[row2, column2] = 'C';
                        column2 = column2 - 3;
                        if (column2 < 0)
                        {
                            column2 = 0;
                        }
                        places[row2, column2] = 'C';
                    }

                    else if (places[row2, column2] == '*')
                    {
                        places[row2, column2] = 'C';
                        column2 = column2 + cdice;
                        if (column2 > 11)
                        {
                            column2 = 11;
                        }
                        places[row2, column2] = 'C';
                    }


                    else if (places[row2, column2] == 'L')
                    {
                        places[row2, column2] = 'C';
                        clife = clife + 1;
                        Console.SetCursorPosition(70, 4);
                        Console.Write("Life of C: " + clife);
                    }
                    else if (places[row2, column2] == 'X')
                    {
                        places[row2, column2] = 'C';
                        clife = clife - 1;
                        if (clife == 0)
                        {
                            T = 1;
                            places[row2, column2] = 'C';
                            places[row, column] = 'P';
                            Console.SetCursorPosition(70, 4);
                            Console.Write("Life of C: " + clife);
                            Console.SetCursorPosition(70, 6);
                            Console.Write("CONGRATULATIONS! P WON THE GAME");
                            for (int k = 0; k < places.GetLength(0); k++)
                            {
                                Console.SetCursorPosition(14, 4 + k);
                                for (int j = 0; j < places.GetLength(1); j++)
                                {
                                    Console.Write(places[k, j] + " ");
                                }

                            }
                            Console.ReadLine();
                        }
                    }
                    else if (places[row2, column2] == 'N')
                    {

                    }
                    else if (places[row2, column2] == 'v')
                    {
                        places[row2, column2] = 'C';
                        row2 = row2 + 3;
                        if (row2 == 12)
                        {
                            row2 = row2 - 1;
                        }
                        else if (row2 == 13)
                        {
                            row2 = row2 - 2;
                        }
                        else if (row2 == 14)
                        {
                            row2 = row2 - 3;
                        }
                        places[row2, column2] = 'C';
                    }
                    else if (places[row2, column2] == '^')
                    {
                        places[row2, column2] = 'C';
                        row2 = row2 - 3;
                        if (row2 == -1)
                        {
                            row2 = row2 + 1;
                        }
                        else if (row2 == -2)
                        {
                            row2 = row2 + 2;
                        }
                        else if (row2 == -3)
                        {
                            row2 = row2 + 3;
                        }
                        places[row2, column2] = 'C';
                    }
                    places[row2, column2] = 'C';
                    for (int c = 0; c < rewards3.Length; c++)
                    {
                        places[places2[c], places3[c]] = rewards3[c];
                    }
                    places[row2, column2] = 'C';
                    if (row == -1 && column == -1)
                    {

                    }
                    else
                    {
                        places[row, column] = 'P';

                    }
                    for (int k = 0; k < places.GetLength(0); k++)
                    {
                        Console.SetCursorPosition(14, 4 + k);
                        for (int j = 0; j < places.GetLength(1); j++)
                        {
                            Console.Write(places[k, j] + " ");
                        }

                    }
                    round++;
                }



























            }
                Console.ReadLine();
            
        }

            }

        }

