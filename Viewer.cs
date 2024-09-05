
using System;
using System.Text.RegularExpressions;

namespace editorHTML
{
    public class Viewer
    {
        public static void Show(string text)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Modo Visualização");
            Console.WriteLine("==============");
            Replace(text);
            Console.WriteLine("==============");
            Console.ReadKey();
            Menu.Show();
        }

        public static void Replace(string text)
        {
            var strong = new Regex(@"<\s*strong[^>]*>(.*?)<\s*/\s*strong>", RegexOptions.IgnoreCase);
            var words = text.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                if (strong.IsMatch(words[i]))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(words[i]);
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.Write(words[i] + " ");
                }
            }
            Console.Write("\n");
        }
    }
}