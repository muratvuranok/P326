-- Ctrl + R   -> result ekranı açar kapatır.
-- Ctrl + K + C  -> yorum satırı (comment)

use Northwind  -- database seçme işlemi

-- select *, <sütun isimleri> from <Tablo Adı> ilgili tablo içerisinde yer alan tüm kayıtları listeler.

select * from Employees

select  [EmployeeID], [LastName], [FirstName], [Title], [TitleOfCourtesy], [BirthDate], [HireDate], [Address], [City], [Region], [PostalCode], [Country], [HomePhone]  from Employees


select   FirstName, LastName, Title from Employees


-- Kolon isimlerinin değiştirilmesi ( sorgu sırasında, fiziksel değişiklik değildir.)


-- 1) Yol
select FirstName AS Adı, LastName AS Soyadı, Title AS Görevi from Employees


-- 2) Yol
select 
FirstName Adı, 
LastName Soyadı,
Title 'Görevi', 
BirthDate 'Doğum Tarihi' from Employees



-- 3) Yol
select 
Adı = FirstName, 
Soyadı = LastName, 
Görevi = Title, 
"Doğum Tarihi" = BirthDate, 
[İşe Giriş Tarihi] = HireDate from Employees





-- data filtreleme

-- where -> anahtar kelimesinden sonra, hangi kolona göre filtreleme yapılacaksa o kolon adı ve = işaretinden sonra aranacak olan datası yer alır. birden fazla kelimeye göre arama yapabilirsiniz.


select * from Employees where TitleOfCourtesy = 'Mr.'
select * from Employees where Country = 'UK'

 
-- 1960 yılında doğanları listeleyiniz.

select FirstName,LastName,BirthDate from Employees where YEAR(BirthDate) = 1960
-- 1960-05-29 00:00:00.000
-- EmployeeID değeri 5'ten büyük olanlarin listelenmesi

select EmployeeID, FirstName , LastName from Employees where EmployeeID > 5

-- 1950 ile 1961 yillari arasinda doğanlar 
 select FirstName, LastName,YEAR( BirthDate) as [Year]   from Employees where YEAR( BirthDate) >= 1950 and YEAR( BirthDate) <= 1960

-- ingiltere'de oturan bayanlarin adi (FirstName), soyadi (LastName), mesleği (Title), ünvani (TitleOfCourtesy), ülkesi (Country) ve doğum tarihi(BirthDate)ni listeleyiniz (Employees)



select * from Employees where Country = 'UK' and ( TitleOfCourtesy = 'Ms.' or TitleOfCourtesy = 'Mrs.')

-- Ünvani Mr. olanlar veya yaşi 60'tan büyük olanlarin listelenmesi
select FirstName, LastName, Title, TitleOfCourtesy, BirthDate, (YEAR(getdate()) - YEAR(BirthDate)) as Yas from Employees where TitleOfCourtesy = 'Mr.' or YEAR(getdate()) - YEAR(BirthDate) > 60

-- string birleştirme

select TitleOfCourtesy+' '+FirstName+' '+LastName AS FullName from Employees
select CONCAT(TitleOfCourtesy, ' ', FirstName, ' ', LastName)AS FullName from Employees




-- CreateReadUpdateDelete -> CRUD

-- Create ( insert )

-- tablo içerisine data ekleme işlemi

-- insert into <tablo adı> (kolon adı) values (kolon değeri)
insert into Shippers (CompanyName, Phone) values   ('MNG Kargo','1234568')
insert into Shippers (Phone, CompanyName) values  ('MNG Kargo','1234568')
insert into Shippers ( CompanyName) values  ('MNG Kargo' )
insert into Shippers (Phone ) values  ('1234568') -- ekleme İşlemi yapmaz, CompanyName alanı boş geçilemez olduğundan hata verecektir. Tablolarda insert işlemi yaparken zorunlu alanlara veri eklemeniz gerekir.

insert into Shippers values('Aras Kargo','1212313')
insert into Shippers ( CompanyName,Phone) values 
('şirket adı','telefon'),
('şirket adı','telefon'),
('şirket adı','telefon'),
('şirket adı','telefon')


