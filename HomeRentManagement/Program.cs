using HomeRentManagement.Authentication;
using HomeRentManagement.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSingleton<addDbContex>();
builder.Services.AddSingleton<UserService>();
builder.Services.AddSingleton<RoleService>();
builder.Services.AddSingleton<StatusService>();
builder.Services.AddSingleton<HomeService>();
builder.Services.AddScoped<UserIdDecrypt>();
builder.Services.AddScoped<UnitService>();
builder.Services.AddScoped<TenantService>();
builder.Services.AddScoped<BillGenerateService>();





builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
