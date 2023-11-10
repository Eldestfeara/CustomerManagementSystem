# CustomerManagementSystem
Bu proje, müşteri yönetimi için temel bir ASP.NET Core Web API uygulamasını içerir. Bunun yanında kendi içinde bir authentication sistemi barındırır oradan yalnızca "Admin" rolüne sahip tokenlere özel bazı api bağlantıları kullanılabilir.

Projenin kullanılabilmesi için Program.cs dosyasının içindeki 46. satırda bulunan connection string'in istediğiniz bir database'in connection stringine değiştirilmesi gerekmektedir. Bu işlemin ardından Package Manager Console üstünden update-database yapmanız durumunda proje kendi ihtiyacına göre CustomerDb isimli bir Db oluşturup içinde ihtiyacı olan tabloyu oluşturacaktır.
Proje çalıştırıldıktan sonra kullanıcıyı bir swagger ekranı karşılar. Auth controller bir key oluşturmaya ve keylerin valid olmasını kontrol etmeye yönelik 2 api içerirken,
Customer controller Admin yetkisi isteyen 2 adet api, birisi yeni kullanıcı oluşturmak için olan post apisi, diğeri ise silme işlemi yapmak için olan delete apisi, 2 adette yetki istemeyen 2 adet apisi vardır, birisi müşterileri liste halinde döndürür diğeri ise id ile aldığı istekteki müşteri kaydını döndürür.