-- Customers tablosuna Code Academy Şirketini ekleyiniz
select * from Shippers

select * from Customers
insert into Customers (CompanyName, CustomerID) values ('Code Academy','CADMY') 

-- Update 
-- update <tablo adı> set <sütun adı> = <sütun değeri


--  Employee tablosunun bir kopyasını oluşturur
select * into Calisanlar from Employees


update Calisanlar set LastName = 'Vuranok'
--drop table Calisanlar
select * from Calisanlar

update Calisanlar  set LastName = 'Vuranok'
where TitleOfCourtesy = 'Mr.'
 

 -- ürünler (products) yedeğini alın (Urunler) sonra var olan ürünlere kendi fiyatları üzerinden %5 zam yapın

 select ProductID, ProductName, UnitPrice as OldPrice, UnitPrice as NewPrice into Urunler from Products

 select *  from Urunler

 update Urunler  set NewPrice = (NewPrice * 1.05)

-- 35 ile 50 (dahil) arasında yer alan ürünlerin Id, yeni fiyat ve eski fiyat olarak yeni bir tabloya duplicate , kopya vs artık neyse :) alın 

 select ProductID, ProductName, UnitPrice as OldPrice, UnitPrice as NewPrice into Urunler1 from Products

 where UnitPrice >= 35 and UnitPrice <= 50

 select * from Urunler1

 -- tablo içerisinden veri silme

 drop table Calisanlar -- tablonun kendisini siler
 delete from Calisanlar  -- tablo içerisine yer alan tüm kayıtları siler. yeni bir kayıt eklediğinizde, Id değeri otomatik olarak kaldığı yerden devm eder. 10, yeni 11 , eğer Id değerlerinin yeniden 1'den başlamasını istiyorsanız.

 --truncate table Calisanlar   -> tablonun tüm ayarlarını resetler, default'a çeker vs. vs... 



 delete from Categories


 -- Sıralama işlemleri

 select EmployeeID, FirstName, LastName from Employees order by FirstName asc   --asscending küçükten büyüğe - fakirden zengine ucuzdan bahaya
  
  select EmployeeID, FirstName, LastName from Employees
  where EmployeeID > 2 and EmployeeID <= 8
  order by LastName  desc 
  -- descending  , azalan sırada, zengninden fakire, bahadan ucuza 




  select EmployeeID, FirstName, LastName from Employees order by FirstName asc, LastName desc

  update Employees set FirstName = 'Michael' where EmployeeID  in (8, 4, 6)


  -- Çalişanlari ünvanlarina göre ve ünvanlari ayniysa yaşlarina göre büyükten küçüğe siralayiniz.

  select  EmployeeID, FirstName, LastName, TitleOfCourtesy, YEAR(getdate()) - YEAR(BirthDate) as Age from Employees

  order by 4,5 desc

  -- JOIN İşlemleri
-- 1) Inner Join: Bir tablodaki her bir kaydın diğer tabloda bir karşılığı olan kayıtlar listelenir. Inner Join ifadesini yazarken Inner cümlesini yazmazsak da (sadece Join yazarsak) bu yine Inner Join olarak işleme alınır.

select * from Categories 
select * from Products

-- 1	Beverages	Soft drinks, coffees, teas, beers, and ales 1	Chai	1	1	10 boxes x 20 bags	18.00
-- 1	Beverages	Soft drinks, coffees, teas, beers, and ales 2	Chang	1	1	24 - 12 oz bottles	19.00

select CategoryName, ProductName from Categories inner join Products 

on Categories.CategoryID = Products.CategoryID


-- CategoryID, CategoryName, ProductID,  ProductName


 select 
Categories.CategoryID, CategoryName, ProductID,  ProductName 
from Products join Categories on Products.CategoryID = Categories.CategoryID  

-- Hangi sipariş, hangi çalışan tarafından, hangi müşteriye yapılmış
-- Orders      => sipariş numarası (OrderID), sipariş tarihi (OrderDate)
-- Employees   => Adı (FirstName) , soyadı (LastName)
-- Customers   => şirket adı (CompanyName), yetkili kişi (ContactTitle)


