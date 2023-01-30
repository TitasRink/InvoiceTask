using InvoiceTask.Business.Services;
using InvoiceTask.Repository.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ICountryServices, CountryServices>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//hardcode values

ICountryServices countryServices = new CountryServices();
CalculateVatServices vatServices = new CalculateVatServices();
ClientModel clientEurope = new() { ClientRegion = "Europe" };
SellerModel selleAsia = new SellerModel { Region = "Asia" };

countryServices.AddVatToCountries();
countryServices.GetCountriesFromApiAsync();
vatServices.CheckVatForClient(clientEurope, selleAsia);



app.Run();



