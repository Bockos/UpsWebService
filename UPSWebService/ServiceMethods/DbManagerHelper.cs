using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace UPSWebService.Models
{
    public class DbManagerHelper
    {

        private string _cnnstr;
        public string Cnnstr
        {
            get { return _cnnstr; }
            set
            {
                _cnnstr = value;
                CnnDb = new SqlConnection(_cnnstr);
            }
        }
        public SqlConnection CnnDb;
        public SqlTransaction Transaction = null;

        public void BeginTransaction()
        {
            try
            {
                if (CnnDb.State != ConnectionState.Open)
                    CnnDb.Open();

                Transaction = CnnDb.BeginTransaction();

            }
            catch (Exception exc)
            {
                throw exc;
            }

        }
        public void CommitTransaction()
        {
            try
            {
                Transaction.Commit();
                Transaction = null;
                CnnDb.Close();

            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
        public void RollbackTransaction()
        {
            try
            {
                Transaction.Rollback();
                Transaction = null;
                CnnDb.Close();
            }
            catch (Exception exc)
            {
                throw exc;
            }

        }

    }
}