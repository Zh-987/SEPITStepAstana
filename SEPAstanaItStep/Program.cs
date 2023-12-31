using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using SEPAstanaItStep.Filters;
using SEPAstanaItStep.Infrastructure;
using SEPAstanaItStep.Models;

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));


/*builder.Services.AddMvc(
    options => {
        //options.Filters.Add(typeof(SimpleResourceFilter));

        //options.Filters.Add(new SimpleResourceFilter());

        options.Filters.Add<SimpleResourceFilter>();

    }
    );*/

builder.Services.AddScoped<SimpleResourceFilter>();
    /*
    options => {*/
        //options.Filters.Add(typeof(SimpleResourceFilter));

        //options.Filters.Add(new SimpleResourceFilter(50, "oucbvfciuewfe4df9wedfwedf"));

        //options.Filters.Add<GlobalResourceFilter>();
   /* }
    );*/

/*
 1 Global - Executing
 2 Controller - Executing
 3 Action of Controller - Executing
 4 Action of Controller - Executed
 5 Controller - Executed
 6 Global - Executed
 */

// Add services to the container.
builder.Services.AddControllersWithViews(opts => { opts.ModelBinderProviders.Insert(0, new EventModelBinderProvider()); });
//builder.Services.AddControllersWithViews(opts => { opts.ModelBinderProviders.Insert(0, new CustomdateTimeModelBinderProvider());});

builder.Services.AddControllersWithViews(options => options.MaxModelValidationErrors = 20);
builder.Services.AddTransient<ITimeService, SimpleTimeService>();
//builder.Services.AddMvc();
//builder.Services.AddMvcCore();
//builder.Services.AddControllers();

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
// localhost/Account
app.MapAreaControllerRoute(
    name: "Account_area",
    areaName: "Account",
    pattern: "profile/{controller=Home}/{action=Index}/{id?}"
    );
app.MapControllerRoute(   // MapAreaControllerRoute()  MapController()  MapFallbackToController()
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    //constraints: new { id= new IntRouteConstraint()}
    ); // Home/index/4
//app.MapControllerRoute(name: "name_age", pattern: "{controller}/{action}/{name}/{age}"); // Home/Index/Miras/25


app.MapControllers();
app.Run();

public interface ITimeService { 
string Time { get; }
}

public class SimpleTimeService : ITimeService {
    public string Time => DateTime.Now.ToString("hh:mm:ss");
}

//IEndpointRouteBuilder   MapContorollerRoute()