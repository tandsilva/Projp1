using FakeItEasy;
using ProjP1;
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
    class PedidoEncomendaDB
    {
        private static SQLiteConnection sqliteConnection;

        public PedidoEncomendaDB()
        {
            sqliteConnection = ConnectionSQLite.DbConnection();
        }

        public bool Save(PedidoEncomenda pedidoEncomenda)
        {
            try
            {
                string sql = "INSERT INTO tb_pedidoEncomenda (nomeCliente, pedidoE, valor) values (@NomeCliente, @PedidoE, @Valor)";

                using (var cmd = sqliteConnection.CreateCommand())
                
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@NomeCliente", pedidoEncomenda.NomeCliente);
                    cmd.Parameters.AddWithValue("@PedidoE", pedidoEncomenda.PedidoE);
                    cmd.Parameters.AddWithValue("@Valor", pedidoEncomenda.Valor);
                    cmd.ExecuteNonQuery();
                }
                return true;
                }
            catch (SqlException)
            {
                throw;
            }
        }

        public bool Update(PedidoEncomenda pedidoEncomenda)
        {
            try
            {
                string sql = "UPDATE tb_bilheteria set nomeCliente = @NomeCliente, " +
                                                      "pedidoE = @PedidoE, " +
                                                      "valor = @Valor " +
                                                      "WHERE id = @Id ";

                using (var cmd = sqliteConnection.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@Id", pedidoEncomenda.Id);
                    cmd.Parameters.AddWithValue("@NomeCliente", pedidoEncomenda.NomeCliente);
                    cmd.Parameters.AddWithValue("@PedidoE", pedidoEncomenda.PedidoE);
                    cmd.Parameters.AddWithValue("@Valor", pedidoEncomenda.Valor);
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
                string sql = "DELETE FROM tb_pedidoEncomenda WHERE id = @Id";

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

            sb.Append(" SELECT id, nomeCliente, pedidoE, valor");
            sb.Append("   FROM tb_pedidoEncomenda");

            using (var cmd = sqliteConnection.CreateCommand())
            {
                cmd.CommandText = sb.ToString();
                da = new SQLiteDataAdapter(cmd.CommandText, sqliteConnection);
                da.Fill(dt);
            }
            return dt;
        }

        public PedidoEncomenda FindById(int id)
        {
            DataTable dt = new DataTable();
            SQLiteDataAdapter da = null;

            StringBuilder sb = new StringBuilder();

            sb.Append(" SELECT id, nomeCliente, pedidoE, valor");
            sb.Append("   FROM tb_pedidoEncomenda");
            sb.Append("   WHERE id = " + id);

            using (var cmd = sqliteConnection.CreateCommand())
            {
                cmd.CommandText = sb.ToString();
                da = new SQLiteDataAdapter(cmd.CommandText, sqliteConnection);
                da.Fill(dt);
            }
            return ConvertDataTableToList(dt)[0];
        }

        private List<PedidoEncomenda> ConvertDataTableToList(DataTable dt)
        {
            var data = (from d in dt.AsEnumerable()
                        select NewMethod(d)).ToList();
            return data;
        }

        private static PedidoEncomenda NewMethod(DataRow d)
        {
            return new PedidoEncomenda()
            {
                Id = Convert.ToInt32(d["id"]),
                NomeCliente = Convert.ToString(d["nomeCliente"]),
                PedidoE = Convert.ToDateTime(d["pedidoE"]),
                Valor = Convert.ToInt32(d["valor"])
            };
        }
    }
}
