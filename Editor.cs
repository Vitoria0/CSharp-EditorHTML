using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace editorHTML
{
    public static class Editor
    {
        public static void Show()
        {
            Console.Clear();

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Editor HTML");
            Console.WriteLine("=============");

            Start();
        }

        public static void Start()
        {
            var file = new StringBuilder();

            Console.WriteLine("Digite seu texto abaixo (pressione ESC para sair):");

            while (true)
            {
                var keyInfo = Console.ReadKey(intercept: true);

                if (keyInfo.Key == ConsoleKey.Escape)
                    break;

                Console.Write(keyInfo.KeyChar);
                file.Append(keyInfo.KeyChar);
            }

            Console.WriteLine("\n============");
            Console.WriteLine("Deseja salvar o arquivo?");
            Console.WriteLine("1 - Sim");
            Console.WriteLine("2 - Não");

            short option;
            while (!short.TryParse(Console.ReadLine(), out option) || (option != 1 && option != 2))
            {
                Console.WriteLine("Opção inválida. Tente novamente.");
            }

            if (option == 1)
            {
                File.WriteAllText("teste.html", file.ToString());
                Console.WriteLine("Arquivo salvo com sucesso!");

                // Passa o texto para o Viewer para visualização
                Viewer.Show(file.ToString());
            }
            else if (option == 2)
            {
                Console.WriteLine("Arquivo não salvo.");
            }

            Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
            Menu.Show();
        }
    }
}