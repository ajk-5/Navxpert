using NavXpert.Data;
using NavXpert.Services;
using NavXpert.Models;
using NavXpert.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;




var Origins = "AuthorizedApps";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();


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
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<UserRegistration>();
builder.Services.AddScoped<UserAuthentification>();


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: Origins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:5173")
                          .WithMethods("GET", "POST", "PUT", "DELETE", "OPTION")
                          .AllowAnyHeader();
                      });
});
var app = builder.Build();


app.UseWhen(context => !context.Request.Path.StartsWithSegments("/auth"), Builder =>
{
    Builder.UseMiddleware<AuthMiddleware>();
});



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors("Origins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
