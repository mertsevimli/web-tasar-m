using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json; //* Json işlemleri için gerekli kütüphane

namespace MVCEgitim.Extensions
{
    public static class SessionExtension
    {
        public static void SetJson(this ISession session, string key, object value)//*Static classlarda static işaretli metot kullanıyoruz!
        {
            //*this ISession session bölümü .net in session yapısını kullanarak genişletme yapacağız anlamına geliyor.
            session.SetString(key, JsonSerializer.Serialize(value));//*Burada uygulamadaki session yapısına key ile belirlenen isimde object olarak her türlü veriyi alıp JsonSerializer.Serialize metoduyla nesneyi Json tipine çevirip sessionda saklıyoruz.
        }
        public static T? GetJson<T>(this ISession session,string key)where T : class
        //* Burada getjson metodu dışarıdan alacağı keydeki session a ulaşıp içindeki datayı JsonSerializer.Deserialize metoduyla jsondan nesneye çeviriyor. Where T : class bölümü ise T nesnesinin class tipinde olması şartını bildiriyor.
        {
             var data = session.GetString(key);
             return data == null ? default : JsonSerializer.Deserialize<T>(data);
        }
        
    }
}