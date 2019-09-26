using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace UPSWebService.Models
{
    public class DataAccessCasper
    {
        readonly DbManagerHelper _dbHelper;
        public DataAccessCasper(DbManagerHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }



        public DataTable GetUpsCompanyInfo()
        {
            try
            {
                var cmd = new SqlCommand(@"sp_getUpsCompanyInfo", _dbHelper.CnnDb)
                {
                    CommandType = CommandType.StoredProcedure,
                    Transaction = _dbHelper.Transaction
                };
                //  cmd.Parameters.Add("@YTSCustAccount", SqlDbType.NVarChar, 30).Value = custAccount;
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }




    }
}