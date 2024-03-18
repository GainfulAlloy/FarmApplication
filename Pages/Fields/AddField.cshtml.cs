using FarmApplication.Areas.Identity.Data;
using FarmApplication.Data;
using FarmApplication.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Owin.Security;
using System.Security.Claims;

namespace FarmApplication.Pages.Fields
{
    [Authorize]
    public class AddFieldModel : PageModel
    {
        private readonly ApplicationDBContext _db;
        private readonly UserManager<FarmApplicationDBUser> _userManager;
		
		

        public AddFieldModel(ApplicationDBContext db, UserManager<FarmApplicationDBUser> userManager)
        {
            _db = db;
            this._userManager = userManager;
        }
        [BindProperty]
        public Field field {  get; set; }


		//private Task<FarmApplicationDBUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
		public void ConfigureServices(IServiceCollection services)
		{
			services.Configure<IdentityOptions>(options => options.ClaimsIdentity.UserIdClaimType = ClaimTypes.NameIdentifier);

		}
		public void OnGet()//Field field)
        {
			//var currentuser = _userManager.GetUserId(this.User);
			//field.UserID = currentuser;

			// ViewData["UserID"] = _userManager.GetUserId(this.User);
			//var UserInfo = _userManager.GetUserId(this.User);
			//string userId = SignInManager(User).AuthenticationManager.AuthenticationResponseGrant.Identity.GetUserId();

			//string userId = SignInManager.AuthenticationManager.AuthenticationResponseGrant.Identity.GetUserId();

			//var user = await _userManager.GetUserAsync(User);				
			//var userId = user?.Id;
			//field.UsersID = userId;
		}
        public async Task<IActionResult> OnPostAsync(Field field)//, UserLoginInfo user)
        {
            
			var currentUser = await _userManager.GetUserAsync(User);
			if (currentUser != null)
			{
				field.UserID = currentUser.Id;
				_db.Fields.Add(field);
				await _db.SaveChangesAsync();
				TempData["success"] = "Field Created";
				return RedirectToPage("Index");
				// Redirect to a success page
			}

			//var rates = await _db.Fields.Include(host => host.UsersID).Where(x => x.UsersID == _userManager.GetUserId(User)).ToListAsync();

			// Custom error that will not allow the creation of a field with the name and size as the same value
			if (field.FieldName == field.FieldSize.ToString())
            {
                ModelState.AddModelError("field.FieldName", "Name cant be the same as the size");
            }
            if (ModelState.IsValid)
            {
				//var CurrentUser = await GetCurrentUserAsync();
                //var userID = CurrentUser.Id;
                
                //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                //var UserLoserID = (await _userManager.GetUserAsync(HttpContext.User))?.Id;
                //field.UsersID = (await _userManager.GetUserAsync(HttpContext.User))?.Id;

				

				// this is just returning null at the moment :/
				// should return the users id

				//UserLoginInfo userLoginInfo = await _userManager.GetUserIdAsync(User);

				//FarmApplicationDBUser applicationUser = await _userManager.GetUserAsync(User);

				//field.UsersID = applicationUser;

				//var testing = _userManager.GetUserId(User);

				//field.UsersID = testing;


				await _db.Fields.AddAsync(field);
                await _db.SaveChangesAsync();
                TempData["success"] = "Field Created";
                return RedirectToPage("Index");

            }
            return Page();
        }
    }
}
