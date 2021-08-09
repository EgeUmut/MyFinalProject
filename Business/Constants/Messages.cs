using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün Eklendi!";
        public static string ProductNameInvalid = "Ürün İsmi Geçersiz!";
        public static string MaintenanceTime = "Bakım Yapılıyor Lütfen sonra deneyin";
        public static string ProductsListed = "Ürünler Listelendi!";
        public static string UnitPriceInvalid = "Geçersiz Ürün Fiyatı";
        public static string GetByIdListed = "Ürün Bulundu";
        public static string ProductCountExceedError = "Bir kategoride en fazla 10 ürün olabilir!";
        public static string CategoryLimitExceded = "En fazla 15 farklı kategori olabilir!";
        public static string AuthorizationDenied = "Yeterli yetkiye sahip değilsiniz!";
        public static string UserRegistered = "Kullanıcı Kaydedildi!";
        public static string UserNotFound = "Kullanıcı Bulunamadı! ";
        public static string PasswordError = "Şifreniz Yanlış! ";
        public static string SuccessfulLogin = "Başarıyla Giriş Yapıldı! ";
        public static string UserAlreadyExists = "Bu Kullanıcı Zaten Var! ";
        public static string AccessTokenCreated = "Token Oluşturuldu ";
        public static string ProductNameIsNotValid = "Ürün ismi geçerli değil!";
    }
}
