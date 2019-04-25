using tabuleiro;

namespace xadrez
{
    class Cavalo : Peca
    {
        public Cavalo(Tabuleiro tabu, Cor cor) : base(tabu, cor)
        {
        }

        public override string ToString()
        {
            return "C";
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

            pos.defValores(posicao.linha - 1, posicao.coluna - 2);
            if (tabu.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            pos.defValores(posicao.linha - 2, posicao.coluna - 1);
            if (tabu.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            pos.defValores(posicao.linha - 2, posicao.coluna + 1);
            if (tabu.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            pos.defValores(posicao.linha - 1, posicao.coluna + 2);
            if (tabu.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            pos.defValores(posicao.linha + 1, posicao.coluna + 2);
            if (tabu.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            pos.defValores(posicao.linha + 2, posicao.coluna + 1);
            if (tabu.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            pos.defValores(posicao.linha + 2, posicao.coluna - 1);
            if (tabu.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            pos.defValores(posicao.linha + 1, posicao.coluna - 2);
            if (tabu.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            return mat;
        }
    }
}
