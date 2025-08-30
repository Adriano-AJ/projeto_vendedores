using projeto_vendedores;

Vendedores vendedores = new Vendedores(10);
int option;

do {
    Console.WriteLine("-----------------");
    Console.WriteLine("|      MENU     | ");
    Console.WriteLine("-----------------");
    Console.WriteLine("| 0 - SAIR      |");
    Console.WriteLine("| 1 - CADASTRAR |");
    Console.WriteLine("| 2 - CONSULTAR |");
    Console.WriteLine("| 3 - EXCLUIR   |");
    Console.WriteLine("| 4 - REGISTRAR |");
    Console.WriteLine("| 5 - LISTAR    |");
    Console.WriteLine("-----------------");

    option = Convert.ToInt32(Console.ReadLine());

    switch (option)

    {   case 0:
            Console.WriteLine("Programa Finalizado.");
            break;
        case 1:
            try
            {
                string nome;
                int id;
                double perC;

                if(vendedores.Qtde >= 10)
                {
                    Console.WriteLine("Não é possivel adicionar mais vendedores, o limite é 10!");
                }
                else
                {
                    Console.WriteLine("Digite o nome do vendedor:");
                    nome = Console.ReadLine();
                    Console.WriteLine("Digite a porcentagem de comissao do vendedor:");
                    perC = Double.Parse(Console.ReadLine());

                    id = vendedores.Qtde;

                    Vendedor newV = new Vendedor(id, nome, perC);
                    vendedores.adicionar(newV);
                    Console.WriteLine($"O vendedor: {vendedores.OsVendedores[id].Nome}, foi cadastrado com sucesso!");
                    Console.WriteLine("---------------------------------------------------------------");
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            break;
        case 2:
            try
            {
                int id;
                Console.WriteLine("Digite o id do vendedor:");
                id = int.Parse(Console.ReadLine());

                Vendedor vendedorConsul = new(id);
                Vendedor vendedorEncontrado = vendedores.pesquisar(vendedorConsul);
                if (vendedorEncontrado.Id == -1)
                {
                    Console.WriteLine("Não encontrou");
                }
                else
                {
                    Console.WriteLine(vendedorEncontrado.ToString());
                }

            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            break;
        case 3:
            try
            { 
                int id;
                Console.WriteLine("Digite o id do vendedor a ser removido:");
                id = int.Parse(Console.ReadLine());

                Vendedor vendedorR = new(id);
                if (!vendedores.remover(vendedorR))
                {
                    Console.WriteLine("Vendedor não encontrado.");
                }
                else { Console.WriteLine("Vendedor removido com sucesso"); }
              
            }
            catch(Exception ex) {Console.WriteLine(ex.ToString());}
            break;
        case 4:
            try
            {
                int id, qtde, dia;
                double valor;

                Console.WriteLine("Digite o id do vendedor:");
                id = int.Parse(Console.ReadLine());

                Vendedor vendedorConsul = new(id);
                Vendedor vendedorEncontrado = vendedores.pesquisar(vendedorConsul);
                if (vendedorEncontrado.Id == -1)
                {
                    Console.WriteLine("Vendedor não encontrado.");
                }
                else
                {
                    Console.WriteLine("Digite o dia da venda:");
                    dia = int.Parse(Console.ReadLine());
                    Console.WriteLine("Digite a quantidade de vendas do vendedor:");
                    qtde = int.Parse(Console.ReadLine());
                    Console.WriteLine("Digite o  valor das vendas do vendedor:");
                    valor = double.Parse(Console.ReadLine());


                    Venda venda = new Venda(qtde, valor);
                    vendedorEncontrado.registrarVenda(dia, venda);

                    Console.WriteLine("Venda registrada!");
                }
            } catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            break;
        case 5:
            Console.WriteLine(vendedores.mostrar());
            break;
        default:
            Console.WriteLine("Opção invalida!");
            break;
    }
}while (option != 0);