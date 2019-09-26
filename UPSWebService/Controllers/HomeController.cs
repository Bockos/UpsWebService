using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UPSWebService.AxaptaConnectorClasses;
using UPSWebService.Models;
using UPSWebService.ServiceMethods;
using UPSWebService.UPSservice;

namespace UPSWebService.Controllers
{
    public class HomeController : Controller
    {
        //iptal.. Bu sayfa casper.com.tr template içine gömüldü ve HomePage Action kullanıldı.. 
        public ActionResult Index()
        {
            try
            {
                UPSIntegrationEntities db = new UPSIntegrationEntities();
                var A = db.UPSCargoililcekodlari.ToList();

                List<UPSCargoililcekodlari> B = new List<UPSCargoililcekodlari>();
                foreach (var item in A) //Veritabanından gelen illeri guruplamak için foreach yazdım...
                {
                    UPSCargoililcekodlari C = new UPSCargoililcekodlari();
                    C.il = item.il;
                    C.ilKodu = item.ilKodu;
                    if (B.FirstOrDefault(s => s.ilKodu == item.ilKodu) == null)
                    {
                        B.Add(C);
                    }
                }

                return View(B);
            }
            catch (Exception)
            {
                List<UPSCargoililcekodlari> B = new List<UPSCargoililcekodlari>();
                return View(B);
            }
        }

        ////////////TURBO PAGE -- UPS Kargo///////
        public ActionResult HomePage()
        {
            try
            {
                UPSIntegrationEntities db = new UPSIntegrationEntities();
                var A = db.UPSCargoililcekodlari.ToList();

                List<UPSCargoililcekodlari> B = new List<UPSCargoililcekodlari>();
                foreach (var item in A) //Veritabanından gelen illeri guruplamak için foreach yazdım..
                {
                    UPSCargoililcekodlari C = new UPSCargoililcekodlari();
                    C.il = item.il;
                    C.ilKodu = item.ilKodu;
                    if (B.FirstOrDefault(s => s.ilKodu == item.ilKodu) == null)
                    {
                        B.Add(C);
                    }
                }

                return View(B);
            }
            catch (Exception)
            {
                List<UPSCargoililcekodlari> B = new List<UPSCargoililcekodlari>();
                return View(B);
            }
        }

        ////////////JET TURBO PAGE -- TEM Kurye///////
        public ActionResult HomePage2()
        {
            try
            {
                UPSIntegrationEntities db = new UPSIntegrationEntities();
                var A = db.TEMCargo_ililcekodlari.ToList();
                return View(A);
            }
            catch (Exception)
            {
                List<TEMCargo_ililcekodlari> A = new List<TEMCargo_ililcekodlari>();
                return View(A);
            }
        }


