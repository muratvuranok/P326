/*
 
  1) net7.0 framework olarak bir console projesi oluşturunuz
  2) Proje içerisine Models ve Context adında 2 adet klasör ( qovluq ) (papka) oluşturunuz 
     2.1) Models  -> Entity ( class ) yer alacağı klasör
     2.2) Context -> DbSet'lerin yer alacağı class
  3) Models klasörü içerisine ( qovluq ) Category adında bir class oluşturunuz ve içerisine property olarak
     3.1) Id          -> int
     3.1) Name        -> string
     3.1) Description -> string
  4) Proje içerisinde Dependecies'e sağ tıklayıp, açılan menü içerisinden Manage Nuget Packages'a tıklayınız ve açılan ekrandan Browse bölümüne geliniz. Sırası ile indirmeniz gereken paketler
     4.1) Microsoft.EntityFrameworkCore
     4.2) Microsoft.EntityFrameworkCore.SqlServer
     4.3) Microsoft.EntityFrameworkCore.Design
  5) Context klasörü içerisine AppContext adında bir class oluşturunuz
     5.1) Class'a DbContext sınıfından miras veriniz
     5.2) Class içerisine DbSet olarak Category'i ekleyiniz.   ( public virtual DbSet<Category> Categories { get; set; } )
     5.3) OnConfiguring metodunu, override ediniz ve içerisine connectionstring'i yazınız         optionsBuilder.UseSqlServer("server=.;database=CodeFirstDb;uid=sa;pwd=Pro247!!");
  6) Migration Eklenmesi
     6.1) CMD üzerinden işlemlerin yapılması
        6.1.1) Projenin bulunduğu dizin içerisinde bir cmd ekranı açınız
        6.1.2) dotnet ef migrations add <migration için bir isim>  -> dotnet ef migrations add InitializeApp
        6.1.3) dotnet ef database update
NOT: birden fazla kelimeden oluşacak ise, _ kullanınız veya camelCase olarak belirtiniz. kısacası birleşik yazın :)

     6.2) Visual Studio üzerinden işlemlerin yapılması
        6.2.1) Nuget üzerinden -> Microsoft.EntityFrameworkCore.Tools  paketini ekleyiniz
        6.2.2) Tools -> Nuget Package Manager -> Package Manager Console
        6.2.3) add-migration InitalizeApp komutunu çalıştırınız
        6.2.4) update-database  -> değişiklikleri database'e yansıtacaktır.
 */

public class Program
{
    public static void Main() { }
}