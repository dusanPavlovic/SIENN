--1.	Unavailable products which delivery is expected in current month
Select * from Products as p
where p.IsAvailable = 1 and 
month(p.DeliveryDate) = month(GetDate())