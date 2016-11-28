﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard_HR.Repository.Repository
{
    public class DashboardBp 
    {
        public DataSet ADataset; 

        private readonly string _con = DbConnection.GetDefaultConnection();
        public DataSet GetBusinessplanDataFromDb()
        {
            using (var conn = new SqlConnection(_con))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                ADataset = new DataSet();
                try
                {
                    cmd = new SqlCommand("[dbo].[Dashboard_Get_BusinessplanData]", conn);
                    cmd.Parameters.Add(new SqlParameter("@UserId", ""));
                    cmd.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand = cmd;
                    da.Fill(ADataset);
                    return ADataset;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }
        }

        public DataSet GetDashboardFindByCompanyFromDb()
        {
            using (var conn = new SqlConnection(_con))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                ADataset = new DataSet();
                try
                {
                    cmd = new SqlCommand("[dbo].[Dashboard_Get_DashboardFindByCompanyData]", conn);
                    cmd.Parameters.Add(new SqlParameter("@UserId", ""));
                    cmd.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand = cmd;
                    da.Fill(ADataset);
                    return ADataset;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }
        }
    }
}
