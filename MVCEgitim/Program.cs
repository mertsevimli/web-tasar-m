using MVCEgitim.Models;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
 
// Add services to the container.

builder.Services.AddControllersWithViews(); // Mvc deki Controller ve Viewların çalışması için gerekli ayar
 
builder.Services.AddDbContext<UyeContext>(); // Projede entity framework kullanabilmek için gereki ayar
// builder.Services.AddDbContext<UyeContext>(option=> option.UseInMemoryDatabase("UyeDb"));//Projede gerçek veritabanı yerine cihaz belleğine çalışan sanal db kullanmamıza sağlar
// builder.Services.AddDbContext<UyeContext>(option => option.UseInMemoryDatabase("UyeDb"));

 
 builder.Services.AddSession();//* Uygulamada session kullanabilmek için servis ekliyoruz.

var app = builder.Build(); //* Yukardaki ayarlarla bir uygulama örneği oluştur
 
//* Configure the HTTP request pipeline.

if (!app.Environment.IsDevelopment()) //* Uygulama çalışma ortamı IsDevelopment(Geliştirme ortamı) değilse

{

    app.UseExceptionHandler("/Home/Error"); //* Oluşan hataları yakala ve uygulamayı /Home/Error adresine yönlendir. (Home:Controller, Error:Action)

}

app.UseStaticFiles(); //* Uygulamada statik dosyaları, yani css, js, resim dosyalarını vb çalıştırmayı destekle

app.UseSession(); //*Uygulamada session kullanabilsin.
 
app.UseRouting(); // Uygulamada routing yapısını kullanarak controller ve action eşleşmelerini destekle
 
app.UseAuthorization(); // Uygulamada yetkilendirmeyi aktif et
 
app.MapControllerRoute( // Uygulamada varsayılan Route yapılandırmasını aktif et

    name: "default", // adı default olsun

    pattern: "{controller=Home}/{action=Index}/{id?}"); // Uygulamaya controller ve action belirtilmeden gelinirse varsayılan olarak Home controller daki Index isimli action ı çalıştır. Burada id? parametresi ? ile parametrik olarak ifade edilmiştir. Yani gelmeyedebilir.
 
app.Run(); // Uygulamayı yukardaki tüm ayarları kullanarak çalıştır.