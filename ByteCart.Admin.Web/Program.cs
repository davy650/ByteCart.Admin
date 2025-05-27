using System.Globalization;
using System.Reflection;
using ByteCart.Admin.Web.Components;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Localization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

// Start: Add localization support & Config
builder.Services.AddLocalization();

var cultures = new List<CultureInfo>
{
    new CultureInfo("en-US"),
    new CultureInfo("sw-KE")
};

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new RequestCulture(cultures[0]);
    options.SupportedCultures = cultures;
    options.SupportedUICultures = cultures;
});

builder.Services.AddSingleton<IStringLocalizerFactory, ResourceManagerStringLocalizerFactory>();
builder.Services.AddSingleton(typeof(IStringLocalizer<>), typeof(StringLocalizer<>));

builder.Services.AddTransient(sp => sp.GetRequiredService<IStringLocalizerFactory>().Create("SharedResources", Assembly.GetExecutingAssembly().GetName().Name!));

// End: Add localization support & Config

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();

app.UseRequestLocalization(); 

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
