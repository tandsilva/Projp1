using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class CadastroClienteDB
    {
        private static SQLiteConnection sqliteConnection;

        public CadastroClienteDB()
        {
            sqliteConnection = ConnectionSQLite.DbConnection();
        }

        public bool Save(CadastroCliente costelaria)
        {
            try
            {
                string sql = "INSERT INTO Cliente_Costelaria(Id,Nome_Cliente,Endereco,Telelefone, Aniversario') values (@Id, @NomeCliente, @Endereco, @Telefone,@Aniversario)";

                using (var cmd = sqliteConnection.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@NomeCliente", costelaria.NomeCliente);
                    cmd.Parameters.AddWithValue("@Telefone", costelaria.Telefone);
                    cmd.Parameters.AddWithValue("@Endereco", costelaria.Endereco);
                    cmd.Parameters.AddWithValue("@Aniversario", costelaria.Aniversario);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public bool Update(CadastroCliente costelaria)
        {
            try
            {
                string sql = "UPDATE Cliente_Costelaria set Id = @Id, " +
                                                      "Nome_Cliente = @NomeCliente" +
                                                      "Endereco = @Endereco, " +
                                                      "Telefone = @Telefone, " +
                                                      "Aniversario = @Aniversario " +
                                                      "WHERE Id = @Id ";

                using (var cmd = sqliteConnection.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@Id", costelaria.Id);
                    cmd.Parameters.AddWithValue("@NomeCliente", costelaria.NomeCliente);
                    cmd.Parameters.AddWithValue("@Telefone", costelaria.Telefone);
                    cmd.Parameters.AddWithValue("@Endereco", costelaria.Endereco);
                    cmd.Parameters.AddWithValue("@Aniversario", costelaria.Aniversario);

                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                string sql = "DELETE FROM Cliente_Costelaria WHERE id = @Id";

                using (var cmd = sqliteConnection.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public DataTable FindAll()
        {
            DataTable dt = new DataTable();
            SQLiteDataAdapter da = null;

            StringBuilder sb = new StringBuilder();

            sb.Append(" SELECT id, Nome_cliente,Telefone,Endereco, Aniversario");
            sb.Append("   FROM Cliente_Costelaria");

            using (var cmd = sqliteConnection.CreateCommand())
            {
                cmd.CommandText = sb.ToString();
                da = new SQLiteDataAdapter(cmd.CommandText, sqliteConnection);
                da.Fill(dt);
            }
            return dt;
        }

        public CadastroCliente FindById(int id)
        {
            DataTable dt = new DataTable();
            SQLiteDataAdapter da = null;

            StringBuilder sb = new StringBuilder();

            sb.Append(" SELECT id, Nome_Cliente, Endereco,Telefone, Aniversario");
            sb.Append("   FROM Cliente_Costelaria");
            sb.Append("   WHERE id = " + id);

            using (var cmd = sqliteConnection.CreateCommand())
            {
                cmd.CommandText = sb.ToString();
                da = new SQLiteDataAdapter(cmd.CommandText, sqliteConnection);
                da.Fill(dt);
            }
            return ConvertDataTableToList(dt)[0];
        }

        private List<CadastroCliente> ConvertDataTableToList(DataTable dt)
        {
            var data = (from d in dt.AsEnumerable()
                        select new CadastroCliente()
                        {
                            Id = Convert.ToInt32(d["id"]),
                            NomeCliente = Convert.ToString(d["Nome_Cliente"]),
                            Endereco = Convert.ToString(d["Endereco"]),
                            Telefone = Convert.ToString(d["Telefone"]),
                            Aniversario = Convert.ToDateTime(d["Aniversario"]),
                        }).ToList();
            return data;


        }   
    }
}
