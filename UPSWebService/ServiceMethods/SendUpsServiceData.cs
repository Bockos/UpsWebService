using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UPSWebService.Models;
using UPSWebService.UPSservice;

namespace UPSWebService.ServiceMethods
{
    public class SendUpsServiceData
    {
        public ResultOnDemandPickupRequest_Type1 SendUpsService(string ShipperName, string ShipperAddress, string ShipperCityCode, string ShipperAreaCode, string ShipperPhoneNumber, string ShipperEMail)
        {

            if (!string.IsNullOrEmpty(ShipperCityCode) && !string.IsNullOrEmpty(ShipperAreaCode))
            {
                CreateShipmentSoapClient cssc = new CreateShipmentSoapClient();

                OnDemandPickupRequestInfo_Type1 PickupRequestInfo = new OnDemandPickupRequestInfo_Type1(); //Session ile birlikte gönderilecek class

                BoxType boxType = new BoxType();
                BoxType[] _boxtypeDizi = new BoxType[1];
                ShipmentInfo_Type3 _shipmentInfo_Type3 = new ShipmentInfo_Type3();

                UpsServiceLogin UpsServiceLogin = new UpsServiceLogin();

                //Casper Bina Bilgilerini axaptanın veritabanından SP ile aldık..
                BussinesLogicCasper BLL = new BussinesLogicCasper();
                List<UpsCompanyInfoClass> CompanyInfoList = (List<UpsCompanyInfoClass>)BLL.GetConpanyInfo().Result; // SP'den gelen veriler...


                PickupRequestInfo.LabelSource = 1;
                PickupRequestInfo.PickupRequestDay = DateTime.Now.AddDays(1);
                boxType.BoxTypeCode = 1;
                boxType.BoxCount = 1;
                _boxtypeDizi[0] = boxType;
                PickupRequestInfo.RequestedBoxList = _boxtypeDizi;

                _shipmentInfo_Type3.ShipperName = ShipperName;
                _shipmentInfo_Type3.ShipperAddress = ShipperAddress;
                _shipmentInfo_Type3.ShipperCityCode = Convert.ToInt32(ShipperCityCode); //il
                _shipmentInfo_Type3.ShipperAreaCode = Convert.ToInt32(ShipperAreaCode); //ilçe
                _shipmentInfo_Type3.ShipperPhoneNumber = ShipperPhoneNumber;
                _shipmentInfo_Type3.ShipperMobilePhoneNumber = ShipperPhoneNumber;
                _shipmentInfo_Type3.ShipperEMail = ShipperEMail;
                _shipmentInfo_Type3.ConsigneeAccountNumber = "8576EE";
                _shipmentInfo_Type3.ConsigneeName = CompanyInfoList.FirstOrDefault().UNVAN;
                _shipmentInfo_Type3.ConsigneeAddress = CompanyInfoList.FirstOrDefault().ADRES;
                _shipmentInfo_Type3.ConsigneeCityCode = Convert.ToInt32(CompanyInfoList.FirstOrDefault().ilKodu);
                _shipmentInfo_Type3.ConsigneeAreaCode = Convert.ToInt32(CompanyInfoList.FirstOrDefault().ilceKodu);
                _shipmentInfo_Type3.NumberOfPackages = 1;
                _shipmentInfo_Type3.ServiceLevel = 3; //3 - DOM. STANDARD
                _shipmentInfo_Type3.PaymentType = 1; //[1=Consignee 2=Shipper 4=Thirt Party]
                _shipmentInfo_Type3.PackageType = "K";

                DimensionInfo[] dimension = new DimensionInfo[1];
                DimensionInfo dim = new DimensionInfo();

                dim.Height = 1;
                dim.Length = 1;
                dim.Width = 1;
                dim.DescriptionOfGoods = "";
                dim.Weight = 1;

                dimension[0] = dim;
                _shipmentInfo_Type3.PackageDimensions = dimension;


                PickupRequestInfo.ShipmentInfo = _shipmentInfo_Type3;

                ResultOnDemandPickupRequest_Type1 result;
                result = cssc.OnDemandPickupRequest_Type1(UpsServiceLogin.Login().SessionID, PickupRequestInfo);

                return result;
            }
            else
            {
                return null;
            }
        }


    }
}