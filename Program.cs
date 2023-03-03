using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ServersideProjektH5.Areas.Identity;
using ServersideProjektH5.Codes;
using ServersideProjektH5.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Identity DB connection
var ídentityConnectionString = builder.Configuration.GetConnectionString("IdentityConnection") ?? throw new InvalidOperationException("Connection string 'IdentityConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(ídentityConnectionString));

// ToDo DB connection
var toDoConnectionString = builder.Configuration.GetConnectionString("ToDoConnection") ?? throw new InvalidOperationException("Connection string 'ToDoConnection' not found.");
builder.Services.AddDbContext<ToDoDBContext>(options =>
    options.UseSqlServer(toDoConnectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();

// NVS
builder.Services.AddAuthorization(options => 
{ 
    options.AddPolicy("RequireAuthenticatedUser", policy => 
    { 
        policy.RequireAuthenticatedUser(); 
    }); 
});

// DB Repository
builder.Services.AddScoped<ToDoRepo>();

// Encryption
builder.Services.AddDataProtection();
builder.Services.AddSingleton<Encryption>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
