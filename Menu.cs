using System;

namespace editorHTML
{
    public static class Menu
    {
        public static void Show()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            DrawScreen();
            DrawOptions();

            var option = short.Parse(Console.ReadLine());
            HandleMenuOption(option);
        }

        public static void DrawScreen()
        {
            Console.Write("+");
            for (int i = 0; i <= 30; i++)
            {
                Console.Write("-");
            }
            Console.Write("+");
            Console.Write("\n");
            for (int lines = 0; lines <= 10; lines++)
            {
                Console.Write("|");
                for (int i = 0; i <= 30; i++)
                {
                    Console.Write(" ");
                }
                Console.Write("|");
                Console.Write("\n");
            }
            Console.Write("+");
            for (int i = 0; i <= 30; i++)
            {
                Console.Write("-");
            }
            Console.Write("+");
            Console.Write("\n");

        }

        public static void DrawOptions()
        {
            Console.SetCursorPosition(3, 2);
            Console.Write("Editor HTML");

            Console.SetCursorPosition(3, 3);
            Console.Write("===================");

            Console.SetCursorPosition(3, 4);
            Console.Write("Selecione uma opção:");

            Console.SetCursorPosition(3, 6);
            Console.Write("1 - Novo arquivo");

            Console.SetCursorPosition(3, 7);
            Console.Write("2 - Abrir arquivo");

            Console.SetCursorPosition(3, 9);
            Console.Write("0 - Sair");

            Console.SetCursorPosition(3, 10);
            Console.Write("Opcão: ");
        }

        public static void HandleMenuOption(short option)
        {
            while (!short.TryParse(Console.ReadLine(), out option))
            {
                Console.WriteLine("Opção inválida. Tente novamente.");
            }

            switch (option)
            {
                case 1:
                    Editor.Show();
                    break;
                case 2:
                    Console.WriteLine("Digite o caminho do arquivo que deseja visualizar:");
                    string path = Console.ReadLine();
                    if (File.Exists(path))
                    {
                        string content = File.ReadAllText(path);
                        Viewer.Show(content);
                    }
                    else
                    {
                        Console.WriteLine("Arquivo não encontrado.");
                        Console.ReadKey();
                        Show();
                    }
                    break;
                case 0:
                    {
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                    }
                default: Show(); break;
            }
        }
    }
}