using EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using OnlineTravel.Models;

namespace OnlineTravel.Controllers
{
    [AllowAnonymous]
    [AutoValidateAntiforgeryToken]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser()
                {
                    Name = model.name,
                    Surname = model.surname,
                    Email = model.email,
                    UserName = model.email,
                    Status = true
                };
                var result = await _userManager.CreateAsync(user, model.password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "User");
                    return RedirectToAction("SignIn");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            TempData["SomthingWrong"] = "Somthing wrong";
            return View(model);
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.email);
                if (user == null) return View(model);
                bool isUser = await _userManager.IsInRoleAsync(user, "User");
                bool isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
                if (user.Status && (isUser || isAdmin))
                {
                    var result = await _signInManager.PasswordSignInAsync(model.email, model.password, model.rememberMe, true);
                    if (result.Succeeded)
                    {
                        if (isUser)
                            return RedirectToAction("UserDashboard", "User", new { area = "Member" });
                        else
                            return RedirectToAction("AdminDashboard", "Dashboard", new { area = "Admin" });
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid login attempt");
                    }
                }
                else
                    TempData["AccountBlock"] = "Your account might have been banned!";
            }
            TempData["SomthingWrong"] = "Somthing wrong";
            return View(model);
        }

        [HttpGet]
        public IActionResult PasswordForget()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PasswordForget(ForgetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await _userManager.FindByEmailAsync(model.Email);
                if (currentUser == null)
                    ModelState.AddModelError("", "Email could not be found!");
                else
                {
                    string passwordResetToken = await _userManager.GeneratePasswordResetTokenAsync(currentUser);
                    var uriBuilder = new UriBuilder(HttpContext.Request.Scheme, HttpContext.Request.Host.Host)
                    {
                        Path = Url.Action("ResetPassword", "Account"),
                        Query = $"userId={currentUser.Id}&token={passwordResetToken}",
                        Port = HttpContext.Request.Host.Port ?? 7240
                    };

                    var passwordResetLink = uriBuilder.Uri.ToString();

                    MimeMessage mimeMessage = new MimeMessage();

                    MailboxAddress mailboxAddressFrom = new MailboxAddress("Travel Online", "coreblog@ilkportfolio.com");
                    mimeMessage.From.Add(mailboxAddressFrom);

                    MailboxAddress mailboxAddressTo = new MailboxAddress("User", model.Email);
                    mimeMessage.To.Add(mailboxAddressTo);

                    var bodyBuilder = new BodyBuilder();
                    bodyBuilder.TextBody = passwordResetLink;
                    mimeMessage.Body = bodyBuilder.ToMessageBody();

                    mimeMessage.Subject = "Forget Password";

                    SmtpClient client = new SmtpClient();
                    client.Connect("webmail.ilkportfolio.com", 587, false);
                    client.Authenticate("coreblog@ilkportfolio.com", "cr798*BK");
                    client.Send(mimeMessage);
                    client.Disconnect(true);
                    return View();
                }
            }
            TempData["SomthingWrong"] = "Somthing wrong";
            return View(model);
        }

        [HttpGet]
        public IActionResult ResetPassword(string userid, string token)
        {
            TempData["userid"] = userid;
            TempData["token"] = token.Replace(" ", "+");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            var userid = TempData["userid"];
            var token = TempData["token"];

            if (ModelState.IsValid)
            {
                if (userid == null || token == null)
                {
                    ModelState.AddModelError("", "Credentials are not valid!");
                    TempData["SomthingWrong"] = "Somthing wrong";
                }
                else
                {
                    var user = await _userManager.FindByIdAsync(userid.ToString());
                    var result = await _userManager.ResetPasswordAsync(user, token.ToString(), model.password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("SignIn", "Account");
                    }
                }
            }
            TempData["SomthingWrong"] = "Somthing wrong";
            return View(model);
        }


        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("SignIn");
        }
    }
}