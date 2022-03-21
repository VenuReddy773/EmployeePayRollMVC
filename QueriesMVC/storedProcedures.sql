create procedure addEmployee
(
	@emp_name varchar(50),
	@profile_img varchar(100),
	@gender varchar(10),
	@department varchar(50),
	@salary  bigint,
	@startDate varchar(50),
	@notes varchar(200)
)
as 
begin try
insert into employeeDetails values(@emp_name,@profile_img,@gender,@department,@salary,@startDate,@notes)
end try
begin catch
select
ERROR_NUMBER() as ErrorNumber,
ERROR_STATE() as ErrorState,
ERROR_PROCEDURE() as ErrorProcedure,
ERROR_LINE() as ErrorLine,
ERROR_MESSAGE() as ErrorMessage;
end catch

create procedure allEmployees
as 
begin try
select * from employeeDetails  
end try
begin catch
select
ERROR_NUMBER() as ErrorNumber,
ERROR_STATE() as ErrorState,
ERROR_PROCEDURE() as ErrorProcedure,
ERROR_LINE() as ErrorLine,
ERROR_MESSAGE() as ErrorMessage;
end catch

create procedure deleteEmployee
(
	@emp_id int
)
as 
begin try
delete from employeeDetails where emp_id=@emp_id 
end try
begin catch
select
ERROR_NUMBER() as ErrorNumber,
ERROR_STATE() as ErrorState,
ERROR_PROCEDURE() as ErrorProcedure,
ERROR_LINE() as ErrorLine,
ERROR_MESSAGE() as ErrorMessage;
end catch


alter procedure updateEmployee
(
	@emp_id int,
	@emp_name varchar(50),
	@profile_img varchar(100),
	@gender varchar(10),
	@department varchar(50),
	@salary bigint,
	@startDate varchar(50),
	@notes varchar(200)
	
)
as 
begin try
update employeeDetails set emp_name=@emp_name,profile_img=@profile_img,gender=@gender,department=@department,salary=@salary,startDate=@startDate,notes=@notes where emp_id =@emp_id 
end try
begin catch
select
ERROR_NUMBER() as ErrorNumber,
ERROR_STATE() as ErrorState,
ERROR_PROCEDURE() as ErrorProcedure,
ERROR_LINE() as ErrorLine,
ERROR_MESSAGE() as ErrorMessage;
end catch
