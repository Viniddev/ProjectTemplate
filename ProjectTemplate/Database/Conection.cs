using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjectTemplate.Database
{
    internal class Conection
    {
        public SqlConnection conn = new SqlConnection();
        public AppSettings appSettings = new AppSettings();
        //Exception exception = new Exception();

        public Conection()
        {
            conn.ConnectionString = appSettings.ReadConnectionString("Database");
        }

        public SqlConnection ConectaComOBanco()
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
            return conn;
        }

        public void DesconectaComOBanco()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }
        public void ExecuteQuerySemRetorno(string query)
        {
            ConectaComOBanco();
            SqlCommand cmd = conn.CreateCommand();
            SqlTransaction transaction;
            transaction = conn.BeginTransaction("ConsultasSemRetorno");
            cmd.Connection = conn;
            cmd.Transaction = transaction;
            cmd.CommandTimeout = 120;
            cmd.CommandText = query;

            cmd.ExecuteNonQuery();

            transaction.Commit();

            DesconectaComOBanco();
        }

        public DataSet Select(string query)
        {
            DataSet ds = new DataSet();
            ConectaComOBanco();
            SqlCommand cmd = conn.CreateCommand();
            SqlTransaction transaction;
            transaction = conn.BeginTransaction("Consulta");
            cmd.Connection = conn;
            cmd.Transaction = transaction;
            cmd.CommandTimeout = 120;
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            da.Fill(ds);
            transaction.Commit();
            DesconectaComOBanco();
            return ds;
        }

        public void Bulky(DataTable dt, string destinyTable, int columMapping = 0)
        {
            ConectaComOBanco();
            using (SqlTransaction transaction = conn.BeginTransaction())
            {
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn, SqlBulkCopyOptions.KeepIdentity, transaction))
                {
                    try
                    {
                        bulkCopy.DestinationTableName = destinyTable;
                        int cont = 0;
                        foreach (DataColumn column in dt.Columns)
                        {
                            SqlBulkCopyColumnMapping map = new SqlBulkCopyColumnMapping(column.ColumnName.ToString(), cont + columMapping);
                            bulkCopy.ColumnMappings.Add(map);
                            cont++;
                        }
                        bulkCopy.WriteToServer(dt);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Erro");
                        Console.WriteLine(ex.Message);
                        //Console.ReadLine();

                        transaction.Rollback();
                        DesconectaComOBanco();
                    }
                    finally
                    {
                        DesconectaComOBanco();
                    }
                }
            }
        }
    }
}
