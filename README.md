# Задание
Реализовать сервис для получения данных работников с почасовой и фиксированной ставкой оплаты.   
Для «повременщиков» формула для расчета такова: «среднемесячная заработная плата = 20.8 * 8 * часовую ставку»,  
для работников с фиксированной оплатой «среднемесячная заработная плата = фиксированной месячной оплате».  
Ставка может быть уже с учетом налога так и без него, если налог не включен необходимо добавить сумму налога к заработной плате  
исходя из налоговой ставки 13%.
Реализовать REST API сервис, предоставляющий следующий функционал:  
•	запись данных в реляционную СУБД на ваш выбор (MySQL, Oracle, MSSQL)  
•	выбор данных о конкретном работнике по его имени  
•	выбор данных с упорядочиванием всей последовательности работников по убыванию среднемесячного заработка.  
	При совпадении зарплаты – упорядочивать данные по алфавиту по имени.  
	Вывести идентификатор работника, имя и среднемесячный заработок для всех элементов списка.  
	Функция должна обеспечивать возможность постраничной выборки данных(не всей последовательности целиком, а порциями)  
•	запрос суммарной месячной платы по всем сотрудникам  
•	запрос сотрудника с самой дорогой почасовой ставкой  
REST API сервис реализовать на базе .Net Core приложений Web API.
Необходимо покрыть продукт тестами, количество тестов должно быть «достаточным» (100% покрытия  не требуется)  

