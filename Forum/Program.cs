using Forum.Data;
using Forum.Pages;
using Forum.RazorComponents;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Post = Forum.Models.Post;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
// builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSingleton<HeaderMenu>();
builder.Services.AddSingleton<Post>();
builder.Services.AddSingleton<NavMenu>();
builder.Services.AddSingleton<Authorization>();
builder.Services.AddSingleton<Profile>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
