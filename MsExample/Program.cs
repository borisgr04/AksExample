using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Configuration.AzureKeyVault;

var builder = WebApplication.CreateBuilder(args);

//var settings = builder.Configuration.Build();

//if (!builder.Environment.IsDevelopment())
//{
//    // Way-1
//    // Connect to Azure Key Vault using the Managed Identity.
//    var keyVaultEndpoint = settings["AzureKeyVaultEndpoint"];

//    if (!string.IsNullOrEmpty(keyVaultEndpoint))
//    {
//        var azureServiceTokenProvider = new AzureServiceTokenProvider();
//        var keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));
//        config.AddAzureKeyVault(keyVaultEndpoint, keyVaultClient, new DefaultKeyVaultSecretManager());
//    }
//}
//else
//{
//    // Way-2
//    // Connect to Azure Key Vault using the Client Id and Client Secret (AAD) - Get them from Azure AD Application.
//    var keyVaultEndpoint = settings["AzureKeyVault:Endpoint"];
//    var keyVaultClientId = settings["AzureKeyVault:ClientId"];
//    var keyVaultClientSecret = settings["AzureKeyVault:ClientSecret"];

//    if (!string.IsNullOrEmpty(keyVaultEndpoint) && !string.IsNullOrEmpty(keyVaultClientId) && !string.IsNullOrEmpty(keyVaultClientSecret))
//    {
//        config.AddAzureKeyVault(keyVaultEndpoint, keyVaultClientId, keyVaultClientSecret, new DefaultKeyVaultSecretManager());
//    }
//}

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
