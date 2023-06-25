using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.EntityLayer.Concrete
{
    public class CustomerAccount
    {
        public int CustomerAccountID { get; set; }
        public string CustomerAccountNumber { get; set; }
        public string CustomerAccountCurrency { get; set; } //Hesabın Döviz türü
        public decimal CustomerAccountBalance { get; set; } //Hesap bakiyesi
        public string BankBranch { get; set; }   //Banka şubesi

        public int AppUserID { get; set; }  //Hesab hangi kullanıcının hesabı
        public AppUser AppUser { get; set; } //Hesabın Kullanıcısı Var
        public List<CustomerAccountProcess> CustomerSender { get; set; }//Müşterinin gönderdiği paralar
        public List<CustomerAccountProcess> CustomerReceiver { get; set; }//Müşterinin aldığı paralar paralar
    }
}
