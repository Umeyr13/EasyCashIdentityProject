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
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Index( SendMoneyForCustomerAccountProcessDto sendMoneyForCustomerAccountProcessDto )
        {
            var contex = new Context();
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var receiverAccountNumberID = contex.CustomerAccounts.Where(x=>x.CustomerAccountNumber == sendMoneyForCustomerAccountProcessDto.ReceiverAccountNumber ).Select(y=> y.CustomerAccountID).FirstOrDefault();

            //sendMoneyForCustomerAccountProcessDto.SenderID = user.Id;
            //sendMoneyForCustomerAccountProcessDto.ProcessDate = Convert.ToDateTime( DateTime.Now.ToShortDateString());
            //sendMoneyForCustomerAccountProcessDto.ProcessType = "Havale";
            //sendMoneyForCustomerAccountProcessDto.ReceiverID = receiverAccountNumberID;

            #region otomapper gelince bu değişicek
            var values = new CustomerAccountProcess();
            values.ProcessDate= Convert.ToDateTime(DateTime.Now.ToShortDateString());
            values.SenderID = 1;
            values.ProcessType = "Havale";
            values.ReceiverID = receiverAccountNumberID;
            values.Amount = sendMoneyForCustomerAccountProcessDto.Amount;
            
            #endregion
            _customerAccountProcessServise.TInsert(values);
            return RedirectToAction("Index","Deneme");
        }
    }
}
