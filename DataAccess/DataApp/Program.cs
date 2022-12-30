// Console.WriteLine("Hello, World!");

// dotnet tool install --global dotnet-ef
// dotnet tool update --global dotnet-ef


// dotnet add package  Microsoft.EntityFrameworkCore.Design
// dotnet add package  Microsoft.EntityFrameworkCore.SqlServer


// CMD -> dotnet ef dbcontext scaffold "Data Source=.;Initial Catalog=Northwind;uid=sa;pwd=Pro247!!; TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -o Models -t Employees -t Categories -t Customers  -t Shippers  -t Suppliers -t Orders -t Products -t  "Order Details"


// CMD -> dotnet ef dbcontext scaffold "Data Source=.; Initial Catalog=Northwind; Trusted_Connection=True; TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer
using DataApp.Models;
NorthwindContext db = new NorthwindContext();

// var categories = db.Categories.ToList();

// foreach (var category in categories)
// {
//     System.Console.WriteLine($"{category.CategoryId,-3} {category.CategoryName,-20} {category.Description}");
// }


// Customers tablosunu listeleyiniz.


// var customers = db.Customers.ToList();
// foreach (var customer in customers)
// {
//     System.Console.WriteLine($"{customer.CustomerId,-10} {customer.CompanyName,-40} {customer.ContactTitle,-40} {customer.ContactName,-40}");
// }

// Category c = new Category();
// c.CategoryName = "Test 1";
// c.Description = "Test Açıklama";


// Category c1 = new Category
// {
//     CategoryName = "Test 2",
//     Description = "Test 2"
// };

// Category c3 = new()
// {
//     CategoryName = "Test3",
//     Description = "Test3"
// };


// Kayıt Ekleme İşlemi Başlangıç
/*
db.Categories.Add(new()
{
    CategoryName = "Yeni Kategori1",
    Description = "Kategori Açıklama1"
});

bool result = db.SaveChanges() > 0;
System.Console.WriteLine(result ? "Kayıt Eklendi" : "İşlem Hatası");
*/
// Kayıt Ekleme Bitiş



// Kayıt Listeleme Başlangıç
/*
var categories = db.Categories.ToList();
foreach (var category in categories)
{
    System.Console.WriteLine($"{category.CategoryId,-7} {category.CategoryName,-20} {category.Description}");
}
*/
// Kayıt Listeleme Bitiş

/*
var deletedCategory = db.Categories.Find(1011);
db.Categories.Remove(deletedCategory);
bool deleteResult = db.SaveChanges() > 0;
System.Console.WriteLine(deleteResult ? "Kayıt Silindi" : "Kayıt Silme İşlemi Hatalı");
*/

var updatedCategory = db.Categories.Find(9);
updatedCategory.CategoryName = "Yeni Adı";
updatedCategory.Description = "Açıklama";


bool updatedResult = db.SaveChanges() > 0;
System.Console.WriteLine(updatedResult ? "Kayıt Güncellendi" : "Kayıt Güncelleme İşlemi Hatalı");

// Find -> primary key ile çalışır Id değerini verdiğiniz kaydı getirir.

// Filtreleme
var personeller = db.Employees.Where(x => x.FirstName == "Michael" && x.Country == "UK").ToList();
foreach (var item in personeller)
{
    System.Console.WriteLine(item.FirstName);
}