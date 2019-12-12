using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Types;

namespace DAL
{
    public class DataAccess

    {
        public DataTable Execute(string cmdText, CommandType cmdType, List<ParmStruct> parms)
        {
            SqlCommand cmd = CreateCommand(cmdText, cmdType, parms);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);
            return dt;
        }

        public int ExecuteNonQuery(string cmdText, CommandType cmdType, List<ParmStruct> parms)
        {
            SqlCommand cmd = CreateCommand(cmdText, cmdType, parms);

            using (cmd.Connection)
            {
                cmd.Connection.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public object ExecuteScalar(string cmdText, CommandType cmdType, List<ParmStruct> parms)
        {
            SqlCommand cmd = CreateCommand(cmdText, cmdType, parms);

            using (cmd.Connection)
            {
                cmd.Connection.Open();
                return cmd.ExecuteScalar();
            }
        }

        public SqlCommand CreateCommand(string cmdText, CommandType cmdType, List<ParmStruct> parms)
        {
            //SqlConnection conn = new SqlConnection(
            //    Properties.Settings.Default.cnnString);
            SqlConnection conn = new SqlConnection(
                ConfigurationManager.ConnectionStrings["Forms.Properties.Settings.cnnString"].ConnectionString);



            SqlCommand cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = cmdType;

            if (parms != null)
            {
                foreach (ParmStruct p in parms)
                {
                    cmd.Parameters.Add(new SqlParameter(p.Name,
                        p.DataType, p.Size));
                    cmd.Parameters[p.Name].Value = p.Value;
                    cmd.Parameters[p.Name].Direction = p.Direction;
                }
            }

            return cmd;
        }

    }
}

