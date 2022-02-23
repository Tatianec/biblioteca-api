using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Data.SqlClient;

namespace Repositories
{
    public class Gibi
    {
        public static void save(Models.Gibi gibi)
        {

            using (SqlConnection conexao = new SqlConnection(Configuration.Parameters.getConnectionString()))
            {

                conexao.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conexao;
                    cmd.CommandText = "Insert into Gibi (titulo,valor,editora,dataPublicacao) values(@titulo, @valor, @editora, @dataPublicacao);";
                    cmd.Parameters.Add(new SqlParameter("@titulo", System.Data.SqlDbType.VarChar)).Value = gibi.Titulo;
                    cmd.Parameters.Add(new SqlParameter("@valor", System.Data.SqlDbType.Decimal)).Value = gibi.Valor;
                    cmd.Parameters.Add(new SqlParameter("@editora", System.Data.SqlDbType.VarChar)).Value = gibi.Editora;
                    cmd.Parameters.Add(new SqlParameter("@dataPublicacao", System.Data.SqlDbType.Date)).Value = gibi.DataPublicacao;
                    cmd.ExecuteNonQuery();
                }
            }

        }

        public static List<Models.Gibi> getAll()
        {
            List<Models.Gibi> gibis = new List<Models.Gibi>();

            using (SqlConnection conexao = new SqlConnection(Configuration.Parameters.getConnectionString()))
            {
                conexao.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conexao;
                    cmd.CommandText = "Select id, titulo, valor, editora, dataPublicacao from Gibi;";
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Models.Gibi gibi = new Models.Gibi();
                        gibi.Id = (int)dr["id"];
                        gibi.Titulo = (string)dr["titulo"];
                        gibi.Editora = (string)dr["editora"];
                        gibi.DataPublicacao = (DateTime)dr["dataPublicacao"];
                        gibi.Valor = (Decimal)dr["valor"];

                        gibis.Add(gibi);
                    }

                }
            }
            return gibis;
        }

        public static Models.Gibi getById(int id)
        {

            Models.Gibi gibi = new Models.Gibi();

            using (SqlConnection conexao = new SqlConnection(Configuration.Parameters.getConnectionString()))
            {
                conexao.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conexao;
                    cmd.CommandText = "Select id, titulo, valor, editora, dataPublicacao from Gibi where id = @id;";
                    cmd.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int)).Value = id;
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        gibi.Id = (int)dr["id"];
                        gibi.Titulo = (string)dr["titulo"];
                        gibi.Editora = (string)dr["editora"];
                        gibi.DataPublicacao = (DateTime)dr["dataPublicacao"];
                        gibi.Valor = (Decimal)dr["valor"];

                    }

                }
            }
            return gibi;
        }

        public static void update(Models.Gibi gibi)
        {
            using (SqlConnection conexao = new SqlConnection(Configuration.Parameters.getConnectionString()))
            {
                conexao.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conexao;
                    cmd.CommandText = "Update Gibi set titulo=@titulo, valor=@valor, editora=@editora, dataPublicacao=@dataPublicacao where id = @id;";
                    cmd.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int)).Value = gibi.Id;
                    cmd.Parameters.Add(new SqlParameter("@titulo", System.Data.SqlDbType.VarChar)).Value = gibi.Titulo;
                    cmd.Parameters.Add(new SqlParameter("@valor", System.Data.SqlDbType.Decimal)).Value = gibi.Valor;
                    cmd.Parameters.Add(new SqlParameter("@editora", System.Data.SqlDbType.VarChar)).Value = gibi.Editora;
                    cmd.Parameters.Add(new SqlParameter("@dataPublicacao", System.Data.SqlDbType.Date)).Value = gibi.DataPublicacao;
                    cmd.ExecuteNonQuery();
                }

            }
        }
        public static void deleteById(int id)
        {

            using (SqlConnection conexao = new SqlConnection(Configuration.Parameters.getConnectionString()))
            {
                conexao.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conexao;
                    cmd.CommandText = "Delete from Gibi where id = @id;";
                    cmd.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int)).Value = id;
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
