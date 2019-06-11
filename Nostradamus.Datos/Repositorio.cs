using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Linq;

namespace Nostradamus.Datos
{
    public class Repositorio
    {
        public SqlConnection con;
        private void Connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["conexion"].ToString();
            con = new SqlConnection(constr);
        }
      
        public int Add(Dictionary<string, object> dbArg, string spName)
        {
            try
            {
                Connection();
                con.Open();
                object answer = con.ExecuteScalar(spName, dbArg, null, null, commandType: CommandType.StoredProcedure);
                con.Close();
                int.TryParse(answer.ToString(), out int result);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T Query<T>(string spName, Dictionary<string, object> dbArg)
        {
            try
            {
                Connection();
                con.Open();
                IEnumerable<T> answer = con.Query<T>(spName, dbArg, commandType: CommandType.StoredProcedure);
                con.Close();
                return answer.First();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<T> Query<T>(string spName)
        {
            try
            {
                Connection();
                con.Open();
                IEnumerable<T> list = con.Query<T>(spName, commandType: CommandType.StoredProcedure);
                con.Close();
                return list.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Execute(string spName)
        {
            try
            {
                Connection();
                con.Open();
                con.Execute(spName, commandType: CommandType.StoredProcedure);
                con.Close();
              
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}