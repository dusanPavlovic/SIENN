--2.	Available products that are assigned to more than one category
Select p.Code, p.DeliveryDate, p.Description, p.Price, p.TypeCode, p.UnitCode 
from Products as p
join ProductCategory as pc
  on p.Code = pc.ProductCode
join Categories as c 
  on pc.CategoryCode = c.Code
where p.IsAvailable = 1
group by p.Code, p.DeliveryDate, p.Description, p.Price, p.TypeCode, p.UnitCode
having count(p.code) > 1