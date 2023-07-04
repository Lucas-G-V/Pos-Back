namespace MarmitariaReal.Domain.Entities
{
    public class Receita
    {
        public Guid ReceitaId { get; set; }
        public string Descricao { get; private set; }
        public string UrlImagem { get; private set; }
        public double Preco { get; private set; }

        public Receita(string descricao, string urlImagem, double preco) 
        { 
            Descricao = descricao;
            UrlImagem = urlImagem;
            Preco = preco;
        }

        protected Receita() { }
    }
}
