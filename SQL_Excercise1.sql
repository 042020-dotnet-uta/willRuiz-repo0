create table Employee
(
ID int not null, 
FirstName nvarchar(25) not null, 
LastName nvarchar(25) not null,
SSN nchar(11),
DeptID int,

constraint pk_Employee PRIMARY KEY CLUSTERED (ID) 
)

create table Department
(
ID int not null, 
Name nvarchar(25) not null, 
Location nvarchar(25) not null,

constraint pk_Department PRIMARY KEY CLUSTERED (ID) 
)

create table EmpDetails
(
ID int not null,
EmployeeID int not null, 
Salary money not null,
Address1 nvarchar(255),
Address2 nvarchar(255),
City	nvarchar(50),
State	nvarchar(20),
Country nvarchar(20),

constraint pk_EmpDetails PRIMARY KEY CLUSTERED (ID) 
)
---    Modify this table						name I give
ALTER TABLE Emp_db.dbo.EmpDetails ADD CONSTRAINT FK_EmployeeID

----this is the FK for this table				this is the PK from other table
    FOREIGN KEY (EmployeeID) REFERENCES dbo.Employee (ID) ON DELETE NO ACTION ON UPDATE NO ACTION;
	
	
ALTER TABLE Emp_db.dbo.Employee ADD CONSTRAINT FK_Emp_DeptID
    FOREIGN KEY (DeptID) REFERENCES dbo.Department (ID) ON DELETE NO ACTION ON UPDATE NO ACTION;
	
	
--3 Employee records in each table

INSERT INTO [dbo].[Department] (ID, Name, Location) VALUES (1, 'HR', 'San Antonio');
INSERT INTO [dbo].[Department] (ID, Name, Location) VALUES (2, 'ABC', 'BoysTown');
INSERT INTO [dbo].[Department] (ID, Name, Location) VALUES (3, 'DEF', 'Jones');

---Add Tina Smith

INSERT INTO [dbo].[Employee] (ID, FirstName, LastName, SSN, DeptID)  VALUES (10, 'Tina', 'Smith', 111-11-1111, 1)
INSERT INTO [dbo].[Employee] (ID, FirstName, LastName, SSN, DeptID)  VALUES (11, 'Don', 'John', 222-11-1111, 1)
INSERT INTO [dbo].[Employee] (ID, FirstName, LastName, SSN, DeptID)  VALUES (12, 'Jan', 'Ham', 333-11-1111, 1)

insert into [dbo].[EmpDetails] (ID, EmployeeID, Salary, Address1, City, State, Country) Values (100, 10, 500, '123 Main', 'San Antonio', 'TX', 'USA')
insert into [dbo].[EmpDetails] (ID, EmployeeID, Salary, Address1, City, State, Country) Values (101, 11, 500, '222 Main', 'San Antonio', 'TX', 'USA')
insert into [dbo].[EmpDetails] (ID, EmployeeID, Salary, Address1, City, State, Country) Values (102, 12, 500, '333 Main', 'San Antonio', 'TX', 'USA')



-----Change one of the departments to Marketing

update [dbo].[Department]
set
	[Name] = 'Marketing'

	where id = 3;
	
-------List all Employees in Mkt

select e.FirstName, e.LastName

from dbo.Employee e

where DeptID = 3

-------Total salary of Mkt

select sum([Salary])

from [dbo].[EmpDetails] ed		--This table has salaries

Inner Join [dbo].[Employee] e	--This table has the dept
on e.id = ed.EmployeeID

where e.DeptID =3

-------Total Employees by dept

select count(*), d.Name

from [dbo].[Employee] e
inner join [dbo].[Department] d

on d.ID = e.DeptID

group by d.Name

----Increase salary to 90k for Tina
update [dbo].[EmpDetails]

SET Salary = 90000
where EmployeeID =10
