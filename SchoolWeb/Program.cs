using Microsoft.EntityFrameworkCore;
using SchoolWeb.Data;
using SchoolWeb.Models;
using System.Text.Json;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
if (File.Exists("schedule.json"))
{
    using (FileStream readStream = new FileStream("schedule.json", FileMode.Open))
    {
        builder.Services.AddSingleton<ScheduleInfo>(await JsonSerializer.DeserializeAsync<ScheduleInfo>(readStream));
    }
}
else
{
    using (FileStream writeString = new FileStream("schedule.json", FileMode.Create))
    {
        ScheduleInfo info = new ScheduleInfo()
        {
            YearDuration1 = 33,
            YearDuration2_8 = 35,
            YearDuration9 = 34,
            YearDuration10 = 35,
            YearDuration11 = 34,

            Holiday1Start = DateTime.Parse("01.11.2021"),
            Holiday1End = DateTime.Parse("07.11.2021"),
            Holiday2Start = DateTime.Parse("29.12.2021"),
            Holiday2End = DateTime.Parse("09.01.2022"),
            Holiday3Start = DateTime.Parse("28.03.2022"),
            Holiday3End = DateTime.Parse("03.04.2022"),
            Holiday4Start = DateTime.Parse("07.02.2022"),
            Holiday4End = DateTime.Parse("13.02.2022"),

            Quarter1Start = DateTime.Parse("01.09.2021"),
            Quarter1End = DateTime.Parse("30.10.2021"),
            Quarter2Start = DateTime.Parse("08.11.2021"),
            Quarter2End = DateTime.Parse("28.12.2021"),
            Quarter3Start = DateTime.Parse("10.01.2022"),
            Quarter3End = DateTime.Parse("26.03.2022"),
            Quarter4Start = DateTime.Parse("04.04.2022"),
            Quarter4End = DateTime.Parse("31.05.2022")
        };
        await JsonSerializer.SerializeAsync<ScheduleInfo>(writeString, info);
        builder.Services.AddSingleton<ScheduleInfo>(info);
    }
}
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();
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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
