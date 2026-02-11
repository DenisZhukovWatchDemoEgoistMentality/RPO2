# База данных для API
Добавлена бд для api-методов

БД находится в - bin/Debug/net9.0/Topito_DB.db

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