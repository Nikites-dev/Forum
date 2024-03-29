using Forum.Data;
using Forum.Models;
using Forum.MongoDB;
using Forum.Pages;
using Forum.RazorComponents;
using Forum.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MudBlazor;
using MudBlazor.Services;
using Post = Forum.Models.Post;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
// builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSingleton<BehaviourService>();
builder.Services.AddSingleton<FileSystemService>();
builder.Services.AddSingleton<HeaderMenu>();
builder.Services.AddSingleton<Post>();
builder.Services.AddSingleton<NavMenu>();
builder.Services.AddSingleton<Authorization>();
builder.Services.AddSingleton<Profile>();
builder.Services.AddSingleton<PostService>();
builder.Services.AddSingleton<CreatePost>();
builder.Services.AddSingleton<PostContent>();
builder.Services.AddSingleton<UserDbConnection>();
builder.Services.AddSingleton<PostDbConnection>();
builder.Services.AddSingleton<CreateComment>();
builder.Services.AddSingleton<Interests>();
builder.Services.AddSingleton<ErrorMessage>();
builder.Services.AddMudServices();
// builder.Services.AddSingleton<CommentPost>();

builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomLeft;

    config.SnackbarConfiguration.PreventDuplicates = false;
    config.SnackbarConfiguration.NewestOnTop = false;
    config.SnackbarConfiguration.ShowCloseIcon = true;
    config.SnackbarConfiguration.VisibleStateDuration = 10000;
    config.SnackbarConfiguration.HideTransitionDuration = 500;
    config.SnackbarConfiguration.ShowTransitionDuration = 500;
    config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
});


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
