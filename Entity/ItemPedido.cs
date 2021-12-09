namespace Back_end.Entity
{
    public class ItemPedido
    {
        [ForeignKey("Produto")]
        public int produtoId {get; set;}
        
        [ForeignKey("Pedido")]
        public int pedidoId {get; set;}
    }
}
