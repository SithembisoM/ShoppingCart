using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

using ShoppingCart.UI.Areas.Identity.Services;
using ShoppingCart.UI.Data;
using ShoppingCart.UI.Repositories;
using ShoppingCart.UI.Repositories.Interface;
using ShoppingCart.UI.Service;
using ShoppingCart.UI.Service.Interface;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
string? apikey = builder.Configuration.GetSection("XApiKey").Value;

builder.Services.AddDbContext<ApplicationDbContext>(
  options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
  .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.AddTransient<ICartService, CartService>();
builder.Services.AddTransient<IProductService, ProductService>();

builder.Services.Configure<AuthMessageSenderOptions>(builder.Configuration);

builder.Services.AddHttpClient(
  "Product",
  httpClient =>
  {
    httpClient.BaseAddress = new Uri("http://localhost:5219/");
    httpClient.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
    httpClient.DefaultRequestHeaders.Add("XApiKey", apikey);
  });

builder.Services.AddHttpClient(
  "Cart",
  httpClient =>
  {
    httpClient.BaseAddress = new Uri("http://localhost:5219/");
    httpClient.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
    httpClient.DefaultRequestHeaders.Add("XApiKey", apikey);
  });

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseMigrationsEndPoint();
}
else
{
  app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
  "default",
  "{controller=Product}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
