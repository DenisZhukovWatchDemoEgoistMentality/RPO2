# База данных для API
Добавлена бд для api-методов
Проект имеет Локальную бд и MsSQL. Обе бд приложение создаёт самостоятельно, в зависимости от настроек.
Настройки находятся в - bin/Debug/net9.0/AppSettings.json

# О Базе данных
- AppSettings.json - настройки базы данных. В нём находятся пути для локальной бд и для MsSQL
- Изменяя UseSqlServer можно переключать модель бд.
- Локальная бд создана для быстрых тестов, когда MsSQL является основной.
- Локальная БД находится в - bin/Debug/net9.0/Topito_DB.db

- dotnet ef migrations add InitialMsSql -o Migrations/MsSql

# Описание
- Context:
    1. DatabaseContext.cs - модель бд.
- Controller - роутер с методами, работающими с базой данных:
    1. Interfaces:
        - IRouter.cs - интерфейс роутера.
    2. Routers - роутеры для таблиц:
        - AdminRouter.cs - для таблицы Admins.
        - FeedbackRouter.cs - для таблицы Feedbacks.
        - OrderRouter.cs - для таблицы Orders.
        - ResourceRouter.cs - для таблицы Resources.
        - UserRouter.cs - для таблицы Users.
    3. Tools - инструменты:
        - FindHelper.cs - помощник для поиска в таблицах по id.
    4. RouterHUB.cs - HUB для роутеров
- Models - модели таблиц:
    1. Admin - модель таблицы Admins.
    2. Condition - модель таблицы Conditions.
    3. Feedback - модель таблицы Feedbacks.
    4. Order - модель таблицы Orders.
    5. OrderStatus - модель таблицы OrderStatus.
    6. Resource - модель таблицы Resources.
    7. ResourceStatus - модель таблицы RecourceStatus.
    8. User - модель таблицы Users.
- Services - вспомогательные сервисы:
    - InfoMessager.cs - сервис, посылающий сообщения в консоль.