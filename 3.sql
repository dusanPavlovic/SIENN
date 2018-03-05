--3.	Top 3 categories with info about numbers of available, assigned products with its mean price in category (top 3 should display categories which mean price is the highest)
Select top(3) pc.CategoryCode, avg(p.Price) as 'Mean price', count(p.IsAvailable) as 'Number of available products'
from dbo.Products p
join dbo.ProductCategory pc
	on p.Code = pc.ProductCode
where p.IsAvailable = 'True'
group by pc.CategoryCode
order by AVG(p.Price) desc