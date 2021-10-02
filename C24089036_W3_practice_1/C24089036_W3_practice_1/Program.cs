using System;

namespace C24089036_W3_practice_1
{
    class Program
    {
        static int Main(string[] args)
        {
            int start_week = 0;
            int start_month = 0;

            try
            {
                Console.Write("1月1號星期幾(1~7): ");
                start_week = int.Parse(Console.ReadLine());
                if (start_week < 1 || start_week > 7)
                {
                    Console.WriteLine("超出範圍");
                    Console.ReadKey();
                    return -1;
                }

                Console.Write("從幾月開始(1~12): ");
                start_month = int.Parse(Console.ReadLine());
                if (start_month < 1 || start_month > 12)
                {
                    Console.WriteLine("超出範圍");
                    Console.ReadKey();
                    return -1;
                }
            }
            catch(FormatException)
            {
                Console.WriteLine("請輸入範圍內的整數");
                Console.ReadKey();
                return -1;
            }

            for (int count = start_month; count <= 12; count++)
                DisplayMonth(count, start_week);
            Console.ReadKey();

            return 0;
                 
        }

        private static int CalcWeekDay(int month, int start_week)
        {
            //month_name= {31,28,31,30,31,30,31,31,30,31,30,31}
            int[] end = {0, 3, 0, 3, 2, 3, 2, 3, 3, 2, 3, 2};
            int week_day = start_week;
            for (int i = 0; i < month; i++)
            {
                week_day += end[i];
                if(week_day > 7)
                    week_day -= 7;
            }

            return week_day;
        }

        private static void DisplayMonth(int month, int start_week)
        {
            string[] month_name = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"};
            int[] monthDays = new int[] { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            Console.WriteLine(month_name[month-1]);
            Console.WriteLine("Mon Tue Wed Thu Fri Sat Sun");

            int weekDay = CalcWeekDay(month, start_week);
            int nextLine = 0;
            nextLine = weekDay;
            for (int i = 1; i < weekDay; i++)
                Console.Write("    ");

            for (int i = 1; i <= monthDays[month]; i++)
            {
                Console.Write(value: $"{i,3} ");
                if (nextLine++ % 7 == 0) Console.Write("\n");
            }
            Console.WriteLine("\n");
        }

    }
}
