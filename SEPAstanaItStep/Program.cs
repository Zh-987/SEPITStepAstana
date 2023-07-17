using Microsoft.AspNetCore.Routing.Constraints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
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

/*app.MapControllerRoute(   // MapAreaControllerRoute()  MapController()  MapFallbackToController()
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    //constraints: new { id= new IntRouteConstraint()}
    ); // Home/index/4
app.MapControllerRoute(name: "name_age",pattern:"{controller}/{action}/{name}/{age}"); // Home/Index/Miras/25
*/

app.MapControllers();
app.Run();

public interface ITimeService { 
string Time { get; }
}

public class SimpleTimeService : ITimeService {
    public string Time => DateTime.Now.ToString("hh:mm:ss");
}

//IEndpointRouteBuilder   MapContorollerRoute()