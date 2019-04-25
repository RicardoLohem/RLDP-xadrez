using tabuleiro;

namespace xadrez
{
    class Peao : Peca
    {
        public Peao(Tabuleiro tabu, Cor cor) : base(tabu, cor)
        {
        }

        public override string ToString()
        {
            return "P";
        }

        private bool podeMover(Posicao pos)
        {
            Peca p = tabu.peca(pos);
            return p == null || p.cor != cor;
        }

        private bool livre(Posicao pos)
        {
            return tabu.peca(pos) == null;
        }

        public override bool[,] movPossiveis()
        {
            bool[,] mat = new bool[tabu.linhas, tabu.colunas];

            Posicao pos = new Posicao(0, 0);
            
            if (cor == Cor.Branca)
            {
                pos.defValores(pos.linha - 1, posicao.coluna);
                if (tabu.posicaoValida(pos) && livre(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.defValores(pos.linha - 2, posicao.coluna);
                if (tabu.posicaoValida(pos) && livre(pos) && qteMovimentos == 0)
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.defValores(pos.linha - 1, posicao.coluna - 1);
                if (tabu.posicaoValida(pos) && podeMover(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.defValores(pos.linha - 1, posicao.coluna + 1);
                if (tabu.posicaoValida(pos) && podeMover(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
            }
            else
            {
                pos.defValores(pos.linha + 1, posicao.coluna);
                if (tabu.posicaoValida(pos) && livre(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.defValores(pos.linha + 2, posicao.coluna);
                if (tabu.posicaoValida(pos) && livre(pos) && qteMovimentos == 0)
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.defValores(pos.linha + 1, posicao.coluna - 1);
                if (tabu.posicaoValida(pos) && podeMover(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.defValores(pos.linha + 1, posicao.coluna + 1);
                if (tabu.posicaoValida(pos) && podeMover(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
            }

            return mat;
        }
    }
}
