using Azure.Data.Tables;
using Projekt_Cloud.Components;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration["AzureStorageConnectionString"];
builder.Services.AddSingleton(new TableServiceClient(connectionString));

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
