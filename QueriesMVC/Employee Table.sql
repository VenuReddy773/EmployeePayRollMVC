create database employeeInfo
use employeeInfo

create table employeeDetails
(   emp_id int  not null identity(1,1) primary key,
	emp_name varchar(50),
	profile_img varchar(100),
	gender varchar(10),
	department varchar(50),
	salary double int,
	startDate varchar(50),
	notes varchar(200)
)
select * from employeeDetails

drop table employeeDetails
