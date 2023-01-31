using InvoiceTask.Business.Services;
using InvoiceTask.Repository.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ICountryServices, CountryServices>();
builder.Services.AddScoped<ICalculateVatServices, CalculateVatServices>();



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

//hardcode values for testing

//var vatServices = new CalculateVatServices();
//var countryServices = new CountryServices();

//countryServices.GetCountriesFromApiAsync();

//ClientModel clientEurope = new() { Region = "Europe", IsVatPayer = true};
//SellerModel selleAsia = new() { Region = "Asia", IsVatPayer = true};
//vatServices.CheckVatForClient(clientEurope, selleAsia);


app.Run();



