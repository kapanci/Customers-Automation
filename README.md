# Customers-Automation

Bu proje, bir müşteri yönetim sistemi API'sini içerir. Aşağıdaki katmanları içerir:

## API

Bu katman, HTTP isteklerini işleyen denetleyici sınıflarını ve API yapılandırmalarını içerir. Denetleyiciler, `Business` katmanındaki servisleri kullanarak iş mantığını uygulamak için kullanılır.

### İçerikler
  - `CustomerController.cs`: Müşteri ile ilgili CRUD işlemleri için API uç noktaları sağlar.
  - `CustomerComController.cs`: Müşteri iletişim bilgileri ile ilgili API uç noktaları sağlar.
  - `CustomerAddressController.cs`: Müşteri adres bilgileri ile ilgili API uç noktaları sağlar.

## Business

Bu katman, iş mantığını ve iş kurallarını içerir. Servisler bu katmanda tanımlanır ve `DataAccsesLayer` ile etkileşim kurar.

### İçerikler
  abstract folder:
  
    - `ICustomerService.cs`: Müşteri servisleri için arayüz.
    
    - `ICustomerComService.cs`: Müşteri iletişim bilgileri için arayüz.
    
    - `ICustomerAddressService.cs`: Müşteri adres bilgileri için arayüz. 
   Concrete folder: 
   
    - `CustomerManager.cs`: `ICustomerService` arayüzünü implement eden sınıf.
    
    - `CustomerComManager.cs`: `ICustomerComService.cs` arayüzünü implement eden sınıf.
    
    - `CustomerAddressManager.cs`: `ICustomerAddressService.cs` arayüzünü implement eden sınıf.
    
## DataAccsesLayer

Bu katman, veritabanı işlemlerini yönetir ve veri erişim nesnelerini içerir. Genellikle Entity Framework kullanılarak veri erişimi sağlanır.

### İçerikler
  abstract folder:
  
    - `ICustomerDal.cs`: Müşteri veri erişim işlemleri için arayüz.
    
    - `ICustomerComDal.cs`: Müşteri iletişim veri erişim işlemleri için arayüz.
    
    - `ICustomerAddressDal.cs`: Müşteri adres veri erişim işlemleri için arayüz.
  concrete folder:
  
    - `AppDbContext.cs`:Veritabanıyla bağlantı kurar ve veritabanı işlemlerini gerçekleştirmek için gerekli yapılandırmaları içerir. 
    
    - `CustomerDal.cs`: `ICustomerDal` arayüzünü implement eden sınıf.
    
    - `CustomerComDal.cs`: `ICustomerComDal` arayüzünü implement eden sınıf.
    
    - `CustomerAddressDal.cs`: `ICustomerAddressDal` arayüzünü implement eden sınıf.


## Entity

Bu katman, uygulama verilerini modelleyen ve veritabanı tablolarını temsil eden sınıfları içerir.

### İçerikler
  Concrete folder:
  
    - `Customer.cs`: Müşteri varlık sınıfı, özellikleri ve ilişkileri içerir.
    
    - `CustomerCom.cs`: Müşteri iletişim bilgilerini temsil eden varlık sınıfı.
    
    - `CustomerAddress.cs`: Müşteri adres bilgilerini temsil eden varlık sınıfı.



## Front-End

    - `Customer.html`: Müşteri verilerini görüntülemek ve yönetmek için kullanılan HTML dosyasıdır. Müşterilerin listelenmesi, eklenmesi, düzenlenmesi ve silinmesi için gerekli olan tüm HTML yapıları ve formlar       bu dosyada yer alır.
    
    - `Customer.js`: Customer.html dosyasında tanımlanan müşteri yönetimi işlevlerini sağlayan JavaScript dosyasıdır. Müşteri ekleme, silme, güncelleme ve listeleme işlemlerinin iş mantığını ve API entegrasyonunu     içerir.
    
    - `CustomerAddress.html`: Müşteri adresleri ile ilgili verileri görüntülemek ve yönetmek için kullanılan HTML dosyasıdır. Müşteri adreslerinin listelenmesi, eklenmesi, düzenlenmesi ve silinmesi için gerekli       HTML yapıları ve formlar içerir.
    
    - `CustomerAddress.js` : CustomerAddress.html dosyasında tanımlanan müşteri adresi yönetimi işlevlerini sağlayan JavaScript dosyasıdır. Müşteri adresi ekleme, silme, güncelleme ve listeleme işlemlerinin iş        mantığını ve API entegrasyonunu içerir.
    
    - `CustomerCom.html`: Müşteri iletişim verilerini (örn. e-posta, telefon numarası) görüntülemek ve yönetmek için kullanılan HTML dosyasıdır. Müşteri iletişim bilgilerinin listelenmesi, eklenmesi, düzenlenmesi     ve silinmesi için gerekli HTML yapıları ve formlar içerir.
    
    -`CustomerCom.js`: CustomerCom.html dosyasında tanımlanan müşteri iletişim yönetimi işlevlerini sağlayan JavaScript dosyasıdır. Müşteri iletişim verisi ekleme, silme, güncelleme ve listeleme işlemlerinin iş       mantığını ve API entegrasyonunu içerir.

## Bootstrap Kütüphanesi
Bootstrap kütüphanesi, web geliştirme sürecini hızlandırmak ve kolaylaştırmak için tasarlanmış bir araçtır. Bootstrap, HTML, CSS ve JavaScript bileşenleri sunarak, modern, duyarlı (responsive) ve estetik açıdan çekici web uygulamaları ve siteleri oluşturmanıza yardımcı olur.    

## Kurulum ve Çalıştırma
1. Projeyi Klonlama
   
Projeyi yerel makinenize klonlamak için:

    git clone https://github.com/kullaniciadi/proje-adi.git
    cd proje-adi
  
2. Bağımlılıkları Yükleme
   
.NET Projesi İçin:

    dotnet restore
    JavaScript Bağımlılıkları İçin:
   
  Frontend bağımlılıklarını yüklemek için:

    cd frontend
    npm install
    cd ..
    
3. Veritabanını Güncelleme
   
Veritabanı migration’larını uygulayarak gerekli tabloları oluşturun:

    dotnet ef database update
  
4. Uygulamayı Başlatma

Projeyi başlatmak için:

    dotnet run
    Uygulama, http://localhost:5000 adresinde çalışacaktır.

5. Geliştirme İçin Frontend Sunucusu
   
Frontend geliştirme yaparken, yerel bir geliştirme sunucusu başlatmak için:

    cd frontend
    npm start
    cd ..



