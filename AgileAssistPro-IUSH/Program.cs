using Microsoft.EntityFrameworkCore;
using AgileAssistPro_IUSH.Controllers;
using AgileAssistPro_IUSH.Data;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AgileAssistProIushContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
.AddCookie(option =>
{
    option.LoginPath = "/Acceso/Acceso";
    option.ExpireTimeSpan = TimeSpan.FromMinutes(20);
    option.AccessDeniedPath = "/Home/Error";
    //Para esta, cuando cree el espacio de Privacy, irá una foto de nosotros como policías diciendo que alto ahí jóven
});
builder.Services.AddScoped<Da_Logica>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Acceso}/{action=Acceso}/{id?}");
//Aleja, por amor a Cristo nunca vuelva a modificar esta parte- SIempre Controller Acceso y acción Acceso

app.Run();
