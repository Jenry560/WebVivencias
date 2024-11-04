using Microsoft.EntityFrameworkCore;
using WebVivencias.Components;
using WebVivencias.Models;
using WebVivencias.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


builder.Services.AddScoped<SessionStorageService>();
builder.Services.AddDbContext<VivenciasContext>(options =>
 options.UseSqlServer("Data Source=DESKTOP-NDORDVA\\SQLEXPRESS;Initial Catalog=Vivencias;Integrated Security=True;TrustServerCertificate=True;")
);

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
app.UseAntiforgery();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
