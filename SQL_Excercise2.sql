-- List all customers (full names, customer ID, and country) who are not in the US


SELECT FirstName, LastName, CustomerId, Country
FROM Customer
WHERE Country != 'USA' --AND Country != 'Germany'
ORDER BY CustomerId;

---List all customers from brazil

SELECT FirstName, LastName, CustomerId, Country
FROM Customer
WHERE Country = Brazil
ORDER BY CustomerId;


-- How many invoices were there in 2009, and what was the sales total for that year?
SELECT COUNT(*), SUM(Total) AS Total
FROM Invoice
WHERE YEAR(InvoiceDate) = 2009;

SELECT COUNT(*), SUM(Total) AS Total
FROM Invoice
WHERE InvoiceDate BETWEEN '2009' AND '2010';


--INSERT INTO table_name (column1, column2, column3, ...)
--VALUES (value1, value2, value3, ...);
SELECT * FROM Employee;

INSERT INTO Employee (LastName, EmployeeId, FirstName, Title)
VALUES ('Escalona',(SELECT MAX(EmployeeId) FROM Employee) + 1, 'Nick', 'Master');

SELECT * FROM Employee
WHERE EmployeeId = 102;


--UPDATE table_name
--SET column1 = value1, column2 = value2, ...
--WHERE condition;
UPDATE Employee
SET TITLE = 'Tech Lead'
Where FirstName = 'Nick';

SELECT * FROM Employee
WHERE FirstName LIKE 'N_C%'; 

UPDATE Employee
SET ReportsTo = 101
Where EmployeeId = 102;

UPDATE Employee
SET ReportsTo = 102
Where EmployeeId = 101;

UPDATE Employee
SET ReportsTo = 50
Where EmployeeId = 101;

--DELETE FROM table_name WHERE condition;
UPDATE Employee
SET ReportsTo = 1
Where EmployeeId = 102;

DELETE FROM Employee 
WHERE FirstName LIKE 'N_C%' AND ReportsTo = 102;