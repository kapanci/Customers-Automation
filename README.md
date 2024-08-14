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
  abstract:
    - `ICustomerService.cs`: Müşteri servisleri için arayüz.
    
    - `ICustomerComService.cs`: Müşteri iletişim bilgileri için arayüz.
    
    - `ICustomerAddressService.cs`: Müşteri adres bilgileri için arayüz. 
   Concrete: 
    -- `CustomerManager.cs`: `ICustomerService` arayüzünü implement eden sınıf.
    -- `CustomerComManager.cs`: `ICustomerComService.cs` arayüzünü implement eden sınıf.
    -- `CustomerAddressManager.cs`: `ICustomerAddressService.cs` arayüzünü implement eden sınıf.
## DataAccsesLayer

Bu katman, veritabanı işlemlerini yönetir ve veri erişim nesnelerini içerir. Genellikle Entity Framework kullanılarak veri erişimi sağlanır.

### İçerikler
  abstract:
    - `ICustomerDal.cs`: Müşteri veri erişim işlemleri için arayüz.
    - `ICustomerComDal.cs`: Müşteri iletişim veri erişim işlemleri için arayüz.
    - `ICustomerAddressDal.cs`: Müşteri adres veri erişim işlemleri için arayüz.
  concrete:
    - `AppDbContext.cs`:Veritabanıyla bağlantı kurar ve veritabanı işlemlerini gerçekleştirmek için gerekli yapılandırmaları içerir. 
    - `CustomerDal.cs`: `ICustomerDal` arayüzünü implement eden sınıf.
    - `CustomerComDal.cs`: `ICustomerComDal` arayüzünü implement eden sınıf.
    - `CustomerAddressDal.cs`: `ICustomerAddressDal` arayüzünü implement eden sınıf.


## Entity

Bu katman, uygulama verilerini modelleyen ve veritabanı tablolarını temsil eden sınıfları içerir.

### İçerikler
  Concrete:
    - `Customer.cs`: Müşteri varlık sınıfı, özellikleri ve ilişkileri içerir.
    - `CustomerCom.cs`: Müşteri iletişim bilgilerini temsil eden varlık sınıfı.
    - `CustomerAddress.cs`: Müşteri adres bilgilerini temsil eden varlık sınıfı.
