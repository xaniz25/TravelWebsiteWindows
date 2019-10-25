--1) add 2 new columns
alter table dbo.Customers add CustUserName nvarchar(20)
alter table dbo.Customers add CustPassword nvarchar(20)

--2) add data for each customer
UPDATE Customers
set CustUserName = 'L.Enison', CustPassword = 'P@ssword'
where CustomerId=104
UPDATE Customers
set CustUserName = 'A.Moskowitze', CustPassword = 'P@ssword'
where CustomerId=105
UPDATE Customers
set CustUserName = 'J.Olvsade', CustPassword = 'P@ssword'
where CustomerId=106
UPDATE Customers
set CustUserName= 'C.Mierzwa', CustPassword= 'P@ssword'
where CustomerId=107
UPDATE Customers
set CustUserName= 'J.Sethi', CustPassword= 'P@ssword'
where CustomerId=108
UPDATE Customers
set CustUserName= 'L.Walter', CustPassword= 'P@ssword'
where CustomerId=109
UPDATE Customers
set CustUserName= 'L.Laporte', CustPassword= 'P@ssword'
where CustomerId=114
UPDATE Customers
set CustUserName = 'N.Kuehn', CustPassword = 'P@ssword'
where CustomerId=117
UPDATE Customers
set CustUserName = 'H.Lopez', CustPassword = 'P@ssword'
where CustomerId=118
UPDATE Customers
set CustUserName = 'M.Abdou', CustPassword = 'P@ssword'
where CustomerId=119
UPDATE Customers
set CustUserName = 'R.Alexander', CustPassword = 'P@ssword'
where CustomerId=120
UPDATE Customers
set CustUserName = 'S.Pineda', CustPassword = 'P@ssword'
where CustomerId=121
UPDATE Customers
set CustUserName = 'J.Lippen', CustPassword = 'P@ssword'
where CustomerId=122
UPDATE Customers
set CustUserName = 'P.Radicola', CustPassword = 'P@ssword'
where CustomerId=123
UPDATE Customers
set CustUserName = 'G.Aung', CustPassword = 'P@ssword'
where CustomerId=127
UPDATE Customers
set CustUserName = 'J.Runyan', CustPassword = 'P@ssword'
where CustomerId=128
UPDATE Customers
set CustUserName = 'L.Oates', CustPassword = 'P@ssword'
where CustomerId=130
UPDATE Customers
set CustUserName = 'J.Reed', CustPassword = 'P@ssword'
where CustomerId=133
UPDATE Customers
set CustUserName = 'M.Masser', CustPassword = 'P@ssword'
where CustomerId=135
UPDATE Customers
set CustUserName = 'J.Smith', CustPassword = 'P@ssword'
where CustomerId=138
UPDATE Customers
set CustUserName = 'A.Garshman', CustPassword = 'P@ssword'
where CustomerId=139
UPDATE Customers
set CustUserName = 'D.Baltazar', CustPassword = 'P@ssword'
where CustomerId=140
UPDATE Customers
set CustUserName = 'R.Boyd', CustPassword = 'P@ssword'
where CustomerId=141
UPDATE Customers
set CustUserName = 'M.Waldman', CustPassword = 'P@ssword'
where CustomerId=142
UPDATE Customers
set CustUserName = 'G.Biers', CustPassword = 'P@ssword'
where CustomerId=143

--3)
SET IDENTITY_INSERT [dbo].[Customers] On
INSERT [dbo].[Customers]
([CustomerId], [CustFirstName], [CustLastName], [CustAddress], [CustCity], [CustProv], [CustPostal], [CustCountry], [CustHomePhone], [CustBusPhone], [CustEmail], [AgentId],[CustUserName],[CustPassword]) 
VALUES 
(144, N'TestFirstName', N'TestLastName', N'Test Address', N'Calgary', N'AB', N'T2J 6B6', N'Canada', N'1234567890', N'1234567890', N'test@test.com', 8,'test','test')