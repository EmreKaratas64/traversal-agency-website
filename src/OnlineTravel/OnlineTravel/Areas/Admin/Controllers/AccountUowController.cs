using BusinessLayer.UOWAbstract;
using DTOLayer.DTOs.AccountUowDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace OnlineTravel.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountUowController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountUowController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult SendOperation()
        {
            return View();
        }


        [HttpPost]
        public IActionResult SendOperation(SendOperationModelDto model)
        {
            var senderValue = _accountService.TGetByID(model.SenderID);
            var receiverValue = _accountService.TGetByID(model.ReceiverID);

            senderValue.Balance -= model.Amount;
            receiverValue.Balance += model.Amount;

            List<Account> modifiedAccounts = new List<Account> { senderValue, receiverValue };
            _accountService.TMultiUpdate(modifiedAccounts);

            return RedirectToAction("AdminDashboard", "Dashboard");
        }
    }
}
