# hello-dotnet 🚀

Учебное CLI-приложение на C#/.NET 10 с тестами xUnit и автоматической публикацией бинарников в GitHub Releases.

[![.NET CI/CD](https://github.com/Focsi4ek/hello-dotnet/actions/workflows/ci.yml/badge.svg)](https://github.com/Focsi4ek/hello-dotnet/actions/workflows/ci.yml)

## Возможности

- Вывод версии, операционной системы и архитектуры.
- Приветствие и вычисление суммы чисел от 1 до 10.
- Вывод аргументов командной строки.
- Шесть тестовых случаев для функций приветствия и суммы.

## Бинарники

Файлы публикуются в [Releases](https://github.com/Focsi4ek/hello-dotnet/releases).

| Платформа | Файл |
| --- | --- |
| Linux x64 | `hello-dotnet-linux-x64` |
| macOS Apple Silicon | `hello-dotnet-macos-arm64` |
| Windows x64 | `hello-dotnet-windows-x64.exe` |

Каждый бинарник собирается как self-contained single-file: .NET Runtime включён в файл, устанавливать SDK для запуска не требуется.

После скачивания на macOS:

```bash
chmod +x hello-dotnet-macos-arm64
./hello-dotnet-macos-arm64 Привет
```

## Проверки через Docker

Из корня проекта при запущенном Docker:

```bash
docker run --rm \
  -u "$(id -u):$(id -g)" \
  -e DOTNET_CLI_HOME=/tmp \
  -e NUGET_PACKAGES=/tmp/nuget \
  -e DOTNET_CLI_TELEMETRY_OPTOUT=1 \
  -e DOTNET_NOLOGO=1 \
  -v "$PWD":/app \
  -w /app \
  mcr.microsoft.com/dotnet/sdk:10.0 \
  sh -c '
set -e
dotnet restore HelloDotnet.sln
dotnet format HelloDotnet.sln --verify-no-changes --no-restore
dotnet build HelloDotnet.sln --configuration Release --no-restore --warnaserror
dotnet test HelloDotnet.sln --configuration Release --no-build
dotnet run --project src/HelloDotnet --configuration Release --no-build -- Привет
'
```

## CI/CD

Push в `main` и pull request запускают проверку форматирования, сборку и тесты.

Отправка тега `v*` дополнительно запускает:

1. Сборку бинарников для Linux, macOS и Windows.
2. Запись версии из тега в каждый бинарник.
3. Проверку запуска, версии, суммы и аргумента.
4. Публикацию трёх файлов в GitHub Releases.

## Структура

- `src/HelloDotnet/` — приложение.
- `tests/HelloDotnet.Tests/` — тесты xUnit.
- `HelloDotnet.sln` — решение с двумя проектами.
- `global.json` — выбор версии SDK.
- `.github/workflows/ci.yml` — workflow CI/CD.
