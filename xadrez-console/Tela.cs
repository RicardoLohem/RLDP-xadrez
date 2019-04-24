using System;
using System.Collections.Generic;
using tabuleiro;
using xadrez_console;

namespace xadrez_console
{
    class Tela
    {

        public static void printPartida(PartidaDeXadrez partida)
        {
            imprimirTabuleiro(partida.tabu);
            Console.WriteLine();
            printPecasCap(partida);
            Console.WriteLine();

            Console.WriteLine("Turno: " + partida.turno);

            if (!partida.fim)
            {
                Console.WriteLine("Aguardando jogada: " + partida.jogadorAtual);
                if (partida.xeque)
                {
                    Console.WriteLine("XEQUE!");
                }
            }
            else
            {
                Console.WriteLine("XEQUEMATE!");
                Console.WriteLine("Vencedor: " + partida.jogadorAtual);
            }
        }

        public static void printPecasCap(PartidaDeXadrez partida)
        {
            Console.WriteLine("Peças capturadas: ");

            Console.Write("Brancas: ");
            printConjunto(partida.pecasCap(Cor.Branca));

            Console.Write("Pretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            
            printConjunto(partida.pecasCap(Cor.Vermelha));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        public static void printConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");
            foreach (Peca x in conjunto)
            {
                Console.Write(x + " ");
            }
            Console.WriteLine("]");
        }


        public static void imprimirTabuleiro(Tabuleiro tabu)
        {
            for (int i = 0; i < tabu.linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tabu.colunas; j++)
                {
                   imprimirPeca(tabu.peca(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void imprimirTabuleiro(Tabuleiro tabu, bool[,] posiPossiveis)
        {
            ConsoleColor fundoPadrao = Console.BackgroundColor;
            ConsoleColor fundoMudado = ConsoleColor.DarkGray;

            for (int i = 0; i < tabu.linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tabu.colunas; j++)
                {
                    if (posiPossiveis[i, j])
                    {
                        Console.BackgroundColor = fundoMudado;
                    }
                    else
                    {
                        Console.BackgroundColor = fundoPadrao;
                    }

                    imprimirPeca(tabu.peca(i, j));
                    Console.BackgroundColor = fundoPadrao;

                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = fundoPadrao;
        }

        public static PosicaoXadrez lerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }

        public static void imprimirPeca(Peca peca)
        {
            if (peca == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (peca.cor == Cor.Branca)
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
                Console.Write(" ");
            }
        }
    }
}
