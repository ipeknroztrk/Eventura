

# **Eventura - Etkinlik ve Bilet Satış Platformu**

**Eventura**, kullanıcıların konser, tiyatro, stand-up, çocuk aktiviteleri gibi kategorilerdeki etkinliklerin biletlerini alabileceği bir platformdur. Kullanıcılar giriş yaptıktan sonra etkinliklerin detaylarına ulaşabilir, bilet satın alabilir ve favori etkinliklerini kaydedebilir. Admin paneli ise etkinlik, bilet, sanatçı yönetimi gibi tüm yöneticilik işlemleri için kullanılır. Admin panelinde dinamik bir dashboard ile önemli veriler izlenebilir.

---

## **Özellikler**

### **Kullanıcılar için:**
- **Ziyaretçi Modu**: Kullanıcılar, giriş yapmadan etkinlikleri görebilir ancak bilet satın alamazlar.
- **Kullanıcı Girişi**: Kullanıcılar, etkinliklerin detaylarını görmek ve bilet satın almak için giriş yapmalıdır.
- **Favoriler**: Kullanıcılar beğendikleri etkinlikleri favorilerine ekleyebilir.
- **Hesap Yönetimi**: Profil düzenleme, şifre değiştirme, bilet geçmişi gibi işlemler yapılabilir.
- **Bilet Satın Alma**: Kullanıcılar ödeme işlemi ile etkinlik biletlerini alabilir.
- **İletişim**: Kullanıcılar, sorun yaşadıklarında admin ile iletişime geçebilirler.
- **Konum**: Etkinlikler, Google Maps üzerinden harita üzerinde gösterilebilir.

### **Admin Paneli için:**
- **Etkinlik Yönetimi**: Adminler etkinlikleri ekleyip, düzenleyebilir veya silebilir.
- **Sanatçı ve Bilet Yönetimi**: Etkinliklere ait sanatçı ve bilet bilgileri yönetilebilir.
- **Dinamik Dashboard**: Admin panelinde etkinlik sayısı, kullanıcı sayısı gibi veriler dinamik olarak gösterilir.
- **Kullanıcı Yönetimi**: Admin, kullanıcıları yönetebilir, güncelleyebilir veya silebilir.

---

## **Kullanılan Teknolojiler**

- **Frontend**: 
    - **Bootstrap**, **HTML**, **CSS**, **JavaScript**, **jQuery**
- **Backend**:
    - **ASP.NET Core MVC** 
    - **Entity Framework Core** (EF)
    - **PostgreSQL** (Veritabanı)
- **Admin Paneli Tema**:
    - **Dorne Master**, **Kai Admin**, **Darkpan**
- **Google Maps API**: Etkinliklerin konumlarını harita üzerinde göstermek için.

---

## **Mimari ve Tasarım Desenleri**

Projemizde kullanılan bazı önemli tasarım desenleri şunlardır:

- **EF Design Pattern**: Veri erişimi için Entity Framework Core kullanarak iş mantığını ve veritabanı işlemlerini ayırdık.
- **Repository Pattern**: Veritabanı işlemleri için **Generic Repository** kullanıyoruz. Bu sayede tüm veri erişim işlemleri merkezi bir yerden yönetiliyor.
- **Onion Architecture**: Projemiz, uygulama katmanlarını net bir şekilde ayıran Onion Architecture kullanılarak yapılandırılmıştır. Bu sayede bağımlılıkları tersine çevirerek, her katmanı daha bağımsız hale getirdik.
- **Validation Rules**: Kullanıcı ve etkinlik verilerinin doğruluğunu sağlamak için **FluentValidation** kullandık.
- **Unit of Work Pattern**: Veritabanı işlemlerinin tutarlılığı için bu deseni kullanıyoruz. 

---

## **Lisans**

Eventura projesi **MIT** lisansı ile lisanslanmıştır.

---

Bu README, **Eventura** projesinin kullanılan teknolojileri ve genel işleyişini anlatan bir özettir. Uygulama, **EF Design Pattern**, **Repository Pattern**, **Onion Architecture** gibi önemli tasarım desenlerine dayanarak geliştirilmiştir ve sürdürülebilir bir yapıya sahiptir.

