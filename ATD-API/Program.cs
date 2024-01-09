using ATD_API.Data;
using ATD_API.Repositories.Classes;
using ATD_API.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "DemoJWT", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Jwt Authorization",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
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
            new string[]{}
        }
    });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        RequireExpirationTime = true,
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:key"]))
    };
});



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MyDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString(
        "DemoConnectionString")));
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddTransient<IAchat, AchatRepo>();
builder.Services.AddTransient<IArticle, ArticleRepo>();
builder.Services.AddTransient<IArticleLocation, ArticleLocationRepo>();
builder.Services.AddTransient<ICoursDeChange, CoursDeChangeRepo>();
builder.Services.AddTransient<IEmballage, EmballageRepo>();
builder.Services.AddTransient<IEmballageByArticle, EmballageByArticleRepo>();
builder.Services.AddTransient<IFacture, FactureRepo>();
builder.Services.AddTransient<IFamille, FamilleRepo>();
builder.Services.AddTransient<IFournisseur, FournisseurRepo>();
builder.Services.AddTransient<IHistoriquePrixVente, HistoriquePrixVenteRepo>();
builder.Services.AddTransient<IInventaire, InventaireRepo>();
builder.Services.AddTransient<ILocation, LocationRepo>();
builder.Services.AddTransient<IMonnaie, MonnaieRepo>();
builder.Services.AddTransient<IPaiement, PaiementRepo>();
builder.Services.AddTransient<IParametreSociete, ParametreSocieteRepo>();
builder.Services.AddTransient<IPrixAchatArticle, PrixAchatArticleRepo>();
builder.Services.AddTransient<IPrixArticleLocation, PrixArticleLocationRepo>();
builder.Services.AddTransient<ISignaletique, SignaletiqueRepo>();
builder.Services.AddTransient<IStock, StockRepo>();
builder.Services.AddTransient<IPortefeuille, PortefeuilleRepo>();
builder.Services.AddTransient<ICommande, CommandeRepo>();
builder.Services.AddTransient<ILivraison, LivraisonRepo>();
builder.Services.AddTransient<IMouvement, MouvementRepo>();
builder.Services.AddTransient<IDepense, DepenseRepo>();
builder.Services.AddTransient<IRole, RoleRepo>();
builder.Services.AddTransient<IUtilisateur, UtilisateurRepo>();
builder.Services.AddTransient<ILogin, LoginRepo>();
builder.Services.AddTransient<IIventaitaireComptable, InventaireComptableRepo>();



var app = builder.Build();



// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DemoJWTToken v1"));
//}


app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
