

MyDate date1 = new MyDate(25, 11, 2004);

Console.WriteLine($"Исходная дата: {date1}");

date1.AddDays(10);
Console.WriteLine($"Дата через 10 дней: {date1}");

date1.AddDays(-15);
Console.WriteLine($"Дата назад на 15 дней: {date1}");

MyDate date2 = new MyDate(1, 1, 2024);
Console.WriteLine($"Вторая дата: {date2}");

int difference = date1.DiffOfDates(date2);
Console.WriteLine($"Разница в днях между датами: {difference}");

internal class MyDate
{
    private int day;
    private int month;
    private int year;

    public MyDate()
    {
        day = 1;
        month = 1;
        year = 2000;
    }

    public MyDate(int day, int month, int year)
    {
        this.day = day;
        this.month = month;
        this.year = year;
    }
    private int CalculateTotalDays()
    {
        int totalDays = 0;

        for (int i = 1; i < year; i++)
            totalDays += IsLeapYear(i) ? 366 : 365;
        for (int i = 1; i < month; i++)
            totalDays += GetDaysInMonth(i, year);
        totalDays += day;

        return totalDays;
    }

    private bool IsLeapYear(int year) =>
        (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);

    private int GetDaysInMonth(int month, int year)
    {
        switch (month)
        {
            case 1: return 31;
            case 2: return IsLeapYear(year) ? 29 : 28;
            case 3: return 31;
            case 4: return 30;
            case 5: return 31;
            case 6: return 30;
            case 7: return 31;
            case 8: return 31;
            case 9: return 30;
            case 10: return 31;
            case 11: return 30;
            case 12: return 31;
            default: throw new ArgumentException("Некорректный месяц");
        }
    }
    public int DiffOfDates(MyDate date)
    {
        int days1 = CalculateTotalDays();
        int days2 = date.CalculateTotalDays();
        return Math.Abs(days1 - days2);
    }
    public void AddDays(int daysToAdd)
    {
        while (daysToAdd != 0)
        {
            if (daysToAdd > 0)
            {
                int daysInCurrentMonth = GetDaysInMonth(month, year);
                if (day + daysToAdd > daysInCurrentMonth)
                {
                    daysToAdd -= (daysInCurrentMonth - day + 1);
                    day = 1; 
                    month++;
                    if (month > 12)
                    {
                        month = 1; 
                        year++;
                    }
                }
                else
                {
                    day += daysToAdd; 
                    daysToAdd = 0;
                }
            }
            else
            {
                if (day + daysToAdd < 1)
                {
                    month--;
                    if (month < 1)
                    {
                        month = 12; 
                        year--;
                    }
                    day = GetDaysInMonth(month, year); 
                    daysToAdd++; 
                }
                else
                {
                    day += daysToAdd; 
                    daysToAdd = 0;
                }
            }
        }
    }

    public override string ToString()
    {
        return $"{day:00}/{month:00}/{year}";
    }
}

