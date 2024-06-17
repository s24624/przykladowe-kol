using Microsoft.EntityFrameworkCore;
using WebApplication2.Context;
using WebApplication2.Repository;
using WebApplication2.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<SailboatDbContext>(opt =>
{
    opt.UseSqlServer("Data Source=localhost,1433; User ID=SA; Password=yourStrong(!)Password; Initial Catalog=apdb; Integrated Security=False; Connect Timeout=30; Encrypt=False");
});
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IClientRepository,ClientRepostiory>();


var app = builder.Build();

app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();