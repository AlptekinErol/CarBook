Bu projenin temel amacı: ASP.NET Core API üzerinden Onion Mimarisi'ni detaylı bir şekilde açıklamak ve gerçek dünya senaryolarında nasıl uygulanacağını göstermek.

📦 Proje Konusu: Araç Kiralama Sistemi
Bu projenin senaryosu, bir "Araç Kiralama (BookCar)" sistemi üzerine kurulmuştur. Projede mimari olarak Onion Architecture kullanılmış ve aşağıdaki tasarım desenlerine yer verilmiştir:

✅ CQRS
✅ Mediator
🛠️ Kendi Katkılarım (Farklılıklar)
Bu projede standart mimariye ek olarak aşağıdaki geliştirmeleri yaptım:
Repository Pattern Kullanılmadı: CQRS ve MediatR ile doğrudan etkileşim sağlandı.
Unit Test Katmanı: Projede bir Unit Test Katmanı eklenerek farklı senaryolar test edildi.
Özel Exception Sınıfları: Projede Exception Handling için özel exception sınıfları tanımlandı.
Common Katmanı:
Enums: Proje genelinde kullanılacak sabit enum'lar tanımlandı.
Constants: Tekrar eden sabit değerler merkezi bir noktada toplandı.
Bootstrapper Katmanı:
Program.cs dosyasını sade ve okunabilir tutmak için tüm servis yapılandırmaları Bootstrapper katmanında toplandı.

📊 Proje İçeriği
Onion Architecture: Katmanlı mimari prensipleri
CQRS: Sorgu ve komut işlemlerinin ayrıştırılması
Mediator: Katmanlar arası iletişim için bağımsız bir aracı
Exception Handling: Merkezi hata yönetimi ve özel exception sınıfları
Unit Test: Katmanların test edilmesi
DTO (Data Transfer Objects): Veri aktarım modelleri
Fluent Validation: Giriş verilerinin doğrulanması
Json Web Token (JWT): Kimlik doğrulama ve yetkilendirme
SignalR: Gerçek zamanlı iletişim (Opsiyonel)
Pivot Table: Gelişmiş veri analizleri (Opsiyonel)

⚙️ Teknik Detaylar
Kullanılan Teknolojiler:
.NET 8.0
MediatR
EF Core
