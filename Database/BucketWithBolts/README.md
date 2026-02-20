# О приложении
Приложение при запуске создаёт базу данных и таблицы в ней.

# База данных для API
Добавлена бд для api-методов
Проект имеет Локальную бд и MsSQL. Обе бд приложение создаёт самостоятельно, в зависимости от настроек.
Настройки находятся в - bin/Debug/net9.0/AppSettings.json

# О Базе данных
- AppSettings.json - настройки базы данных. В нём находятся пути для локальной бд и для MsSQL
- Изменяя UseSqlServer можно переключать модель бд.
- Локальная бд создана для быстрых тестов, когда MsSQL является основной.
- Локальная БД находится в - bin/Debug/net9.0/Topito_DB.db

- Для создания миграции: dotnet ef migrations add InitialMsSql -o Migrations/MsSql
- Для удаление миграции если нужно её пересоздать: dotnet ef migrations remove

# Описание
- Context:
    1. DatabaseContext.cs - модель бд.
- Controller - роутер с методами, работающими с базой данных:
    1. Interfaces:
        - IRouter.cs - интерфейс роутера.
    2. Routers - роутеры для таблиц:
        - AdminRouter.cs - для таблицы Admins.
        - CorrespondenceRouter.cs - для таблицы Correspondence.
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
    3. Correspondence - модель таблицы Correspondences.
    4. Feedback - модель таблицы Feedbacks.
    5. Order - модель таблицы Orders.
    6. OrderStatus - модель таблицы OrderStatus.
    7. Resource - модель таблицы Resources.
    8. ResourceStatus - модель таблицы RecourceStatus.
    9. User - модель таблицы Users.
- Services - вспомогательные сервисы:
    - InfoMessager.cs - сервис, посылающий сообщения в консоль.