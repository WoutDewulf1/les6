using Microsoft.EntityFrameworkCore;
using PeopleManager.Ui.Mvc.Contracts;
using PeopleManager.Ui.Mvc.Core;
using PeopleManager.Ui.Mvc.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IPersonService, InMemoryPersonService>();

builder.Services.AddDbContext<PeopleManagerDatabase>(options =>
{
    options.UseInMemoryDatabase(nameof(PeopleManagerDatabase));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<PeopleManagerDatabase>();
    dbContext.Initialize();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
