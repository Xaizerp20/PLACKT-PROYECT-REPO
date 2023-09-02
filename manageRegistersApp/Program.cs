using manageRegistersApp.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using DataLibrary;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Components.Authorization;
using manageRegistersApp.Authentication;
using manageRegistersApp.Services;


var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddAuthenticationCore();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<ProtectedSessionStorage>();
builder.Services.AddSingleton<IDataAccess, DataAccess>();
builder.Services.AddMudServices();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddScoped<ProtectedSessionStorage>();
builder.Services.AddSingleton<IEventService, EventService>();
builder.Services.AddHostedService<TimerBackgroundService>();
builder.Services.AddAuthentication("Cookies").AddCookie();
builder.Services.AddScoped<AuthMiddleware>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<ArrivalsService>();
builder.Services.AddScoped<ClientService>();
builder.Services.AddScoped<IssueService>();
builder.Services.AddScoped<VehicleService>();
builder.Services.AddSingleton<ShiftService>();
builder.Services.AddSingleton<EmailsService>();
builder.Services.AddScoped<CommonUtilities>();
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddSession();

/*
builder.Services.AddTransient<MySqlConnection>(_ =>
{
    var config = _.GetRequiredService<IConfiguration>();
    return new MySqlConnection(config.GetConnectionString("DefaultConnection"));
});
*/



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseAuthentication();
app.UseAuthorization();
app.UseSession();


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.UseMiddleware<AuthMiddleware>();
app.UseMiddleware<CustomMiddleware>();



app.Run();
