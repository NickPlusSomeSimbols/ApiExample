using RepetitionInfrastructure;
using Microsoft.EntityFrameworkCore;
using RepetitionInfrastructure.Services;
using RepetitionInfrastructure.ServiceInterfaces;
using Repetition.Extentions;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

builder.Services.AddControllers();

builder.Services.AddDbContext<RepetitionDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IAuthorBookService, AuthorBookService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.SwaggerForAuth(); // Includes AddSwaggerGen
builder.IdentityConfing(configuration);

//builder.Services.AddScoped<IHttpContextAccessor, HttpContextAccessor>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
