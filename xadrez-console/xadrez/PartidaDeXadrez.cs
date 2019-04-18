using System;
using tabuleiro;

namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro tabu { get; private set; }
        private int turno;
        private Cor jogadorAtual;
        public bool fim { get; private set; }

        public PartidaDeXadrez()
        {
            tabu = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            fim = false;
            poePecas();
        }

        public void fazMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tabu.tiraPeca(origem);
            p.plusQteMovimentos();
            Peca pecaCapturada = tabu.tiraPeca(destino);
            tabu.porPeca(p, destino);
        }

        private void poePecas()
        {
            tabu.porPeca(new Torre(tabu, Cor.Branca), new PosicaoXadrez('c', 1).toPosicao());
            tabu.porPeca(new Torre(tabu, Cor.Branca), new PosicaoXadrez('c', 2).toPosicao());
            tabu.porPeca(new Torre(tabu, Cor.Branca), new PosicaoXadrez('d', 2).toPosicao());
            tabu.porPeca(new Torre(tabu, Cor.Branca), new PosicaoXadrez('e', 2).toPosicao());
            tabu.porPeca(new Torre(tabu, Cor.Branca), new PosicaoXadrez('e', 1).toPosicao());
            tabu.porPeca(new Rei(tabu, Cor.Branca), new PosicaoXadrez('d', 1).toPosicao());

            tabu.porPeca(new Torre(tabu, Cor.Vermelha), new PosicaoXadrez('c', 7).toPosicao());
            tabu.porPeca(new Torre(tabu, Cor.Vermelha), new PosicaoXadrez('c', 8).toPosicao());
            tabu.porPeca(new Torre(tabu, Cor.Vermelha), new PosicaoXadrez('d', 7).toPosicao());
            tabu.porPeca(new Torre(tabu, Cor.Vermelha), new PosicaoXadrez('e', 7).toPosicao());
            tabu.porPeca(new Torre(tabu, Cor.Vermelha), new PosicaoXadrez('e', 8).toPosicao());
            tabu.porPeca(new Rei(tabu, Cor.Vermelha), new PosicaoXadrez('d', 8).toPosicao());
        }
    }
}
