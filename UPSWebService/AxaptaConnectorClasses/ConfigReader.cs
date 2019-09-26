using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace UPSWebService.AxaptaConnectorClasses
{
    public class ConfigReader
    {
        public static string AxUserName
        {
            get { return ConfigurationSettings.AppSettings["AxUserName"]; }

        }
        public static string AxPassword
        {
            get { return ConfigurationSettings.AppSettings["AxPassword"]; }
        }
        public static string AxDomain
        {
            get { return ConfigurationSettings.AppSettings["AxDomain"]; }
        }
        public static string AxCompany
        {
            get { return ConfigurationSettings.AppSettings["AxCompany"]; }
        }
        public static string AxAos
        {
            get { return ConfigurationSettings.AppSettings["AxAos"]; }
        }

        public static string Username
        {
            get { return ConfigurationSettings.AppSettings["Username"]; }
        }
        public static string Password
        {
            get { return ConfigurationSettings.AppSettings["Password"]; }
        }


    }
}