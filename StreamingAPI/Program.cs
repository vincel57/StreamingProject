using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StreamingAPI.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<StreamingAPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("StreamingAPIContext") ?? throw new InvalidOperationException("Connection string 'StreamingAPIContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
#pragma warning disable CS8602 // Déréférencement d'une éventuelle référence null.
using (var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<StreamingAPIContext>();
    //context.Database.EnsureDeleted();
    //context.Database.EnsureCreated();
}
#pragma warning restore CS8602 // Déréférencement d'une éventuelle référence null.
app.Run();
