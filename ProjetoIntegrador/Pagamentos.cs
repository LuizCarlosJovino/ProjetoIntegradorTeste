using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoIntegrador
{
    internal class Pagamentos
    {
        public string Moeda { get; set; }
        public string FormaDePagamento { get; set; }

        public Pagamentos(string moeda, string formaDePagamento)
        {
            Moeda = moeda;
            FormaDePagamento = formaDePagamento;
        }

        internal string Pagar()
        {
            return Moeda;
        }

        internal string Cobrar()
        {
            return FormaDePagamento;
        }
    }
    
}
