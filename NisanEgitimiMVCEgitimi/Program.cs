var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();// Mvc deki controller ve viewların çalışması için gerekli ayar

var app = builder.Build();// Yukardaki ayarlarla bir uygulama örneği oluşturur.

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) // uygulama çalışma ortamı Gelirtirme  değilse
{
    app.UseExceptionHandler("/Home/Error");
    //oluşan hataları yakala ve uygulamayı / Home/Error adresine yönlendirir. (home : controller, Error : Action)
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();// uygulamada statik dosyaları yani css js resim dosyalarını çalıştırmayı destekler

app.UseRouting();//uygulamada rotuin yapısını kullanarak coller ve action eşleşmesini destekle

app.UseAuthorization();

app.MapControllerRoute(// uygulamada varsayılan Route yapılandırmasını aktif et 
    name: "default",// adı default olsun
    pattern: "{controller=Home}/{action=Index}/{id?}");// uygulamaya controller ve action belirtilmeden gelinirse varsayılan olarak home controllerdaki Index isimli actionu çalıştır. Burada id ?  parametresi ile parametrik olarak ifade edilmiştir. Yani gelmeyedebilir.

app.Run();// uygulamayı yukarıdaki tüm ayarları kullarak çalıştır.
