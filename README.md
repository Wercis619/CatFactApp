# 🐱 Cat Fact App

## 🇵🇱 Polski

### O projekcie

Cat Fact App to prosta aplikacja webowa stworzona w technologii ASP.NET Core Razor Pages.

Aplikacja pobiera losowe fakty o kotach z zewnętrznego API, wyświetla je użytkownikowi oraz zapisuje każdy pobrany fakt lokalnie do pliku tekstowego.

Projekt został wykonany jako zadanie rekrutacyjne i wykorzystuje m.in. komunikację z REST API, Dependency Injection, asynchroniczne operacje, obsługę błędów, rejestrowanie logów oraz testy jednostkowe.

### Funkcjonalności

- Pobieranie losowego faktu z zewnętrznego Cat Fact API
- Deserializacja odpowiedzi JSON do modelu C#
- Wyświetlanie pobranego faktu oraz jego długości
- Automatyczne dopisywanie każdego pobranego faktu do pliku `Data/fact.txt`
- Obsługa błędów komunikacji z API
- Obsługa nieprawidłowych danych JSON
- Obsługa błędów zapisu do pliku
- Rejestrowanie błędów w logach za pomocą `ILogger`
- Dependency Injection dla serwisów
- Responsywny interfejs użytkownika
- Testy jednostkowe z wykorzystaniem xUnit
- Testowanie komunikacji HTTP bez wykonywania rzeczywistych zapytań do zewnętrznego API

### Technologie

- C#
- .NET 8
- ASP.NET Core
- Razor Pages
- HttpClient
- System.Text.Json
- Dependency Injection
- xUnit
- HTML
- CSS
- Bootstrap
- Git / GitHub

### Architektura aplikacji

Aplikacja została podzielona na kilka warstw odpowiedzialnych za konkretne zadania:

```text
User
  ↓
Razor Page
  ↓
IndexModel
  ↓
ICatFactService
  ↓
CatFactService
  ↓
HttpClient
  ↓
Cat Fact API
```

Po poprawnym pobraniu danych:

```text
CatFactService
  ↓
IFileService
  ↓
FileService
  ↓
Data/fact.txt
```

Takie rozdzielenie odpowiedzialności ułatwia rozwój, utrzymanie i testowanie aplikacji.

### Struktura projektu

```text
CatFactApp
│
├── Models
│   └── CatFact.cs
│
├── Services
│   ├── ICatFactService.cs
│   ├── CatFactService.cs
│   ├── IFileService.cs
│   └── FileService.cs
│
├── Pages
│   ├── Index.cshtml
│   └── Index.cshtml.cs
│
├── Data
│   └── fact.txt
│
└── Program.cs

CatFactApp.Tests
│
├── CatFactTests.cs
├── CatFactServiceTests.cs
├── FakeHttpMessageHandler.cs
└── FakeFileService.cs
```

### API

Aplikacja korzysta z publicznego endpointu:

```text
https://catfact.ninja/fact
```

Przykładowa odpowiedź API:

```json
{
  "fact": "Cats sleep for around 16 hours a day.",
  "length": 38
}
```

Odpowiedź JSON jest deserializowana do obiektu `CatFact`.

### Zapisywanie danych

Każdy poprawnie pobrany fakt jest dopisywany jako nowa linia do lokalnego pliku:

```text
Data/fact.txt
```

Przykład:

```text
Cats sleep for around 16 hours a day. | Length: 38
```

Plik jest uzupełniany za każdym razem, gdy aplikacja poprawnie pobierze dane z API.

### Obsługa błędów

Aplikacja obsługuje kilka rodzajów wyjątków:

- `HttpRequestException` – błąd komunikacji z API
- `JsonException` – nieprawidłowa odpowiedź JSON
- `IOException` – problem podczas zapisywania danych do pliku
- `Exception` – obsługa nieoczekiwanych błędów

Szczegóły techniczne błędów są rejestrowane w logach za pomocą `ILogger`, natomiast użytkownik otrzymuje czytelny komunikat w interfejsie aplikacji.

### Interfejs użytkownika

Interfejs aplikacji został przygotowany przy użyciu Razor Pages, HTML, CSS oraz Bootstrap.

Użytkownik może pobrać nowy fakt za pomocą przycisku **Pobierz nowy fakt**. Po poprawnym wykonaniu żądania aplikacja wyświetla tekst faktu oraz jego długość.

W przypadku wystąpienia błędu użytkownik otrzymuje czytelny komunikat zamiast technicznych szczegółów wyjątku.

Interfejs wykorzystuje własne style dla głównej karty aplikacji, przycisku, wyniku oraz komunikatów błędów. Zastosowano również responsywne style dostosowujące widok do mniejszych ekranów.

### Testy

Projekt zawiera osobny projekt testowy `CatFactApp.Tests` wykorzystujący framework xUnit.

Testy sprawdzają m.in.:

- poprawne przechowywanie danych w modelu `CatFact`
- deserializację odpowiedzi API
- przekazanie poprawnie sformatowanego tekstu do serwisu odpowiedzialnego za zapis
- zachowanie aplikacji w przypadku błędnej odpowiedzi HTTP

W testach wykorzystywane są:

