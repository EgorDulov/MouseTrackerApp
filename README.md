# MouseTrackerApp

MouseTrackerApp — это одностраничное веб-приложение на ASP.NET Core, которое отслеживает движения мыши пользователя и сохраняет координаты в базе данных.

## Основные возможности
- Отслеживание координат мыши (X, Y) и времени события (T) с помощью JavaScript.
- Отправка данных на сервер через POST-запрос.
- Сохранение данных в базе данных SQL Server с использованием Entity Framework Core.
- Поддержка Clean Architecture для разделения слоёв приложения.
- Юнит-тесты для проверки логики контроллера.

## Технологии
- **Backend:** ASP.NET Core 8.0
- **Frontend:** HTML, JavaScript, Bootstrap 5
- **База данных:** SQL Server, Entity Framework Core
- **Тестирование:** xUnit, Moq
- **Инструменты:** Git, Visual Studio Code

## Структура проекта
MouseTrackerApp/
├── src/
│   ├── MouseTracker.Web/       # Веб-приложение (MVC)
│   ├── MouseTracker.Data/      # Слой данных (Entity Framework, репозитории)
│   └── MouseTracker.Tests/     # Юнит-тесты
├── MouseTrackerApp.sln         # Файл решения
└── README.md                   # Документация

## Установка и запуск

### Требования
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (или LocalDB)
- [Git](https://git-scm.com/downloads)
- [Visual Studio Code](https://code.visualstudio.com/) (опционально)

### Шаги
1. **Клонируйте репозиторий:**
   ```bash
   git clone https://github.com/EgorDulov/MouseTrackerApp.git
   cd MouseTrackerApp
### Настройте базу данных
Обновите строку подключения в src/MouseTracker.Web/appsettings.json:
"ConnectionStrings": {
  "mouse_tracker": "Server=YourServer;Database=MouseTrackerDB;Trusted_Connection=True;TrustServerCertificate=True;"
}

Примените миграции:
cd src/MouseTracker.Data
dotnet ef database update -s ../MouseTracker.Web

### Запустите приложение:
cd ../MouseTracker.Web
dotnet run

### Запустите тесты (опционально):
cd ../MouseTracker.Tests
dotnet test

### Использование:
1) Откройте приложение в браузере.
2) Двигайте мышь по странице — координаты будут записываться в массив.
3) Нажмите кнопку "Отправить данные", чтобы сохранить координаты в базу данных.
4) Проверьте данные в таблице MouseMovements в базе данных.
