using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UPSWebService;
using UPSWebService.UPSservice;

namespace UPSWebService.ServiceMethods
{
    public class UpsServiceLogin
    {
        string CustomerNumber = "8576EE";
        string UserName = "cdb53h52maw";
        string Password = "vb356bNPz4";


        public ResultLogin_Type1 Login()
        {
            CreateShipmentSoapClient cssc = new CreateShipmentSoapClient();
            ResultLogin_Type1 parameters = cssc.Login_Type1(CustomerNumber, UserName, Password);
            //UPSservice.CreateShipmentSoapClient.CreateShipment shipment = new CreateShipment();
            //ResultLogin_Type1 parameters = shipment.Login_Type1(CustomerNumber, UserName, Password);
            return parameters;
        }
    }
}