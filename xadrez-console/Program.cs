using System;
using tabuleiro;
using xadrez;

namespace xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro ta = new Tabuleiro(8, 8);

            ta.porPeca(new Torre(ta, Cor.Preta), new Posicao(0, 0));
            ta.porPeca(new Torre(ta, Cor.Preta), new Posicao(1, 3));
            ta.porPeca(new Rei(ta, Cor.Preta), new Posicao(2, 4));

            Tela.imprimirTabuleiro(ta);

            Console.WriteLine();
        }
    }
}
