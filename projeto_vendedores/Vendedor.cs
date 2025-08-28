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
        public Vendedor(int id): this(id, "", 0.0)
        {
            
        }
        public Vendedor(): this(-1, "", 0.0) { }

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
                valorV += (asVendas[i] == null )? 0 : asVendas[i].valorMedio();
            }
            
            return valorV;
        }
        public double valorComissao()
        {
            return valorVendas() * (percComissao / 100); ;
        }

        public override string ToString()
        { 

            string msg = $"" +
                $"---------------------------------------------\n" +
                $"ID: {this.id.ToString()}\n" +
                $"Nome: {this.nome}\n" +
                $"Valor Total: R$ {this.valorVendas()}\n" +
                $"Valor de Comissao: R$ {this.valorComissao()} \n" +
                $"---------------------------------------------";

            return  msg;

        }

        public override bool Equals(object obj)
        {
            return (this.Id == ((Vendedor)obj).Id);
        }
    }
}
