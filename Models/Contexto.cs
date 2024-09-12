using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient; 

namespace Csharp.Models
{
    using System;
using System.Data.SqlClient;

class Contexto
{
    static void Main()
    {
        // Defina sua string de conexão
        string connectionString = "Server=DESKTOP-JULIA;Database=PROD_REC;";
       

        // Abre a conexão com o banco de dados
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                // Abrindo a conexão
                connection.Open();
                Console.WriteLine("Conexão aberta com sucesso.");

                // Definindo o comando SQL
                string sql = "SELECT * FROM USUARIOS"; 
                // Criando o comando
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    // Executando a consulta e lendo os dados
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Exibindo os dados de exemplo
                            Console.WriteLine($"{reader["Coluna"]}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
    }
}

}