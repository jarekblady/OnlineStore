using System.Text;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OnlineStore.API.Validators;
using OnlineStore.Repository;
using OnlineStore.Repository.Context;
using OnlineStore.Repository.Entities;
using OnlineStore.Repository.Repositories.AccountRepository;
using OnlineStore.Repository.Repositories.BrandRepository;
using OnlineStore.Repository.Repositories.CartProductRepository;
using OnlineStore.Repository.Repositories.CartRepository;
using OnlineStore.Repository.Repositories.CategoryRepository;
using OnlineStore.Repository.Repositories.ProductRepository;
using OnlineStore.Service;
using OnlineStore.Service.DTOs;
using OnlineStore.Service.Middleware;
using OnlineStore.Service.Services.AccountService;
using OnlineStore.Service.Services.BrandService;
using OnlineStore.Service.Services.CartService;
using OnlineStore.Service.Services.CategoryService;
using OnlineStore.Service.Services.ProductService;
using OnlineStore.Service.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


var authenticationSettings = new AuthenticationSettings();

builder.Configuration.GetSection("Authentication").Bind(authenticationSettings);

builder.Services.AddSingleton(authenticationSettings);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "Bearer";
    options.DefaultScheme = "Bearer";
    options.DefaultChallengeScheme = "Bearer";
}).AddJwtBearer(cfg =>
{
    cfg.RequireHttpsMetadata = false;
    cfg.SaveToken = true;
    cfg.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = authenticationSettings.JwtIssuer,
        ValidAudience = authenticationSettings.JwtIssuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey)),
    };
});




builder.Services.AddDbContext<StoreDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("StoreConnectionString")));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddFluentValidationAutoValidation(conf => { conf.DisableDataAnnotationsValidation = true; });
builder.Services.AddScoped<IValidator<RegisterUserDto>, RegisterUserValidator>();
builder.Services.AddScoped<IValidator<ProductQuery>, ProductQueryValidator>();

builder.Services.AddScoped<ErrorHandlingMiddleware>();

builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<ICartProductRepository, CartProductRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IBrandRepository, BrandRepository>();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IBrandService, BrandService>();


builder.Services.AddCors();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Store API");
    });
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<StoreDbContext>();
        DbInitializer.Initialize(context);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred creating the DB.");
    }
}
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseAuthentication();
//app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(opt =>
{
    opt.AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins("http://localhost:3000");
});

app.UseAuthorization();

app.MapControllers();

app.Run();
