for /D %%p in (*API) DO @timeout /t 1 > nul & start "%%p" /D %%p cmd /K dotnet run