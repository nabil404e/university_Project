using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using university_Project.Models;
using university_Project.Repostitray;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddControllersWithViews(option =>
//{
//    option.Filters.Add(new ErrorHandeler());     
//});
    //builder.Services.AddControllersWithViews(option =>
    //{
    //    option.Filters.Add(new Author);
    //});
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(option=>
{
    option.Password.RequiredLength= 5; 
    option.Password.RequireUppercase = false;
}).AddEntityFrameworkStores<university_DB_dbContext>();
// make bulider  to acesss

builder.Services.AddScoped<iResult, ResultRepostriy>();    // make  server  builder  to Access interface and  Repository  , 
builder.Services.AddScoped<ICouresRepostitray , CoursesRepostitray>();
builder.Services.AddScoped<iTrainer, TrainerRepositry>();
builder.Services.AddScoped<Instractor, InstractorRepostitray>();
builder.Services.AddScoped<iDepartment, DepartmentRepostitray>();
builder.Services.AddScoped<iApplayForm, ApplayFormRepo>();

builder.Services.AddDbContext<university_DB_dbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("cs"))); 
builder.Services.AddControllersWithViews();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
