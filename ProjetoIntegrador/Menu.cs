using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoIntegrador
{
    internal class Menu
    {
        private int _CurrenTId = 1;
        // criar um lista de empresa 
        private List<Empresa> _Empresas = new List<Empresa>();
        public void ChamarMenu()
        {
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.WriteLine("   Ola escolha uma opçao!!!  ");
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.WriteLine("                             ");
            Console.WriteLine("[1] Lista Empresa:");
            Console.WriteLine("[2] Cadastrar Empresa:");
            Console.WriteLine("[3] Deleta Empresa:");
            Console.WriteLine("[4] Altera Dados Da Empresa: ");
            Console.WriteLine("                             ");
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");

            // Switch usado para  define uma opcão do usuario

            switch (Console.ReadLine())
            {
                
                case "1":

                    var empresas = Empresa.GetAll();

                    ListarEmpresas(empresas);
                    //Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");

                    Console.ReadLine();

                    Console.Clear();

                    ChamarMenu();

                    break;

                case "2":

                    Empresa empresa = new Empresa();
                    empresa.Save();

                    Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                    Console.WriteLine("  Cadastro Realizado com Sucesso!  ");
                    Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                    Thread.Sleep(1000);// ESPERA 1 SEGUNDOS

                    Console.ReadLine();

                    ChamarMenu();

                    break;

                case "3":

                    Console.WriteLine("Informe o id que deseja deletar ");

                    var idDeletar = long.Parse(Console.ReadLine());

                    //criar uma variavel e atribuir um objeto 
                    var empresaDeletar = new Empresa(idDeletar);

                    // fazer uma verificacão se o ID e valido 
                    if (empresaDeletar.IsValid())
                    {
                        empresaDeletar.Delete();

                        Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                        Console.WriteLine("         Empresa Excluida!         ");
                        Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                        
                    }
                    else
                    {
                        Console.WriteLine($"Não existe empresa com ID {idDeletar}!");
                    }


                    Thread.Sleep(1000);

                    Console.Clear();

                    ChamarMenu();

                    break;

                case "4":
                    Console.WriteLine("Informe O ID Da Empresa!");

                    var idUpdate = long.Parse(Console.ReadLine());

                    var empresaUpdate = new Empresa(idUpdate);

                    // fazer uma verificacão se o ID e valido 
                    if (empresaUpdate.IsValid())
                    {
                        AlteraDados(empresaUpdate);
                    }
                    else
                    {
                        Console.WriteLine($"Não Existe Empresa com Id {idUpdate}!");

                    }
                    Thread.Sleep(1000);

                    Console.Clear();

                    ChamarMenu();

                    break;
            }
        }
        // adicionar os dados da empresa na lista 
        private void AdicionarDados(Empresa empresa)
        {
            _Empresas.Add(empresa);
        }

        // usado para lista empresa 
        private void ListarEmpresas(List<Empresa> items)
        {
            // verifca se exite empresa cadastrada 
            if (items.Count < 1)
            {
                Console.WriteLine("Sem Empresas Cadastradas!");
            }
            foreach (var empresa in items)
            {
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.WriteLine($" ID : {empresa.ID_Empresa} \n Nome : {empresa.Nome} \n CNPJ : {empresa.CNPJ} \n Email: {empresa.Email} \n Telefone : {empresa.Telefone} \n Endereco : {empresa.Endereco} \n Observacoes : {empresa.Observacoes}");
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            }
        }
        // usado para deleta empresa 
        private void DeletaDados(int id)
        {
            //LAMBDA usado agora pra remover Dados
            _Empresas.RemoveAll(empresa => empresa.ID_Empresa == id);

        }
        // usado para altera dados da empresa de acordo com opcão do usuario 
        private void AlteraDados(Empresa empresa)

        {
            Console.Clear();
            Console.WriteLine($"Menu de Alteração");
            Console.WriteLine($"1 - Nome ");
            Console.WriteLine($"2  - Cnpj");
            Console.WriteLine($"3 - Email");
            Console.WriteLine($"4 - Telefone");
            Console.WriteLine($"5 - endereço");
            Console.WriteLine($"6 - Observaçoes");
            Console.WriteLine($"Salvar - Salvar alterações");

            Console.WriteLine("\nInforme o campo que deseja alterar:");
            var entrada = Console.ReadLine().ToUpper();



            while (entrada != "SALVAR")
            {
                // if pra verifica se a informação esta valida 
                if(entrada != "1" && entrada != "2" && entrada != "3" && entrada != "4" && entrada != "5" && entrada != "6")
                {
                    Console.WriteLine("Campo invalido");
                }
                else
                {

                
                Console.WriteLine("Informe o novo valor a ser atribuido");
                var valor = Console.ReadLine();

                    switch (entrada)
                    {
                        case "1":
                            empresa.Nome = valor;
                            break;
                        case "2":
                            empresa.CNPJ = valor;
                            break;
                        case "3":
                            empresa.Email = valor;
                            break;
                        case "4":
                         empresa.Telefone = valor;
                            break;
                        case "5":
                            empresa.Endereco = valor;
                            break;
                        case "6":
                            empresa.Observacoes = valor;
                            break;
                    }

                }
                Console.Clear();
                Console.WriteLine($"Menu de Alteração");
                Console.WriteLine($"1 - Nome ");
                Console.WriteLine($"2  - Cnpj");
                Console.WriteLine($"3 - Email");
                Console.WriteLine($"4 - Telefone");
                Console.WriteLine($"5 - endereço");
                Console.WriteLine($"6 - Observaçoes");
                Console.WriteLine($"Salvar - Salvar alterações");

                Console.WriteLine("\n Escrevar Salvar se tiver tudo certo: / Ou informe o campo que deseja alterar:");
                entrada = Console.ReadLine().ToUpper();

                

                

            }
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.WriteLine("        Alterado Com Sucesso!      ");
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");

            empresa.Update();
        }
    }
}
