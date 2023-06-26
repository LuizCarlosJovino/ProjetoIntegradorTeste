using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ProjetoIntegrador.BancoDados
{
    internal class DBInfo
    {
        // faz a ligação com o banco de dados 
        public const string DBConnection = @"Data Source=BUE0102D004\SQLEXPRESS;Initial Catalog=EMPRESA_TRAMPOU;User ID=sa;Password=Senac@2023;";

        // faz o teste de conexao 
        public static bool TestDBConnection()
        {
            var result = false;

            using (var conn = new SqlConnection(DBConnection))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                // 
                cmd.CommandText = "SELECT COUNT (ID) FROM EMPRESAS ";

                var reader = cmd.ExecuteReader();

                if(reader.Read())
                {
                    Console.WriteLine($" O comondo foi executado e retornou {reader.GetInt32(0)} registros em empresas!");
                }

                //conn.Close();
            }

            return result;
        }
    }
}
