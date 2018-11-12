using System;
using System.Collections.Generic;
using System.Text;

namespace Dashboard.Domain.Entities
{
    public class ClienteProduto
    {
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
    }
}
