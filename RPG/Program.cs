using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Program
    {

        public static ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));

        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Init g = new Init();
                g.goHome();
            } while (true);
        }

        public static void gameOver()
        {
            Console.Clear();
            Program.WriteFormattedLine("{0}", Program.colors[4], "===============================");
            Program.WriteFormattedLine("{0}", Program.colors[4], "===========GAME OVER===========");
            Program.WriteFormattedLine("{0}", Program.colors[4], "===============================");
            Console.WriteLine("Voulez vous rejouer ? (o/n)");
            string overInput = Console.ReadLine();
            if (overInput == "o")
            {
                Console.Clear();
                Init f = new Init();
                f.goHome();

            } else if (overInput == "n")
            {
                Environment.Exit(0);
            } else
            {
                gameOver();
            }
        }

        public static void WriteFormattedLine(string format, ConsoleColor color, params string[] answers)
        {
            int formatLength = format.Length;
            int currIndex = 0;
            bool readingNumber = false;
            string numberRead = string.Empty;
            while (currIndex < formatLength)
            {
                var ch = format[currIndex];
                switch (ch)
                {
                    case '{':
                        Console.ForegroundColor = color;
                        readingNumber = true;
                        numberRead = string.Empty;
                        break;
                    case '}':
                        var number = int.Parse(numberRead);
                        var answer = answers[number];
                        Console.Write(answer);
                        Console.ResetColor();
                        readingNumber = false;
                        break;
                    default:
                        if (readingNumber)
                            numberRead += ch;
                        else
                            Console.Write(ch);
                        break;
                }

                currIndex++;
            }

            Console.WriteLine("");
        }
    }
}
