using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace projeto_vendedores
{
    internal class Vendedor
    {
        private int id;
        private string nome;
        private double percComissao;
        private Venda[] asVendas;

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public double PercComissao { get => percComissao; set => percComissao = value; }
        public Venda[] AsVendas { get => asVendas;}

        public Vendedor(int id, string nome, double percComissao) 
        {
            this.id = id;
            this.nome = nome;
            this.percComissao = percComissao;
            this.asVendas = new Venda[31];
        }
        public Vendedor() { }

        public void registrarVenda(int dia, Venda venda)
        {
            if (dia >= 1 && dia <= 31)
            {
                this.asVendas[dia-1] = venda;

            }
        }

        public double valorVendas()
        {
            double valorV = 0;

            for (int i = 0; i < asVendas.Length; i++)
            {
                valorV += asVendas[i].valorMedio();
            }
            
            return valorV;
        }
        public double valorComissao()
        {
            return valorVendas() * (percComissao / 100); ;
        }

    }
}
