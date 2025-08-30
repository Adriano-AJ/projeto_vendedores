using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace projeto_vendedores
{
    internal class Vendedores
    {
        private Vendedor[] osVendedores;
        private int max;
        private int qtde;

        public int Max { get => max;}
        public int Qtde { get => qtde;}
        public Vendedor[] OsVendedores { get => osVendedores;}

        public Vendedores(int max)
        {
            this.max = max;
            this.qtde = 0;
            this.osVendedores = new Vendedor[max];
            for (int ii= 0; ii< max; ii++)
            {
                this.osVendedores[ii] = new Vendedor();
            }
        }

        public bool adicionar(Vendedor v)
        {
            bool podeAdicionar = (this.qtde < this.max);
            if (podeAdicionar)
                this.osVendedores[this.qtde++] = v;
            return podeAdicionar;
        }

        public Vendedor pesquisar(Vendedor v)
        {
            Vendedor vendedorAchado = new Vendedor();
            foreach (Vendedor vendedor in this.osVendedores)
            {
                if (vendedor.Equals(v))
                {
                    vendedorAchado = vendedor;
                    break;
                }
            }
            /*
            int i = 0;
            while (i < this.max && this.asCoisas[i].Id != c.Id)
            {
                ++i;
            }
            if (i < this.max)
            {
                coisaAchada = this.asCoisas[i];
            }
            */
            return vendedorAchado;
        }

        public bool remover(Vendedor v)
        {

            int j;
            bool podeRemover = (pesquisar(v).Id != -1) && (v.AsVendas == null);

            if (podeRemover)
            {
                int i = 0;
                while (i < this.max && this.osVendedores[i].Id != v.Id)
                {
                    ++i;
                }
                for (j = i; j < this.max - 1; ++j)
                {
                    this.osVendedores[j] = this.osVendedores[j + 1];
                }
                this.osVendedores[j] = new Vendedor();
                this.qtde--;
            }
            return podeRemover;
        }

        public double valorVendas()
        {
            double valorV = 0;

            for (int i = 0; i < osVendedores.Length; i++) 
            {
                valorV += osVendedores[i].valorVendas();
            }
                
             return valorV;
        }
        public double valorComissao()
        {
            double valorC = 0;

            for (int i = 0; i < osVendedores.Length; i++)
            {
                valorC += osVendedores[i].valorComissao();
            }

            return valorC;
        }
        public string mostrar()
        {
            string ret = "";
            double valorTotal = 0;
            double comissaoTotal = 0;

            foreach (Vendedor vendedor in this.osVendedores)
            {
                if (vendedor.Id != -1)
                {
                    ret += vendedor.ToString();
                    valorTotal += vendedor.valorVendas();
                    comissaoTotal += vendedor.valorComissao();

                }
            }

            ret += $"---------------------------------------\n" +
                $"Valor total de vendas: R$ {valorTotal}\n" +
                $"Valor total de comissao: R$ {comissaoTotal}";

            return ret;
        }
    }
}
