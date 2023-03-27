using GOFLY.Prueba.Api.DataAccess;
using GOFLY.Prueba.Api.Logic.Business;
using GOFLY.Prueba.Api.Logic.Interface;
using GOFLY.Prueba.Api.Logic.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
string _myCore = "AllowAll";
// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: _myCore, builder =>
    {
        builder.WithOrigins("*");
        builder.WithHeaders("*");
        builder.WithMethods("*");
        //.AllowAnyHeader()
        //.AllowAnyMethod();
    });
});
builder.Services.AddControllers();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSingleton<ILoginRepository, LoginRepository>();
builder.Services.AddSingleton<IAuthService, AuthService>();
builder.Services.AddSingleton<IDataBaseConnectionFactory, DataBaseConnectionFactory>();
builder.Services.AddSingleton<IUserDataAccess, UserDataAccess>();
builder.Services.AddSingleton<IActivityDataAccess, ActivityDataAccess>();
builder.Services.AddSingleton<IUserBusiness, UserBusiness>();
builder.Services.AddSingleton<IActivityBusiness, ActivityBusiness>();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(_myCore);
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
