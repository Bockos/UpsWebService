using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UPSWebService.Models
{
    public class ResultClass
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Result { get; set; }
        public ExceptionClass Exception { get; set; }
       // public string AxaptaMessage { get; set; }
    }


    public partial class ExceptionClass
    {
        public virtual int ErrorCode { get; set; }
        public virtual string Message { get; set; }
        public virtual string InnerException { get; set; }
    }

    public static class ErrorCode
    {
        #region Başarılı durumlar
        public static ExceptionClass AuthenticationOk = new ExceptionClass { ErrorCode = 0, Message = "Kimlik bilgileri doğru", InnerException = string.Empty };
        public static ExceptionClass ListOk = new ExceptionClass { ErrorCode = 0, Message = "Listelendi", InnerException = string.Empty };
        public static ExceptionClass UpdateOk = new ExceptionClass { ErrorCode = 0, Message = "Güncellendi", InnerException = string.Empty };
        public static ExceptionClass InsertOk = new ExceptionClass { ErrorCode = 0, Message = "Kayıt Edildi", InnerException = string.Empty };
        public static ExceptionClass DeleteOk = new ExceptionClass { ErrorCode = 0, Message = "Silindi", InnerException = string.Empty };
        public static ExceptionClass RecordFound = new ExceptionClass { ErrorCode = 0, Message = "Kayıt Bulundu", InnerException = string.Empty };

        public static ExceptionClass LoginSuccess = new ExceptionClass { ErrorCode = 0, Message = "Giriş Başarılı.", InnerException = string.Empty };
        public static ExceptionClass YtsAuthenticationSuccess = new ExceptionClass { ErrorCode = 0, Message = "Yetkili teknik servis giriş kontrol başarılı.", InnerException = string.Empty };
        public static ExceptionClass TokenActive = new ExceptionClass { ErrorCode = 0, Message = "Token aktif.", InnerException = string.Empty };
        public static ExceptionClass PermissionHave = new ExceptionClass { ErrorCode = 0, Message = "İşlem yetkisi var.", InnerException = string.Empty };
        public static ExceptionClass LogOutOk = new ExceptionClass { ErrorCode = 0, Message = "Logout işlemi yapıldı.", InnerException = string.Empty };
        public static ExceptionClass EmailSend = new ExceptionClass { ErrorCode = 0, Message = "Email Gönderildi", InnerException = string.Empty };
        public static ExceptionClass CanForward = new ExceptionClass { ErrorCode = 0, Message = "Bu kayıt ilerletilebilir.", InnerException = string.Empty };




        #endregion

        #region Hatalı durumlar
        public static ExceptionClass SystemErr = new ExceptionClass { ErrorCode = 9999, Message = "Sistemsel Hata", InnerException = string.Empty };
        public static ExceptionClass IpUdidIsNull = new ExceptionClass { ErrorCode = 9998, Message = "Ip/udid numarası gönderilmedi.", InnerException = string.Empty };
        public static ExceptionClass TokenNoActive = new ExceptionClass { ErrorCode = 9997, Message = "Token numarası aktif değil.", InnerException = string.Empty };
        public static ExceptionClass PermissionNotHave = new ExceptionClass { ErrorCode = 9996, Message = "İşlem yetkisi yok.", InnerException = string.Empty };
        public static ExceptionClass LogOutError = new ExceptionClass { ErrorCode = 9995, Message = "Logout işlemi yapılamadı.", InnerException = string.Empty };
        public static ExceptionClass SourceTypeIsNull = new ExceptionClass { ErrorCode = 9994, Message = "Kaynak kodu gönderilmedi", InnerException = string.Empty };
        public static ExceptionClass AxaptaWarning = new ExceptionClass { ErrorCode = 9993, Message = "Axapta uyarısı aldı", InnerException = string.Empty };
        public static ExceptionClass AuthenticationFail = new ExceptionClass { ErrorCode = 9992, Message = "Kimlik Bilgileri Hatalı", InnerException = string.Empty };
        public static ExceptionClass LoginFailed = new ExceptionClass { ErrorCode = 9991, Message = "Giriş bilgileri hatalıdır.", InnerException = string.Empty };
        public static ExceptionClass YtsAuthenticationFailed = new ExceptionClass { ErrorCode = 9990, Message = "Hesabınızın yetkili teknik servis giriş izni yoktur.", InnerException = string.Empty };
        public static ExceptionClass YtsAnotherTokenActive = new ExceptionClass { ErrorCode = 9989, Message = "Şu an bu kullanıcı ile başka bir aktif bağlantı var.", InnerException = string.Empty };
        public static ExceptionClass SourceError = new ExceptionClass { ErrorCode = 9988, Message = "İşlem kaynağında hata", InnerException = string.Empty };
        public static ExceptionClass EmailNotSend = new ExceptionClass { ErrorCode = 9987, Message = "Email Gönderilemedi", InnerException = string.Empty };


        public static ExceptionClass NoRecord = new ExceptionClass { ErrorCode = 1001, Message = "Kayıt Bulunamadı", InnerException = string.Empty };
        public static ExceptionClass UpdateFailed = new ExceptionClass { ErrorCode = 1002, Message = "Güncellenenemedi", InnerException = string.Empty };
        public static ExceptionClass InsertFailed = new ExceptionClass { ErrorCode = 1003, Message = "Kayıt Edilemedi", InnerException = string.Empty };
        public static ExceptionClass DeleteFailed = new ExceptionClass { ErrorCode = 1004, Message = "Silinemedi", InnerException = string.Empty };
        public static ExceptionClass ListFail = new ExceptionClass { ErrorCode = 1005, Message = "Listelenemedi", InnerException = string.Empty };


        public static ExceptionClass FilterInvalid = new ExceptionClass { ErrorCode = 1006, Message = "Sorgulama Filtresi Eklenmedi.", InnerException = string.Empty };
        public static ExceptionClass CustomerAccountInvalid = new ExceptionClass { ErrorCode = 1007, Message = "İlgili Bayi Adı Boş geldi.", InnerException = string.Empty };
        public static ExceptionClass PhoneInvalid = new ExceptionClass { ErrorCode = 1008, Message = "Telefon numarası 10 karakter olmalıdır.", InnerException = string.Empty };
        public static ExceptionClass RepairStageInvalid = new ExceptionClass { ErrorCode = 1009, Message = "Onarım aşamaları boş gelemez.", InnerException = string.Empty };
        public static ExceptionClass SerialNumberInvalid = new ExceptionClass { ErrorCode = 1010, Message = "Seri numarası boş olamaz.", InnerException = string.Empty };
        public static ExceptionClass ModifiedSerialNumInvalid = new ExceptionClass { ErrorCode = 1011, Message = "Değiştirilen Seri numarası boş olamaz.", InnerException = string.Empty };
        public static ExceptionClass EmailInvalid = new ExceptionClass { ErrorCode = 1012, Message = "E-Maili geçerli formatta değil.", InnerException = string.Empty };
        public static ExceptionClass AccountNumberIsvalid = new ExceptionClass { ErrorCode = 1013, Message = "Bayi kodunu gönderilmedi.", InnerException = string.Empty };
        public static ExceptionClass UserIdIsNull = new ExceptionClass { ErrorCode = 1014, Message = "UserId gönderilmedi.", InnerException = string.Empty };
        public static ExceptionClass PasswordIsNull = new ExceptionClass { ErrorCode = 1015, Message = "Parola gönderilmedi.", InnerException = string.Empty };
        public static ExceptionClass TypeIsNull = new ExceptionClass { ErrorCode = 1016, Message = "Tip gönderilmedi.", InnerException = string.Empty };
        public static ExceptionClass ProductGroupIdInvalid = new ExceptionClass { ErrorCode = 1017, Message = "Ürün grubu filtresi boş gelemez", InnerException = string.Empty };

        public static ExceptionClass StateInvalid = new ExceptionClass { ErrorCode = 1018, Message = "İl alanı boş gönderilemez.", InnerException = string.Empty };
        public static ExceptionClass EndUserNameInvalid = new ExceptionClass { ErrorCode = 1019, Message = "Son kullanıcı adı boş gelemez.", InnerException = string.Empty };

        public static ExceptionClass ServiceOrderInvalid = new ExceptionClass { ErrorCode = 1020, Message = "Servis no gönderilmedi.", InnerException = string.Empty };
        public static ExceptionClass bilnum = new ExceptionClass { ErrorCode = 1020, Message = "Kargo Numarası gönderilmedi.", InnerException = string.Empty };

        public static ExceptionClass ErrorIdNull = new ExceptionClass { ErrorCode = 1021, Message = "Arıza grubu gönderilmemiş.", InnerException = string.Empty };

        public static ExceptionClass GsmInValid = new ExceptionClass { ErrorCode = 1022, Message = "Gsm no 5 ile başlamalı ve 10 rakamdan oluşmalıdır.", InnerException = string.Empty };
        public static ExceptionClass AddressInValid = new ExceptionClass { ErrorCode = 1023, Message = "Adres bilgisi en az 10 hane olmalıdır.", InnerException = string.Empty };
        public static ExceptionClass CountyInvalid = new ExceptionClass { ErrorCode = 1024, Message = "İlçe alanı boş gönderilemez.", InnerException = string.Empty };
        public static ExceptionClass DescriptionInvalid = new ExceptionClass { ErrorCode = 1025, Message = "Açıklama en az 10 hane olmalıdır.", InnerException = string.Empty };
        public static ExceptionClass PhisicalControlNoteInvalid = new ExceptionClass { ErrorCode = 1026, Message = "Fiziksel kontrol noktaları en az 10 hane olmalıdır.", InnerException = string.Empty };
        public static ExceptionClass DefectGroupInvalid = new ExceptionClass { ErrorCode = 1027, Message = "Arıza grubu gönderilmedi.", InnerException = string.Empty };
        public static ExceptionClass DefectTypeInvalid = new ExceptionClass { ErrorCode = 1028, Message = "Arıza tanımı gönderilmedi.", InnerException = string.Empty };

        public static ExceptionClass ProjectInvalid = new ExceptionClass { ErrorCode = 1029, Message = "Proje gönderilmedi.", InnerException = string.Empty };
        public static ExceptionClass IdentityInvalid = new ExceptionClass { ErrorCode = 1030, Message = "TC Kimlik  numarası 11 karakter olmalıdır.", InnerException = string.Empty };
        public static ExceptionClass SendTypeInvalid = new ExceptionClass { ErrorCode = 1031, Message = "Gönderim tipi boş olamaz.", InnerException = string.Empty };
        public static ExceptionClass EmployeePreviousInvalid = new ExceptionClass { ErrorCode = 1032, Message = "Önceki kullanıcı boş olamaz.", InnerException = string.Empty };
        public static ExceptionClass EmployeeNextInvalid = new ExceptionClass { ErrorCode = 1033, Message = "Sonraki kullanıcı boş olamaz.", InnerException = string.Empty };
        public static ExceptionClass StartDateInvalid = new ExceptionClass { ErrorCode = 1034, Message = "Başlangıç tarihi hatalı.", InnerException = string.Empty };
        public static ExceptionClass EndDateInvalid = new ExceptionClass { ErrorCode = 1100, Message = "Bitiş tarihi hatalı.", InnerException = string.Empty };
        public static ExceptionClass ProductCodeInvalid = new ExceptionClass { ErrorCode = 1035, Message = "Ürün kodu hatalı.", InnerException = string.Empty };
        public static ExceptionClass ErrorStatusIdInvalid = new ExceptionClass { ErrorCode = 1036, Message = "Arıza durumu gönderilmemiş.", InnerException = string.Empty };
        public static ExceptionClass RepairJournalIdInvalid = new ExceptionClass { ErrorCode = 1037, Message = "Onarım günlüğü numarası hatalı.", InnerException = string.Empty };

        public static ExceptionClass ServiceSymptomsStatusInvalid = new ExceptionClass { ErrorCode = 1038, Message = "Ana ürün arıza durumu hatalı.", InnerException = string.Empty };
        public static ExceptionClass DefectRealInvalid = new ExceptionClass { ErrorCode = 1039, Message = "Tespit edilen arıza hatalı.", InnerException = string.Empty };
        public static ExceptionClass DefectStatusReferanceInvalid = new ExceptionClass { ErrorCode = 1040, Message = "Onurum sonucu hatalı.", InnerException = string.Empty };
        public static ExceptionClass ServiceSymptomsResultInvalid = new ExceptionClass { ErrorCode = 1041, Message = "Teknisyen açıklaması hatalı.", InnerException = string.Empty };
        public static ExceptionClass DefectAssumeInvalid = new ExceptionClass { ErrorCode = 1042, Message = "Arıza durumu hatalı.", InnerException = string.Empty };
        public static ExceptionClass ProductAmountInvalid = new ExceptionClass { ErrorCode = 1043, Message = "Ürün ücreti hatalı.", InnerException = string.Empty };
        public static ExceptionClass ProductCurrenyInvalid = new ExceptionClass { ErrorCode = 1044, Message = "Ürün para birimi hatalı.", InnerException = string.Empty };
        public static ExceptionClass ProductCurrenyAmountInvalid = new ExceptionClass { ErrorCode = 1045, Message = "Ürün para birimi tutarı hatalı.", InnerException = string.Empty };
        public static ExceptionClass AccountInfoInvalid = new ExceptionClass { ErrorCode = 1046, Message = "Firma ambar bilgileri bulunamadı.", InnerException = string.Empty };
        public static ExceptionClass RepairJournalLineIdInvalid = new ExceptionClass { ErrorCode = 1047, Message = "Onarım günlüğü parça no hatalı.", InnerException = string.Empty };
        public static ExceptionClass ProjectCategoryGroupIdInvalid = new ExceptionClass { ErrorCode = 1048, Message = "Ücret kategorisi hatalı.", InnerException = string.Empty };
        public static ExceptionClass ProjectCategoryIdInvalid = new ExceptionClass { ErrorCode = 1049, Message = "Ücret tipi hatalı.", InnerException = string.Empty };
        public static ExceptionClass PriceInvalid = new ExceptionClass { ErrorCode = 1050, Message = "Ücret bilgisi hatalı.", InnerException = string.Empty };
        public static ExceptionClass PriceIsZero = new ExceptionClass { ErrorCode = 1051, Message = "Ücret 0'dan büyük olmalı.", InnerException = string.Empty };
        public static ExceptionClass TransactionTypeInvalid = new ExceptionClass { ErrorCode = 1052, Message = "İşlem tipi hatalı.", InnerException = string.Empty };
        public static ExceptionClass StockInvalid = new ExceptionClass { ErrorCode = 1053, Message = "Stok bilgisi hatalı.", InnerException = string.Empty };
        public static ExceptionClass TechnicalInvalid = new ExceptionClass { ErrorCode = 1054, Message = "Teknisyen bilgisi hatalı.", InnerException = string.Empty };
        public static ExceptionClass RepairCenterInvalid = new ExceptionClass { ErrorCode = 1055, Message = "Onarım merkezi bilgisi hatalı.", InnerException = string.Empty };
        public static ExceptionClass DefectCenterInvalid = new ExceptionClass { ErrorCode = 1056, Message = "Arıza kabul merkezi bilgisi hatalı.", InnerException = string.Empty };
        public static ExceptionClass FirstNameInvalid = new ExceptionClass { ErrorCode = 1057, Message = "İsim bilgisi hatalı.", InnerException = string.Empty };
        public static ExceptionClass LastNameInvalid = new ExceptionClass { ErrorCode = 1058, Message = "Soyadı bilgisi hatalı.", InnerException = string.Empty };
        public static ExceptionClass WareHouseInvalid = new ExceptionClass { ErrorCode = 1059, Message = "Ambar bilgisi hatalı.", InnerException = string.Empty };
        public static ExceptionClass RefundHeaderInvalid = new ExceptionClass { ErrorCode = 1060, Message = "İade grup no bilgisi hatalı.", InnerException = string.Empty };
        public static ExceptionClass RecIdInvalid = new ExceptionClass { ErrorCode = 1061, Message = "Kayıt No numarası boş olamaz.", InnerException = string.Empty };
        public static ExceptionClass CantForward = new ExceptionClass { ErrorCode = 1062, Message = "Bu kayıt ilerletilemez.", InnerException = string.Empty };
        public static ExceptionClass TermInvalid = new ExceptionClass { ErrorCode = 1063, Message = "Dönem belirtilmedi.", InnerException = string.Empty };


        public static ExceptionClass foreignFormNo = new ExceptionClass { ErrorCode = 1109, Message = "Dış Servis Numarası Boş olamaz.", InnerException = string.Empty };
        public static ExceptionClass CargoCompany = new ExceptionClass { ErrorCode = 1101, Message = "Kargo Adı Boş Olamaz.", InnerException = string.Empty };
        public static ExceptionClass DocumentNumber = new ExceptionClass { ErrorCode = 1102, Message = "Kargo Adı Boş Olamaz.", InnerException = string.Empty };
        public static ExceptionClass SenderPerson = new ExceptionClass { ErrorCode = 1103, Message = "Gönderen Boş Olamaz.", InnerException = string.Empty };
        public static ExceptionClass ReceivingPerson = new ExceptionClass { ErrorCode = 1105, Message = "Alıcı Adı Boş Olamaz.", InnerException = string.Empty };
        public static ExceptionClass CargoNumber = new ExceptionClass { ErrorCode = 1106, Message = "Kargo Adedi En Az 1 Adet Olmalıdır..", InnerException = string.Empty };


        public static ExceptionClass SalesId = new ExceptionClass { ErrorCode = 1107, Message = "Satış Numarası boş olamaz.", InnerException = string.Empty };
        public static ExceptionClass ShipCarrier = new ExceptionClass { ErrorCode = 1108, Message = "Kargo adı boş olamaz", InnerException = string.Empty };
        public static ExceptionClass CargoDocNumber = new ExceptionClass { ErrorCode = 1109, Message = "Kargo numarası boş olamaz", InnerException = string.Empty };


        #endregion


    }
}
