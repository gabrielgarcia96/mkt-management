using Blazored.LocalStorage;
using Marketing.App.Components;
using Marketing.App.Security;
using Marketing.Application.Interfaces;
using Marketing.Application.Services;
using Marketing.Infrastructure;
using Marketing.Infrastructure.Interfaces;
using Marketing.Infrastructure.Repository;
using Microsoft.AspNetCore.Components.Authorization;
using Radzen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddAuthorizationCore();

// Config Radzen 
builder.Services.AddRadzenComponents();



// Builder Services
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IAccountService, AccountService>();

// Builder Repositorys
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();


//Config Database
builder.Services.AddSingleton<ConfigurationMongoDb>(provider =>
{
    var configuration = provider.GetRequiredService<IConfiguration>();
    var connectionString = configuration["ConnectionString:MongoDb"];
    var databaseName = configuration["MongoDbSettings:DatabaseName"];
    return new ConfigurationMongoDb(connectionString, databaseName);
});

// Important line, for authentication don't remove
builder.Services.AddScoped<AuthenticationStateProvider>(provider =>
    provider.GetRequiredService<CustomAuthProvider>());
builder.Services.AddScoped<CustomAuthProvider>();

// LocalStorage
builder.Services.AddBlazoredLocalStorage();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
//app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
