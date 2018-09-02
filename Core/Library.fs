namespace Core

module CronUtility =
    open System.Drawing

    type Day =
        | Sunday = 0
        | Monday = 1
        | Tuesday = 2
        | Wednesday = 3
        | Thursday = 4
        | Friday = 5
        | Saturday = 6
    
    type Cron() =
        static member New = new Cron()
        
        // Returns cron expression that fires every minute.
        member this.Minutely() = "* * * * *"
        
        // Returns cron expression that fires every hour at the specified minute.
        member this.Hourly(minute) = sprintf "%d * * * *" minute
        // Returns cron expression that fires every hour at the first minute.
        member this.Hourly() = this.Hourly(0)
        
        // Returns cron expression that fires every day at the specified hour and minute in UTC.
        member this.Daily(hour, minute) = sprintf "%d %d * * *" minute hour
        // Returns cron expression that fires every day at the first minute of the specified hour in UTC.
        member this.Daily(hour) = this.Daily(hour, 0)
        // Returns cron expression that fires every day at 00:00 UTC.
        member this.Daily() = this.Daily(0)
        
        // Returns cron expression that fires every week at the specified day of week, hour and minute in UTC.
        member this.Weekly(day: Day, hour, minute) = sprintf "%d %d * * %d" minute hour (int day)
        //  Returns cron expression that fires every week at the first minute of the specified day of week and hour in UTC.
        member this.Weekly(day: Day, hour) = this.Weekly(day, hour, 0)
        // Returns cron expression that fires every week at 00:00 UTC of the specified day of the week.
        member this.Weekly(day) = this.Weekly(day, 0)
        // Returns cron expression that fires every week at Monday, 00:00 UTC.
        member this.Weekly() = this.Weekly(Day.Monday)
        
        // Returns cron expression that fires every month at the specified day of month, hour and minute in UTC.
        member this.Monthly(day, hour, minute) = sprintf "%d %d %d * *" minute hour day
        // Returns cron expression that fires every month at the first minute of the specified day of month and hour in UTC.
        member this.Monthly(day, hour) = this.Monthly(day, hour, 0)
        // Returns cron expression that fires every month at 00:00 UTC of the specified day of month.
        member this.Monthly(day) = this.Monthly(day, 0)
        // Returns cron expression that fires every month at 00:00 UTC of the first day of month.
        member this.Monthly() = this.Monthly(1)
        
        // Returns cron expression that fires every year at the specified month, day, hour and minute in UTC.
        member this.Yearly(month, day, hour, minute) = sprintf "%d %d %d %d *" minute hour day month
        // Returns cron expression that fires every year at the first minute of the specified month, day and hour in UTC.
        member this.Yearly(month, day, hour) = this.Yearly(month, day, hour, 0)
        // Returns cron expression that fires every year at 00:00 UTC of the specified month and day of month.
        member this.Yearly(month, day) = this.Yearly(month, day, 0)
        // Returns cron expression that fires every year in the first day at 00:00 UTC of the specified month.
        member this.Yearly(month) = this.Yearly(month, 1)
        // Returns cron expression that fires every year on Jan, 1st at 00:00 UTC.
        member this.Yearly() = this.Yearly(1)
        
        // Returns cron expression that fires every &lt;<paramref name="interval"></paramref>&gt; minutes.
        member this.MinuteInterval(interval) = sprintf "*/%d * * * *" interval
        // Returns cron expression that fires every &lt;<paramref name="interval"></paramref>&gt; hours.
        member this.HourInterval(interval) = sprintf "0 */%d * * *" interval
        // Returns cron expression that fires every &lt;<paramref name="interval"></paramref>&gt; days.
        member this.DayInterval(interval) = sprintf "0 0 */%d * *" interval
        // Returns cron expression that fires every &lt;<paramref name="interval"></paramref>&gt; months.
        member this.MonthInterval(interval) = sprintf "0 0 1 */%d *" interval