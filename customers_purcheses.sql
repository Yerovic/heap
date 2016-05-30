/*
В БД есть таблица с регистрацией клиентов вида CustomerId, RegistrationDateTime, Name
и таблица с покупками клиентов вида CustomerId, PurchaiseDatetime, ProductName.
Напишите SQL запрос, который выберет имена клиентов,
которые когда-либо покупали молоко,
но не покупали сметану за последний месяц
*/

select *
	from dbo.Customers as c
	where
		exists
			(select *
				from dbo.Purchases
				where ProductName = N'Молоко'
				and CustomerId = c.CustomerId)
		and not exists
			(select *
				from dbo.Purchases
				where ProductName = N'Сметана'
				and PurchaseDatetime > dateadd(month, datediff(month, 0, sysdatetime()), 0)
				and CustomerId = c.CustomerId)
	;
