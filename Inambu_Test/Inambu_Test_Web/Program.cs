using Application;
using Inambu_Test_Web.Components;
using Infrastructure;
using Infrastructure.Perisitence;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Configure Application Services
builder.Services.ConfigureApplication(builder.Configuration);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

}

//Initialize Database if not exists
using var scope = app.Services.CreateScope();
var init = scope.ServiceProvider.GetRequiredService<ApplicationDBInitializer>();
await init.InitializeAsync();

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
