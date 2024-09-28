using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppBanca.Models;

namespace AppBanca.ViewModel
{
    public class RClienteViewModel
    {
        public Cliente? FormCliente { get; set; }
        public IEnumerable<Cliente>? ListCliente { get; set; }
    }
}