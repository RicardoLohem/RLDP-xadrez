using System.Collections.Generic;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class PartidaDeXadrez
    {
        public Tabuleiro tabu { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool fim { get; private set; }
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;
        public bool xeque { get; private set; }

        public PartidaDeXadrez()
        {
            tabu = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            fim = false;
            xeque = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            poePecas();
        }

        public Peca fazMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tabu.tiraPeca(origem);
            p.plusQteMovimentos();
            Peca pecaCap = tabu.tiraPeca(destino);
            tabu.porPeca(p, destino);
            if (pecaCap != null)
            {
                capturadas.Add(pecaCap);
            }
            return pecaCap;
        }

        public void desfazMov(Posicao origem, Posicao destino, Peca pecaCap)
        {
            Peca p = tabu.tiraPeca(destino);
            p.minusQteMovimentos();
            if (pecaCap != null)
            {
                tabu.porPeca(pecaCap, destino);
                capturadas.Remove(pecaCap);
            }
            tabu.porPeca(p, origem);
        }

        public void fazJogada(Posicao origem, Posicao destino)
        {
            Peca pecaCap = fazMovimento(origem, destino);

            if (emXeque(jogadorAtual))
            {
                desfazMov(origem, destino, pecaCap);
                throw new TabuleiroExcecao("Você não pode se por em xeque!");
            }

            if (emXeque(inimigo(jogadorAtual)))
            {
                xeque = true;
            }
            else
            {
                xeque = false;
            }

            if (testeXmate(inimigo(jogadorAtual)))
            {
                fim = true;
            }
            else
            {
                turno++;
                trocaJogador();
            }
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

        private Cor inimigo(Cor cor)
        {
            if (cor == Cor.Branca)
            {
                return Cor.Vermelha;
            }
            else
            {
                return Cor.Branca;
            }
        }

        private Peca rei(Cor cor)
        {
            foreach (Peca x in pecasNoJogo(cor))
            {
                if (x is Rei)
                {
                    return x;
                }
            }
            return null;
        }

        public bool emXeque(Cor cor)
        {
            Peca R = rei(cor);
            if (R == null)
            {
                throw new TabuleiroExcecao("Não tem rei da cor " + cor + " no tabuleiro!");
            }
            foreach(Peca x in pecasNoJogo(inimigo(cor)))
            {
                bool[,] mat = x.movPossiveis();
                if (mat[R.posicao.linha, R.posicao.coluna])
                {
                    return true;
                }
            }
            return false;
        }

        public bool testeXmate(Cor cor)
        {
            if (!emXeque(cor))
            {
                return false;
            }

            foreach (Peca x in pecasNoJogo(cor))
            {
                bool[,] mat = x.movPossiveis();
                for (int i = 0; i < tabu.linhas; i++)
                {
                    for (int j = 0; j < tabu.colunas; j++)
                    {
                        if (mat[i, j])
                        {
							Posicao origem = x.posicao;
                            Posicao destino = new Posicao(i, j);
                            Peca pecaCap = fazMovimento(origem, destino);
                            bool testeXmate = emXeque(cor);
                            desfazMov(origem, destino, pecaCap);

                            if (!testeXmate)
                            {
                                return false;
                            }
                        }
                    }
                }

            }
            return true;
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
            porNovaPeca('a', 1, new Torre(tabu, Cor.Branca));
            porNovaPeca('b', 1, new Cavalo(tabu, Cor.Branca));
            porNovaPeca('c', 1, new Bispo(tabu, Cor.Branca));
            porNovaPeca('d', 1, new Dama(tabu, Cor.Branca));
            porNovaPeca('e', 1, new Rei(tabu, Cor.Branca));
            porNovaPeca('f', 1, new Bispo(tabu, Cor.Branca));
            porNovaPeca('g', 1, new Cavalo(tabu, Cor.Branca));
            porNovaPeca('h', 1, new Torre(tabu, Cor.Branca));
            porNovaPeca('a', 2, new Peao(tabu, Cor.Branca));
            porNovaPeca('b', 2, new Peao(tabu, Cor.Branca));
            porNovaPeca('c', 2, new Peao(tabu, Cor.Branca));
            porNovaPeca('d', 2, new Peao(tabu, Cor.Branca));
            porNovaPeca('e', 2, new Peao(tabu, Cor.Branca));
            porNovaPeca('f', 2, new Peao(tabu, Cor.Branca));
            porNovaPeca('g', 2, new Peao(tabu, Cor.Branca));
            porNovaPeca('h', 2, new Peao(tabu, Cor.Branca));

            porNovaPeca('a', 8, new Torre(tabu, Cor.Vermelha));
            porNovaPeca('b', 8, new Cavalo(tabu, Cor.Vermelha));
            porNovaPeca('c', 8, new Bispo(tabu, Cor.Vermelha));
            porNovaPeca('d', 8, new Dama(tabu, Cor.Vermelha));
            porNovaPeca('e', 8, new Rei(tabu, Cor.Vermelha));
            porNovaPeca('f', 8, new Bispo(tabu, Cor.Vermelha));
            porNovaPeca('g', 8, new Cavalo(tabu, Cor.Vermelha));
            porNovaPeca('h', 8, new Torre(tabu, Cor.Vermelha));
            porNovaPeca('a', 7, new Peao(tabu, Cor.Vermelha));
            porNovaPeca('b', 7, new Peao(tabu, Cor.Vermelha));
            porNovaPeca('c', 7, new Peao(tabu, Cor.Vermelha));
            porNovaPeca('d', 7, new Peao(tabu, Cor.Vermelha));
            porNovaPeca('e', 7, new Peao(tabu, Cor.Vermelha));
            porNovaPeca('f', 7, new Peao(tabu, Cor.Vermelha));
            porNovaPeca('g', 7, new Peao(tabu, Cor.Vermelha));
            porNovaPeca('h', 7, new Peao(tabu, Cor.Vermelha));

        }
    }
}
