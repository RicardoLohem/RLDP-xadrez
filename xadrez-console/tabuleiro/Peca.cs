namespace tabuleiro
{
    class Peca
    {
        public Posicao posicao { get; set; }
        public Tabuleiro tabu { get; set; }
        public Cor cor { get; protected set; }
        public int qteMovmentos { get; set; }

        public Peca(Tabuleiro tabu, Cor cor)
        {
            this.posicao = null;
            this.tabu = tabu;
            this.cor = cor;
            this.qteMovmentos = 0;
        }
    }
}
