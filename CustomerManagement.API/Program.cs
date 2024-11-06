using CustomerManagement.API.Data;
using CustomerManagement.API.Interfaces;
using CustomerManagement.API.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<ICustomer, CustomerService>();
builder.Services.AddScoped<CustomerContext>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();