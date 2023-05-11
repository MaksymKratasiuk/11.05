namespace _11._05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int ch = 0;
            do
            {
                Console.WriteLine("enter task->");
                ch = int.Parse(Console.ReadLine());
                switch (ch)
                {
                    case 1: Task1.task1(); break;
                    case 2:
                        Task2.task2();
                        break;
                }
            } while (ch != 0);
        }

    }
}