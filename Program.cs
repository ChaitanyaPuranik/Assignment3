using Microsoft.EntityFrameworkCore;
using ProductRegistration_Group.Models;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

//Adding MVC + API support - F
builder.Services.AddControllersWithViews();
builder.Services.AddControllers(); 


var provider = builder.Services.BuildServiceProvider();
var config = provider.GetRequiredService<IConfiguration>();

//Register db context
builder.Services.AddDbContext<Assignment3Context>(
    item => item.UseSqlServer(config.GetConnectionString("dbcs")));



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}   

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Products}/{action=Index}/{id?}"
    );

app.Run();
