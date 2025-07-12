using SMARTSUPLEMENTOS.Data;
using SMARTSUPLEMENTOS.DTO;
using SMARTSUPLEMENTOS.Models;
using SMARTSUPLEMENTOS.Services;
using SMARTSUPLEMENTOS.Settings;
using Microsoft.OpenApi.Models;
using BCrypt;
using BCrypt.Net;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Sqlite;
using SMARTSUPLEMENTOS.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

//Cofigure Key
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));

var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();
if (jwtSettings == null || string.IsNullOrEmpty(jwtSettings.SecretKey))
{
    throw new InvalidOperationException("JwtSettings não está configurado corretamente.");
}
var key = Encoding.ASCII.GetBytes(jwtSettings.SecretKey);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Minha API", Version = "v1" });

    // Ativando o esquema de segurança JWT
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Digite o token assim: Bearer {seu_token}"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("A string de conexão 'DefaultConnection' não está configurada.");
}
builder.Services.AddDbContext<SmartContext>(options =>
    options.UseSqlite(connectionString));

//DI

builder.Services.AddScoped<JwtService>();

builder.Services.AddScoped<IloginRepository,LoginRepository>();
builder.Services.AddScoped<ILoginService, LoginService>();

builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();

builder.Services.AddScoped<IPedidosRepository, PedidosRepository>();
builder.Services.AddScoped<IPedidosService, PedidosService>();


//Authorization
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false

        };
    });
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
});

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

await AdminPadrao(app.Services);

app.MapAuthEndPoint();
app.MapProdutoEndPoint();
app.MapPedidoEndPoint();
app.Run();


async Task AdminPadrao(IServiceProvider serviceProvider)
{
    using var scope = serviceProvider.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<SmartContext>();

    if (!db.Usuarios.Any(u => u.Role == "Admin"))
    {
        var admin = new Usuarios
        {
            Username = "Admin1234",
            Password = BCrypt.Net.BCrypt.HashPassword("1234Admin"),
            Role = "Admin"
        };
        db.Add(admin);
        await db.SaveChangesAsync();
    }
}