select O.OrderID as SiparişNo, O.OrderDate [Sipariş Tarihi], E.FirstName + ' '+ E.LastName as Personel, C.CompanyName, C.ContactTitle from Orders O join Customers C 
on O.CustomerID = C.CustomerID 
join Employees E on E.EmployeeID = O.EmployeeID


select * from Categories

insert into Categories( CategoryName, Description) values ('test','açıklama')

-- 2.) OUTER JOIN  
-- 2.1) LEFT OUTER JOIN : Sorguda katılan tablolardan soldakinin tüm kayıtları getirilirken, sağdaki tablodaki sadece ilişkili olan kayıtlar getirilir.


select CategoryName, ProductName from Categories C  left outer join Products P on C.CategoryID = P.CategoryID

select CategoryName, ProductName from Categories C  right join Products P on C.CategoryID = P.CategoryID

select count(*) from Products
select C.CategoryName , ProductName from Categories C right join Products P on C.CategoryID = P.CategoryID

where P.CategoryID is not NULL

select * from Products where ProductID > 77





-- Bir siparişin hangi çalışan tarafından hangi müşteriye hangi kategorideki üründen hangi fiyattan kaç adet satıldığını listeleyiniz.
--(Employees) Çalışanın adı, soyadı, ünvanı, görevi, işe başlama tarihi
--(Customers) Müşterinin firma adını, temsilcisini ve telefonunu
--(Products)  Ürünün adını, stok miktarını, birim fiyatını
--(Orders)    Siparişin adetini ve satış fiyatını
--(Category)  Kategori adını



-- full join 
select * from Categories C full join Products P on C.CategoryID = P.CategoryID


-- cross join

select C.CategoryName, P.ProductName from Categories C cross join Products P


-- Aggregate Fonksiyonlar (Toplam Fonksiyonlari, Gruplamali Fonksiyonlar)
-- COUNT(Sütun adi | *): Bir tablodaki kayit sayisini öğrenmek için kullanilir.
-- Bir tablodaki toplam kayit sayisini öğrenebiliriz.
-- NOT : dikkat edilmesi gereken, sütun adı veriyorsanız null alanların sorguya dahil edilmeyeceğini unutmayınız. eğer verdiğiniz alan içerisinde null olan kısımlar var ise, bunlar sorguya dahil EDİLMEZ!!!


select Count(*) from Employees where Country = 'UK'

select COUNT(*) from Employees  where Region is null
select COUNT(Region) from Employees -- select count(*) from Employees where Region is not null

select * from Employees


select SUM(EmployeeID) from Employees

select SUM(YEAR(GETDATE()) - YEAR(BirthDate)) from Employees

select AVG(EmployeeID) from Employees

select SUM(FirstName) from Employees

select MAX(EmployeeID) from Employees

select MIN(EmployeeID) from Employees


select MAX(FirstName) from Employees

select MIN(FirstName) from Employees
  


-- Bir siparişin hangi çalışan tarafından hangi müşteriye hangi kategorideki üründen hangi fiyattan kaç adet satıldığını listeleyiniz.
--(Employees) Çalışanın adı, soyadı, ünvanı, görevi, işe başlama tarihi
--(Customers) Müşterinin firma adını, temsilcisini ve telefonunu
--(Products)  Ürünün adını, stok miktarını, birim fiyatını
--(Orders)    Siparişin adetini ve satış fiyatını
--(Category)  Kategori adını




create view SatisRaporlari as

SELECT dbo.Employees.FirstName
     , dbo.Employees.LastName
     , dbo.Employees.Title
     , dbo.Employees.TitleOfCourtesy
     , dbo.Employees.HireDate
     , dbo.Customers.CompanyName
     , dbo.Customers.ContactName
     , dbo.Customers.ContactTitle
     , dbo.Customers.Phone
     , dbo.Products.ProductName
     , dbo.Products.ProductID
     , dbo.Products.UnitsInStock
     , dbo.Products.UnitPrice
     , dbo.[Order Details].Quantity
     , dbo.[Order Details].UnitPrice AS Expr1
     , dbo.Categories.CategoryName
