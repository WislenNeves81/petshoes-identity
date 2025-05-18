using Authorization.Configurations;
using Authorization.Extensions;
using Microsoft.Extensions.Options;
using PetShoes.Identity.Infrastructure.IoC;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Adicionando logs para facilitar a depura��o
builder.Services.AddLogging(loggingBuilder => loggingBuilder.AddConsole());

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

#region Autentica��o  
var tokenConfigurations = new TokenConfigurations();
new ConfigureFromConfigurationOptions<TokenConfigurations>(
    builder.Configuration.GetSection("TokenConfigurations"))
    .Configure(tokenConfigurations);

builder.Services.AddJwtSecurity(tokenConfigurations);
#endregion

new RootBootstrapper().BootstrapperRegisterServices(builder.Services);

var app = builder.Build();

// Configurando Scalar corretamente antes do Run()
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options
            .WithTitle("PetShoes Api")
            .WithSidebar(false);
        options
            .WithPreferredScheme("Bearer")
            .WithHttpBearerAuthentication(bearer =>
            {
                bearer.Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6WyJ3aXNsZW4ubmV2ZXNAZ21haWwuY29tLmJyIiwid2lzbGVuLm5ldmVzQGdtYWlsLmNvbS5iciJdLCJqdGkiOiI1ODExOGY5Ni1lZjY0LTQ2YWUtYjA3NC1kZWI3M2MyOGM2ZjkiLCJ1c2VyTmFtZSI6Ildpc2xlbiBOZXZlcyIsImlzTWFzdGVyQWNjb3VudCI6IlRydWUiLCJyb2xlIjoidXNlciIsIm5iZiI6MTc0NjQ4OTgwMSwiZXhwIjoxNzQ5MDgxODAxLCJpYXQiOjE3NDY0ODk4MDEsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjcxOTQiLCJhdWQiOiJodHRwczovL2xvY2FsaG9zdDo3MTk0In0.Ctck9cx0EPEco9CZyLdJsNAHsPVJEdSNEex-jwcdvlM";
            });
    });
}

// Aplicando middlewares na ordem correta
app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
