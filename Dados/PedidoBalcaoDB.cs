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
    class PedidoBalcaoDB
    {
            private static SQLiteConnection sqliteConnection;

            public PedidoBalcaoDB()
            {
                sqliteConnection = ConnectionSQLite.DbConnection();
            }

            public bool Save(PedidoBalcao pedidoBalcao)
            {
                try
                {
                    string sql = "INSERT INTO tb_pedidoBalcao (nomeCliente, pedidoE, valor) values (@NomeCliente, @PedidoE, @Valor)";

                    using (var cmd = sqliteConnection.CreateCommand())

                    {
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@NomeCliente", pedidoBalcao.NomeCliente);
                        cmd.Parameters.AddWithValue("@PedidoB", pedidoBalcao.PedidoB);
                        cmd.Parameters.AddWithValue("@Valor", pedidoBalcao.Valor);
                        cmd.ExecuteNonQuery();
                    }
                    return true;
                }
                catch (SqlException)
                {
                    throw;
                }
            }

            public bool Update(PedidoBalcao pedidoBalcao)
            {
                try
                {
                    string sql = "UPDATE tb_pedidoBalcao set nomeCliente = @NomeCliente, " +
                                                          "pedidoE = @PedidoE, " +
                                                          "valor = @Valor " +
                                                          "WHERE id = @Id ";

                    using (var cmd = sqliteConnection.CreateCommand())
                    {
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@Id", pedidoBalcao.Id);
                        cmd.Parameters.AddWithValue("@NomeCliente", pedidoBalcao.NomeCliente);
                        cmd.Parameters.AddWithValue("@PedidoE", pedidoBalcao.PedidoE);
                        cmd.Parameters.AddWithValue("@Valor", pedidoBalcao.Valor);
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
                    string sql = "DELETE FROM tb_pedidoBalcao WHERE id = @Id";

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

                sb.Append(" SELECT id, nomeCliente, pedidoB, valor");
                sb.Append("   FROM tb_pedidoBalcao");

                using (var cmd = sqliteConnection.CreateCommand())
                {
                    cmd.CommandText = sb.ToString();
                    da = new SQLiteDataAdapter(cmd.CommandText, sqliteConnection);
                    da.Fill(dt);
                }
                return dt;
            }

            public PedidoBalcao FindById(int id)
            {
                DataTable dt = new DataTable();
                SQLiteDataAdapter da = null;

                StringBuilder sb = new StringBuilder();

                sb.Append(" SELECT id, nomeCliente, pedidoB, valor");
                sb.Append("   FROM tb_pedidoBalcao");
                sb.Append("   WHERE id = " + id);

                using (var cmd = sqliteConnection.CreateCommand())
                {
                    cmd.CommandText = sb.ToString();
                    da = new SQLiteDataAdapter(cmd.CommandText, sqliteConnection);
                    da.Fill(dt);
                }
                return ConvertDataTableToList(dt)[0];
            }

            private List<PedidoBalcao> ConvertDataTableToList(DataTable dt)
            {
                var data = (from d in dt.AsEnumerable()
                            select NewMethod(d)).ToList();
                return data;
            }

            private static PedidoBalcao NewMethod(DataRow d)
            {
                return new PedidoBalcao()
                {
                    Id = Convert.ToInt32(d["id"]),
                    NomeCliente = Convert.ToString(d["nomeCliente"]),
                    PedidoB = Convert.ToDateTime(d["pedidoB"]),
                    Valor = Convert.ToInt32(d["valor"])
                };
            }
        }
    } 

