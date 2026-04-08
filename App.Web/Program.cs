using Microsoft.OpenApi.Models;
using App.Config.Dependencies;
using App.Common.Classes.DTO.Contracts;
using System.Text.Json.Serialization.Metadata;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.TypeInfoResolver = new DefaultJsonTypeInfoResolver
        {
            Modifiers =
            {
                // Modifier: renombrar "Id" a "{modelo}Id" en JSON
                // TaskModel.Id → "taskId", UserModel.Id → "userId", etc.
                static typeInfo =>
                {
                    if (!typeInfo.Type.IsSubclassOf(typeof(BaseModel))) return;

                    var idProp = typeInfo.Properties
                        .FirstOrDefault(p => p.Name.Equals("id", StringComparison.OrdinalIgnoreCase));

                    if (idProp != null)
                    {
                        var modelName = typeInfo.Type.Name.Replace("Model", "");
                        idProp.Name = $"{char.ToLower(modelName[0])}{modelName[1..]}Id";
                    }
                }
            }
        };
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Base MicroService ",
        Description="Base MicroServices Api"
    });

    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description="Jwt Autorization",
        Name="Authorization",
        In=ParameterLocation.Header,
        Type=SecuritySchemeType.ApiKey,
        Scheme="Bearer"
    });

    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference= new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

Container.Register(builder.Services,builder.Configuration);

var app = builder.Build();

//Create or Initialize the BD
Container.CreateDataBase(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
