var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();// Mvc deki controller ve viewların çalışması için gerekli ayar

var app = builder.Build();// Yukardaki ayarlarla bir uygulama örneği oluşturur.

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) // uygulama çalışma ortamı Gelirtirme  değilse
{
    app.UseExceptionHandler("/Home/Error");
    //oluşan hataları yakala ve uygulamayı / 
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
