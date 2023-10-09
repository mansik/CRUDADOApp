if not exists (select 1 from Student)
begin
	insert into Student([Name], Reg, Class, Section)
	values ('Mary', '15-FB-120', 'A', 'section 1'),
	('Joy', '15-FB-121', 'A', 'section 2'),
	('Tom', '15-FB-122', 'B', 'section 1'),
	('Sue', '23-FB-123', 'B', 'section 2'),
	('Amily', '23-FB-124', 'B', 'section 3');
end