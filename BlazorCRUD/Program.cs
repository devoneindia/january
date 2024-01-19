using BlazorCRUD.Components;
using BlazorCRUD.Context;
using BlazorCRUD.Contracts;
using BlazorCRUD.Services;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient("Http", client =>
{
    client.BaseAddress = new Uri("https://localhost:7108/"); // Replace with your actual API base URL
});

builder.Services.AddDbContext<UserDbContext>
    (options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("ConnectionStrings")));
builder.Services.AddTransient<IUser, UserManager>();
builder.Services.AddHttpClient();
builder.Services.AddControllersWithViews();
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

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
