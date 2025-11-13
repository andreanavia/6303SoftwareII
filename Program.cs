using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MovieReservationSystem.Data;
using MovieReservationSystem.Models;
using MovieReservationSystem.Repositories;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// =========================================
// 1️⃣ CONFIGURAR DATABASE CONTEXT (SQLite)
// =========================================
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(configuration.GetConnectionString("DefaultConnection")
                      ?? "Data Source=movies.db"));

// =========================================
// 2️⃣ CONFIGURAR IDENTITY (Usuarios y Roles)
// =========================================
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

// =========================================
// 3️⃣ CONFIGURAR JWT AUTHENTICATION
// =========================================
var jwtKey = configuration["Jwt:Key"] ?? "change_this_dev_secret";
var keyBytes = Encoding.UTF8.GetBytes(jwtKey);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(keyBytes)
    };
});

// =========================================
// 4️⃣ CONTROLADORES, SWAGGER, REPOSITORIOS
// =========================================
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();

// =========================================
// 5️⃣ CONFIGURAR CORS (Permitir frontend local)
// =========================================
// ⚠️ En desarrollo: permite cualquier origen para evitar bloqueos.
// ⚠️ En producción: cambia a WithOrigins("https://tu-dominio.com")
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", p =>
    {
        p.AllowAnyOrigin()
         .AllowAnyHeader()
         .AllowAnyMethod();
    });
});

var app = builder.Build();

// =========================================
// 6️⃣ SEED DE BASE DE DATOS, ROLES Y ADMIN
// =========================================
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var db = services.GetRequiredService<ApplicationDbContext>();
    await db.Database.MigrateAsync();

    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

    string[] roles = { "Admin", "User" };
    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
            await roleManager.CreateAsync(new IdentityRole(role));
    }

    var adminEmail = "admin@local";
    var adminPwd = "Admin123!";

    if (await userManager.FindByEmailAsync(adminEmail) is null)
    {
        var admin = new ApplicationUser
        {
            UserName = adminEmail,
            Email = adminEmail,
            EmailConfirmed = true
        };

        var result = await userManager.CreateAsync(admin, adminPwd);
        if (result.Succeeded)
            await userManager.AddToRoleAsync(admin, "Admin");
    }
}

// =========================================
// 7️⃣ CONFIGURAR PIPELINE DE MIDDLEWARE
// =========================================
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseRouting();
app.UseCors("AllowFrontend");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