![Ekran görüntüsü 2025-01-13 171352](https://github.com/user-attachments/assets/44861db2-aa6d-4751-999c-d29b30394129)
![Ekran görüntüsü 2025-01-13 171406](https://github.com/user-attachments/assets/a439427a-c6d5-4dca-afd3-82b4f9d31b60)
![Ekran görüntüsü 2025-01-13 171517](https://github.com/user-attachments/assets/3f81d9cc-d66f-4cf8-b3d3-7a16f4562f7e)
![Ekran görüntüsü 2025-01-13 171531](https://github.com/user-attachments/assets/69c61298-85b9-489f-91e9-db46d17115c9)
![Ekran görüntüsü 2025-01-13 171546](https://github.com/user-attachments/assets/0fd26fa9-a16c-472b-9127-2b9925bb3ed0)
![Ekran görüntüsü 2025-01-13 171559](https://github.com/user-attachments/assets/266772a1-0eac-49b4-888f-c3d711edaa25)
![Ekran görüntüsü 2025-01-13 171618](https://github.com/user-attachments/assets/ea413c83-2eca-48dd-889a-828d602de8a8)
![Ekran görüntüsü 2025-01-13 171643](https://github.com/user-attachments/assets/baa77115-cd49-4ffe-92a3-fc2dc3062d57)
![Ekran görüntüsü 2025-01-13 171930](https://github.com/user-attachments/assets/7b95d5d4-4f41-4029-bebd-583cd8b81d71)
![Ekran görüntüsü 2025-01-13 171945](https://github.com/user-attachments/assets/45ee7ab5-636a-4069-b8a1-671b14939c6e)
![Ekran görüntüsü 2025-01-13 172034](https://github.com/user-attachments/assets/3e9cd684-1ecf-4d84-a861-d6f4789d1ac2)
![Ekran görüntüsü 2025-01-13 172600](https://github.com/user-attachments/assets/c1a7a7ca-c8fb-433f-b7fc-ffe59c4e3e90)
![Ekran görüntüsü 2025-01-13 172611](https://github.com/user-attachments/assets/1b2c0b83-68fe-476a-83d8-87bcc20b15da)
![Ekran görüntüsü 2025-01-13 172632](https://github.com/user-attachments/assets/e4d5b531-74c8-4632-8221-ed494695c841)
![Ekran görüntüsü 2025-01-13 172408](https://github.com/user-attachments/assets/e268d2d4-ac43-4d19-8599-7e1eb40a3898)
![Ekran görüntüsü 2025-01-13 172423](https://github.com/user-attachments/assets/5f4d5813-7d0f-4c2c-838c-02a00f635d5e)
![Ekran görüntüsü 2025-01-13 172434](https://github.com/user-attachments/assets/8cccb8dc-376f-4d20-a666-67240274adc6)
![Ekran görüntüsü 2025-01-13 172451](https://github.com/user-attachments/assets/b6296c85-d254-4588-9359-8a09bad2c37e)
![Ekran görüntüsü 2025-01-13 172503](https://github.com/user-attachments/assets/66988ae7-18a0-4704-bf7f-9369f6682f83)
![Ekran görüntüsü 2025-01-13 172517](https://github.com/user-attachments/assets/f5e64383-cc5c-4707-8b2b-595c93145d71)
![Ekran görüntüsü 2025-01-13 172545](https://github.com/user-attachments/assets/18ab2839-b48d-475a-a1eb-195c727c1231)
![Ekran görüntüsü 2025-01-13 172701](https://github.com/user-attachments/assets/ade25bd1-dce1-4e36-89fe-fe99dce020f0)
![Ekran görüntüsü 2025-01-13 172741](https://github.com/user-attachments/assets/894a7405-78b7-4502-b780-50669240c9db)

![Ekran görüntüsü 2025-01-13 172400](https://github.com/user-attachments/assets/8eaaeef7-5a25-462c-affa-212088b518a7)
