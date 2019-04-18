using tabuleiro;

namespace xadrez
{
    class Rei : Peca
    {
        public Rei(Tabuleiro tabu, Cor cor) : base(tabu, cor)
        {
        }

        public override string ToString()
        {
            return "R";
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
            if (tabu.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            // NE

            pos.defValores(posicao.linha - 1, posicao.coluna + 1);
            if (tabu.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            // Direita

            pos.defValores(posicao.linha, posicao.coluna + 1);
            if (tabu.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            // SE

            pos.defValores(posicao.linha + 1, posicao.coluna + 1);
            if (tabu.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            // Abaixo

            pos.defValores(posicao.linha + 1, posicao.coluna);
            if (tabu.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            // SO

            pos.defValores(posicao.linha + 1, posicao.coluna - 1);
            if (tabu.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            // Esquerda

            pos.defValores(posicao.linha, posicao.coluna - 1);
            if (tabu.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            // NO

            pos.defValores(posicao.linha - 1, posicao.coluna - 1);
            if (tabu.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            return mat;
        }
    }
}
