# Routine Helper (Windows + Android)

A .NET MAUI routine app that lets you create routines and schedules a local notification **10 minutes before** each routine time.

## Features
- Add routines with title + time.
- Daily reminder scheduled 10 minutes before routine time.
- Works on Android and Windows from a single MAUI codebase.

## Run
1. Install .NET 8 SDK + MAUI workload.
2. Restore packages:
   ```bash
   dotnet restore
   ```
3. Run on Windows:
   ```bash
   dotnet build -f net8.0-windows10.0.19041.0
   ```
4. Run on Android (connected emulator/device):
   ```bash
   dotnet build -f net8.0-android
   ```

## How reminder timing works
When a routine is saved, the app computes `routine_time - 10 minutes`. If that time has already passed for today, it schedules for tomorrow, then repeats daily.
