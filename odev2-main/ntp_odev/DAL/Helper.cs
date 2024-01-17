﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class Helper
    {
        private static SqlConnection _connection;
        private static SqlCommand _command; 
        private static SqlDataReader _reader;
        private static Helper _helper;
        SqlConnection cn;
        SqlCommand cmd;
        string cstr = ConfigurationManager.ConnectionStrings["cstr"].ConnectionString;

        

        public int ExecuteNonQuery(string cmdtext, SqlParameter[] p = null)
        {
            try
            {

           
            using (cn = new SqlConnection(cstr))
            {
                using (cmd = new SqlCommand(cmdtext, cn))
                {
                    if (p != null)
                    {
                        cmd.Parameters.AddRange(p);
                    }
                    cn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public SqlDataReader ExecuteReader(string cmdtext, SqlParameter[] p = null)
        {
            try
            {

            
            cn = new SqlConnection(cstr);
            cmd = new SqlCommand(cmdtext, cn);
            if (p != null)
            {
                cmd.Parameters.AddRange(p);
            }
            cn.Open();
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
