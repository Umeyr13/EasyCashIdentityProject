using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.EntityLayer.Concrete
{
    public class AppUser:IdentityUser<int>//Buradan tablonun key türünü bile ğeiştirebiliriz
        
        //IdentityUser tablosuna bu sayede adres, tel gibi tabloda olmayan şeyleri sonradan ekleyebiliceğiz
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string District { get; set; } //ilçe, kasaba
        public string City { get; set; }
        public string ImageUrl { get; set; }
        public int ConfirmCode { get; set; }
        public List<CustomerAccount> CustomerAccount { get; set; }//Kullanıcının hesapları olabilir

    }
}
