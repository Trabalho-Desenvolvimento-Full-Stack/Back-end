namespace Back_end.Entity
{
    public class Pedido
    {
        public int id {get; set;}
        [ForeignKey("Cliente")]
        public int clienteId {get; set;}
        public double preco {get; set;}
        public string status {get; set;}
    }
}
