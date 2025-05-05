using Authorization.Configurations;
using Authorization.Extensions;
using Microsoft.Extensions.Options;
using PetShoes.Identity.Infrastructure.IoC;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
            builder =>
            builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
});

#region Autenticação  
    var tokenConfigurations = new TokenConfigurations();
    new ConfigureFromConfigurationOptions<TokenConfigurations>(
       builder.Configuration.GetSection("TokenConfigurations"))
           .Configure(tokenConfigurations);

    builder.Services.AddJwtSecurity(tokenConfigurations);
#endregion

new RootBootstrapper().BootstrapperRegisterServices(builder.Services);

var app = builder.Build();

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
                bearer.Token = "your-dynamic-token";
            });
    });
}

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
