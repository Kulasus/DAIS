using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace PollsApplication.ORM
{
    class Database
    {
        private SqlConnection Connection { get; set; }
        private SqlTransaction SqlTransaction { get; set; }
        public string Language { get; set; }

        public Database()
        {
            Connection = new SqlConnection();
            Language = "en";
        }

        public bool Connect(string connectionString)
        {
            if(Connection.State != System.Data.ConnectionState.Open)
            {
                try
                {
                    Connection.ConnectionString = connectionString;
                    Connection.Open();
                }
                catch(Exception)
                {
                    throw new ORMException("Connection could not be established.. Try again in a few minutes. If problem persist, please contact our support on lukas.kondiolka.st@vsb.cz");
                }
            }
            return true;
        }

        public bool Connect()
        {
            if(Connection.State != System.Data.ConnectionState.Open)
            {
                return Connect(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            }
            return false;
        }

        public void Close()
        {
            Connection.Close();
        }

        public void BeginTransaction()
        {
            SqlTransaction = Connection.BeginTransaction(IsolationLevel.Serializable);
        }

        public void EndTransaction()
        {
            SqlTransaction.Commit();
            Close();
        }

        public void Rollback()
        {
            SqlTransaction.Rollback();
        }

        public int ExecuteNonQuery(SqlCommand command)
        {
            int rowNumber = 0;
            try
            {
                rowNumber = command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new ORMException("Something went wrong while executing sql querry!\n" +
                    "Please contact our support on lukas.kondiolka.st@vsb.cz");
            }
            return rowNumber;
        }

        public SqlCommand CreateCommand(string strCommand)
        {
            SqlCommand command = new SqlCommand(strCommand, Connection);

            if(SqlTransaction != null)
            {
                command.Transaction = SqlTransaction;
            }
            return command;
        }

        public SqlDataReader Select(SqlCommand command)
        {
            SqlDataReader sqlReader = command.ExecuteReader();
            return sqlReader;
        }
    }
}
