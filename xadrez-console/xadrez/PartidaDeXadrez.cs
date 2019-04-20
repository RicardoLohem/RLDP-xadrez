using System.Collections.Generic;
using tabuleiro;

namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro tabu { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool fim { get; private set; }
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;

        public PartidaDeXadrez()
        {
            tabu = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            fim = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            poePecas();
        }

        public void fazMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tabu.tiraPeca(origem);
            p.plusQteMovimentos();
            Peca pecaCapturada = tabu.tiraPeca(destino);
            tabu.porPeca(p, destino);
            if (pecaCapturada != null)
            {
                capturadas.Add(pecaCapturada);
            }
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
                jogadorAtual = Cor.Vermelha;
            }
            else
            {
                jogadorAtual = Cor.Branca;
            }
        }

        public HashSet<Peca> pecasCap(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in capturadas)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);

                }
            }
            return aux;
        }

        public HashSet<Peca> pecasNoJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in pecas)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);

                }
            }
            aux.ExceptWith(pecasCap(cor));
            return aux;
        }


        public void porNovaPeca(char coluna, int linha, Peca peca)
        {
            tabu.porPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            pecas.Add(peca);
        }

        private void poePecas()
        {
            porNovaPeca('c', 1, new Torre(tabu, Cor.Branca));
            porNovaPeca('c', 2, new Torre(tabu, Cor.Branca));
            porNovaPeca('d', 2, new Torre(tabu, Cor.Branca));
            porNovaPeca('e', 2, new Torre(tabu, Cor.Branca));
            porNovaPeca('e', 1, new Torre(tabu, Cor.Branca));
            porNovaPeca('d', 1, new Rei(tabu, Cor.Branca));

            porNovaPeca('c', 7, new Torre(tabu, Cor.Vermelha));
            porNovaPeca('c', 8, new Torre(tabu, Cor.Vermelha));
            porNovaPeca('d', 7, new Torre(tabu, Cor.Vermelha));
            porNovaPeca('e', 7, new Torre(tabu, Cor.Vermelha));
            porNovaPeca('e', 8, new Torre(tabu, Cor.Vermelha));
            porNovaPeca('d', 8, new Rei(tabu, Cor.Vermelha));
        }
    }
}
