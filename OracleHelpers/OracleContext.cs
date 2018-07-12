using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace EmployeesAPI.OracleHelpers
{
    public class OracleContext
    {
        public static string ConnectionString { set; get; }

        private static OracleConnection conn = null;

        private static bool Open()
        {
            conn = new OracleConnection(ConnectionString);
            try
            {
                conn.Open();
                return true;
            }
            catch (System.Exception ex)
            {
                var ms =  $"User Id=HR;Password=123456;Data Source={Environment.GetEnvironmentVariable("DB_ENVIRONMENT")} --- {ex.Message}";
                throw new System.Exception(ms, ex);
            }
        }
        private static void Close()
        {
            if (conn != null)
            {
                conn.Close();
                conn.Dispose();
                conn = null;
            }
        }
        public static int CreateUpdateDelete(string sql)
        {
            Open();
            OracleCommand cmd = new OracleCommand(sql, conn);
            int result = cmd.ExecuteNonQuery();
            Close();
            return result;
        }
        public static IList<T> QueryForList<T>(string sql)
        {
            Open();
            OracleDataReader Dtr = QueryForReader(sql);
            var list = DataReaderToList<T>(Dtr);
            Close();
            return list;
        }
        public static object QueryForObj<T>(string sql)
        {
            Open();
            OracleDataReader Dtr = QueryForReader(sql);
            var obj = DataReaderToObject<T>(Dtr);
            Close();
            return obj;
        }

        private static OracleDataReader QueryForReader(string sql)
        {
            try
            {
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                OracleDataReader dtr = cmd.ExecuteReader();
                return dtr;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        private static IList<T> DataReaderToList<T>(OracleDataReader rdr)
        {
            IList<T> list = new List<T>();

            while (rdr.Read())
            {
                T t = System.Activator.CreateInstance<T>();
                Type obj = t.GetType();

                for (int i = 0; i < rdr.FieldCount; i++)
                {
                    object tempValue = null;


                    if (rdr.IsDBNull(i))
                    {
                        string typeFullName = obj.GetProperty(rdr.GetName(i)).PropertyType.FullName;
                        tempValue = GetDBNullValue(typeFullName);
                    }
                    else
                    {
                        tempValue = rdr.GetValue(i);
                    }

                    obj.GetProperty(rdr.GetName(i)).SetValue(t, tempValue, null);
                }

                list.Add(t);
            }
            return list;
        }

        private static object DataReaderToObject<T>(OracleDataReader rdr)
        {
            T t = System.Activator.CreateInstance<T>();
            Type obj = t.GetType();


            if (rdr.Read())
            {
                for (int i = 0; i < rdr.FieldCount; i++)
                {
                    object tempValue = null;


                    if (rdr.IsDBNull(i))
                    {


                        string typeFullName = obj.GetProperty(rdr.GetName(i)).PropertyType.FullName;
                        tempValue = GetDBNullValue(typeFullName);


                    }
                    else
                    {
                        tempValue = rdr.GetValue(i);


                    }


                    obj.GetProperty(rdr.GetName(i)).SetValue(t, tempValue, null);


                }
                return t;
            }
            else
                return null;


        }

        private static object GetDBNullValue(string typeFullName)
        {

            typeFullName = typeFullName.ToLower();


            if (typeFullName == OracleDbType.Varchar2.ToString().ToLower())
            {
                return String.Empty;
            }
            if (typeFullName == OracleDbType.Int32.ToString().ToLower())
            {
                return 0;
            }
            if (typeFullName == OracleDbType.Date.ToString().ToLower())
            {
                return Convert.ToDateTime("");
            }
            if (typeFullName == OracleDbType.Boolean.ToString().ToLower())
            {
                return false;
            }
            if (typeFullName == OracleDbType.Int16.ToString().ToLower())
            {
                return 0;
            }


            return null;
        }

        public static int ExecuteProc(string ProcName)
        {
            return ExecuteSQL(ProcName, null, CommandType.StoredProcedure);
        }


        public static int ExcuteProc(string ProcName, OracleParameter[] pars)
        {
            return ExecuteSQL(ProcName, pars, CommandType.StoredProcedure);
        }


        public static int ExecuteSQL(string strSQL)
        {
            return ExecuteSQL(strSQL, null);
        }


        public static int ExecuteSQL(string strSQL, OracleParameter[] paras)
        {
            return ExecuteSQL(strSQL, paras, CommandType.Text);
        }

        public static int ExecuteSQL(string strSQL, OracleParameter[] paras, CommandType cmdType)
        {
            int i = 0;
            Open();
            OracleCommand cmd = new OracleCommand(strSQL, conn);
            cmd.CommandType = cmdType;
            if (paras != null)
            {
                cmd.Parameters.AddRange(paras);
            }
            i = cmd.ExecuteNonQuery();
            Close();


            return i;
        }

    }
}
