using Microsoft.EntityFrameworkCore;
using MouseTracker.Infrastructure.Data;
using MouseTracker.Domain.Interfaces; 
using MouseTracker.Application.UseCases;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("mouse_tracker")));
builder.Services.AddScoped<IMouseMovementRepository, MouseMovementRepository>();
builder.Services.AddScoped<SaveMouseMovementsUseCase>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();