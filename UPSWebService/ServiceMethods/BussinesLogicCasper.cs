using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using UPSWebService.AxaptaConnectorClasses;

namespace UPSWebService.Models
{
    public class BussinesLogicCasper
    {
         private readonly DbManagerHelper _dbHelper;
         public BussinesLogicCasper()
        {
            _dbHelper = new DbManagerHelper { Cnnstr = ConfigurationManager.ConnectionStrings["AxDBConnectionString"].ConnectionString };
        }


        public ResultClass GetConpanyInfo()
        {
            #region Parameters
           
            var exception = new ExceptionClass();
            var success = false;
            object result = null;
            #endregion
            #region Service Code
            try
            {
                var list = new List<UpsCompanyInfoClass>();
                var dataaccessclass = new DataAccessCasper(_dbHelper);
                var datatable = dataaccessclass.GetUpsCompanyInfo();

                if (datatable.Rows.Count.Equals(0))
                {
                    success = true;
                    exception = ErrorCode.NoRecord;
                    result = list;
                }
                else
                {
                    foreach (DataRow datarow in datatable.Rows)
                    {
                        var item = new UpsCompanyInfoClass()
                        {
                            UNVAN = datarow["UNVAN"].ToString(),
                            ADRES = datarow["ADRES"].ToString(),
                            TELEFON = datarow["TELEFON"].ToString(),
                            ilceKodu = datarow["ILCE_KODU"].ToString(),
                            ilKodu = datarow["IL_KODU"].ToString(),
                        };
                        list.Add(item);
                    }
                    result = list;
                    exception = ErrorCode.ListOk;
                    success = true;
                }
            }
            catch (Exception exc)
            {
                exception = ErrorCode.SystemErr;
                exception.InnerException = exc.Message;
            }
            #endregion
            return new ResultClass { /*Exception = exception,Message = exception.Message,*/ Success = success, Result = result };
        }



        public bool B_UPSOnDemantPickup_OrderDB_InsertData(string AxRecId, string ShipperContactType, string ShipperAddress, string ShipperAreaCode, string ShipperCityCode, string ShipperEMail, string ShipperName,
                                                             string ShipperPhoneNumber, string ShipperDescription, string ShipperSerialNumber, string UPSTrackingNum,string TEMTrackingNum,int cargoType)
        {
            UPSIntegrationEntities db = new UPSIntegrationEntities();

            try
            {
                B_UPSOnDemantPickup_Order dbClass = new B_UPSOnDemantPickup_Order();
                dbClass.AxRecId = AxRecId;
                dbClass.ContactType = ShipperContactType;
                dbClass.CustomerAddress = ShipperAddress;
                dbClass.CustomerCounty = ShipperAreaCode;
                dbClass.CustomerState = ShipperCityCode;
                dbClass.CustomerEMail = ShipperEMail;
                dbClass.CustomerName = ShipperName;
                dbClass.CustomerPhone = ShipperPhoneNumber;
                dbClass.DefectDesc = ShipperDescription;
                dbClass.OrderDate = DateTime.Now;
                dbClass.SerialNumber = ShipperSerialNumber;
                dbClass.UPSTrackingNum = UPSTrackingNum;
                dbClass.CargoType = cargoType.ToString();
                dbClass.TEMTrackingNum = TEMTrackingNum.ToString();
                //dbClass.id = 1;
                //dbClass.PartyId = "1";
                //dbClass.ServiceCustAccount = "1";
                //dbClass.ServiceLocation = 11;
                //dbClass.ServiceOrderId = "234";
                db.B_UPSOnDemantPickup_Order.Add(dbClass);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }


        }



    }
}