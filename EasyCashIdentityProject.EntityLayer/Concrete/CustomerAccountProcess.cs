using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.EntityLayer.Concrete
{
    public class CustomerAccountProcess
    {
        public int CustomerAccountProcessID { get; set; }
        public string ProcessType { get; set; } //İşlem türü, alım-satım gibi netür bir işlem olduğunu tutmak için
        public decimal Amount { get; set; } //Ne kadar para gönderildi? Miktar
        public DateTime ProcessDate { get; set; } // İşlem saati
        public int? SenderID { get; set; } //Gönderen kişinin ID
        public int? ReceiverID { get; set; } //Alan kişinin ID
        public CustomerAccount SenderCustomer { get; set; }//Gönderen müşteri
        public CustomerAccount ReceiverCustomer { get; set; }//Alan müşteri
        public string Description { get; set; } //gönderilen para açıklaması
       
        //Kullanıcı hesabının işlemleri olarak düşünürsek CustomerAccount ile ilişkili aslında
    }
}
/*
 ID - İşlem türü (Gelen,gider,Ödeme) - Miktar - Tarih - Alıcı - Gönderici 
Bu ilişkiye daha sonra bakıcaz
 */