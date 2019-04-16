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
                Tabuleiro ta = new Tabuleiro(8, 8);

                ta.porPeca(new Torre(ta, Cor.Preta), new Posicao(0, 0));
                ta.porPeca(new Torre(ta, Cor.Preta), new Posicao(1, 3));
                ta.porPeca(new Rei(ta, Cor.Preta), new Posicao(0, 2));

                ta.porPeca(new Torre(ta, Cor.Branca), new Posicao(3, 5));

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
