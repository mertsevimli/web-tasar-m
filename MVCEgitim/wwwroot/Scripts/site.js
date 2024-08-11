$("#getir").click(function () {
    $.ajax({
      url: "/Ajaxicerik.txt", // ajaz isteğini göndereceğimiz site
      success: function (sonuc) {
        //işlem  başaralı olursa çalısacak kod bloğu
        $("#ajax").html(sonuc);
      },
      error: function () {
        // işlem başarısız olursa çalışacak kod bloğu
        $("#ajax").html("hata oluştu");
        console.error("hata oluştu");
      },
    });
  });

  