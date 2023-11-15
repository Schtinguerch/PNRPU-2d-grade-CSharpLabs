using static System.Console;

namespace UKit.Console
{
    public static class UConsole
    {
        public static void SetCursorOnTop()  =>
            SetWindowPosition(0, WindowTop - (WindowTop - CursorTop));

        public static void ScrollUp() => 
            SetCursorPosition(0, 0);

        public static int ReadInt(string message = "")
        {
            if (message != null)
                Write(message);

            int value;

            while (!int.TryParse(ReadLine(), out value))
                Write("Ошибка, выражение не является целым числом.\n" +
                    "Необходимо повторить ввод\n >> ");

            return value;
        }

        public static int ReadInt(string message, int minValue, int maxValue)
        {
            if (message != null)
                Write(message);

            int value = -1;
            var isSuit = false;

            while (!isSuit)
            {
                var isValid = int.TryParse(ReadLine(), out value);
                var isInRange = value >= minValue && value <= maxValue;

                isSuit = isValid && isInRange;

                if (!isValid)
                    Write("Ошибка, выражение не является целым числом.\n" +
                        "Необходимо повторить ввод\n >> ");
            
                if (!isSuit)
                    Write($"Ошибка, число не входит в интервал [{minValue}; {maxValue}].\n" +
                        "Необходимо повторить ввод\n >> ");
            }

            return value;
        }

        public static int ReadInt(string message, InputCondition<int> condition)
        {
            if (message != null)
                Write(message);

            int value = -1;
            var isSuit = false;

            while (!isSuit)
            {
                var isValid = int.TryParse(ReadLine(), out value);
                var isInRange = condition.IsSuit(value);

                isSuit = isValid && isInRange;

                if (!isValid)
                    Write("Ошибка, выражение не является целым числом.\n" +
                        "Необходимо повторить ввод\n >> ");

                if (!isSuit)
                    Write($"Ошибка, число не соответствует условию: \"{condition.CommentMessage}\".\n" +
                        "Необходимо повторить ввод\n >> ");
            }

            return value;
        }


        public static double ReadDouble(string message = "")
        {
            if (message != null)
                Write(message);

            double value;

            while (!double.TryParse(ReadLine(), out value))
                Write("Ошибка, выражение не является целым числом.\n" +
                    "Необходимо повторить ввод\n >> ");

            return value;
        }

        public static double ReadDouble(string message, double minValue, double maxValue)
        {
            if (message != null)
                Write(message);

            double value = -1d;
            var isSuit = false;

            while (!isSuit)
            {
                var isValid = double.TryParse(ReadLine(), out value);
                var isInRange = value >= minValue && value <= maxValue;

                isSuit = isValid && isInRange;

                if (!isValid)
                    Write("Ошибка, выражение не является целым числом.\n" +
                        "Необходимо повторить ввод\n >> ");

                if (!isSuit)
                    Write($"Ошибка, число не входит в интервал [{minValue}; {maxValue}].\n" +
                        "Необходимо повторить ввод\n >> ");
            }

            return value;
        }


        public static bool ReadBool(string message = "", string trueAnswer = "t", string falseAnswer = "f")
        {
            if (message != null)
                Write(message);

            trueAnswer = trueAnswer.ToLower();
            falseAnswer = falseAnswer.ToLower();

            var value = false;

            while (true)
            {
                var input = ReadLine().Trim().ToLower();

                if (bool.TryParse(input, out value))
                    return value;

                if (input == trueAnswer)
                    return true;

                if (input == falseAnswer)
                    return false;

                Write("Ошибка, выражение не является логическим значением.\n" +
                        "Необходимо повторить ввод\n >> ");
            }
        }
    }
}
