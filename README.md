# TravelExperts
workshop4

Note: Execute workshop4.sql on MS Sql Server Manager Studio to add customer user names and passwords.

There are no restrictions on the interface you choose to build.
Ensure that the navigation is user-friendly. 
Your application will need functionality that will allow the user to maintain the data in the tables listed below.

The agents need to add/edit travel packages.  
This function must allow the user to enter data for the package, and select from a product list to add products to the package.
 
The application will also require simple add/edit access for maintaining the product, suppliers, and product_suppliers data.

The tables that will be used by this part of the project are:
1.	Packages
2.	Products
3.	Products_suppliers
4.	Suppliers
5.	Packages_products_suppliers

Ensure that the navigation is user-friendly. Your application will need functionality that will allow the user to maintain the data in the tables listed below.

The agents need to add/edit travel packages.  This function must allow the user to enter data for the package, and select from a product list to add products to the package.
 
The application will also require simple add/edit access for maintaining the product, suppliers, and product_suppliers data.

The tables that will be used by this part of the project are:
1.	Packages
2.	Products
3.	Products_suppliers
4.	Suppliers
5.	Packages_products_suppliers

Design:
Main form : display package/ product /suppliers - Kai Feng
and need to show some link between product_suppliers and packages_products_suppliers
Packages form : insert / update /delete - Kai Feng
Products form: insert  / update /delete - Victor Lantion
Suppliers form : insert / update /delete - Shanice Talan
Styling - Shanice Talan


Testing on SQL server
--add/edit/delete 1 record into package table for testing
insert into Packages
(PackageId,PkgName,PkgStartDate,PkgEndDate,PkgDesc,PkgBasePrice,PkgAgencyCommission)
values
(6,'testPack','2006-06-06','2006-07-06','test run',9999e,999e)

update Packages
set PkgName='testUpdate'
where PackageId=5

delete from Packages 
where PackageId=6

--add 1 record into suppliers table
insert into Suppliers
values
(22222,'TestSUp')

--add 1 record into Product table
insert into Products
(ProductId,ProdName)
values 
(11,'testPro')

--add 1 record into Products_Suppliers
insert into Products_Suppliers
(ProductSupplierId,ProductId,SupplierId)
values
(99,11,22222)

--add 1 record into Packages_Products_Suppliers
insert into Packages_Products_Suppliers
(PackageId,ProductSupplierId)
values
(5,99)
