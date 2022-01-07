# ASP.NETCoreIdentity
MVC User Registration &amp; Login with ASP.NET Core Identity
1) Add > New Scaffolded Item > select Identity
2) update Startup.cs 
----------------------------------------------
	ConfigureServices =>    services.AddRazorPages()
	Configure    	  =>    app.UseAuthentication()
	UseEndpoints      =>	endpoints.MapRazorPages()
----------------------------------------------
3) add few more properties into model class(/Areas/Identity/Data/)
----------------------------------------------
    [PersonalData]
    [Column(TypeName ="nvarchar(100)")]
    public string FirstName { get; set; }

    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string LastName { get; set; }
----------------------------------------------
4) create the physical DB through DB Migration
----------------------------------------------

	Add-Migration InitialCreate
        Update-Database

----------------------------------------------
5) add MVC layout :- partial layout for logged in user.(Views/Shared/_Layout.cshml) 
----------------------------------------------
    <partial name="_LoginPartial" ></partial>

----------------------------------------------
6) add css style sheet (wwwroot/css/site.css)
7) create _AuthLayout.cshtml in /Areas/Identity/Pages
8) Add > NewItem. Select Razor Layout > _AuthLayout.cshtml
9)  Open => /Areas/Identity/Pages/Account as Register.cshtml
10) InputModel update properties for first name and last name.
----------------------------------------------
    [Required]
    [DataType(DataType.Text)]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [Required]
    [DataType(DataType.Text)]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }
----------------------------------------------
11) To save these property values to corresponding table AspNetUsers, update OnPostAsync, save the first name and last name to ApplicationUser instance before inserting into the table.
----------------------------------------------
    var user = new ApplicationUser 
					{ 
						UserName = Input.Email,
						Email = Input.Email,
						FirstName = Input.FirstName, 
						LastName = Input.LastName 
					};
					
    var result = await _userManager.CreateAsync(user, Input.Password);
----------------------------------------------
12) Update  Register.cshtml
13) Confirmation of email address before first login disabled using Following Code.
	(/Areas/Identity/IdentityHostingStartup.cs.)
----------------------------------------------
	public void Configure(IWebHostBuilder builder)
    {
	     ...
		options.SignIn.RequireConfirmedAccount = false;
		 ...
    }
    
----------------------------------------------
14) Update  Login.cshtml
----------------------------------------------
15) Redirect already logged in user back to home page from login or registration page
    update onGetAsync method statements in both login and register page.
----------------------------------------------
	public async Task OnGetAsync(string returnUrl = null)
	{
		if (User.Identity.IsAuthenticated)
		{
			Response.Redirect("/Home");
		}

		...
	}
----------------------------------------------
16) protect controllers or actions from unauthorized request using Authorize attribute
----------------------------------------------
	[Authorize]
	public class HomeController : Controller
	{
		...
	}
	
----------------------------------------------

Refer this for more details 

https://www.codaffection.com/asp-net-core-article/asp-net-core-identity-for-user-authentication-and-registration/