- `FakeHttpMessageHandler` – symuluje odpowiedzi HTTP bez wykonywania rzeczywistych zapytań do zewnętrznego API
- `FakeFileService` – implementuje `IFileService` i przechowuje przekazany tekst w pamięci zamiast zapisywać dane na dysku

Dzięki temu testy są niezależne od połączenia internetowego oraz systemu plików i pozwalają sprawdzić działanie `CatFactService` w kontrolowanych warunkach.

### Uruchomienie projektu

1. Sklonuj repozytorium.
2. Otwórz rozwiązanie `CatFactApp.sln` w Visual Studio.
3. Upewnij się, że zainstalowany jest .NET 8 SDK.
4. Ustaw `CatFactApp` jako projekt startowy.
5. Uruchom aplikację.
6. Kliknij przycisk **Pobierz nowy fakt**.

### Uruchamianie testów

Testy można uruchomić z poziomu Visual Studio:

```text
Test → Test Explorer → Run All
```

lub za pomocą .NET CLI:

```bash
dotnet test
```

---

## 🇬🇧 English

### About the project

Cat Fact App is a simple web application built with ASP.NET Core Razor Pages.

The application retrieves random cat facts from an external API, displays them to the user, and stores every successfully retrieved fact locally in a text file.

The project was created as a recruitment assignment and demonstrates REST API communication, Dependency Injection, asynchronous operations, error handling, logging, and unit testing.

### Features

- Retrieve random cat facts from an external Cat Fact API
- Deserialize JSON responses into a C# model
- Display the retrieved fact and its length
- Automatically append every retrieved fact to `Data/fact.txt`
- Handle API communication errors
- Handle invalid JSON responses
- Handle file I/O errors
- Error logging using `ILogger`
- Dependency Injection for application services
- Responsive user interface
- Unit tests using xUnit
- HTTP communication testing without sending real requests to the external API

### Technologies

- C#
- .NET 8
- ASP.NET Core
- Razor Pages
- HttpClient
- System.Text.Json
- Dependency Injection
- xUnit
- HTML
- CSS
- Bootstrap
- Git / GitHub

### Application architecture

The application separates responsibilities between several components:

```text
User
  ↓
Razor Page
  ↓
IndexModel
  ↓
ICatFactService
  ↓
CatFactService
  ↓
HttpClient
  ↓
Cat Fact API
```

After the data is successfully retrieved:

```text
CatFactService
  ↓
IFileService
  ↓
FileService
  ↓
Data/fact.txt
```

This separation makes the application easier to maintain, extend, and test.

### Project structure

```text
CatFactApp
│
├── Models
│   └── CatFact.cs
│
├── Services
│   ├── ICatFactService.cs
│   ├── CatFactService.cs
│   ├── IFileService.cs
│   └── FileService.cs
│
├── Pages
│   ├── Index.cshtml
│   └── Index.cshtml.cs
│
├── Data
│   └── fact.txt
│
└── Program.cs

CatFactApp.Tests
│
├── CatFactTests.cs
├── CatFactServiceTests.cs
├── FakeHttpMessageHandler.cs
└── FakeFileService.cs
```

### API

The application uses the following public endpoint:

```text
https://catfact.ninja/fact
```

Example API response:

```json
{
  "fact": "Cats sleep for around 16 hours a day.",
  "length": 38
}
```

The JSON response is deserialized into a `CatFact` object.

### Data storage

Every successfully retrieved fact is appended as a new line to:

```text
Data/fact.txt
```

Example:

```text
Cats sleep for around 16 hours a day. | Length: 38
```

The existing file content is preserved and each new fact is appended to the end of the file.

### Error handling

The application handles several types of exceptions:

- `HttpRequestException` – API communication errors
- `JsonException` – invalid JSON responses
- `IOException` – file writing errors
- `Exception` – unexpected errors

Technical error details are logged using `ILogger`, while the user receives a clear error message in the application interface.

### User interface

The user interface was built using Razor Pages, HTML, CSS, and Bootstrap.

The user can retrieve a new fact using the **Pobierz nowy fakt** button. After a successful request, the application displays the retrieved fact and its length.

In case of an error, the application displays a clear user-friendly message instead of technical exception details.

Custom styles are used for the main application card, button, result area, and error messages. Responsive styles are also included for smaller screens.

### Unit tests

The solution contains a separate `CatFactApp.Tests` project using xUnit.

The tests verify:

- correct data storage in the `CatFact` model
- API response deserialization
- passing correctly formatted data to the file service
- application behavior when the API returns an unsuccessful HTTP status

The tests use:

- `FakeHttpMessageHandler` – simulates HTTP responses without sending real requests to the external API
- `FakeFileService` – implements `IFileService` and stores the received text in memory instead of writing to the file system

This keeps the tests independent of the internet connection and file system and allows `CatFactService` to be tested under controlled conditions.

### Running the application

1. Clone the repository.
2. Open `CatFactApp.sln` in Visual Studio.
3. Make sure the .NET 8 SDK is installed.
4. Set `CatFactApp` as the startup project.
5. Run the application.
6. Click **Pobierz nowy fakt** to retrieve a cat fact.

### Running tests

Tests can be executed using Visual Studio:

```text
Test → Test Explorer → Run All
```

or using the .NET CLI:

```bash
dotnet test
```

---
