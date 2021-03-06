﻿using System;
using tabuleiro;
using xadrez_console;

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
                    try
                    {
                        Console.Clear();
                        Tela.printPartida(partida);

                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicao origem = Tela.lerPosicaoXadrez().toPosicao();

                        partida.valPosiOrigem(origem);

                        bool[,] posiPossveis = partida.tabu.peca(origem).movPossiveis();

                        Console.Clear();
                        Tela.imprimirTabuleiro(partida.tabu, posiPossveis);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = Tela.lerPosicaoXadrez().toPosicao();

                        partida.valPosiDestino(origem, destino);

                        partida.fazJogada(origem, destino);
                    }
                    catch(TabuleiroExcecao e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine("Aperte Enter para continuar a partida");
                        Console.ReadLine();
                    }

                }

                Console.Clear();
                Tela.printPartida(partida);
        }
            catch(TabuleiroExcecao e)
            {
                Console.WriteLine(e.Message);
            }
           
            Console.ReadLine();
        }
    }
}
