using Microsoft.Dynamics.BusinessConnectorNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UPSWebService.AxaptaConnectorClasses
{
    public class AxSendData
    {
        public string AxaptaSendDataMethodUPS(DateTime _orderDate, string _customerName, string _customerPhone, string _customerEMail, string _customerState, string _customerCounty, string _customerAddress,
                                            string _serialNumber, string _defectDesc, int _contactType, string _uPSTrackingNum, string _serviceOrderId, int _serviceLocation, int _serviceCustAccount,int _cargoType)
        {
            var axc = new AxaptaConnector();
            var axObject = axc.AxaptaObject();

          


            try
            {
                var parameters = new object[]
                {
                           _orderDate,
                           _customerName,
                           _customerPhone,
                           _customerEMail,
                           _customerState,
                           _customerCounty,
                           _customerAddress,
                           _serialNumber,
                           _defectDesc,
                           _contactType,
                           _uPSTrackingNum,
                           _serviceOrderId,
                           _serviceLocation,
                           _serviceCustAccount,
                           _cargoType

                };
                var returnvalue = axObject.CallStaticClassMethod("B_UPSServiceIntegrationEngine", "createOrderUPS", parameters).ToString(); ;

                axObject.Logoff();
                return returnvalue;
            }
            catch (Exception)
            {
                axObject.Logoff();
                throw;
            }
        }



        public string AxaptaSendDataMethodTEM(DateTime _orderDate, string _customerName, string _customerPhone, string _customerEMail, string _customerState, string _customerCounty, string _customerAddress,
                                           string _serialNumber, string _defectDesc, int _contactType,string _temTrackingNum, string _serviceOrderId, int _serviceLocation, int _serviceCustAccount, int _cargoType)
        {
            var axc = new AxaptaConnector();
            var axObject = axc.AxaptaObject();


            //AxaptaContainer container = axObject.CreateAxaptaContainer();

            try
            {
                var parameters = new object[]
                {
                           _orderDate,
                           _customerName,
                           _customerPhone,
                           _customerEMail,
                           _customerState,
                           _customerCounty,
                           _customerAddress,
                           _serialNumber,
                           _defectDesc,
                           _contactType,
                           _temTrackingNum,
                           _serviceOrderId,
                           _serviceLocation,
                           _serviceCustAccount,
                           _cargoType

                };
                var RecId = axObject.CallStaticClassMethod("B_UPSServiceIntegrationEngine", "createOrderTEM", parameters);


                //string s = "";
                //foreach (var item in container)
                //{
                //    s += item.ToString() + ":";
                //}
                //string[] dizi = s.Split(':');

                axObject.Logoff();
                return RecId.ToString();

            }
            catch (Exception)
            {
                axObject.Logoff();
                throw;
            }
        }



        public string getTrackinNumPhoneIMEI(string phone, string imei, string cargoType) //Phone phone,B_ItemSerialNum imei,str cargoType
        {
            var axc = new AxaptaConnector();
            var axObject = axc.AxaptaObject();


            //AxaptaContainer container = axObject.CreateAxaptaContainer();

            try
            {
                var parameters = new object[]
                {
                    phone,
                    imei,
                    cargoType
                          
                };
                var trackingNum = axObject.CallStaticClassMethod("B_UPSServiceIntegrationEngine", "getTrackinNumPhoneIMEI", parameters);

                axObject.Logoff();
                return trackingNum.ToString();

            }
            catch (Exception)
            {
                axObject.Logoff();
                throw;
            }
        }

    }
}