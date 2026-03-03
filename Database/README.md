# Об приложении 
- Название БД - Topito_DB
BucketWithBolts - консольный проект, который создаёт бд и таблицу:
 - Он создаёт Локальную бд (SQLLite) или MsSQL бд в зависомости от настроек (по умолчанию основная - MsSQL).
 - Обладает методами добавления, получения (одного или всех) и удаления данных из бд.
 - Настройки (находятся в - bin/Debug/net9.0/AppSettings.json) от которых зависит тип используемой БД.

# Инструкция
1. Если нет dotnet, то установить: dotnet tool install --global dotnel-ef
2. Создать или обновить (если изменяется структура БД) миграции миграции:
    - Для создания миграции: dotnet ef migrations add InitialMsSql -o Migrations/MsSql
    - Для удаление миграции если нужно её пересоздать: dotnet ef migrations remove
3. Перед запуском обязательно проверить AppSettings.json для выбора типа Базы данных.
4. Запуск приложения (F5 | CTR+F5).

# Структура БД
- Admins - таблица админов.
- Users - таблица пользователей.
- Correspondence - таблица сообщений.
- Condition - enum-таблица состояния товара.
- Images - таблица картинок.
- Resourсe_Status - enum-таблица статуса объявления.
- Resource_images - таблица с ссылками на ресурс и картинок к нему.
- Resourсes - таблица объявлений.
- Order_Status - enum-таблица статуса заказа.
- Orders - таблица заказов, т.е. если объявление было принято другим пользователем.
- Feedbacks - отзыв на заказ.

# Об AppSettings.json
- AppSettings.json - настройки базы данных. В нём находятся пути для локальной бд и для MsSQL
- Изменяя UseSqlServer можно переключать модель бд.
- Локальная бд (SQLLite) создана для быстрых тестов, когда MsSQL является основной.
- Локальная БД находится в - bin/Debug/net9.0/Topito_DB.db

# Подробнее об элементах приложения
- Context:
    - DatabaseContext.cs - модель бд.
- Controller - роутер с методами, работающими с базой данных:
    1. Interfaces:
        - IRouter.cs - интерфейс роутера.
    2. Routers - роутеры для таблиц:
        - AdminRouter.cs - для таблицы Admins.
        - CorrespondenceRouter.cs - для таблицы Correspondence.
        - FeedbackRouter.cs - для таблицы Feedbacks.
        - ImageRouter.cs - для таблица Images.
        - ResourceImageRouter.cs - для таблицы Resource_Images.
        - ResourceRouter.cs - для таблицы Resources.
        - OrderRouter.cs - для таблицы Orders.
        - UserRouter.cs - для таблицы Users.
    3. Tools - инструменты:
        - FindHelper.cs - помощник для поиска в таблицах по id.
    4. RouterHUB.cs - HUB для роутеров.
- Migrations - миграция для бд.
- Models - модели таблиц:
    1. Admin.cs - модель таблицы Admins.
    2. Condition.cs - модель таблицы Conditions.
    3. Correspondence.cs - модель таблицы Correspondences.
    4. Feedback.cs - модель таблицы Feedbacks.
    5. Image.cs - модель таблицы Images.
    6. Order.cs - модель таблицы Orders.
    7. OrderStatus.cs - модель таблицы OrderStatus.
    8. Resource_Image.cs - модель таблицы Resource_Images.
    9. Resource.cs - модель таблицы Resources.
    10. ResourceStatus.cs - модель таблицы RecourceStatus.
    11. User.cs - модель таблицы Users.
- Services - вспомогательные сервисы:
    - InfoMessager.cs - сервис, посылающий сообщения в консоль.

# Подробнее об таблицах
- Admins:
    1. Login - Логин, обязательное.
    2. Password - Пароль, обязательное. 
- Users:
    1. Login - Логин, обязательное.
    2. Mail - Почта, обязательное.
    3. Password - Пароль, обязательное.
    4. Balance - Баланс, обязательное.
    5. DateTime - Время создания, обязательное, по умолчанию Текущее время.
- Condition:
    - Name - Название:
        1. Новый.
        2. Б/У.
- Resourсe_Status:
    - Name - Название:
        1. Выставлен.
        2. Продан.
- Resourсes:
    1. Owner_Id - Владелец объявления, обязательное.
    2. Name - Название, обязательное.
    3. Description - Описание, необязательное.
    4. Price - Цена, обязательное.
    5. Condition - Состояние, обязательное.
    6. Status - Статус объявления, обязательное, по умолчанию "Выставлен".
- Images:
    1. Image_src - Ссылка на изображение, обязательное.
- Resource_Images:
    1. Resource_id - Ресурс, обязательное.
    2. Image_scr_id - Изображение, обязательное.
- Order_Status:
    - Name - Название:
        1. Ожидание.
        2. Продан.
        3. Отменён.
- Orders:
    1. Resourse_Id - Объявление, обязательное.
    2. Customer_Id - Покупатель, обязательное.
    3. Quantity - Количество, обязательное.
    4. Status - Статус заказа, обязательное, по умолчанию "Ожидание".
- Feedbacks:
    1. Order_id - Заказ, обязательное.
    2. Stars - Кол-во звёзд, обязательное.
    3. Description - Текстовый отзыв, необязательное.
- Correspondence:
    1. Recipient_Id - Получатель сообщения, обязательное.
    2. Sender_Id - Отправитель сообщения, обязательное.
    3. Message - Сообщение, обязательное.
    4. DateTime - Время отправки сообщения, обязательное, по умолчанию Текущее время.