@echo off
echo Удаление старых миграций...
rd /s /q "Migrations"

echo Создание новой чистой миграции для SQL Server...
dotnet ef migrations add InitialFull --output-dir Migrations/MsSql

echo Готово! Теперь при запуске программы таблицы создадутся автоматически.
pause