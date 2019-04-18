namespace tabuleiro
{
    abstract class Peca
    {
        public Posicao posicao { get; set; }
        public Tabuleiro tabu { get; set; }
        public Cor cor { get; protected set; }
        public int qteMovimentos { get; set; }

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

        public abstract bool[,] movPossiveis();
    }
}
