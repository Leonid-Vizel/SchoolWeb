using Microsoft.EntityFrameworkCore;
using SchoolWeb.Data;
using Microsoft.AspNetCore.Identity;
using SchoolWeb.Models;
using System.Reflection;
using SchoolWeb;

var builder = WebApplication.CreateBuilder(args);

//Configure schedule
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

builder.Services.AddSingleton<ScheduleInfo>(info);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireNonAlphanumeric = false;
})
    .AddEntityFrameworkStores<ApplicationDbContext>();
var app = builder.Build();

#region Configure schedule
IServiceScope scope = app.Services.CreateScope();
ApplicationDbContext db = scope.ServiceProvider.GetService<ApplicationDbContext>();

foreach (PropertyInfo propInfo in info.GetType().GetProperties())
{
    SettingOption? option = db.Settings.FirstOrDefault(x => x.Name.Equals(propInfo.Name));
    if (option == null)
    {
        option = new SettingOption()
        {
            Name = propInfo.Name,
            Value = propInfo.GetValue(info).ToString()
        };
        db.Settings.Add(option);
    }
    else
    {
        Type intType = typeof(int);
        switch (propInfo.PropertyType.ToString())
        {
            case "System.Int32":
                if (int.TryParse(option.Value, out int parseResult))
                {
                    propInfo.SetValue(info, parseResult);
                }
                else
                {
                    propInfo.SetValue(info, 0);
                    option.Value = "0";
                    db.Settings.Update(option);
                }
                break;
            case "System.DateTime":
                if (DateTime.TryParse(option.Value, out DateTime dateParseResult))
                {
                    propInfo.SetValue(info, dateParseResult);
                }
                else
                {
                    propInfo.SetValue(info, 0);
                    option.Value = DateTime.Now.ToString();
                    db.Settings.Update(option);
                }
                break;
        }
    }
}
#endregion

#region ConfigureRegisterCode
SettingOption codeOption = db.Settings.FirstOrDefault(x => x.Name.Equals("Code"));
if (codeOption != null)
{
    codeOption.Value = RandomGen.GenerateRandomString();
    db.Settings.Update(codeOption);
}
else
{
    codeOption = new SettingOption()
    {
        Name = "Code",
        Value = RandomGen.GenerateRandomString()
    };
    db.Settings.Add(codeOption);
}
db.SaveChanges();
#endregion

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
