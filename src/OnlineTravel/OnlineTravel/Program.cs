using BusinessLayer.Container;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using OnlineTravel.CQRS.Handlers.DestinationHandlers;
using OnlineTravel.Models;

var builder = WebApplication.CreateBuilder(args);
/* 
 options =>
{
    options.User.RequireUniqueEmail = true;

}
 */
// Add services to the container.

builder.Services.AddScoped<GetDestinationQueryHandler>();
builder.Services.AddScoped<GetDestinationByIDQueryHandler>();
builder.Services.AddScoped<AddDestinationQueryHandler>();
builder.Services.AddScoped<UpdateDestinationQueryHandler>();

builder.Services.AddMediatR(typeof(Program));

builder.Services.AddLogging(x =>
{
    x.ClearProviders();
    x.SetMinimumLevel(LogLevel.Debug);
    x.AddDebug();
});
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>().AddErrorDescriber<CustomIdentityValidator>().AddEntityFrameworkStores<Context>().AddDefaultTokenProviders();


builder.Services.AddHttpClient();
builder.Services.CustomValidator();
builder.Services.AddAutoMapper(typeof(Program));
// EF bağımlılığını azaltmak için gereken konfigürasyonlar aşağıdaki ContainerDependencies fonksiyonunda
builder.Services.ContainerDependencies();
builder.Services.AddControllersWithViews();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddMvc().AddRazorOptions(options =>
{
    options.ViewLocationFormats.Add("/Views/Home/{0}.cshtml");
});
builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.ConfigureApplicationCookie(options =>
{
    // cookie settings
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromDays(1);
    options.AccessDeniedPath = new PathString("/UserLogin/AccessDenied/");
    options.LoginPath = "/Account/SignIn/";
    options.SlidingExpiration = true;
});



var app = builder.Build();

ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
{
    var path = Directory.GetCurrentDirectory();
    builder.AddFile($"{path}\\Logs\\Log1.txt");
});

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
    pattern: "{controller=Home}/{action=ShowHome}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});


app.Run();