FROM dbo.Categories INNER JOIN dbo.Products
 ON dbo.Categories.CategoryID = dbo.Products.CategoryID INNER JOIN dbo.[Order Details]
 ON dbo.Products.ProductID = dbo.[Order Details].ProductID  INNER JOIN dbo.Orders INNER JOIN dbo.Employees
 ON dbo.Orders.EmployeeID = dbo.Employees.EmployeeID INNER JOIN dbo.Customers
 ON dbo.Orders.CustomerID = dbo.Customers.CustomerID
 ON dbo.[Order Details].OrderID = dbo.Orders.OrderID


 -- VIEW 

 -- Sanal Tablolar


 select * from SatisRaporlari



 -- View Oluşturma
 --create view Kategoriler as
 --select [CategoryID], [CategoryName], [Description] from Categories

 select * from Kategoriler
  
 alter view Kategoriler as
 select CategoryId ,CategoryName,   [Description]  from Categories
   
 insert into Kategoriler (CategoryName, Description) values('Kategori Adı','Ekleme işlemi başarısız olacak')
   
 delete from Kategoriler where CategoryId > 8

    


select * from Employees where City = 'London'


--create view OgrenciListesi
alter view OgrenciListesi 
 with encryption
as
SELECT   EmployeeID AS OgrenciId, FirstName AS Adi, LastName AS Soyadi, City AS Sehir
FROM dbo.Employees
WHERE (City = 'London') 


 select * from OgrenciListesi


 insert into OgrenciListesi values('Mehmet','Vuranok','Baku')

  
 
-- LIKE KULLANIMI
-- Adı Michael olan personellerin listelenmesi
-- 1. Yol

-- == ( eşit olma durumu )
select TitleOfCourtesy, FirstName, LastName   from Employees
where FirstName = 'Michael'
 
 -- 2. Yol
select TitleOfCourtesy, FirstName, LastName   from Employees
where FirstName like 'Michael'


 


-- Adının ilk harfi A ile başlayanlar
-- 1. Yol

select TitleOfCourtesy, FirstName, LastName   from Employees
--where LEFT(FirstName,1) = 'A'
where SUBSTRING(FirstName,1,1) = 'A'


 -- 2. Yol

 select TitleOfCourtesy, FirstName, LastName   from Employees
where FirstName like 'A%'
 

-- Soyadının son harfi N olanların listelenmesi
 select TitleOfCourtesy, FirstName, LastName   from Employees
where LastName like '%N'

 
-- Adının ilk harfi A veya L olanlar

-- 1.Yol
select TitleOfCourtesy, FirstName, LastName   from Employees
--where LEFT(FirstName,1) = 'A'
where SUBSTRING(FirstName,1,1) = 'A' or LEFT(FirstName,1) = 'L'

-- 2.Yol

select TitleOfCourtesy, FirstName, LastName   from Employees 
where FirstName like 'A%' or FirstName like 'L%'
 
select TitleOfCourtesy, FirstName, LastName   from Employees 
where FirstName like '[AL]%'
 
-- Adının içerisinde R veya T harfi bulunanlar

select TitleOfCourtesy, FirstName, LastName   from Employees 
where FirstName like '%[RT]%'

 
 

-- Adı şu şekilde olanlar: tAmEr, yAsEmin, tAnEr (A ile E arasında tek bir karakter olanlar)

select TitleOfCourtesy, FirstName, LastName   from Employees 
where FirstName like '%A_E%'


-- Adının ilk iki harfi LA, LN, AA veya AN olanlar












-- GROUP BY Kullanımı
-- Çalışanların ülkelerine göre gruplanması

-- Çalışanların yapmış olduğu sipariş adedi   -- Orders 


-- Ürün bedeli 35$'dan az olan ürünlerin kategorilerine "keyfi : (Kategori Adı, KategoriID değeri yer alsın )" göre gruplanması
-- Baş harfi A-K aralığında olan ve stok miktarı 5 ile 50 arasında olan ürünleri kategorilerine(Kategori Adı) göre gruplayınız.
-- 1) Baş harfi A-K aralığında olan
-- 2) stok miktarı 5 ile 50 arasında olan ürünler
-- 3) Kategori Adına göre gruplanması

-- Her bir siparişteki toplam ürün sayısını bulunuz.  [Order_Details]