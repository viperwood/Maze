using System.Media;
using System.Runtime.InteropServices;
using MZ.Properties;
using System.Linq;
using System.Diagnostics.Metrics;
using System.ComponentModel;

class GameProgram
{
    private static int kristal = 0;
    private static int histori = 0;
    private static SoundPlayer bg = new SoundPlayer(Resources.bg);
    private static SoundPlayer bg2 = new SoundPlayer(Resources.bg2);
    private static SoundPlayer bg3 = new SoundPlayer(Resources.bg3);

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct FontInfo
    {
        internal int cbSize;
        internal int FontIndex;
        internal short FontWidth;
        public short FontSize;
        public int FontFamily;
        public int FontWeight;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string FontName;
    }

    [DllImport("kernel32.dll", ExactSpelling = true)]
    private static extern IntPtr GetConsoleWindow();

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    [DllImport("kernel32.dll", SetLastError = true)]
    static extern IntPtr GetStdHandle(int nStdHandle);

    [return: MarshalAs(UnmanagedType.Bool)]
    [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    internal static extern bool SetCurrentConsoleFontEx(IntPtr hConsoleOutput, bool MaximumWindow, ref FontInfo ConsoleCurrentFontEx);

    static void SetCurrentFont(short fontSize = 26)
    {
        FontInfo set = new FontInfo
        {
            cbSize = Marshal.SizeOf<FontInfo>(),
            FontIndex = 0,
            FontFamily = 54,
            FontName = "Consolas",
            FontWeight = 400,
            FontSize = fontSize
        };
        SetCurrentConsoleFontEx(GetStdHandle(-11), false, ref set);
    }
    static void Main()
    {
        ShowWindow(GetConsoleWindow(), 3);
        SetCurrentFont();
        Console.Title = "Maze";
        Menu();
    }
    static void writeColor(char a, ConsoleColor bg)
    {
        Console.BackgroundColor = bg;
        Console.Write(a);
        Console.ResetColor();
    }
    static void writeColor(char a, ConsoleColor fg, ConsoleColor bg)
    {
        Console.BackgroundColor = bg;
        Console.ForegroundColor = fg;
        Console.Write(a);
        Console.ResetColor();
    }
    
    static void Loka3()
    {
        Console.Clear();
        Console.CursorVisible = false;
        if (histori == 3)
        {
            Console.WriteLine("Вы спустились в часть лабиринта с вводам пароля, необходимо подобрать пароль наступая на нажимные пластины," +
                "если вы нажмете неправильную пластину, вас выкинет в самую первую комнату, а пароль сбросится и придётся вводить все с самого начала. \r\n" +
                "\r\n Нажмите Enter чтобы продолжить...");
            Console.ReadKey(true);
            Console.Clear();
            histori++;
        }
        int strok = 5, kolon = 5, temp = 0, kartax=11, kartay = 11, counter = 0, index=0;
        bool exit = false, rest = false;
        int[,] password = new int[,]
        {
            { 3, 7 },
            { 5, 2 },
            { 8, 5 },
            { 7, 7 },
            { 3, 3 },
            { 5, 8 },
            { 2, 5 },
            { 7, 3 },
            { 15, 8 },
            { 15, 2 },
            { 17, 7 },
            { 13, 3 },
            { 18, 5 },
            { 13, 7 },
            { 12, 5 },
            { 17, 3 },
            { 17, 13 },
            { 13, 17 },
            { 18, 15 },
            { 13, 13 },
            { 15, 18 },
            { 15, 12 },
            { 12, 15 },
            { 17, 17 },
        };
        int[] truepassword = { 7, 3, 5, 8, 1, 2, 6, 4 };
        int[,] caveStart =
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
        int[,] cave =
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
        while (!exit)
        {
            if (rest)
            {
                Console.Clear();
                for (int o = 0; o < kartay; o++)
                {
                    for (int i = 0; i < kartax; i++)
                    {
                        cave[o, i] = caveStart[o, i];
                    }
                }
                rest = false;
                strok = 5; kolon = 5;
                counter = 0;
                temp = 0;
                kartay = 11;
                kartax = 11;
            }

            for (int o = 0; o < kartay; o++)
            {
                for (int i = 0; i < kartax; i++)
                {
                    switch (cave[o, i])
                    {
                        case 0:
                            writeColor(' ', ConsoleColor.Gray);
                            break;
                        case 1:
                            writeColor(' ', ConsoleColor.DarkGray);
                            break;
                        case 2:
                            writeColor('♦', ConsoleColor.Black, ConsoleColor.Magenta);
                            break;
                        case 8:
                            writeColor(' ', ConsoleColor.Blue);
                            break;
                        case 9:
                            writeColor(' ', ConsoleColor.Cyan);
                            break;
                        case 7:
                            writeColor('☺', ConsoleColor.Black, ConsoleColor.DarkYellow);
                            break;
                        case 6:
                            writeColor(' ', ConsoleColor.Black);
                            break;
                    };
                }
                Console.WriteLine();
            }
            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    if (kolon - 1 > 0 && (cave[strok, kolon - 1] == 0 || cave[strok, kolon - 1] == 8 || cave[strok, kolon - 1] == 9))
                    {
                        cave[strok, kolon] = temp;
                        temp = cave[strok, kolon - 1];
                        kolon--;
                        cave[strok, kolon] = 7;
                    }
                    else if (kolon - 1 > 0 && (cave[strok, kolon - 1] == 2))
                    {
                        Console.Clear(); Console.WriteLine("Вы нашли кристалл и вернулись в город дабы продать его и приобрести билет. \r\n" +
                "\r\n Нажмите Enter чтобы продолжить...");
                        Console.ReadKey(true);
                        kristal++;
                        Console.Clear();
                        bg3.Stop();
                        Game();
                    }
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    if (kolon + 1 < 20 && (cave[strok, kolon + 1] == 0 || cave[strok, kolon + 1] == 8 || cave[strok, kolon + 1] == 9))
                    {
                        cave[strok, kolon] = temp;
                        temp = cave[strok, kolon + 1];
                        kolon++;
                        cave[strok, kolon] = 7;
                    }
                    else if (kolon + 1 < 20 && (cave[strok, kolon + 1] == 2))
                    {
                        Console.Clear(); Console.WriteLine("Вы нашли кристалл и вернулись в город дабы продать его и приобрести билет. \r\n" +
                "\r\n Нажмите Enter чтобы продолжить...");
                        Console.ReadKey(true);
                        kristal++;
                        Console.Clear();
                        bg3.Stop();
                        Game();
                    }
                    break;
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    if (strok - 1 > 0 && (cave[strok - 1, kolon] == 0 || cave[strok - 1, kolon] == 8 || cave[strok - 1, kolon] == 9))
                    {
                        cave[strok, kolon] = temp;
                        temp = cave[strok - 1, kolon];
                        strok--;
                        cave[strok, kolon] = 7;
                    }
                    else if (strok - 1 > 0 && (cave[strok - 1, kolon] == 2))
                    {
                        Console.Clear(); Console.WriteLine("Вы нашли кристалл и вернулись в город дабы продать его и приобрести билет. \r\n" +
                "\r\n Нажмите Enter чтобы продолжить...");
                        Console.ReadKey(true);
                        kristal++;
                        Console.Clear();
                        bg3.Stop();
                        Game();
                    }
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    if (strok + 1 < 30 && (cave[strok + 1, kolon] == 0 || cave[strok + 1, kolon] == 8 || cave[strok + 1, kolon] == 9))
                    {
                        cave[strok, kolon] = temp;
                        temp = cave[strok + 1, kolon];
                        strok++;
                        cave[strok, kolon] = 7;
                    }
                    else if (strok + 1 < 30 && (cave[strok + 1, kolon] == 2))
                    {
                        Console.Clear(); Console.WriteLine("Вы нашли кристалл и вернулись в город дабы продать его и приобрести билет. \r\n" +
                "\r\n Нажмите Enter чтобы продолжить...");
                        Console.ReadKey(true);
                        kristal++;
                        Console.Clear();
                        bg3.Stop();
                        Game();
                    }
                    break;
            }
            bool contains = false;
            for (int i = 0; i < password.GetUpperBound(0) + 1; i++)
            {
                if (password[i, 0] == kolon && password[i, 1] == strok )
                {
                    contains = true;
                    index = i;
                    break;
                }
            }
            if (contains && index>=counter)
            {
                if (password[counter, 0] == kolon && password[counter, 1] == strok)
                {
                    counter++;
                    temp = 8;
                }
                else
                {
                    rest = true;
                }
            }
            if (counter == 8 && kolon != 10 && strok != 5)
            {
                cave[5, 10] = 0;
                kartax = 21;
            }
            else if (counter == 16 && kolon != 15 && strok != 10)
            {
                cave[10, 15] = 0;
                kartay = 21;
            }
            else if (counter == 24 && kolon != 15 && strok != 20)
            {
                cave[20, 15] = 0;
                kartay = 31;
            }
            Console.SetCursorPosition(0, 0);
        }
    }
        static void Loka2()
    {
        bg3.PlayLooping();
        Console.Clear();
        if (histori == 2)
        {
            Console.WriteLine("Вы попали в лабиринт, вам необходимо найти выход, ведь вход в лабиринт завалило, как только вы в него зашли, поэтому пути назад нет, \r\n" +
                "есть слух что в последней комнате всегда есть запасной выход. Идти вам уже некуда, так что вперёд. \r\n" +
                "\r\n Нажмите Enter чтобы продолжить...");
            Console.ReadKey(true);
            Console.Clear();
            histori++;
        }
        Console.CursorVisible = false;
        int strok = 24, kolon = 1, temp = 0;
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
                                if (u + o >= 0 && u + o < 38 && p + i >= 0 && p + i < 38)
                                {
                                    switch(lab[u + o, p + i])
                                    {
                                        case 0:
                                            Console.SetCursorPosition(p + i, u + o);
                                            writeColor(' ', ConsoleColor.Gray);
                                            break;
                                        case 2:
                                            Console.SetCursorPosition(p + i, u + o);
                                            writeColor('♦', ConsoleColor.Black, ConsoleColor.Magenta);
                                            break;
                                        case 1:
                                            Console.SetCursorPosition(p + i, u + o);
                                            writeColor(' ', ConsoleColor.DarkGray);
                                            break;
                                        case 7:
                                            Console.SetCursorPosition(p + i, u + o);
                                            writeColor('☺', ConsoleColor.Black, ConsoleColor.DarkYellow);
                                            break;
                                    }
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
                    if (kolon - 1 >= 0 && lab[strok, kolon - 1] == 0)
                    {
                        lab[strok, kolon] = temp;
                        temp = lab[strok, kolon - 1];
                        kolon--;
                        lab[strok, kolon] = 7;
                    }
                    else if (kolon - 1 >= 0 && lab[strok, kolon - 1] == 2)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(40, 24);
                        Console.WriteLine("Проход завалило, надо найти другой выход");
                        Console.ReadKey(true);
                        Console.SetCursorPosition(40, 24);
                        Console.ResetColor();
                        Console.WriteLine("                                        ");
                    }
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    if (kolon + 1 < 38 && lab[strok, kolon + 1] == 0)
                    {
                        lab[strok, kolon] = temp;
                        temp = lab[strok, kolon + 1];
                        kolon++;
                        lab[strok, kolon] = 7;
                    }
                    else if (kolon + 1 < 38 && lab[strok, kolon + 1] == 2) { Loka3(); }
                    break;
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    if (strok - 1 >= 0 && lab[strok - 1, kolon] == 0)
                    {
                        lab[strok, kolon] = temp;
                        temp = lab[strok - 1, kolon];
                        strok--;
                        lab[strok, kolon] = 7;
                    }
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    if (strok + 1 < 38 && lab[strok + 1, kolon] == 0)
                    {
                        lab[strok, kolon] = temp;
                        temp = lab[strok + 1, kolon];
                        strok++;
                        lab[strok, kolon] = 7;
                    }
                    break;
            }
        }
    }
    static void Loka1()
    {
        Console.CursorVisible = false;
        bg2.PlayLooping();
        Console.Clear();
        if (histori == 1)
        {
            Console.WriteLine("Выйдя из города вы попали на дорогу, она ведёт к лабиринту, однако она очень длинная и вам никак не успеть, \r\n" +
                "по этому вам необходимо найти короткую дорогу, через горы (▲) и воду (~) передвигаться вы не можете. \r\n" +
                "Проходя через лес есть большая вероятность встретить монстров и получить раны (♥), вы не бессмертно будьте внимательны. \r\n" +
                "Вам необходимо попасть в безопасную зону (♦) до наступления ночи (количество ходов снизу), так как ночью выходят очень опасные монстры\r\n" +
                "и без сопровождения опытных авантюристов ночевать на открытой местности некоем случае нельзя. Доберитесь до лабиринта, точки проходов отмечены (♦). \r\n" +
                "Удачи в пути! \r\n" +
                "\r\n Нажмите Enter чтобы продолжить...");
            Console.ReadKey(true);
            Console.Clear();
            histori++;
        }
        bool exit = false;
        int strok = 5, kolon = 2, temp = 3, schet = 22, life = 5, chekx = 19;
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
                    switch (map[y, x])
                        {
                        case 0:
                            writeColor('~', ConsoleColor.Black, ConsoleColor.Blue);
                                break;
                        case 2:
                            writeColor('♦', ConsoleColor.Black, ConsoleColor.Magenta);
                                break;
                        case 6:
                            writeColor('♦', ConsoleColor.Black, ConsoleColor.Yellow);
                                break;
                        case 9:
                            writeColor('♦', ConsoleColor.Black, ConsoleColor.DarkGray);
                                break;
                        case 3:
                            writeColor(' ', ConsoleColor.Gray);
                                break;
                        case 4:
                            writeColor('▲', ConsoleColor.Black, ConsoleColor.DarkGray);
                                break;
                        case 5:
                            Console.Write(schet);
                                break;
                        case 1:
                            writeColor('♠', ConsoleColor.Black, ConsoleColor.DarkGreen);
                                break;
                        case 7:
                            writeColor('☺', ConsoleColor.Black, ConsoleColor.DarkYellow);
                                break;
                        case 8:
                            writeColor('„', ConsoleColor.Black, ConsoleColor.Green);
                                break;
                    };
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
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
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
                    break;
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
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
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
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
                    break;
            }
            Console.SetCursorPosition(0, 0);
        }
    }
    static void Game()
    {
        Console.CursorVisible = false;
        if (histori == 0)
        {
            Console.WriteLine("Вы находитесь в городе на которые в скором времени нападёт армия девонов, \r\n" +
                "дабы выжить необходимо уплыть на корабле, однако мест на корабле не хватает. Однако капитан корабля готов продать вам билет за 1000 монет. \r\n" +
                "Такая сумма неподъемна для вас. Разочаровавшись, вы ушли в бар дабы хотя бы выпить в свой последний раз. \r\n" +
                "Усевшись за барную стойку рядом со старцем, вы завили с ним беседу и узнали, что на востоке есть не разграбленный лабиринт. \r\n" +
                "Там по легендам находится довольно дорогой кристалл и местный ювелир готов выкупить его у любого за 1000 монет. \r\n" +
                "Услышав это вы собрались духом, поблагодарили старца и вышли на дорогу к выходу из города, да начнется ваше приключение. \r\n" +
                "\r\n Нажмите Enter чтобы продолжить...");
            Console.ReadKey(true);
            Console.Clear();
            histori++;
        }
        bg.PlayLooping();
        bool exit = false, dialog = false, dialog1 = false;
        int strok = 7, kolon = 21, temp = 4, money = 250;
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
                    switch (town[y, x])
                    { 
                    case 0:
                            writeColor(' ', ConsoleColor.Blue);
                            break;
                    case 2:
                            writeColor(' ', ConsoleColor.Magenta);
                            break;
                    case 3:
                            writeColor(' ', ConsoleColor.Gray);
                            break;
                    case 4:
                            writeColor(' ', ConsoleColor.DarkGray);
                            break;
                    case 5:
                            writeColor(' ', ConsoleColor.DarkRed);
                            break;
                    case 9:
                            writeColor(' ', ConsoleColor.Yellow);
                            break;
                    case 1:
                            writeColor(' ', ConsoleColor.DarkGreen);
                            break;
                    case 6:
                            Console.Write(" ");
                            break;
                    case 7:
                            writeColor('☺', ConsoleColor.Black, ConsoleColor.DarkYellow);
                            break;
                    case 8:
                            writeColor('☻', ConsoleColor.Black, ConsoleColor.Cyan);
                            break;
                    };
                }
                Console.WriteLine();
            }
            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    if (kolon - 1 >= 8 && town[strok, kolon - 1] != 8)
                    {
                        town[strok, kolon] = temp;
                        temp = town[strok, kolon - 1];
                        kolon--;
                        town[strok, kolon] = 7;
                    }
                    else if (kolon - 1 >= 8 && town[strok, kolon - 1] == 8) { dialog = true; }
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    if (kolon + 1 < 24 && town[strok, kolon + 1] != 8)
                    {
                        town[strok, kolon] = temp;
                        temp = town[strok, kolon + 1];
                        kolon++;
                        town[strok, kolon] = 7;
                    }
                    else if (kolon + 1 < 24 && town[strok, kolon + 1] == 8) { dialog = true; }
                    else if (kolon + 1 >= 24) { bg.Stop(); Loka1(); }
                    break;
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    if (strok - 1 >= 6 && town[strok - 1, kolon] != 8)
                    {
                        town[strok, kolon] = temp;
                        temp = town[strok - 1, kolon];
                        strok--;
                        town[strok, kolon] = 7;
                    }
                    else if (strok - 1 >= 6 && town[strok - 1, kolon] == 8) { dialog = true; }
                    else if (strok - 1 >= 5 && kolon == 13 && town[strok - 1, kolon] == 9) { dialog1 = true; }
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    if (strok + 1 < 9 && town[strok + 1, kolon] != 8)
                    {
                        town[strok, kolon] = temp;
                        temp = town[strok + 1, kolon];
                        strok++;
                        town[strok, kolon] = 7;
                    }
                    else if (strok + 1 < 9 && town[strok + 1, kolon] == 8) { dialog = true; }
                    break;
            }
            if (dialog == true)
            {
                bool Ex = false;
                int vibor = 0, buf = 0;
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
                            Console.SetCursorPosition(5, 11);
                            Console.WriteLine("<");
                            vibor = 1;
                            break;
                        case ConsoleKey.RightArrow:
                        case ConsoleKey.D:
                            Console.SetCursorPosition(5, 11);
                            Console.WriteLine(">");
                            vibor = 2;
                            break;
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
                            Console.SetCursorPosition(5, 11);
                            Console.WriteLine("<");
                            vibor = 1;
                            break;
                        case ConsoleKey.RightArrow:
                        case ConsoleKey.D:
                            Console.SetCursorPosition(5, 11);
                            Console.WriteLine(">");
                            vibor = 2;
                            break;
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
                            Console.WriteLine("Недостаточно кристалов!"); Console.ReadKey(true);
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
        Console.WriteLine("Правила: \r\n" +
            "Главное правило, не использовать бумагу и карандаш, другие средства записи. \r\n" +
            "Второе правило, веселитесь! \r\n" +
            "\r\n Управление: \r\n" +
            "Передвижение на W, A, S, D или на стрелочки. \r\n" +
            "Что бы выбрать нужный ответ в диалогах нажмите Enter.\r\n" +
            "\r\n Предыстория: \r\n" +
            "Вы являетесь жителем городка на охваченном войной континенте и в скором времени на городок нападут демоны, \r\n" +
            "чтобы не стать для них пищей, вы должны уплыть на корабле, однако, вам не хватает денег на билет, да еще и капитан не может продать билет дешевле\r\n" +
            "так как корабль и так полон людьми, но благо рядом с кораблем есть ювелирная лавка, где можно продать кристаллы. \r\n" +
            "Однако, и кристаллов у вас нет. Совсем отчаявшись, вы ушли в таверну выпить напоследок, там за кружкой пива вам\r\n" +
            "рассказали про кристалл, находящийся в лабиринте на востоке, однако, чтобы попасть в лабиринт, вам необходимо пройти\r\n" +
            "через очень опасный лес, который кишит монстрами, до лабиринта конечно ведет дорога, \r\n" +
            "но она очень длинная, а ночью из леса выходят еще более опасные монстры. И без \r\n" +
            "опытного сопровождения ночевать на дороге не представляется возможным. Благо по пути есть деревушка, в которой можно переночевать. \r\n" +
            "Мужчина так же рассказал, что, пройдя лабиринт вы встретите систему защиты кристалла, \r\n" +
            "она представляет собой несколько комнат, в которых нужно ввести пароль нажимая на плиты на полу. \r\n" +
            "Правда, если вы неправильно введете пароль, все пройденные комнаты закроются, \r\n" +
            "а вас вернет опять в начало. Именно по этой причине никто еще не забрал кристалл. \r\n" +
            "Ну что-ж, вперед на поиски кристалла, дабы сохранить свою жизнь! \r\n" +
            "\r\n Нажмите Enter для выхода...");
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