using CustomerManagement.UI.Interfaces;
using CustomerManagement.UI.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient<ICustomer, CustomerService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:52952/"); 
});

builder.Services.AddControllersWithViews();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Customer}/{action=Index}/{id?}");

app.Run();