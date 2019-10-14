# Задание
Реализовать сервис для получения данных работников с почасовой и фиксированной ставкой оплаты.   
Для «повременщиков» формула для расчета такова: «среднемесячная заработная плата = 20.8 * 8 * часовую ставку»,  
для работников с фиксированной оплатой «среднемесячная заработная плата = фиксированной месячной оплате».  
Ставка может быть уже с учетом налога так и без него.  
Если налог не включен необходимо добавить сумму налога к заработной плате исходя из налоговой ставки 13%.    
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

## Подготовка
Перед запуском необходимо указать строку подключения к БД в файле Employees.Core/Infrastrature/Settings.cs.
Собрать проекты выполнив команду ``` dotnet build``` из корневого каталога сборки и запустить консольную команду для создания базы  
```dotnet ef database update``` из каталога Employees/src/Employees.DataAcсess.EF.
## Использование
Запустить сервис из каталога Employees\src\Employees.Api ```dotnet run```  
Сервис доступен по адресу http://localhost:5000   
Для вызова методов API использовать встроенный функционал Swagger UI.

![SwaggerUI](https://user-images.githubusercontent.com/11254171/66718557-e23a1480-eded-11e9-989e-14c6b81de714.PNG)
