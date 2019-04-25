using tabuleiro;

namespace xadrez
{
    class Dama : Peca
    {
        public Dama(Tabuleiro tabu, Cor cor) : base(tabu, cor)
        {
        }

        public override string ToString()
        {
            return "D";
        }

        private bool podeMover(Posicao pos)
        {
            Peca p = tabu.peca(pos);
            return p == null || p.cor != cor;
        }


        public override bool[,] movPossiveis()
        {
            bool[,] mat = new bool[tabu.linhas, tabu.colunas];

            Posicao pos = new Posicao(0, 0);

            // Acima

            pos.defValores(posicao.linha - 1, posicao.coluna);

            while (tabu.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tabu.peca(pos) != null && tabu.peca(pos).cor != cor)
                {
                    break;
                }
                pos.linha = pos.linha - 1;
            }

            // Abaixo

            pos.defValores(posicao.linha + 1, posicao.coluna);

            while (tabu.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tabu.peca(pos) != null && tabu.peca(pos).cor != cor)
                {
                    break;
                }
                pos.linha = pos.linha + 1;
            }

            // Direita

            pos.defValores(posicao.linha, posicao.coluna + 1);

            while (tabu.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tabu.peca(pos) != null && tabu.peca(pos).cor != cor)
                {
                    break;
                }
                pos.coluna = pos.coluna + 1;
            }

            // Esquerda

            pos.defValores(posicao.linha, posicao.coluna - 1);

            while (tabu.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tabu.peca(pos) != null && tabu.peca(pos).cor != cor)
                {
                    break;
                }
                pos.coluna = pos.coluna - 1;
            }

            // NO

            pos.defValores(posicao.linha - 1, posicao.coluna - 1);

            while (tabu.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tabu.peca(pos) != null && tabu.peca(pos).cor != cor)
                {
                    break;
                }
                pos.defValores(pos.linha - 1, pos.coluna - 1);
            }

            // NE

            pos.defValores(posicao.linha - 1, posicao.coluna + 1);

            while (tabu.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tabu.peca(pos) != null && tabu.peca(pos).cor != cor)
                {
                    break;
                }
                pos.defValores(pos.linha - 1, pos.coluna + 1);
            }


            // SE

            pos.defValores(posicao.linha + 1, posicao.coluna + 1);

            while (tabu.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tabu.peca(pos) != null && tabu.peca(pos).cor != cor)
                {
                    break;
                }
                pos.defValores(pos.linha + 1, pos.coluna + 1);
            }

            // SO

            pos.defValores(posicao.linha + 1, posicao.coluna - 1);

            while (tabu.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tabu.peca(pos) != null && tabu.peca(pos).cor != cor)
                {
                    break;
                }
                pos.defValores(pos.linha + 1, pos.coluna - 1);
            }

            return mat;
        }
    }
}
