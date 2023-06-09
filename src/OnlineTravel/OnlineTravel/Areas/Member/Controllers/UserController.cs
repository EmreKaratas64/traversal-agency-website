﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OnlineTravel.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize(Roles = "User")]
    [Route("Member/[controller]/[action]/{id?}")]
    public class UserController : Controller
    {
        DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());

        public IActionResult UserDashboard()
        {
            return View();
        }
    }
}
