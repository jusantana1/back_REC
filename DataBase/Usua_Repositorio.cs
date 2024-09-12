using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Csharp.Models;

namespace Csharp.DataBase
{
    public class Usua_Repositorio
    {
        private string connectionString = "Server=DESKTOP-JULIA;Database=PROD_REC;";

    // Método para listar todos os clientes
    public List<CadUserModel> ListarClientes() 
    {
        var usuarios = new List<CadUserModel>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string sql = "SELECT usua_id, usua_nome, usua_email, usua_dt_cadastro FROM USUARIOS";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    CadUserModel.add(new CadUserModel
                    {
                        usua_id = (int)reader["usua_id"],
                        usua_nome = (string)reader["usua_nome"],
                        usua_email = (string)reader["usua_email"],
                        usua_dt_cadastro = (string)reader["usua_dt_cadastro"]
                    });
                }
            }
        }

        return ListarClientes (); 
    }

    // Método para inserir um novo cliente
    public void InserirCliente(CadUserModel CadUserModel)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string sql = "INSERT INTO USUARIOS (usua_nome, usua_email, usua_dt_cadastro) VALUES (@usua_nome, @usua_email, @usua_dt_cadastro)";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("usua_nome", CadUserModel.usua_nome);
                command.Parameters.AddWithValue("@usua_email", CadUserModel.usua_email);
                command.Parameters.AddWithValue("@usua_dt_cadastro", CadUserModel.usua_dt_cadastro);
                command.ExecuteNonQuery();
            }
        }
    }
        
    }
}