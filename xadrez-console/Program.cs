using System;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.fim)
                {
                    Console.Clear();
                    Tela.imprimirTabuleiro(partida.tabu);

                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Posicao origem = Tela.lerPosicaoXadrez().toPosicao();

                    bool[,] posiPossveis = partida.tabu.peca(origem).movPossiveis();

                    Console.Clear();
                    Tela.imprimirTabuleiro(partida.tabu, posiPossveis);

                    Console.WriteLine();
                    Console.Write("Destino: ");
                    Posicao destino = Tela.lerPosicaoXadrez().toPosicao();

                    Console.Clear();
                    Tela.imprimirTabuleiro(partida.tabu);

                    partida.fazMovimento(origem, destino);

                }
        }
            catch(TabuleiroExcecao e)
            {
                Console.WriteLine(e.Message);
            }
            

            Console.ReadLine();
        }
    }
}
