namespace Back_end.Entity
{
    public class Produto
    {
        public int id {get; set;}
        public string nome {get; set;}
        [ForeignKey("Categoria")]
        public string categoria {get; set;}
        public double preco {get; set;}
        public string titulo {get; set;}
        public string descricao {get; set;}
        public string imagem {get;  set;}
    }
}
