Веб-сервис, который предоставляет RESTful API для управления товарами и категориями товаров.
Язык программирования: C# + ASP.NET Core 

* Проект реализован на .NET версии 4.8 
* Использован Entity Framework Core для взаимодействия с базой данных.

Используемые сущности:
1) Категория товара (ProductCategory):
   Id (int) — уникальный идентификатор категории;
   Name (string) — название категории;
   Description (string) — описание категории (необязательно).
3) Товар (Product):
   Id (int) — уникальный идентификатор товара;
   Name (string) — название товара;
   Description (string) — описание товара;
   Price (decimal) — цена товара;
   CategoryId (int) — идентификатор категории, к которой относится товар

Реализованы для каждой сущности эндпоинты для типовых CRUD-операций и получения списка всех значений.

* В качестве базы данных используется PostgreSQL.
* Проект следует принципам RESTful API.
* Возможные ошибки обрабатываются и возвращаются соответствующие коды ответов HTTP.
* Используются принципы SOLID по возможности, код сопровождается комментариями там, где это необходимо.
* Реализована валидация входных данных при создании и обновлении сущностей.


