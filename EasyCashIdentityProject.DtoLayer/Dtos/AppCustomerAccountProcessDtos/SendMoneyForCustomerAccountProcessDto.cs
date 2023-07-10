using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.DtoLayer.Dtos.AppCustomerAccountProcessDtos
{
    public class SendMoneyForCustomerAccountProcessDto
    {
    
        public string ProcessType { get; set; } 
        public decimal Amount { get; set; } //Ne kadar para gönderildi? Miktar
        public DateTime ProcessDate { get; set; } // İşlem saati
        public int SenderID { get; set; } //Gönderen kişinin ID
        public int ReceiverID { get; set; } //Alan kişinin ID
        public string ReceiverAccountNumber { get; set; } //Alıcının Hesap Numarası
        public string Description { get; set; } 
    }
}
