using EasyCashIdentityProject.BusinessLayer.Abstract;
using EasyCashIdentityProject.DataAccessLayer.Concrete;
using EasyCashIdentityProject.DtoLayer.Dtos.AppCustomerAccountProcessDtos;
using EasyCashIdentityProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityProject.PresentationLayer.Controllers
{
    
    public class SendMoneyController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICustomerAccountProcessServise _customerAccountProcessServise;

        public SendMoneyController(UserManager<AppUser> userManager, ICustomerAccountProcessServise customerAccountProcessServise)
        {
            _userManager = userManager;
            _customerAccountProcessServise = customerAccountProcessServise;
        }

        [HttpGet]
        public IActionResult Index( string mycurrency)
        {
            ViewBag.currency = mycurrency;
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Index( SendMoneyForCustomerAccountProcessDto sendMoneyForCustomerAccountProcessDto )
        {
            var contex = new Context();
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var receiverAccountNumberID = contex.CustomerAccounts.Where(x=>x.CustomerAccountNumber == sendMoneyForCustomerAccountProcessDto.ReceiverAccountNumber ).Select(y=> y.CustomerAccountID).FirstOrDefault();
            var senderAccountNumberID = contex.CustomerAccounts.Where(x => x.AppUserID == user.Id).Where(y=> y.CustomerAccountCurrency== "Türk Lirası").Select(z=>z.CustomerAccountID).FirstOrDefault(); // gönderen kullanıcının hesabının ID si

            #region otomapper gelince bu değişicek
            var values = new CustomerAccountProcess();
            values.ProcessDate= Convert.ToDateTime(DateTime.Now.ToShortDateString());
            values.SenderID = senderAccountNumberID;
            values.ProcessType = "Havale";
            values.ReceiverID = receiverAccountNumberID;
            values.Amount = sendMoneyForCustomerAccountProcessDto.Amount;
            values.Description= sendMoneyForCustomerAccountProcessDto.Description;
            #endregion

            _customerAccountProcessServise.TInsert(values);
            return RedirectToAction("Index","Deneme");
        }
    }
}
