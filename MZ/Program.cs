using System;
using System.Media;
using MZ.Properties;

class GameProgram
{
    private static int kristal = 0;
    private static SoundPlayer bg = new SoundPlayer(Resources.bg);
    private static SoundPlayer bg2 = new SoundPlayer(Resources.bg2);
    private static SoundPlayer bg3 = new SoundPlayer(Resources.bg3);
    static void Main()
    {
        Console.Title = "Maze";
        Menu();
    }
    static void Loka3()
    {
        Console.Clear();
        Console.CursorVisible = false;
        int napr = 0, strok = 5, kolon = 5, temp = 0, kartax=11, kartay = 11, schet = 1;
        bool exit = false, rest = false, proh = false;
        int[] password = { 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 };
        int[] truepassword = { 7, 3, 5, 8, 1, 2, 6, 4 };
        int[,] Chascop =
        {
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        { 1, 0, 0, 0, 0, 9, 0, 0, 0, 0, 1, 0, 0, 0, 0, 9, 0, 0, 0, 0, 1},
        { 1, 0, 0, 9, 0, 0, 0, 9, 0, 0, 1, 0, 0, 9, 0, 0, 0, 9, 0, 0, 1},
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        { 1, 0, 9, 0, 0, 7, 0, 0, 9, 0, 1, 0, 9, 0, 0, 0, 0, 0, 9, 0, 1},
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        { 1, 0, 0, 9, 0, 0, 0, 9, 0, 0, 1, 0, 0, 9, 0, 0, 0, 9, 0, 0, 1},
        { 1, 0, 0, 0, 0, 9, 0, 0, 0, 0, 1, 0, 0, 0, 0, 9, 0, 0, 0, 0, 1},
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
        { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 1, 0, 0, 0, 0, 9, 0, 0, 0, 0, 1},
        { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 1, 0, 0, 9, 0, 0, 0, 9, 0, 0, 1},
        { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 1, 0, 9, 0, 0, 0, 0, 0, 9, 0, 1},
        { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 1, 0, 0, 9, 0, 0, 0, 9, 0, 0, 1},
        { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 1, 0, 0, 0, 0, 9, 0, 0, 0, 0, 1},
        { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
        { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}
        };
        int[,] Chas =
        {
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        { 1, 0, 0, 0, 0, 9, 0, 0, 0, 0, 1, 0, 0, 0, 0, 9, 0, 0, 0, 0, 1},
        { 1, 0, 0, 9, 0, 0, 0, 9, 0, 0, 1, 0, 0, 9, 0, 0, 0, 9, 0, 0, 1},
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        { 1, 0, 9, 0, 0, 7, 0, 0, 9, 0, 1, 0, 9, 0, 0, 0, 0, 0, 9, 0, 1},
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        { 1, 0, 0, 9, 0, 0, 0, 9, 0, 0, 1, 0, 0, 9, 0, 0, 0, 9, 0, 0, 1},
        { 1, 0, 0, 0, 0, 9, 0, 0, 0, 0, 1, 0, 0, 0, 0, 9, 0, 0, 0, 0, 1},
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
        { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 1, 0, 0, 0, 0, 9, 0, 0, 0, 0, 1},
        { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 1, 0, 0, 9, 0, 0, 0, 9, 0, 0, 1},
        { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 1, 0, 9, 0, 0, 0, 0, 0, 9, 0, 1},
        { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 1, 0, 0, 9, 0, 0, 0, 9, 0, 0, 1},
        { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 1, 0, 0, 0, 0, 9, 0, 0, 0, 0, 1},
        { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
        { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1},
        { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 1, 0, 0, 0, 0, 2, 0, 0, 0, 0, 1},
        { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1},
        { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}
        };
        while (exit == false)
        {
            if (rest == true)
            {
                Console.Clear();
                for (int o = 0; o < kartay; o++)
                {
                    for (int i = 0; i < kartax; i++)
                    {
                        Chas[o, i] = Chascop[o, i];
                    }
                }
                rest = false;
                for (int i = 0; i < 8 ; i++) { password[i] = 0; }
                strok = 5; kolon = 5;
                schet = 1;
                temp = 0;
                kartay = 11;
                kartax = 11;
                password = new[] { 0, 0, 0, 0, 0, 0, 0, 0 };
                truepassword = new[] { 7, 3, 5, 8, 1, 2, 6, 4 };
            }

            for (int o = 0; o < kartay; o++)
            {
                for (int i = 0; i < kartax; i++)
                {
                    if (Chas[o, i] == 0)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.Write(" ");
                        Console.ResetColor();
                    }
                    else if (Chas[o, i] == 1)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.Write(" ");
                        Console.ResetColor();
                    }
                    else if (Chas[o, i] == 2)
                    {
                        Console.BackgroundColor = ConsoleColor.Magenta;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("♦");
                        Console.ResetColor();
                    }
                    else if (Chas[o, i] == 8)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.Write(" ");
                        Console.ResetColor();
                    }
                    else if (Chas[o, i] == 9)
                    {
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        Console.Write(" ");
                        Console.ResetColor();
                    }
                    else if (Chas[o, i] == 7)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("☺");
                        Console.ResetColor();
                    }
                    else if (Chas[o, i] == 6)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(" ");
                        Console.ResetColor();
                    }
                }
                Console.WriteLine();
            }
            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    napr = 1;
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    napr = 2;
                    break;
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    napr = 3;
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    napr = 4;
                    break;
            }
            if (napr == 1)
            {
                if (kolon - 1 > 0 && (Chas[strok, kolon - 1] == 0 || Chas[strok, kolon - 1] == 8 || Chas[strok, kolon - 1] == 9))
                {
                    Chas[strok, kolon] = temp;
                    temp = Chas[strok, kolon - 1];
                    kolon--;
                    Chas[strok, kolon] = 7;
                }
                else if (kolon - 1 > 0 && (Chas[strok, kolon - 1] == 2)) { kristal++; Console.Clear(); bg3.Stop(); Game(); }
            }
            if (napr == 2)
            {
                if (kolon + 1 < 20 && (Chas[strok, kolon + 1] == 0 || Chas[strok, kolon + 1] == 8 || Chas[strok, kolon + 1] == 9))
                {
                    Chas[strok, kolon] = temp;
                    temp = Chas[strok, kolon + 1];
                    kolon++;
                    Chas[strok, kolon] = 7;
                }
                else if (kolon + 1 < 20 && (Chas[strok, kolon + 1] == 2)) { kristal++; Console.Clear(); bg3.Stop(); Game(); }
            }
            if (napr == 3)
            {
                if (strok - 1 > 0 && (Chas[strok - 1, kolon] == 0 || Chas[strok - 1, kolon] == 8 || Chas[strok - 1, kolon] == 9))
                {
                    Chas[strok, kolon] = temp;
                    temp = Chas[strok - 1, kolon];
                    strok--;
                    Chas[strok, kolon] = 7;
                }
                else if (strok - 1 > 0 && (Chas[strok - 1, kolon] == 2)) { kristal++; Console.Clear(); bg3.Stop(); Game(); }
            }
            if (napr == 4)
            {
                if (strok + 1 < 30 && (Chas[strok + 1, kolon] == 0  || Chas[strok + 1, kolon] == 8 || Chas[strok + 1, kolon] == 9))
                {
                    Chas[strok, kolon] = temp;
                    temp = Chas[strok + 1, kolon];
                    strok++;
                    Chas[strok, kolon] = 7;
                }
                else if (strok + 1 < 30 && (Chas[strok + 1, kolon] == 2)) { kristal++; Console.Clear(); bg3.Stop(); Game(); }
            }
            if (kolon < 11 && strok < 11)
            {
                if (temp == 9 && (kolon == 5 && strok == 2)) { password[0] = schet; if (password[0] == truepassword[0]) { schet++; temp = 8; } else { rest = true; } }
                else if (temp == 9 && (kolon == 7 && strok == 3)) { password[1] = schet; if (password[1] == truepassword[1]) { schet++; temp = 8; } else { rest = true; } }
                else if (temp == 9 && (kolon == 8 && strok == 5)) { password[2] = schet; if (password[2] == truepassword[2]) { schet++; temp = 8; } else { rest = true; } }
                else if (temp == 9 && (kolon == 7 && strok == 7)) { password[3] = schet; if (password[3] == truepassword[3]) { schet++; temp = 8; } else { rest = true; } }
                else if (temp == 9 && (kolon == 5 && strok == 8)) { password[4] = schet; if (password[4] == truepassword[4]) { schet++; temp = 8; } else { rest = true; } }
                else if (temp == 9 && (kolon == 3 && strok == 7)) { password[5] = schet; if (password[5] == truepassword[5]) { schet++; temp = 8; } else { rest = true; } }
                else if (temp == 9 && (kolon == 2 && strok == 5)) { password[6] = schet; if (password[6] == truepassword[6]) { schet++; temp = 8; } else { rest = true; } }
                else if (temp == 9 && (kolon == 3 && strok == 3)) { password[7] = schet; if (password[7] == truepassword[7]) { schet++; temp = 8; } else { rest = true; } }
                if (proh == false)
                {
                    for (int i = 0; i < password.Length; i++) { if (password[i] == 0) { proh = false; break; } else { proh = true; } }
                    if (proh == true)
                    {
                        Chas[5, 10] = 0;
                        kartax = 21;
                        schet = 1;
                        truepassword = new[] { 6, 5, 8, 1, 4, 7, 3, 2 };
                        password = new[] { 0, 0, 0, 0, 0, 0, 0, 0 };
                        proh = false;
                    }
                }
            }
            else if (kolon > 11 && strok < 11)
            {
                if (temp == 9 && (kolon == 15 && strok == 2)) { password[0] = schet; if (password[0] == truepassword[0]) { schet++; temp = 8; } else { rest = true; } }
                else if (temp == 9 && (kolon == 17 && strok == 3)) { password[1] = schet; if (password[1] == truepassword[1]) { schet++; temp = 8; } else { rest = true; } }
                else if (temp == 9 && (kolon == 18 && strok == 5)) { password[2] = schet; if (password[2] == truepassword[2]) { schet++; temp = 8; } else { rest = true; } }
                else if (temp == 9 && (kolon == 17 && strok == 7)) { password[3] = schet; if (password[3] == truepassword[3]) { schet++; temp = 8; } else { rest = true; } }
                else if (temp == 9 && (kolon == 15 && strok == 8)) { password[4] = schet; if (password[4] == truepassword[4]) { schet++; temp = 8; } else { rest = true; } }
                else if (temp == 9 && (kolon == 13 && strok == 7)) { password[5] = schet; if (password[5] == truepassword[5]) { schet++; temp = 8; } else { rest = true; } }
                else if (temp == 9 && (kolon == 12 && strok == 5)) { password[6] = schet; if (password[6] == truepassword[6]) { schet++; temp = 8; } else { rest = true; } }
                else if (temp == 9 && (kolon == 13 && strok == 3)) { password[7] = schet; if (password[7] == truepassword[7]) { schet++; temp = 8; } else { rest = true; } }
                if (proh == false)
                {
                    for (int i = 0; i < password.Length; i++) { if (password[i] == 0) { proh = false; break; } else { proh = true; } }
                    if (proh == true)
                    {
                        Chas[10, 15] = 0;
                        kartay = 21;
                        schet = 1;
                        truepassword = new[] { 1, 4, 6, 5, 3, 8, 7, 2 };
                        password = new[] { 0, 0, 0, 0, 0, 0, 0, 0 };
                        proh = false;
                    }
                }
            }
            else if (kolon > 11 && strok > 11)
            {
                if (temp == 9 && (kolon == 15 && strok == 12)) { password[0] = schet; if (password[0] == truepassword[0]) { schet++; temp = 8; } else { rest = true; } }
                else if (temp == 9 && (kolon == 17 && strok == 13)) { password[1] = schet; if (password[1] == truepassword[1]) { schet++; temp = 8; } else { rest = true; } }
                else if (temp == 9 && (kolon == 18 && strok == 15)) { password[2] = schet; if (password[2] == truepassword[2]) { schet++; temp = 8; } else { rest = true; } }
                else if (temp == 9 && (kolon == 17 && strok == 17)) { password[3] = schet; if (password[3] == truepassword[3]) { schet++; temp = 8; } else { rest = true; } }
                else if (temp == 9 && (kolon == 15 && strok == 18)) { password[4] = schet; if (password[4] == truepassword[4]) { schet++; temp = 8; } else { rest = true; } }
                else if (temp == 9 && (kolon == 13 && strok == 17)) { password[5] = schet; if (password[5] == truepassword[5]) { schet++; temp = 8; } else { rest = true; } }
                else if (temp == 9 && (kolon == 12 && strok == 15)) { password[6] = schet; if (password[6] == truepassword[6]) { schet++; temp = 8; } else { rest = true; } }
                else if (temp == 9 && (kolon == 13 && strok == 13)) { password[7] = schet; if (password[7] == truepassword[7]) { schet++; temp = 8; } else { rest = true; } }
                if (proh == false)
                {
                    for (int i = 0; i < password.Length; i++) { if (password[i] == 0) { proh = false; break; } else { proh = true; } }
                    if (proh == true)
                    {
                        Chas[20, 15] = 0;
                        kartay = 31;
                    }
                }
            }
            Console.SetCursorPosition(0, 0);
        }
    }
        static void Loka2()
    {
        bg3.PlayLooping();
        Console.Clear();
        Console.CursorVisible = false;
        int napr = 0, strok = 24, kolon = 1, temp = 0;
        bool exit = false;
        int[,] lab =
            {
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
        { 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1},
        { 1, 0, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1, 0, 1, 0, 1, 1, 1, 0, 1, 0, 1, 1, 0, 1, 1, 1, 0, 1, 0, 1},
        { 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 1},
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 0, 1, 0, 1},
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 1},
        { 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 0, 0, 1, 0, 1},
        { 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 1},
        { 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 1},
        { 1, 0, 1, 0, 1, 0, 1, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 1},
        { 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 0, 1},
        { 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 1, 1, 0, 1},
        { 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 1, 0, 0, 0, 1},
        { 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1},
        { 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 0, 1, 0, 1, 0, 1, 1, 0, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 0, 1, 1, 1},
        { 1, 1, 1, 1, 1, 0, 1, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 1, 1, 0, 1, 0, 1, 0, 0, 0, 1, 1, 1, 0, 0, 0, 1},
        { 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 1, 1, 1, 0, 2},
        { 1, 0, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 0, 0, 1, 1, 1},
        { 1, 0, 1, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 1, 1, 0, 0, 0, 1},
        { 1, 0, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 0, 1},
        { 1, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1},
        { 1, 0, 1, 0, 0, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1},
        { 1, 0, 0, 0, 1, 1, 1, 0, 0, 0, 1, 1, 1, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        { 1, 1, 1, 1, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1},
        { 2, 7, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        { 1, 0, 1, 1, 1, 1, 1, 0, 0, 0, 1, 0, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 0, 1, 1},
        { 1, 0, 1, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1},
        { 1, 0, 1, 0, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1},
        { 1, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1},
        { 1, 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
        { 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        { 1, 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 0, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1},
        { 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 1},
        { 1, 0, 1, 0, 1, 1, 1, 0, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 0, 1, 0, 1, 1, 0, 1, 0, 1, 0, 1, 1, 1, 0, 1},
        { 1, 0, 1, 0, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1},
        { 1, 0, 1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 0, 1},
        { 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1},
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}
        };
        
        while (exit == false)
        {
            Console.SetCursorPosition(0, 0);
            for (int u = 0; u < 38; u++)
            {
                for (int p = 0; p < 38; p++)
                {
                    if (lab[u, p] == 7)
                    {
                        for (int o = -1; o < 2; o++)
                        {
                            for (int i = -1; i < 2; i++)
                            {
                                if (u + o >= 0 && u + o < 38 && p + i >= 0 && p + i < 38 && lab[u + o, p + i] == 0)
                                {
                                    Console.SetCursorPosition( p + i,u + o);
                                    Console.BackgroundColor = ConsoleColor.Gray;
                                    Console.Write(" ");
                                    Console.ResetColor();
                                }
                                else if (u + o >= 0 && u + o < 38 && p + i >= 0 && p + i < 38 && lab[u + o, p + i] == 2)
                                {
                                    Console.SetCursorPosition(p + i, u + o);
                                    Console.BackgroundColor = ConsoleColor.Magenta;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.Write("♦");
                                    Console.ResetColor();
                                }
                                else if (u + o >= 0 && u + o < 38 && p + i >= 0 && p + i < 38 && lab[u + o, p + i] == 1)
                                {
                                    Console.SetCursorPosition(p + i, u + o);
                                    Console.BackgroundColor = ConsoleColor.DarkGray;
                                    Console.Write(" ");
                                    Console.ResetColor();
                                }
                                else if (u + o >= 0 && u + o < 38 && p + i >= 0 && p + i < 38 && lab[u + o, p + i] == 7)
                                {
                                    Console.SetCursorPosition(p + i, u + o);
                                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.Write("☺");
                                    Console.ResetColor();
                                }
                            }
                        }
                    }
                    else { Console.SetCursorPosition(p, u);}
                }
            }
            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    napr = 1;
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    napr = 2;
                    break;
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    napr = 3;
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    napr = 4;
                    break;
            }
            if (napr == 1)
            {
                if (kolon - 1 >= 0 && lab[strok, kolon - 1] == 0)
                {
                    lab[strok, kolon] = temp;
                    temp = lab[strok, kolon - 1];
                    kolon--;
                    lab[strok, kolon] = 7;
                }
                else if (kolon - 1 >= 0 && lab[strok, kolon - 1] == 2) { Console.BackgroundColor = ConsoleColor.Blue; Console.ForegroundColor = ConsoleColor.Black; Console.SetCursorPosition(3 , 24); Console.WriteLine("Проход заволило, надо найти другой выход"); Console.ResetColor(); Console.ReadKey(true); Console.Clear(); }
            }
            if (napr == 2)
            {
                if (kolon + 1 < 38 && lab[strok, kolon + 1] == 0)
                {
                    lab[strok, kolon] = temp;
                    temp = lab[strok, kolon + 1];
                    kolon++;
                    lab[strok, kolon] = 7;
                }
                else if (kolon + 1 < 38 && lab[strok, kolon + 1] == 2) {Loka3(); }
            }
            if (napr == 3)
            {
                if (strok - 1 >= 0 && lab[strok - 1, kolon] == 0)
                {
                    lab[strok, kolon] = temp;
                    temp = lab[strok - 1, kolon];
                    strok--;
                    lab[strok, kolon] = 7;
                }
            }
            if (napr == 4)
            {
                if (strok + 1 < 38 && lab[strok + 1, kolon] == 0)
                {
                    lab[strok, kolon] = temp;
                    temp = lab[strok + 1, kolon];
                    strok++;
                    lab[strok, kolon] = 7;
                }
            }
        }
    }
    static void Loka1()
    {
        bg2.PlayLooping();
        Console.Clear();
        Console.CursorVisible = false;
        bool exit = false;
        int napr = 0, strok = 5, kolon = 2, temp = 3, schet = 22, life = 5, chekx = 19;
        int[,] map =
            {
        { 0, 0, 0, 0, 0, 4, 1, 1, 1, 1, 8, 8, 8, 8, 8, 8, 8, 8, 4, 8, 0, 0, 0, 0, 0, 0, 0, 0, 1, 8, 1, 3, 3, 3, 1, 1, 1},
        { 0, 0, 0, 0, 4, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 4, 8, 4, 8, 1, 0, 0, 0, 0, 0, 1, 1, 1, 4, 3, 4, 3, 4, 1, 4},
        { 0, 0, 0, 0, 4, 4, 8, 3, 3, 3, 3, 3, 3, 8, 1, 1, 1, 8, 8, 1, 4, 8, 8, 1, 1, 1, 8, 1, 8, 8, 4, 3, 4, 3, 1, 3, 9},
        { 0, 0, 0, 4, 8, 8, 8, 3, 8, 8, 8, 8, 3, 1, 8, 8, 8, 4, 4, 1, 1, 1, 1, 8, 3, 3, 3, 3, 4, 3, 3, 3, 0, 3, 3, 3, 4},
        { 0, 0, 2, 8, 1, 1, 8, 3, 8, 1, 4, 1, 3, 1, 1, 8, 8, 4, 4, 1, 8, 1, 3, 3, 3, 1, 4, 3, 4, 3, 4, 8, 0, 0, 1, 1, 1},
        { 8, 8, 7, 8, 1, 1, 8, 3, 4, 1, 1, 4, 3, 1, 1, 1, 1, 4, 4, 1, 1, 8, 3, 1, 1, 8, 1, 3, 3, 3, 4, 1, 1, 0, 4, 1, 4},
        { 1, 8, 3, 8, 8, 8, 3, 3, 1, 8, 1, 1, 3, 4, 1, 1, 1, 8, 4, 8, 8, 8, 3, 1, 8, 1, 1, 4, 3, 4, 8, 1, 4, 0, 0, 1, 1},
        { 1, 8, 3, 8, 8, 8, 3, 8, 1, 1, 1, 1, 3, 1, 1, 1, 3, 3, 6, 3, 3, 3, 3, 1, 1, 4, 3, 3, 3, 4, 1, 1, 1, 1, 0, 0, 4},
        { 1, 8, 3, 3, 3, 3, 3, 8, 1, 0, 0, 1, 3, 1, 1, 4, 3, 8, 8, 1, 8, 1, 1, 1, 4, 1, 1, 1, 4, 3, 1, 3, 3, 1, 1, 1, 1},
        { 1, 8, 8, 8, 8, 8, 8, 8, 1, 0, 0, 1, 3, 1, 1, 1, 3, 8, 4, 1, 1, 8, 1, 1, 8, 1, 3, 3, 1, 3, 4, 1, 3, 8, 1, 1, 4},
        { 1, 1, 8, 8, 8, 8, 1, 1, 1, 1, 1, 1, 3, 3, 3, 3, 3, 4, 1, 0, 8, 1, 1, 8, 8, 4, 1, 1, 8, 8, 4, 1, 3, 3, 3, 3, 9},
        { 8, 8, 8, 8, 8, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 8, 4, 1, 0, 0, 8, 1, 1, 8, 1, 8, 8, 1, 4, 1, 1, 1, 8, 8, 4, 4},
        };
        while (exit == false)
        {
            for (int y = 0; y < 12; y++)
            {
                for (int x = 0; x < chekx; x++)
                {
                    if (map[y, x] == 0)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("~");
                        Console.ResetColor();
                    }
                    else if (map[y, x] == 2)
                    {
                        Console.BackgroundColor = ConsoleColor.Magenta;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("♦");
                        Console.ResetColor();
                    }
                    else if (map[y, x] == 6)
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("♦");
                        Console.ResetColor();
                    }
                    else if (map[y, x] == 9)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("♦");
                        Console.ResetColor();
                    }
                    else if (map[y, x] == 3)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(" ");
                        Console.ResetColor();
                    }
                    else if (map[y, x] == 4)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("▲");
                        Console.ResetColor();
                    }
                    else if (map[y, x] == 5)
                    {
                        Console.Write(schet);
                    }
                    else if (map[y, x] == 1)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("♠");
                        Console.ResetColor();
                    }
                    else if (map[y, x] == 7)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("☺");
                        Console.ResetColor();
                    }
                    else if (map[y, x] == 8)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("„");
                        Console.ResetColor();
                    }
                }
                Console.WriteLine();
            }
            Console.SetCursorPosition(0, 12); Console.Write("     "); Console.SetCursorPosition(0, 12);
            for (int i = 0; i < life; i++) { Console.ForegroundColor = ConsoleColor.Red; Console.Write("♥"); Console.ResetColor(); }
            if (life == 0) { Console.WriteLine("Вы погибли, попробуйте еще раз"); Console.ReadKey(true); Console.Clear(); Loka1(); }
            Console.SetCursorPosition(9, 12); Console.WriteLine($"{schet} ");
            if (schet == 0) { Console.WriteLine("Ходы закончились, попробуйте еще раз"); Console.ReadKey(true); Console.Clear(); Loka1(); }
            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    napr = 1;
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    napr = 2;
                    break;
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    napr = 3;
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    napr = 4;
                    break;
            }
            if (napr == 1)
            {
                if (kolon - 1 >= 0 && map[strok, kolon - 1] != 0 && map[strok, kolon - 1] != 4 && map[strok, kolon - 1] != 2 && map[strok, kolon - 1] != 1)
                {
                    map[strok, kolon] = temp;
                    temp = map[strok, kolon - 1];
                    kolon--;
                    schet--;
                    map[strok, kolon] = 7;
                }
                else if (kolon - 1 >= 0 && map[strok, kolon - 1] != 0 && map[strok, kolon - 1] != 4 && map[strok, kolon - 1] == 2 && map[strok, kolon - 1] != 1)
                {
                    Console.Clear();
                    Game();
                }
                else if (kolon - 1 >= 0 && map[strok, kolon - 1] != 0 && map[strok, kolon - 1] == 1)
                {
                    map[strok, kolon] = temp;
                    temp = map[strok, kolon - 1];
                    kolon--;
                    schet--;
                    map[strok, kolon] = 7;
                    life--;
                }
            }
            if (napr == 2)
            {
                if (kolon + 1 < chekx && map[strok, kolon + 1] != 0 && map[strok, kolon + 1] != 4 && map[strok, kolon + 1] != 2 && map[strok, kolon + 1] != 1 && map[strok, kolon + 1] != 6 && map[strok, kolon + 1] != 9)
                {
                    map[strok, kolon] = temp;
                    temp = map[strok, kolon + 1];
                    kolon++;
                    schet--;
                    map[strok, kolon] = 7;
                }
                else if (kolon + 1 < chekx && map[strok, kolon + 1] != 0 && map[strok, kolon + 1] != 4 && map[strok, kolon + 1] != 1 && map[strok, kolon + 1] == 6)
                {
                    map[strok, kolon] = temp;
                    temp = map[strok, kolon + 1];
                    kolon++;
                    map[strok, kolon] = 7;
                    chekx = 37;
                    life = 5;
                    schet = 31;
                }
                else if (kolon + 1 < chekx && map[strok, kolon + 1] != 0 && map[strok, kolon + 1] != 4 && map[strok, kolon + 1] != 1 && map[strok, kolon + 1] == 9)
                {
                    if (strok == 2 && kolon + 1 == 36) { Console.WriteLine("Проход в шахту завален, ищите другой вход!"); }
                    else { Loka2(); bg2.Stop(); }
                }
                else if (kolon + 1 < chekx && map[strok, kolon + 1] != 0 && map[strok, kolon + 1] == 1)
                {
                    map[strok, kolon] = temp;
                    temp = map[strok, kolon + 1];
                    kolon++;
                    schet--;
                    map[strok, kolon] = 7;
                    life--;
                }
            }
            if (napr == 3)
            {
                if (strok - 1 >= 0 && map[strok - 1, kolon] != 0 && map[strok - 1, kolon] != 4 && map[strok - 1, kolon] != 2 && map[strok - 1, kolon] != 1)
                {
                    map[strok, kolon] = temp;
                    temp = map[strok - 1, kolon];
                    strok--;
                    schet--;
                    map[strok, kolon] = 7;
                }
                else if (strok - 1 >= 0 && map[strok - 1, kolon] != 0 && map[strok - 1, kolon] != 4 && map[strok - 1, kolon] == 2 && map[strok - 1, kolon] != 1)
                {
                    Console.Clear();
                    Game();
                }
                else if (strok - 1 >= 0 && map[strok - 1, kolon] != 0 && map[strok - 1, kolon] == 1)
                {
                    map[strok, kolon] = temp;
                    temp = map[strok - 1, kolon];
                    strok--;
                    schet--;
                    map[strok, kolon] = 7;
                    life--;
                }
            }
            if (napr == 4)
            {
                if (strok + 1 < 12 && map[strok + 1, kolon] != 0 && map[strok + 1, kolon] != 4 && map[strok + 1, kolon] != 2 && map[strok + 1, kolon] != 1)
                {
                    map[strok, kolon] = temp;
                    temp = map[strok + 1, kolon];
                    strok++;
                    schet--;
                    map[strok, kolon] = 7;
                }
                else if (strok + 1 < 12 && map[strok + 1, kolon] != 0 && map[strok + 1, kolon] != 4 && map[strok + 1, kolon] == 2 && map[strok + 1, kolon] != 1)
                {
                    Console.Clear();
                    Game();
                }
                else if (strok + 1 < 12 && map[strok + 1, kolon] != 0 && map[strok + 1, kolon] == 1)
                {
                    map[strok, kolon] = temp;
                    temp = map[strok + 1, kolon];
                    strok++;
                    schet--;
                    map[strok, kolon] = 7;
                    life--;
                }
            }
            Console.SetCursorPosition(0, 0);
        }
    }
    static void Game()
    {
        bg.PlayLooping();
        Console.CursorVisible = false;
        bool exit = false, dialog = false, dialog1 = false;
        int napr = 0, strok = 7, kolon = 21, temp = 4, money = 250;
        int[,] town =
            {
        { 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 5, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 5, 5, 5, 1, 1, 1, 1, 1, 5, 5, 5, 1, 1, 1 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 5, 5, 5, 5, 5, 1, 1, 1, 5, 5, 5, 5, 5, 1, 1 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 1, 5, 3, 3, 3, 3, 3, 5, 1, 5, 3, 3, 3, 3, 3, 5, 1 },
        { 0, 0, 0, 0, 2, 2, 0, 0, 1, 1, 3, 9, 3, 9, 3, 1, 1, 1, 3, 6, 3, 6, 3, 1, 1 },
        { 0, 0, 0, 0, 2, 2, 0, 0, 1, 1, 3, 3, 3, 9, 3, 1, 1, 1, 3, 3, 3, 6, 3, 1, 1 },
        { 0, 2, 0, 0, 2, 0, 0, 2, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4 },
        { 0, 0, 2, 2, 2, 2, 2, 0, 8, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 7, 4, 4, 4 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4 }
        };
        while (exit == false)
        {
            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 24; x++)
                {
                    if (town[y, x] == 0)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.Write(" ");
                        Console.ResetColor();
                    }
                    else if (town[y, x] == 2)
                    {
                        Console.BackgroundColor = ConsoleColor.Magenta;
                        Console.Write(" ");
                        Console.ResetColor();
                    }
                    else if (town[y, x] == 3)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.Write(" ");
                        Console.ResetColor();
                    }
                    else if (town[y, x] == 4)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.Write(" ");
                        Console.ResetColor();
                    }
                    else if (town[y, x] == 5)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.Write(" ");
                        Console.ResetColor();
                    }
                    else if (town[y, x] == 9)
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.Write(" ");
                        Console.ResetColor();
                    }
                    else if (town[y, x] == 1)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.Write(" ");
                        Console.ResetColor();
                    }
                    else if (town[y, x] == 6)
                    {
                        Console.Write(" ");
                    }
                    else if (town[y, x] == 7)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("☺");
                        Console.ResetColor();
                    }
                    else if (town[y, x] == 8)
                    {
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("☻");
                        Console.ResetColor();
                    }
                }
                Console.WriteLine();
            }
            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    napr = 1;
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    napr = 2;
                    break;
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    napr = 3;
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    napr = 4;
                    break;
            }
            if (napr == 1)
            {
                if (kolon - 1 >= 8 && town[strok, kolon - 1] != 8)
                {
                    town[strok, kolon] = temp;
                    temp = town[strok, kolon - 1];
                    kolon--;
                    town[strok, kolon] = 7;
                }
                else if (kolon - 1 >= 8 && town[strok, kolon - 1] == 8) { dialog = true; }
            }
            if (napr == 2)
            {
                if (kolon + 1 < 24 && town[strok, kolon + 1] != 8)
                {
                    town[strok, kolon] = temp;
                    temp = town[strok, kolon + 1];
                    kolon++;
                    town[strok, kolon] = 7;
                }
                else if (kolon + 1 < 24 && town[strok, kolon + 1] == 8) { dialog = true; }
                else if (kolon + 1 >= 24) { bg.Stop(); Loka1(); }
            }
            if (napr == 3)
            {
                if (strok - 1 >= 6 && town[strok - 1, kolon] != 8)
                {
                    town[strok, kolon] = temp;
                    temp = town[strok - 1, kolon];
                    strok--;
                    town[strok, kolon] = 7;
                }
                else if (strok - 1 >= 6 && town[strok - 1, kolon] == 8) { dialog = true; }
                else if (strok - 1 >= 5 && kolon == 13 && town[strok - 1, kolon] == 9) { dialog1 = true; }
            }
            if (napr == 4)
            {
                if (strok + 1 < 9 && town[strok + 1, kolon] != 8)
                {
                    town[strok, kolon] = temp;
                    temp = town[strok + 1, kolon];
                    strok++;
                    town[strok, kolon] = 7;
                }
                else if (strok + 1 < 9 && town[strok + 1, kolon] == 8) { dialog = true; }
            }
            if (dialog == true)
            {
                bool Ex = false;
                int vibor = 0, buf = 0;
                napr = 0;
                Console.WriteLine($"Билет на корабль стоит 1000 монет. У вас есть: {money} монет.");
                Console.WriteLine("Хотите приобрести?");
                Console.WriteLine("Да   ^   Нет");
                while (Ex == false)
                {
                    ConsoleKeyInfo vib = Console.ReadKey(true);
                    switch (vib.Key)
                    {
                        case ConsoleKey.LeftArrow:
                        case ConsoleKey.A:
                            napr = 1;
                            break;
                        case ConsoleKey.RightArrow:
                        case ConsoleKey.D:
                            napr = 2;
                            break;
                    }
                    if (napr == 1)
                    {
                        Console.SetCursorPosition(5, 11);
                        Console.WriteLine("<");
                        vibor = 1;
                    }
                    else if (napr == 2)
                    {
                        Console.SetCursorPosition(5, 11);
                        Console.WriteLine(">");
                        vibor = 2;

                    }
                    if (vib.Key.ToString() == "Enter" && vibor != 0)
                    {
                        buf = 1;
                    }
                    if (buf == 1)
                    {
                        if (vibor == 1 && money >= 1000) { Console.SetCursorPosition(0, 12); Console.WriteLine("С вами приятно иметь дело! Заходите на борт, отправляемся! )"); Console.ReadKey(true); bg.Stop(); Menu();}
                        else if (vibor == 1 && money < 1000)
                        {
                            Console.SetCursorPosition(0, 12);
                            Console.WriteLine("Недостаточно средств!"); Console.ReadKey(true);
                            Ex = true;
                        }
                        else if (vibor == 2) { Ex = true; }
                    }
                }
                Console.Clear();
                dialog = false;
            }
            if (dialog1 == true)
            {
                bool Ex = false;
                int vibor = 0, buf = 0;
                napr = 0;
                Console.WriteLine($"Здесь вы можете продать кристаллы, 1 кристалл = 1000 монет. У вас есть: {kristal} кристаллов.");
                Console.WriteLine("Хотите продать?");
                Console.WriteLine("Да   ^   Нет");
                while (Ex == false)
                {
                    ConsoleKeyInfo vib = Console.ReadKey(true);
                    switch (vib.Key)
                    {
                        case ConsoleKey.LeftArrow:
                        case ConsoleKey.A:
                            napr = 1;
                            break;
                        case ConsoleKey.RightArrow:
                        case ConsoleKey.D:
                            napr = 2;
                            break;
                    }
                    if (napr == 1)
                    {
                        Console.SetCursorPosition(5, 11);
                        Console.WriteLine("<");
                        vibor = 1;
                    }
                    else if (napr == 2)
                    {
                        Console.SetCursorPosition(5, 11);
                        Console.WriteLine(">");
                        vibor = 2;

                    }
                    if (vib.Key.ToString() == "Enter" && vibor != 0)
                    {
                        buf = 1;
                    }
                    if (buf == 1)
                    {
                        if (vibor == 1 && kristal >= 1) { Console.SetCursorPosition(0, 12); Console.WriteLine("С вами приятно иметь дело! )"); kristal--; money = money + 1000; Console.ReadKey(true); Ex = true; }
                        else if (vibor == 1 && kristal < 1)
                        {
                            Console.SetCursorPosition(0, 12);
                            Console.WriteLine("Недостаточно средств!"); Console.ReadKey(true);
                            Ex = true;
                        }
                        else if (vibor == 2) { Ex = true; }
                    }
                }
                Console.Clear();
                dialog1 = false;
            }
            Console.SetCursorPosition(0, 0);
        }
    }
    static void Rules() 
    {
        Console.Clear();
        Console.WriteLine("Правила");
        Console.WriteLine("Управление:");
        Console.WriteLine("Передвижение на W, A, S, D или на стрелочки.");
        Console.WriteLine("Что бы выбрать нужный ответ в диалогах нажмите Enter.");
        Console.WriteLine("Предыстория:");
        Console.WriteLine("Вы являетесь жителем городка на охваченном войной континенте и в скором времени на городок наподут демоны,");
        Console.WriteLine("чтобы не стать для них пищей вы должны уплыть на корабле, однако вам не хватает денег на билет, да еще и капитан не может продать билет дешевле");
        Console.WriteLine("так как корабль и так полон людьми, но благо рядом с кораблем есть ювилирная лавка где можно продать кристаллы.");
        Console.WriteLine("Однако и кристаллов у вас нет. Совсем отчаявшись вы ушли в товерну выпить напоследок, там за кружкой пива вам ");
        Console.WriteLine("рассказали про кристалл находящийся в лаберинте на востоке, однако чтобы попасть в лобиринт вам необходимо пройти");
        Console.WriteLine("через очень опасный лес который кишит монстрами, до лабиринта конечно ведет дорога, но она очень длинная, а ночью из леса выходят еще более опасные монстры и без");
        Console.WriteLine("опытного сопровождения наачевать на дороге не представляется возможным. Благо по пути есть деревушка в которой можно переночивать.");
        Console.WriteLine("Мужчина так же рассказал что пройдя лабиринт вы встретите листему защиты кристалла,");
        Console.WriteLine(" она представляет собой несколько комнат в которых нужно ввести пороль нажимая на плиты на полу. Правда если вы не правильно введете пороль, все пройденные комнаты закроются,");
        Console.WriteLine("а вас вернет опять в начало. Именно по этой причине никто еще не забрал кристал.");
        Console.WriteLine("Ну чтож вперед на поиски кристала дабы сохранить свою жизнь!");
        Console.WriteLine();
        Console.WriteLine("Что нужно делать:");
        Console.WriteLine("На пред локации (город) вы можете погулять, поговорить с капитаном или зайти в ювилирную лавку, а потом пойдя напрво начать свое путишествие.");
        Console.WriteLine("На первой локации (лес) вам необходимо пройти по точкам помеченными символом ♦ и попасть в лабиринт.");
        Console.WriteLine("На второй локации вам необходимо пройти лабиринт записывая проход на свою карту.");
        Console.WriteLine("На третей локации необходимо методом подбора найти правильный пороль, правильные пластины будут опускаться вниз и замирать, но если вы ошибетесь в воде, весь прогресс");
        Console.WriteLine("комнат с паролем слетит и вам надо будет все начать занава.");
        Console.WriteLine("После того как вы возьмете кристал вы переместитесь в город, а дальше вам необходимо продать кристал и купить билет на корабль.");
        Console.ReadKey(true);
        Menu(); 
    }
    static void Menu()
    {
        Console.Clear();
        Console.WriteLine("---Меню---");
        Console.WriteLine("1) Играть ");
        Console.WriteLine("2) Правила");
        Console.WriteLine("3) Выйти");
        Console.Write("Ваш выбор: ");
        int vibor = Convert.ToInt32(Console.ReadLine());
        if (vibor == 1) { Console.Clear(); Game(); }
        else if (vibor == 2) { Console.Clear(); Rules(); }
        else if (vibor == 3) { Environment.Exit(0); }
        else if (vibor > 3) { Console.Clear(); Console.WriteLine("Ошибка "); Console.ReadKey(true); Menu(); }
    }
}