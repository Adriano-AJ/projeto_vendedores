using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_vendedores
{
    internal class Venda
    {
        private int qtde;
        private double valor;

        public double Valor { get => valor;}
        public int Qtde { get => qtde;}

        public Venda(int qtde, double valor) 
        { 
            this.qtde = qtde;
            this.valor = valor;
        }
        public double valorMedio()
        {
            double valorM = valor/qtde;
            return valorM;
        }
    }
}
