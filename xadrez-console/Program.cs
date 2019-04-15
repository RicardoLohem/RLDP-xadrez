using System;
using tabuleiro;
using xadrez;

namespace xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Tabuleiro ta = new Tabuleiro(8, 8);

                ta.porPeca(new Torre(ta, Cor.Preta), new Posicao(0, 0));
                ta.porPeca(new Torre(ta, Cor.Preta), new Posicao(1, 11));
                ta.porPeca(new Rei(ta, Cor.Preta), new Posicao(0, 2));

                Tela.imprimirTabuleiro(ta);
            }
            catch(TabuleiroExcecao e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
