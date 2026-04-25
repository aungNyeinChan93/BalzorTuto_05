using BlazorBlog.Server.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BlazorBlog.Server.Data;
using BlazorBlog.Application.Services;
using BlazorBlog.Application;
using BlazorBlog.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddDbContextFactory<AppDbContext2Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppDbContext2Context") ?? throw new InvalidOperationException("Connection string 'AppDbContext2Context' not found.")));

builder.Services.AddQuickGridEntityFrameworkAdapter();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
//builder.Services.AddScoped<ArticleService>();
builder.Services.AddInferstructure(builder.Configuration);
builder.Services.AddApplication();


builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseMigrationsEndPoint();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
