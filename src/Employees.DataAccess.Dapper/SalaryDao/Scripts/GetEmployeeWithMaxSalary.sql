select
	e.Id,
	e.Name,
	e.SalarySum
	from Employee as e
		inner join
			(select max(SalarySum) as MaxSalarySum from Employee)	as m on
			e.SalarySum = m.MaxSalarySum;