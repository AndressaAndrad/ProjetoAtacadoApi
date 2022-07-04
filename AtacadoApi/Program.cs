
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//Alterado pelo programador.
builder.Services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo()
        {
            Version = "v1",
            Title = "Atacado API - PSG - Capacitação 2022-04",
            Description = "API REST utilizada para estudo e desenvolvimento do modelo de aplicações, " +
            "baseado em boas praticas e no modelo de maturidade de Richardson.",
            TermsOfService = new Uri("http://www.psgtecnologia.com.br"),
            Contact = new OpenApiContact()
            {
                Name = " Andressa Andrade",
                Email = "andressaandrade.ads@gmail.com"
            },
            License = new OpenApiLicense()
            {
                Name = "PSG Tecnologia - Todos os direitos reservados.",
                Url = new Uri("http://www.psgtecnologia.com.br")
            }

        });
        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    }

);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
