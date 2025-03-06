using System;

namespace MoneyBurned.Dotnet.Lib.Data;

public class Cost
{
    public decimal WorkDayHours { get; set; } = 8;
    public decimal WorkDaysPerWeek { get; set; } = 5;
    public decimal WorkWeeksPerMonth { get; set; } = 4.35M;
    public decimal ValuePerHour { get; private set; } = 0M;


    public Cost(decimal costPerHour)
    {
        ValuePerHour = costPerHour;
    }

    public Cost(decimal costPer, CostIntervalType intervalType)
    {
        ValuePerHour = ConvertCostToHourFrom(costPer, intervalType);
    }

    public Cost(string costPerInterval)
    {
        string[] costPer = costPerInterval.Split(["/", "per", "pro", "à"], StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        if (costPer != null)
        {
            decimal costValue = Decimal.Parse(costPer[0]);
            if (costPer.Length == 2)
            {
                switch (costPer[1].ToLower())
                {
                    case "m":
                    case "min":
                        ValuePerHour = ConvertCostToHourFrom(costValue, CostIntervalType.Minute);
                        break;
                    case "d":
                    case "day":
                    case "tag":
                        ValuePerHour = ConvertCostToHourFrom(costValue, CostIntervalType.Day);
                        break;
                    case "md":
                    case "pd":
                    case "pt":
                    case "arbeitstag":
                        ValuePerHour = ConvertCostToHourFrom(costValue, CostIntervalType.WorkDay);
                        break;
                    case "w":
                    case "wk":
                    case "week":
                    case "woche":
                        ValuePerHour = ConvertCostToHourFrom(costValue, CostIntervalType.Week);
                        break;
                    case "ww":
                    case "wwk":
                    case "mw":
                    case "pw":
                    case "aw":
                        ValuePerHour = ConvertCostToHourFrom(costValue, CostIntervalType.WorkWeek);
                        break;
                    case "mth":
                    case "month":
                    case "mo":
                    case "mon":
                    case "monat":
                        ValuePerHour = ConvertCostToHourFrom(costValue, CostIntervalType.Month);
                        break;
                    case "wmth":
                    case "workmonth":
                    case "mm":
                    case "pm":
                    case "arbeitsmonat":
                        ValuePerHour = ConvertCostToHourFrom(costValue, CostIntervalType.Month);
                        break;
                    case "y":
                    case "yr":
                    case "year":
                    case "j":
                    case "jahr":
                        ValuePerHour = ConvertCostToHourFrom(costValue, CostIntervalType.Year);
                        break;
                    case "wy":
                    case "my":
                    case "py":
                    case "aj":
                    case "pj":
                        ValuePerHour = ConvertCostToHourFrom(costValue, CostIntervalType.WorkYear);
                        break;
                    case "h":
                    default:
                        ValuePerHour = costValue;
                        break;
                }
            }
            else
            {
                ValuePerHour = costValue;
            }
        }
        else
        {
            ValuePerHour = 0;
        }
    }

    public decimal GetCostPer(CostIntervalType intervalType)
    {
        return intervalType switch
        {
            CostIntervalType.Minute => ValuePerHour / 60,
            CostIntervalType.Day => ValuePerHour * 24,
            CostIntervalType.WorkDay => ValuePerHour * WorkDayHours,
            CostIntervalType.Week => ValuePerHour * (24 * 7),
            CostIntervalType.WorkWeek => ValuePerHour * (WorkDayHours * WorkDaysPerWeek),
            CostIntervalType.Month => ValuePerHour * (24 * 30.5M),
            CostIntervalType.WorkMonth => ValuePerHour * (WorkDayHours * WorkDaysPerWeek * WorkWeeksPerMonth),
            CostIntervalType.Year => ValuePerHour * (24 * 365),
            CostIntervalType.WorkYear => ValuePerHour * (WorkDayHours * WorkDaysPerWeek * WorkWeeksPerMonth * 12),
            _ => ValuePerHour,
        };
    }

    private decimal ConvertCostToHourFrom(decimal cost, CostIntervalType intervalType)
    {
        return intervalType switch
        {
            CostIntervalType.Minute => cost * 60,
            CostIntervalType.Day => cost / 24,
            CostIntervalType.WorkDay => cost / WorkDayHours,
            CostIntervalType.Week => cost / (24 * 7),
            CostIntervalType.WorkWeek => cost / (WorkDayHours * WorkDaysPerWeek),
            CostIntervalType.Month => cost / (24 * 30.5M),
            CostIntervalType.WorkMonth => cost / (WorkDayHours * WorkDaysPerWeek * WorkWeeksPerMonth),
            CostIntervalType.Year => cost / (24 * 365),
            CostIntervalType.WorkYear => cost / (WorkDayHours * WorkDaysPerWeek * WorkWeeksPerMonth * 12),
            _ => cost,
        };
    }
}

public enum CostIntervalType
{
    Minute,
    Hour,
    Day,
    WorkDay,
    Week,
    WorkWeek,
    Month,
    WorkMonth,
    Year,
    WorkYear
}
