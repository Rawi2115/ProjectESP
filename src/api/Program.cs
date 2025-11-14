using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;



var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SqliteDbContext>(op =>
{
    op.UseSqlite("Data Source=rfid.db");
});

builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.AddSignalR();
builder.Services.AddCors(options =>
{
   options.AddDefaultPolicy(po =>
   {
       po.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
   });
});
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(opt =>
{
    opt.SerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;
    opt.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(opt =>
{
    opt.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
builder.Services.AddScoped<IProvinceService, ProvinceService>();
builder.Services.AddOpenApi();
var app = builder.Build();
app.UseCors();
app.UseStaticFiles();
app.MapControllers();
app.MapOpenApi();
app.MapScalarApiReference();
app.MapGet("/", () => "Hello World!");
app.MapPost("/echo", (CardData cardData) => Console.WriteLine(cardData.Uid));
app.MapHub<RfidHub>("/uidhub");

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<SqliteDbContext>();
    await dbContext.Database.MigrateAsync();
}
app.Run();


public class CardData {
    public string Uid { get; set; } = null!;
}