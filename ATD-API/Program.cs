using ATD_API.Data;
using ATD_API.Repositories.Classes;
using ATD_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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



var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
