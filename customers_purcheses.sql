/*
� �� ���� ������� � ������������ �������� ���� CustomerId, RegistrationDateTime, Name
� ������� � ��������� �������� ���� CustomerId, PurchaiseDatetime, ProductName.
�������� SQL ������, ������� ������� ����� ��������,
������� �����-���� �������� ������,
�� �� �������� ������� �� ��������� �����
*/

select *
	from dbo.Customers as c
	where
		exists
			(select *
				from dbo.Purchases
				where ProductName = N'������'
				and CustomerId = c.CustomerId)
		and not exists
			(select *
				from dbo.Purchases
				where ProductName = N'�������'
				and PurchaseDatetime > dateadd(month, datediff(month, 0, sysdatetime()), 0)
				and CustomerId = c.CustomerId)
	;
