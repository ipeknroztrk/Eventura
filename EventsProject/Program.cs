using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;

System.Globalization.CultureInfo.DefaultThreadCurrentCulture = new System.Globalization.CultureInfo("tr-TR");
System.Globalization.CultureInfo.DefaultThreadCurrentUICulture = new System.Globalization.CultureInfo("tr-TR");

var builder = WebApplication.CreateBuilder(args);


// Session configuration
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Session süresi
    options.Cookie.HttpOnly = true; // Güvenlik için HttpOnly
    options.Cookie.IsEssential = true; // Session'ı temel ihtiyaç olarak ayarla
});


// Dependency Injection (DI) için servisleri ekleme
//kart ve payment
builder.Services.AddScoped<IGenericService<SavedCard>, SavedCardManager>();
builder.Services.AddScoped<ISavedCardService, SavedCardManager>();
builder.Services.AddScoped<ISavedCardDal, EfSavedCardDal>();


builder.Services.AddScoped<IGenericService<Payment>, PaymentManager>();
builder.Services.AddScoped<IPaymentService, PaymentManager>();
builder.Services.AddScoped<IPaymentDal, EfPaymentDal>();


// Register services
builder.Services.AddScoped<IEventsTicketsService, EventsTicketManager>(); // Ensure this is added
builder.Services.AddScoped<IEventsTicketDal, EfEventsTicketDal>();
// Register other services similarly
builder.Services.AddScoped<IArtistDal, EfArtistDal>();
builder.Services.AddScoped<IArtistService, ArtistManager>();

builder.Services.AddScoped<IEventService, EventManager>();
builder.Services.AddScoped<IEventDal, EfEventDal>();

builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<EfCategoryDal, EfCategoryDal>();
builder.Services.AddScoped<IGenericDal<Category>, EfCategoryDal>();

builder.Services.AddScoped<ITicketService, TicketManager>();
builder.Services.AddScoped<ITicketDal, EfTicketDal>();
builder.Services.AddScoped<IGenericDal<Ticket>, EfTicketDal>();
builder.Services.AddScoped<IGenericDal<Artist>, EfArtistDal>();

builder.Services.AddScoped<IGenericDal<Message>, EfMessageDal>();
builder.Services.AddScoped<IMessageDal, EfMessageDal>();
builder.Services.AddScoped<IMessageService, MessageManager>();

builder.Services.AddScoped<ICityService, CityManager>();
builder.Services.AddScoped<ICityDal, EfCityDal>();
builder.Services.AddScoped<IGenericDal<City>, EfCityDal>();

builder.Services.AddDbContext<Context>();

// Identity ayarları ve cookie konfigürasyonu
builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
})
.AddEntityFrameworkStores<Context>()
.AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Oturum süresi
    options.LoginPath = "/Member/Account/Login"; // Giriş sayfası
    options.SlidingExpiration = true; // Kullanıcı aktifse süre uzar
});

// MVC ve diğer servisler
builder.Services.AddControllersWithViews();
builder.Services.AddMvc();



var app = builder.Build();

// Middleware'ler
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication(); // Kullanıcı kimlik doğrulama
app.UseAuthorization(); // Yetkilendirme

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
