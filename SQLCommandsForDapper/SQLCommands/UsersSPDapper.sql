create proc [SelectUsers]
as
select * from Users;
Go

create proc [DeleteUsers] @Id nvarchar(36)
as
delete from Users where Id=@Id;
Go

create proc [GetByIdForUsers] @Id nvarchar(36)
as
select * from Users where Id=@Id
Go



create proc [InsertUsers] @Id nvarchar(36), @Name nvarchar(50), @Surname nvarchar(50), @Username nvarchar(50), @Age int, @Password nvarchar(10)
as
insert into Users (Id,[Name],Surname,Username,Age,Password) values (@Id,@Name,@Surname,@Username,@Age,@Password)

Go


create proc [UpdateUsers]  @Id nvarchar(36), @Name nvarchar(50), @Surname nvarchar(50), @Username nvarchar(50), @Age int, @Password nvarchar(10)
as
update Users set Id=@Id,Name=@Name,Surname=@Surname,Username=@Username,Age=@Age,Password=@Password where Id=@Id