using System;
using tabuleiro;

namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro tabu { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
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

        public void fazJogada(Posicao origem, Posicao destino)
        {
            fazMovimento(origem, destino);
            turno++;
            trocaJogador();
        }

        public void valPosiOrigem(Posicao pos)
        {
            if (tabu.peca(pos) == null)
            {
                throw new TabuleiroExcecao("Não existe peça na posição escolhida!");
            }

            if (jogadorAtual != tabu.peca(pos).cor)
            {
                throw new TabuleiroExcecao("A peça escolhida não é sua!");
            }

            if (!tabu.peca(pos).haMovPossiveis())
            {
                throw new TabuleiroExcecao("Não há movimentos possíveis para a peça escolhida!");
            }
        }

        public void valPosiDestino(Posicao origem, Posicao destino)
        {
            if (!tabu.peca(origem).podeMovPara(destino))
            {
                throw new TabuleiroExcecao("Posição de destino inválida!");
            }

        }

        private void trocaJogador()
        {
            if (jogadorAtual == Cor.Branca)
            {
                jogadorAtual = Cor.Preta;
            }
            else
            {
                jogadorAtual = Cor.Branca;
            }
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
