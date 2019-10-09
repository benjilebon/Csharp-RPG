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
                Init g = new Init();
                g.goHome();
                Console.WriteLine("Voulez-vous rejouer ? (o/n)");
            } while (Console.ReadLine() == "o");
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
