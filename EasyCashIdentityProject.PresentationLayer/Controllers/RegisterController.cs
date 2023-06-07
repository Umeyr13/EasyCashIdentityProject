using EasyCashIdentityProject.DtoLayer.Dtos.AppUserDtos;
using EasyCashIdentityProject.EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace EasyCashIdentityProject.PresentationLayer.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(AppUserRegisterDto appUserRegisterDto)
        {

            if (ModelState.IsValid)
            {
                Random random = new Random();
                int code;
                code = random.Next(100000, 1000000);
                AppUser appUser = new AppUser()
                {
                    UserName = appUserRegisterDto.Username,
                    Name = appUserRegisterDto.Name,
                    Surname = appUserRegisterDto.Surname,
                    Email = appUserRegisterDto.Email,
                    City ="TR",
                    District ="Avcılar",
                    ImageUrl="132",
                    ConfirmCode = code
                };
                var result = await _userManager.CreateAsync(appUser,appUserRegisterDto.Password);//Await yazar yazmaz metot Asenkron metot a dönüştü.
                if (result.Succeeded)
                {
                    //mail gönderme
                    MimeMessage mimeMessage = new MimeMessage();
                    MailboxAddress mailboxAddressFrom = new MailboxAddress("Easy Cash Admin", "send.posta@hotmail.com");
                    MailboxAddress mailboxAddressTo = new MailboxAddress("User",appUser.Email);
                    mimeMessage.From.Add(mailboxAddressFrom);
                    mimeMessage.To.Add(mailboxAddressTo);
                    var bodyBuilder = new BodyBuilder();
                    bodyBuilder.TextBody = "Kayıt işleimini gerçekleştirmek için onay kodunuz:" + code;
                    mimeMessage.Body = bodyBuilder.ToMessageBody();
                    mimeMessage.Subject = "Easy Cash Onay Kodu";
                    SmtpClient client = new SmtpClient(); //MailKit li olanı seçtik
                    client.Connect("smtp.office365.com", 587,false);
                    client.Authenticate("send.posta@hotmail.com", "nknqpaqjnxvxamcl");
                    client.Send(mimeMessage);
                    client.Disconnect(true);
                    TempData["Mail"] = appUserRegisterDto.Email;
                    return RedirectToAction("Index","ConfirmMail");
                }
                else 
                {

                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("",item.Description);
                    }
                   
                }
            
            }

            return View();
        }

    }
}
