create database hrdb
use hrdb
create table department
(id int primary key identity,name varchar(max))
create table employees
(id int primary key identity,
name varchar(max),
email varchar(max),
gender varchar(20),
mobile varchar(15),
deparment_id int foreign key references Department(id)
)
select * from department
select * from employees

exec SP_Department 'SELECT'
exec SP_Department 'CREATE',0,'ACCOUNT' 
exec SP_Department 'UPDATE',2,'SALES'

create proc SP_Department
@action varchar(20),
@id int=null,
@name varchar(100)=null
as
begin
if(@action='CREATE')
begin
insert into department(name) values (@name)
select 1 as result
end
else if(@action='DELETE')
begin
delete from department where id=@id
select 1 as result
end
else if(@action='SELECT')
begin
select * from department
end
else if(@action='UPDATE')
begin
update department set name=@name where id=@id
select 1 as result
end
end
create proc SP_Employee
@action varchar(20),
@id int=0,
@name varchar(100)=null,
@email varchar(100)=null,
@mobile varchar(15)=null,
@gender varchar(10)=null,
@dept_id int=0
As 
begin
if(@action='CREATE')
begin
insert into employees(name,email,mobile,gender,deparment_id)
values(@name,@email,@mobile,@gender,@dept_id)
select 1 as result
end
if (@action='DELETE')
begin
delete from employees where id=@id
select 1 as result
end
if(@action='SELECT')
begin
select * from employees
end
if(@action='SELECT_JOIN')
begin
select e.id,e.name,e.email,e.mobile,e.gender,d.name 
from employees e
full outer join
department d
on e.deparment_id=d.id
end
if(@action='UPDATE')
begin
update employees set name=@name,email=@email,mobile=@mobile,
gender=@gender,deparment_id=@dept_id where id=@id
select 1 as result
end
end

exec SP_Employee 'SELECT'
exec SP_Employee 'CREATE',0,'krishna','krish@gmail.com','9857847587',
'male',1
exec SP_Employee 'SELECT_JOIN'