        public ActionResult Getilce(string ilKodu) //illere göre ilçeleri ajax ile getirmek için..
        {
            UPSIntegrationEntities db = new UPSIntegrationEntities();
            var ilceler = db.UPSCargoililcekodlari.Where(s => s.ilKodu == ilKodu).ToList();
            return Json(ilceler, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CheckTarackingNum(string imei,string cargoType) //illere göre ilçeleri ajax ile getirmek için..
        {
            try
            {
                AxSendData axSendData = new AxSendData();
                string response = axSendData.getTrackinNumPhoneIMEI("", imei, cargoType);
                if (!string.IsNullOrEmpty(response))
                {
                    return Json("Takip Numaranız bulunmaktadır: " + response, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("Takip Numaranız Bulunamadı !! " + response, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {
                return Json("Takip Numaranız Bulunamadı !!! ", JsonRequestBehavior.AllowGet);
            }
        }
       

        [HttpPost]
        public ActionResult AddInfoService(string ShipperName,string ShipperAddress,string ShipperCityCode,string ShipperAreaCode,string ShipperPhoneNumber,string ShipperEMail,
                                            string ShipperSerialNumber, string ShipperDescription,string ShipperContactType,int cargoType)
        {
            UPSIntegrationEntities db = new UPSIntegrationEntities();

            //IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());
            ////////////////////////////////////////////////////////////////UPS///////////////////////////////////////////////////////////////////////////////

            if (cargoType == 1)//cargoType ---> UPS:1 TEM:2 (Ax Enum degerleri..)
            {
                try
                {
                    if (ShipperDescription.Length > 255 || ShipperAddress.Length > 255) //UPS açıklamayı en fazla 255 karakter istiyor.
                    {
                        return Json("Açıklama en fazla 255 karakter olmalıdır !!", JsonRequestBehavior.AllowGet);
                    }

                    if (!string.IsNullOrEmpty(ShipperName) && !string.IsNullOrEmpty(ShipperAddress) && !string.IsNullOrEmpty(ShipperCityCode) && !string.IsNullOrEmpty(ShipperAreaCode) && !string.IsNullOrEmpty(ShipperPhoneNumber) && !string.IsNullOrEmpty(ShipperEMail) && !string.IsNullOrEmpty(ShipperSerialNumber))
                    {

                        if (CheckDuplicate(ShipperEMail, ShipperPhoneNumber) == false)
                        {
                            return Json("Aynı gün içerisinde kayıt açamazsınız.!!", JsonRequestBehavior.AllowGet);
                        }

                        AxSendData axSendData = new AxSendData();
                        string response = axSendData.getTrackinNumPhoneIMEI(ShipperPhoneNumber, ShipperSerialNumber, "1");
                        if (!string.IsNullOrEmpty(response))
                        {
                            return Json("UPS Takip Numaranız bulunmaktadır: " + response, JsonRequestBehavior.AllowGet);
                        }

                        SendUpsServiceData UpsService = new SendUpsServiceData();
                        ResultOnDemandPickupRequest_Type1 result = UpsService.SendUpsService(ShipperName, ShipperAddress, ShipperCityCode, ShipperAreaCode, ShipperPhoneNumber, ShipperEMail);
                        Session["result.ShipmentNo"] = result.ShipmentNo;// Axaptaya kaydetmez ise veritabanına kaydetsin..
                        if (result.ErrorCode != 0)
                        {
                            return Json("UPS'e bilgiler Gönderilemedi. Kısa bir süre sonra Tekrar deneyiniz.!!", JsonRequestBehavior.AllowGet);
                        }

                        

                        var A = db.UPSCargoililcekodlari.ToList();
                        string ShipperCityCode_Name = A.FirstOrDefault(x => x.ilKodu == ShipperCityCode).il.ToString();
                        string ShipperAreaCode_Name = A.FirstOrDefault(x => x.ilceKodu == ShipperAreaCode).ilce.ToString();

                        AxSendData axSendData2 = new AxSendData();
                        string AxRecId = axSendData2.AxaptaSendDataMethodUPS(DateTime.Now, ShipperName, ShipperPhoneNumber, ShipperEMail, ShipperCityCode_Name, ShipperAreaCode_Name, ShipperAddress, ShipperSerialNumber, ShipperDescription, Convert.ToInt32(ShipperContactType), result.ShipmentNo, "", 0, 0, cargoType);


                        BussinesLogicCasper AddDB = new BussinesLogicCasper();
                        bool responsDB = AddDB.B_UPSOnDemantPickup_OrderDB_InsertData(AxRecId, ShipperContactType, ShipperAddress, ShipperAreaCode_Name, ShipperCityCode_Name, ShipperEMail, ShipperName, ShipperPhoneNumber, ShipperDescription, ShipperSerialNumber, result.ShipmentNo, "", cargoType);
                        if (responsDB == false)
                        {
                            return Json("DB'ye Bilgileriniz Gönderilemedi !!", JsonRequestBehavior.AllowGet);
                        }



                        return Json("UPS Referans No: " + result.ShipmentNo, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json("Bilgilerinizi Eksik (kontrol ederek tekrar giriniz..)", JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    BussinesLogicCasper AddDB = new BussinesLogicCasper();
                    bool responsDB = AddDB.B_UPSOnDemantPickup_OrderDB_InsertData("", ShipperContactType, ShipperAddress, ShipperAreaCode, ShipperCityCode, ShipperEMail, ShipperName, ShipperPhoneNumber, ShipperDescription, ShipperSerialNumber, Session["result.ShipmentNo"].ToString(), "", cargoType);
                    Session["result.ShipmentNo"] = null;
                   
                    return Json("Bilgileriniz Gönderilemedi !!" , JsonRequestBehavior.AllowGet);
                }
            }

            ////////////////////////////////////////////////////////////////TEM///////////////////////////////////////////////////////////////////////////////

            else if (cargoType == 2)//cargoType ---> UPS:1 TEM:2 (Ax Enum degerleri..)
            {
                string TEM_ForAxCode = "";

                try
                {
                   
                    if (!string.IsNullOrEmpty(ShipperName) && !string.IsNullOrEmpty(ShipperAddress) && !string.IsNullOrEmpty(ShipperCityCode) && !string.IsNullOrEmpty(ShipperAreaCode) && !string.IsNullOrEmpty(ShipperPhoneNumber) && !string.IsNullOrEmpty(ShipperEMail) && !string.IsNullOrEmpty(ShipperSerialNumber))
                    {
                        if (CheckDuplicate(ShipperEMail, ShipperPhoneNumber) == false)
                        {
                            return Json("Aynı gün içerisinde kayıt açamazsınız.!!", JsonRequestBehavior.AllowGet);
                        }
                        AxSendData axSendData = new AxSendData();
                        string response = axSendData.getTrackinNumPhoneIMEI(ShipperPhoneNumber, ShipperSerialNumber, "2");
                        if (!string.IsNullOrEmpty(response))
                        {
                            return Json("Kurye Takip Numaranız bulunmaktadır: " + response, JsonRequestBehavior.AllowGet);
                        }
                        
                        TEM_ForAxCode = "TEM" + DateTime.UtcNow.ToString("yyyyMMddHHmmssff", CultureInfo.InvariantCulture);

                        AxSendData axSendData2 = new AxSendData();
                        string AxRexId_TEMTrackingNum = axSendData2.AxaptaSendDataMethodTEM(DateTime.Now, ShipperName, ShipperPhoneNumber, ShipperEMail, ShipperCityCode, ShipperAreaCode, ShipperAddress, ShipperSerialNumber, ShipperDescription, Convert.ToInt32(ShipperContactType), TEM_ForAxCode, "", 0, 0, cargoType);


                        BussinesLogicCasper AddDB = new BussinesLogicCasper();
                        bool responsDB = AddDB.B_UPSOnDemantPickup_OrderDB_InsertData(AxRexId_TEMTrackingNum, ShipperContactType, ShipperAddress, ShipperAreaCode, ShipperCityCode, ShipperEMail, ShipperName, ShipperPhoneNumber, ShipperDescription, ShipperSerialNumber, "", TEM_ForAxCode, cargoType);
                        if (responsDB == false)
                        {
                            return Json("DB'ye Bilgileriniz Gönderilemedi !!", JsonRequestBehavior.AllowGet);
                        }



                        return Json("TEM Referans No: " + TEM_ForAxCode, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json("Bilgilerinizi Eksik (kontrol ederek tekrar giriniz..)", JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {

                    BussinesLogicCasper AddDB = new BussinesLogicCasper();
                    bool responsDB = AddDB.B_UPSOnDemantPickup_OrderDB_InsertData("", ShipperContactType, ShipperAddress, ShipperAreaCode, ShipperCityCode, ShipperEMail, ShipperName, ShipperPhoneNumber, ShipperDescription, ShipperSerialNumber, "", TEM_ForAxCode, cargoType);
                    
                    return Json("Bilgileriniz Gönderilemedi !!" , JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json("Kargo Tipi Seçilmedi !!", JsonRequestBehavior.AllowGet);
            }
           


        }


        public static bool CheckDuplicate(string EMail, string Phone)
        {
            UPSIntegrationEntities db = new UPSIntegrationEntities();
            bool response = true;
            var duplicateControl = db.B_UPSOnDemantPickup_Order.Where(s => s.CustomerEMail == EMail || s.CustomerPhone == Phone).ToList();
            if (duplicateControl.Count() > 0)
            {
                DateTime d = Convert.ToDateTime(duplicateControl.OrderByDescending(s => s.id).FirstOrDefault().OrderDate);
                DateTime dNow = DateTime.Now;
                if (d.Year == dNow.Year && d.Month == dNow.Month && d.Day == dNow.Day)
                {
                    response = false;
                }
            }
            return response;
        }


    }
}
