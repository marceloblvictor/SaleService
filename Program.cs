using SalesService.Clients;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<CustomersClient, CustomersClient>();

builder.Services.AddHttpClient("productsApi", client =>
{
    client.BaseAddress = new Uri("https://localhost:7210/api/");
});
builder.Services.AddHttpClient(CustomersClient.CUSTOMERS_API, client =>
{
    client.BaseAddress = new Uri("https://localhost:7134/api/");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
