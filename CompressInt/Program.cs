using System;
using System.Diagnostics;

namespace InterviewTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            var num = long.MaxValue;

            Console.WriteLine($"Исходное число: {num}");

            var timer = Stopwatch.StartNew();

            Console.WriteLine($"Метод деления. Ответ: {CompressDivide(num)}. Заняло: {timer.Elapsed}");

            timer = Stopwatch.StartNew();

            Console.WriteLine($"Метод преобразования в строку. Ответ: {CompressStringConvert(num)}. Заняло: {timer.Elapsed}");
        }

        static long CompressDivide(long num)
        {
            Func<long, long> _compress = (long _num) =>
            {
                long reminder = 0, sum = 0;
                do
                {
                    reminder = _num % 10;
                    sum += reminder;
                    _num = _num / 10;
                }
                while (reminder != 0);
                return sum;
            };

            do
            {
                num = _compress(num);
            }
            while (num > 9);

            return num;
        }

        static long CompressStringConvert(long num)
        {
            Func<long, long> _compress = (long _num) =>
            {
                long sum = 0;

                foreach (var _char in num.ToString())
                {
                    sum += Convert.ToInt32(_char.ToString());
                };

                return sum;
            };

            do
            {
                num = _compress(num);
            }
            while (num > 9);

            return num;
        }

    }
}
