# CronTimeUtility
Cron Time Utility written in F# targeting .NET Core 2.0

In F#:

```fsharp
let utility = Cron.New
```

In C#:
```csharp
var let utility = Cron.New()
```

Then:

```csharp
utility.Minutely()
utility.Minutely(...)
... And more
...
