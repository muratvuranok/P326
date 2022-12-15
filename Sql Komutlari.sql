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