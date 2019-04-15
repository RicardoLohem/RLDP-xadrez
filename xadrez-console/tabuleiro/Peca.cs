namespace tabuleiro
{
    class Peca
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qteMovmentos { get; set; }
        public Tabuleiro MyProperty { get; set; }
    }
}
