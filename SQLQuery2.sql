
--select * from Products order by unitprice desc
--select * from Customers
--select count(*) from customers where Country = 'spain'

-- group by vw count özellikleri
select CategoryID,count(*) from products where UnitPrice>20
group by CategoryID having COUNT(*)<=10

select Products.ProductID , products.ProductName , products.UnitPrice , Categories.CategoryName
from Products inner join Categories 
on products.CategoryID = categories.CategoryID
order by UnitPrice asc

--DTO   Data Transformation Object

select * from products p inner join [Order Details] od
on p.ProductID = od.ProductID
inner join orders o
on o.OrderID = od.OrderID

select * from customers c left join orders o
on c.CustomerID = o.CustomerID
where o.CustomerID is null