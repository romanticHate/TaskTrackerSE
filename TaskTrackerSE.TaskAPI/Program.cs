using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;
using TaskTrackerSE.Infrastructure.Extencions;
using TaskTrackerSE.Infrastructure.Filters;

//  Builder
var builder = WebApplication.CreateBuilder(args);
// Configuration Builder
var configuration = builder.Configuration;

// Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add services to the container.
builder.Services.AddControllers(options =>
{
    options.Filters.Add<GlobalExceptionFilter>();

}).AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;

}).ConfigureApiBehaviorOptions(options => {

    // options.SuppressModelStateInvalidFilter = true;
 });

builder.Services.AddOptions(configuration);
builder.Services.AddDbContexts(configuration);
builder.Services.AddServices();
builder.Services.AddSwagger($"{Assembly.GetExecutingAssembly().GetName().Name}.xml");

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = configuration["Authentication:Issuer"],
        ValidAudience = configuration["Authentication:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Authentication:SecretKey"]))
    };

});

builder.Services.AddMvc(options =>
{
    options.Filters.Add<ValidationFilter>();

}).AddFluentValidation(options =>
{
    options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
});


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

#region Test Code...

app.UseRouting();
app.UseAuthentication();
#endregion

app.UseAuthorization();

app.MapControllers();

app.Run();
