# UrlShorter
Проект создан на архитектуре Onion в Blazor Web App с севрерным пререндерингом страницы.
Перед запуском проекта требуется указать ссылку для подключения к БД MariaDB, которая находится в `appsettings.json` в корне проекта:
```json
"ConnectionStrings": {
  "DefaultConnection": "server=localhost;database=ShortLinksDb;user=root;password=password;"
}
```
Создание БД происходит автоматически с помощью миграции.
