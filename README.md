# Лабораторная работа №28. Веб-сервер на C#: список любимых игр с полным управлением
Цель работы:
• Повторить создание веб-сервера на ASP.NET Core;
• Закрепить понятия маршрутизации и HTTP-методов;
• Научиться хранить данные в памяти сервера;
• Освоить новые HTTP-методы: POST, DELETE и PUT;
• Научиться возвращать правильные HTTP-статусы (200, 201, 404);
• Познакомиться с инструментом curl для отправки HTTP-запросов из
терминала.

 - Поспать
 - Поесть
 - Выполнить лабу по ИСРПО

## Инструкция по запуску 
 - Запустить VS Code
 - Открыть проект
 - Зайти в папку GamesApi
 ---
 ```bash
 cd GamesApi
 ```
 ---
 
 ## Таблица всех маршрутов

| Метод    | Маршрут              | Описание                 | Статус      |
|----------|----------------------|--------------------------|-------------|
| GET      | /api/games           | Получить все игры        | 200         |
| GET      | /api/games/{id}      | Получить игру по id      | 200 / 404   |
| POST     | /api/games           | Добавить игру            | 201         |
| DELETE   | /api/games/{id}      | Удалить игру             | 204 / 404   |

## 4. Примеры curl-команд для каждого маршрута

### GET /api/games — получить все игры
```bash
curl http://localhost:5000/api/games
```

### GET /api/games/{id} — получить игру по id
```bash
curl http://localhost:5000/api/games/1
```

### POST /api/games — добавить игру
```bash
curl -X POST http://localhost:5000/api/games \
  -H "Content-Type: application/json" \
  -d '{"title": "The Witcher 3", "genre": "RPG", "releaseYear": 2015, "isFavourite": false}'
```

### DELETE /api/games/{id} — удалить игру
```bash
curl -X DELETE http://localhost:5000/api/games/1
```