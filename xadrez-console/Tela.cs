using System;
using tabuleiro;

namespace xadrez
{
    class Tela
    {
        public static void imprimirTabuleiro(Tabuleiro tabu)
        {
            for (int i = 0; i < tabu.linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tabu.colunas; j++)
                {
                    if (tabu.peca(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Tela.imprimirPeca(tabu.peca(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void imprimirPeca(Peca peca)
        {
            if(peca.cor == Cor.Branca)
            {
                Console.Write(peca);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(peca);
                Console.ForegroundColor = aux;
            }
        }
    }
}
