using FarmApplication.Areas.Identity.Data;
using FarmApplication.Data;
using FarmApplication.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Security.Claims;

namespace FarmApplication.Pages.Fields
{
	// check the other branch called dont push to main if this breaks.

	[Authorize]
	public class AddFieldModel : PageModel
    {
        private readonly ApplicationDBContext _db;
		private readonly UserManager<FarmApplicationDBUser> _userManager;

		// this allows for multiple constructors/ dependancy injection
		[ActivatorUtilitiesConstructor]
		public AddFieldModel(ApplicationDBContext db, UserManager<FarmApplicationDBUser> userManager)
        {
            _db = db;
			this._userManager = userManager;
		}


        [BindProperty]
        public Field field {  get; set; }

		// i dont think this bit of code did anything, leaving it commented just in case
		/*public void ConfigureServices(IServiceCollection services)
		{
			services.Configure<IdentityOptions>(options => options.ClaimsIdentity.UserIdClaimType = ClaimTypes.NameIdentifier);

		}*/

		public void OnGet()
        {
        }

		// for some reason the debugger cant run this block, but running normally can
        public async Task<IActionResult> OnPost(Field field)
        {
			var currentUser = await _userManager.GetUserAsync(User);
			if (currentUser != null)
			{
				field.UserID = currentUser.Id;
				// Custom error that will not allow the creation of a field with the name and size as the same value
				if (field.FieldName == field.FieldSize.ToString())
				{
					ModelState.AddModelError("field.FieldName", "Name cant be the same as the size");
				}

				if (ModelState.IsValid)
				{
					_db.Fields.Add(field);
					await _db.SaveChangesAsync();
					TempData["success"] = "Field Created";
					return RedirectToPage("Index");

				}			

				// problem - adding the id this way seems to class the modelState as invalid, which stops most the data checks from working.
				// for somereason modelState will always return invalid, and therefore not allow for error checking on the model state.
				
				_db.Fields.Add(field);
				await _db.SaveChangesAsync();
				TempData["success"] = "Field Created";
				return RedirectToPage("Index");
				
			}


			
			
            return Page();
        }
    }
}
