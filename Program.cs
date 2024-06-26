using Microsoft.EntityFrameworkCore;
using pruebaDesempeno.Data;
using pruebaDesempeno.Services.Pets;
using pruebaDesempeno.Extensions;
using System.Reflection;
using Microsoft.AspNetCore.Identity;
using pruebaDesempeno.Services.MailerSend;
using MailerSend.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Conexión a la base de datos con resiliencia a errores transitorios
builder.Services.AddDbContext<VeterinaryContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("MyConnection"),
    Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.20-mysql"),
    mySqlOptions => mySqlOptions.EnableRetryOnFailure())
);

// Servicio de los controladores
builder.Services.AddControllers();

//scopes
builder.Services.AddRepositories(Assembly.GetExecutingAssembly());

//MailerSend
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddHttpClient<IEmailSender, EmailSender>();
builder.Services.Configure<MailerSendOptions>(builder.Configuration.GetSection("MailerSend"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();