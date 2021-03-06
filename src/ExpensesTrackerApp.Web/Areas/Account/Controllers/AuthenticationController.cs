﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpensesTrackerApp.Core.Identity;
using ExpensesTrackerApp.Web.Areas.Account.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesTrackerApp.Web.Areas.Account.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly SignInManager<User> _signInManager;

        public AuthenticationController(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            //ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var result = await _signInManager.PasswordSignInAsync(viewModel.Username, viewModel.Password, false, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError(String.Empty, "Invalid login attempt");
                return View(viewModel);
            }
            /*
            if (!String.IsNullOrEmpty(viewModel.ReturnUrl) && Url.IsLocalUrl(viewModel.ReturnUrl))
            {
                return Redirect(viewModel.ReturnUrl);
            }
            */
            return Redirect("/");
        }
    }
}