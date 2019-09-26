using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Dynamics.BusinessConnectorNet;

namespace UPSWebService.AxaptaConnectorClasses
{
    public class AxaptaConnector
    {
        #region Class Properties
        public static Axapta Ax { get; set; }
        public static string UserName { get { return ConfigReader.AxUserName; } }
        public static string Password { get { return ConfigReader.AxPassword; } }
        public static string Domain { get { return ConfigReader.AxDomain; } }
        public static string Company { get { return ConfigReader.AxCompany; } }
        public static string Aos { get { return ConfigReader.AxAos; } }
        #endregion


        public Axapta AxaptaObject()
        {


            try
            {
                var nc = new NetworkCredential(UserName, Password, Domain);
                Ax = new Axapta();
                Ax.LogonAs(UserName, Domain, nc, Company, "", Aos, "");
            }
            catch (Exception ex)
            {
                Ax = null;
                throw ex;
            }

            return Ax;
        }  
    }
}