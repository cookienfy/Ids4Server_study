using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using IdentityServerHost.Quickstart.UI;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Conductor.IdentityServer.Controllers
{
    public class OAuth2Controller : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        //private readonly UserManager<ApplicationUser> _userManager;
        //private readonly RoleManager<ApplicationRole> _roleManager;
        //private readonly SignInManager<ApplicationUser> _signInManager;
        //private readonly IIdentityServerInteractionService _interaction;
        //private readonly IClientStore _clientStore;
        //private readonly IAuthenticationSchemeProvider _schemeProvider;
        //private readonly IEventService _events;


        //public OAuth2Controller(
        //    UserManager<ApplicationUser> userManager,
        //    RoleManager<ApplicationRole> roleManager,
        //    SignInManager<ApplicationUser> signInManager,
        //    IIdentityServerInteractionService interaction,
        //    IClientStore clientStore,
        //    IAuthenticationSchemeProvider schemeProvider,
        //    IEventService events)
        //{
        //    _userManager = userManager;
        //    _roleManager = roleManager;
        //    _signInManager = signInManager;
        //    _interaction = interaction;
        //    _clientStore = clientStore;
        //    _schemeProvider = schemeProvider;
        //    _events = events;
        //}


        ///// <summary>
        ///// Show login page
        ///// </summary>
        //[HttpGet]
        //public async Task<IActionResult> authorize(string returnUrl)
        //{
        //    // build a model so we know what to show on the login page
        //    var vm = await BuildLoginViewModelAsync(returnUrl);


        //    //if (vm.IsExternalLoginOnly)
        //    //{
        //    //    // we only have one option for logging in and it's an external provider
        //    //    return await ExternalLogin(vm.ExternalLoginScheme, returnUrl);
        //    //}


        //    return View(vm);

        //}

        //private async Task<LoginViewModel> BuildLoginViewModelAsync(string returnUrl)
        //{
        //    var vm = await BuildLoginViewModelAsync(returnUrl);
        //    vm.Username = "edwin";
        //    vm.RememberLogin = true;
        //    return vm;
        //}
    }
}

