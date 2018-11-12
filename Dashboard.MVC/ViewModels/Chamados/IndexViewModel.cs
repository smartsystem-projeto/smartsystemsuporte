using Dashboard.Domain.Entities;
using System.Collections.Generic;

namespace Dashboard.MVC.ViewModels.Chamados
{
    public class IndexViewModel
    {
        public IEnumerable<Chamado> Chamados { get; set; }
    }
}
