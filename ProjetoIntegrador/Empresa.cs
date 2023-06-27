using ProjetoIntegrador.BancoDados;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoIntegrador
{
    internal class Empresa 
    {
        public int ID_Empresa { get; set; } 

        public string Nome { get; set; }

        public string CNPJ { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public string Endereco { get; set; }

        public string Observacoes { get; set; } = string.Empty;

        public Empresa(int id_empresa , string nome, string cnpj, string email, string telefone, string endereco, string observacoes)
        {
            ID_Empresa = id_empresa;
            Nome = nome;
            CNPJ = cnpj;
            Email = email;
            Telefone = telefone;
            Endereco = endereco;
            Observacoes = observacoes;

        }
        public Empresa(long id)
        {
            using (var conn = new SqlConnection(DBInfo.DBConnection))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ID_EMPRESA, NOME,CNPJ, EMAIL,TELEFONE, ENDERECO,OBSERVACOES FROM EMPRESAS WHERE ID_EMPRESA = @ID_EMPRESA";

                cmd.Parameters.AddWithValue("@ID_EMPRESA", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        ID_Empresa = reader.GetInt32(0);
                        Nome = reader.GetString(1);
                        CNPJ = reader.GetString(2);
                        Email = reader.GetString(3);
                        Telefone = reader.GetString(4);
                        Endereco = reader.GetString(5);
                        Observacoes = reader.GetString(6);


                    }
                }

            }
        }

        public Empresa()
        {


            Console.WriteLine("Informe o nome da Empresa:");
            Nome = Console.ReadLine();

            Console.WriteLine("Informe o CNPJ da Empresa:");
            CNPJ = Console.ReadLine();

            Console.WriteLine("Informe o Email da Empresa:");
            Email = Console.ReadLine();

            Console.WriteLine("Informe o Telefone da Empresa:");
            Telefone = Console.ReadLine();

            Console.WriteLine("Informe o Endereço da Empresa:");
            Endereco = Console.ReadLine();

            Console.WriteLine("Informe o Observações da Empresa:");
            Observacoes = Console.ReadLine();



        }

        public void Save()
        {
            using (var conn = new SqlConnection(DBInfo.DBConnection))
            {
                conn.Open();
                var cmd = conn.CreateCommand();

                cmd.CommandText = "INSERT INTO EMPRESAS (NOME,CNPJ,EMAIL,TELEFONE,ENDERECO,OBSERVACOES) VALUES (@NOME, @CNPJ, @EMAIL, @TELEFONE, @ENDERECO, @OBSERVACOES)";

               

                cmd.Parameters.AddWithValue("@NOME", Nome == null ? DBNull.Value : Nome);
                cmd.Parameters.AddWithValue("@CNPJ", CNPJ == null ? DBNull.Value : CNPJ);
                cmd.Parameters.AddWithValue("@EMAIL", Email == null ? DBNull.Value : Email);
                cmd.Parameters.AddWithValue("@TELEFONE", Telefone == null ? DBNull.Value : Telefone);
                cmd.Parameters.AddWithValue("@ENDERECO", Endereco == null ? DBNull.Value : Endereco);
                cmd.Parameters.AddWithValue("@OBSERVACOES", Observacoes == null ? DBNull.Value : Observacoes);

                //cmd.Parameters.AddWithValue("@NOME", Nome);
                //cmd.Parameters.AddWithValue("@CNPJ", CNPJ);
                //cmd.Parameters.AddWithValue("@EMAIL", Email);
                //cmd.Parameters.AddWithValue("@TELEFONE", Telefone);
                //cmd.Parameters.AddWithValue("@ENDERECO", Endereco);
                //cmd.Parameters.AddWithValue("@OBSERVACOES", Observacoes);
                cmd.ExecuteNonQuery();
            }
        }

        public static List<Empresa> GetAll()
        {

            var result = new List<Empresa>();
            using (var conn = new SqlConnection(DBInfo.DBConnection))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ID_EMPRESA, NOME, CNPJ,EMAIL,TELEFONE,ENDERECO,OBSERVACOES FROM EMPRESAS";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var empresa = new Empresa(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5),reader.GetString(6) );
                        result.Add(empresa);
                    }
                }
            }
            return result;
        }

        public bool IsValid()
        {
            return ID_Empresa > 0;
        }

        public void Delete()
        {
            using (var conn = new SqlConnection(DBInfo.DBConnection))
            {
                conn.Open();
                var cmd = conn.CreateCommand();

                cmd.CommandText = "DELETE FROM EMPRESAS WHERE ID_EMPRESA = @ID_EMPRESA";
                cmd.Parameters.AddWithValue("@ID_EMPRESA", ID_Empresa);

                cmd.ExecuteNonQuery();

            }
        }
        public void Update()
        {
            using (var conn = new SqlConnection(DBInfo.DBConnection))
            {
                conn.Open();
                var cmd = conn.CreateCommand();

                cmd.CommandText = "UPDATE EMPRESAS SET NOME = @NOME , CNPJ = @CNPJ ,EMAIL = @EMAIL, TELEFONE = @TELEFONE, ENDERECO = @ENDERECO,OBSERVACOES = @OBSERVACOES WHERE ID_EMPRESA = @ID_EMPRESA";
                cmd.Parameters.AddWithValue("@ID_EMPRESA", ID_Empresa);
                cmd.Parameters.AddWithValue("@NOME", Nome);
                cmd.Parameters.AddWithValue("@CNPJ", CNPJ);
                cmd.Parameters.AddWithValue("@EMAIL", Email);
                cmd.Parameters.AddWithValue("@TELEFONE", Telefone);
                cmd.Parameters.AddWithValue("@ENDERECO", Endereco);
                cmd.Parameters.AddWithValue("@OBSERVACOES", Observacoes);
                
                cmd.ExecuteNonQuery();
            }
        }
    }
}
    
     
