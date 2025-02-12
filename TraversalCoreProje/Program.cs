using BusinessLayer.Container;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using TraversalCoreProje.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddLogging(x =>
{
	x.ClearProviders();
	x.SetMinimumLevel(LogLevel.Debug);
	x.AddDebug();
	x.AddFile($"{Directory.GetCurrentDirectory()}\\LogFile\\log.txt", LogLevel.Debug);
});

// var app e kadar olan kýsým identity auth ile ilgili önemli bir kýsým.
builder.Services.AddDbContext<Context>();

builder.Services.AddIdentity<AppUser, AppRole>().AddErrorDescriber<CustomIdentityValidator>().AddEntityFrameworkStores<Context>()
    .AddEntityFrameworkStores<Context>()
	.AddDefaultTokenProviders();


builder.Services.ContainerDependencies();
// tüm efdal iservice gibi yapýlarý tek bir yerde topladýk businesslayer/container icindeki extensions class ýnda . tek tek burada cagýrmaktan kurtulduk

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.CustomerValidator();
// Add MVC support (with controllers and views)
builder.Services.AddControllersWithViews().AddFluentValidation();

// Add Authorization Policy for authenticated users
builder.Services.AddMvc(options =>
{
	var policy = new AuthorizationPolicyBuilder()
		.RequireAuthenticatedUser()
		.Build();
	options.Filters.Add(new AuthorizeFilter(policy));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404/", "?code={0}");

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Login}/{action=SignIn}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});


app.Run();
