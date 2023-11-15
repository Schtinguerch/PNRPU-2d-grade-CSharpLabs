using System;

using static System.Console;

namespace UKit.Console
{
    public delegate void Action();

    public class ConsoleMenu
    {
        public Pair<Action, string>[] Actions { get; set; }

        public static string Message { get; set; }

        public int CloseCode { get; set; }

        public int AppExitCode { get; set; }

        public static void WaitForKey(ConsoleKey key)
        {
            WriteLine();
            do
            {
                WriteLine($"Нажмите {key}, чтобы продолжить");
            }
            while (ReadKey(true).Key != key);
        }


        public ConsoleMenu(Pair<Action, string>[] actions, int closeCode = 0, int appExitCode = -1)
        {
            if (actions == null)
                throw new ArgumentNullException("Меню без действий - не меню вовсе");

            if (closeCode > 0 && closeCode < actions.Length)
                throw new ArgumentException("Код \"Назад\" совпадает с кодом одного из действий");

            if (appExitCode > 0 && appExitCode < actions.Length)
                throw new ArgumentException("Код \"Выход из приложения\" совпадает с кодом одного из действий");

            Actions = new Pair<Action, string>[actions.Length];
            Array.Copy(actions, Actions, actions.Length);

            CloseCode = closeCode;
            AppExitCode = appExitCode;
        }

        public void ShowMenu()
        {
            int action = -1;
            do
            {
                action = ClearAndChooseAction();
                InvokeAction(action);

                if (action == AppExitCode)
                    Environment.Exit(0);
            }
            while (action != CloseCode);
        }

        private int ClearAndChooseAction()
        {
            UConsole.SetCursorOnTop();

            if (!string.IsNullOrWhiteSpace(Message))
            {
                WriteLine(Message);
                var underLine = "";

                for (int i = 0; i < Message.Length; i++)
                {
                    if (Message[i] == '\n') break;
                    underLine += "=";
                }
                    

                WriteLine(underLine + '\n');
                Message = "";
            }

            for (int i = 0; i < Actions.Length; i++)
                WriteLine($"{i + 1}. {Actions[i].Second}");

            WriteLine($"\n{AppExitCode}. Выход из приложения");

            if (AppExitCode != CloseCode)
                WriteLine($"{CloseCode}. Назад");

            return UConsole.ReadInt("\nВыберите действие: ");
        }

        private void InvokeAction(int actionIndex)
        {
            if (actionIndex < 1 || actionIndex > Actions.Length)
            {
                if (actionIndex != CloseCode && actionIndex != AppExitCode)
                {
                    WriteLine($"Ошибка: действие с номером {actionIndex} отсутствует." +
                        "\nНажмите любую клавишу, чтобы продолжить...");

                    ReadKey();
                }

                return;
            }

            Actions[--actionIndex].First();
        }
    }
}
