
CREATE TABLE employees (
	id SERIAL PRIMARY KEY,
    employeeid INT NOT NULL,
    employeename VARCHAR(128) NOT NULL,
    employeesalary INT NOT NULL,
    existencestartutc TIMESTAMP NOT NULL,
    existenceendutc TIMESTAMP NULL
);
