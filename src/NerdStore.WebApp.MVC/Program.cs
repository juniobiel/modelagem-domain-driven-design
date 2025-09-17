using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NerdStore.Catalogo.Application.AutoMapper;
using NerdStore.Catalogo.Data;
using NerdStore.Pagamentos.Data;
using NerdStore.Vendas.Data;
using NerdStore.WebApp.MVC.Data;
using NerdStore.WebApp.MVC.Setup;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDbContext<CatalogoContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDbContext<VendasContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDbContext<PagamentoContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();

var autoMapperAndMediatRLicenseKey = "eyJhbGciOiJSUzI1NiIsImtpZCI6Ikx1Y2t5UGVubnlTb2Z0d2FyZUxpY2Vuc2VLZXkvYmJiMTNhY2I1OTkwNGQ4OWI0Y2IxYzg1ZjA4OGNjZjkiLCJ0eXAiOiJKV1QifQ.eyJpc3MiOiJodHRwczovL2x1Y2t5cGVubnlzb2Z0d2FyZS5jb20iLCJhdWQiOiJMdWNreVBlbm55U29mdHdhcmUiLCJleHAiOiIxNzg2NDA2NDAwIiwiaWF0IjoiMTc1NDkyOTUzOCIsImFjY291bnRfaWQiOiIwMTk4OTlmMzY4NDU3YzI3OTliODQ4YzZiOTRlMTI1NCIsImN1c3RvbWVyX2lkIjoiY3RtXzAxazJjejc5M213NnpjMG5hbWo1ZnhtZDV0Iiwic3ViX2lkIjoiLSIsImVkaXRpb24iOiIwIiwidHlwZSI6IjIifQ.Xj83QPw2dXhYIDFvEz12Egkn54oKft9PQWye9CFrmsB_JyFzUzrbrry1jWYq7ROstRFyReV1GbgdZ6ajffVsFrWBOk3Hevz0t2Mu1M3Es81BO-R03vJexAzWppHSuuR_j3KGlc0f84Qq_G0H6fgVpCQVmlEFymLRJMeZ6VkorxQLR9msN_PWyPLQKrH8FOkP4QL7Z0XEIO2OsuvzaatiYaAHpvK_Tsf478FxIfDa3_w8lY7hyptEIWMr12nl712goxhz0XVRxbUCcIXGPvTLX4u0i-Yb-3aAKt1dWJPC8zFeJWKOSUx2QbHHvQ3kdPX3sgB44mBReYPNMYwPfkoKCA";

builder.Services.AddAutoMapper(c =>
{
    c.AddMaps(typeof(AutoMappingProfileDomainToView), typeof(AutoMappingProfileViewToDomain));
    c.LicenseKey = autoMapperAndMediatRLicenseKey;
});

builder.Services.AddMediatR(c =>
{
    c.RegisterServicesFromAssemblyContaining<Program>();
    c.LicenseKey = autoMapperAndMediatRLicenseKey;
});

builder.Services.RegisterServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Vitrine}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapRazorPages()
   .WithStaticAssets();

app.Run();
