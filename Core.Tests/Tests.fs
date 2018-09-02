module Tests

open System
open Xunit

module CronTest =
    open Core.CronUtility
    
    let utility = Cron.New
 
    [<Fact>]
    let ``Minutely Returns Formatted String`` () =
        Assert.Equal("* * * * *", utility.Minutely())

    [<Fact>]
    let ``Hourly Without Minute Returns Formatted String With Defaults`` () =
        Assert.Equal("0 * * * *", utility.Hourly())

    [<Fact>]
    let ``Hourly With Minute Returns Formatted String With Minute`` () =
        Assert.Equal("5 * * * *", utility.Hourly(5))

    [<Fact>]
    let ``Daily Without Minute Or Hour Returns Formatted String With Defaults`` () =
        Assert.Equal("0 0 * * *", utility.Daily())
        
    [<Fact>]
    let ``Daily Without Minute Returns Formatted String With Hour And Zero Minute`` () =
        Assert.Equal("0 5 * * *", utility.Daily(5))
        
    [<Fact>]
    let ``Daily With Minute And Hour Returns Formatted String With Hour And Minute`` () =
        Assert.Equal("5 5 * * *", utility.Daily(5, 5))
                
    [<Fact>]
    let ``Weekly Without Day Hour Minute Returns Formatted String With Defaults`` () =
        Assert.Equal("0 0 * * 1", utility.Weekly())
        
    [<Fact>]
    let ``Weekly With Day Without Hour Minute Returns Formatted String With Day`` () =
        Assert.Equal("0 0 * * 4", utility.Weekly(Day.Thursday))
        
    [<Fact>]
    let ``Weekly With Day Hour Without Minute Returns Formatted String With Day Hour`` () =
        Assert.Equal("0 5 * * 4", utility.Weekly(Day.Thursday, 5))
        
    [<Fact>]
    let ``Weekly With Day Hour Minute Returns Formatted String With Day Hour Minute`` () =
        Assert.Equal("5 5 * * 4", utility.Weekly(Day.Thursday, 5, 5))

    [<Fact>]
    let ``Monthly Without Day Hour Minute Returns Formatted String With Defaults`` () =
        Assert.Equal("0 0 1 * *", utility.Monthly())
        
    [<Fact>]
    let ``Monthly Without Hour Minute With Day Returns Formatted String With Day`` () =
        Assert.Equal("0 0 6 * *", utility.Monthly(6))
        
    [<Fact>]
    let ``Monthly Without Minute With Day Hour Returns Formatted String With Day Hour`` () =
        Assert.Equal("0 4 7 * *", utility.Monthly(7, 4))
        
    [<Fact>]
    let ``Monthly With Day Hour Minute Returns Formatted String With Day Hour Minute`` () =
        Assert.Equal("23 4 7 * *", utility.Monthly(7, 4, 23))

    [<Fact>]
    let ``Yearly Without Month Day Hour Minute Returns Formatted String With Defaults`` () =
        Assert.Equal("0 0 1 1 *", utility.Yearly())
        
    [<Fact>]
    let ``Yearly Without Day Hour Minute With Month Returns Formatted String With Month`` () =
        Assert.Equal("0 0 1 7 *", utility.Yearly(7))
        
    [<Fact>]
    let ``Yearly Without Hour Minute With Month Day Returns Formatted String With Month Day`` () =
        Assert.Equal("0 0 18 8 *", utility.Yearly(8, 18))
        
    [<Fact>]
    let ``Yearly Without Minute With Month Day Hour Returns Formatted String With Month Day Hour`` () =
        Assert.Equal("0 14 18 3 *", utility.Yearly(3, 18, 14))

    [<Fact>]
    let ``Yearly With Month Day Hour Minute Returns Formatted String With Month Day Hour Minute`` () =
        Assert.Equal("45 3 17 4 *", utility.Yearly(4, 17, 3, 45))