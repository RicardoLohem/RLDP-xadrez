namespace tabuleiro
{
    abstract class Peca
    {
        public Posicao posicao { get; set; }
        public Tabuleiro tabu { get; protected set; }
        public Cor cor { get; protected set; }
        public int qteMovimentos { get; protected set; }

        public Peca(Tabuleiro tabu, Cor cor)
        {
            this.posicao = null;
            this.tabu = tabu;
            this.cor = cor;
            this.qteMovimentos = 0;
        }

        public void plusQteMovimentos()
        {
            qteMovimentos++;
        }

        public void minusQteMovimentos()
        {
            qteMovimentos--;
        }

        public bool haMovPossiveis()
        {
            bool[,] mat = movPossiveis();
               for (int i = 0; i < tabu.linhas; i++) 
            {
                for (int j = 0; j < tabu.colunas; j++) 
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool podeMovPara(Posicao pos)
        {
            return movPossiveis()[pos.linha, pos.coluna];
        }
        public abstract bool[,] movPossiveis();
    }
}
