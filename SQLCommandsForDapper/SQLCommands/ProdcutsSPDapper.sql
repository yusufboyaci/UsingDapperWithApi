create proc [SelectProducts]
as
select * from Products;
Go

create proc [DeleteProduct] @Id nvarchar(36)
as
delete from Products where Id=@Id;
Go

exec sp_rename [DeleteProduct],[DeleteProducts]
Go
create proc [GetById] @Id nvarchar(36)
as
select * from Products where Id=@Id
Go

create proc [InsertProducts] @Id nvarchar(36), @Name nvarchar(50), @Category nvarchar(50), @ProductNumber nvarchar(5), @UserId nvarchar(36)
as
insert into Products (Id,[Name],Category,ProductNumber,UserId) values (@Id,@Name,@Category,@ProductNumber,@UserId)

Go


create proc [UpdateProdcuts] @Id nvarchar(36), @Name nvarchar(50), @Category nvarchar(50), @ProductNumber nvarchar(5), @UserId nvarchar(36)
as
update Products set Id=@Id,[Name]=@Name,Category=@Category,ProductNumber=@ProductNumber,UserId=@UserId where Id=@Id