namespace _11._05
{
    class Employee
    {
        public string PIB { get; set; }
        public string Position { get; set; }
        public double Salary { get; set; }
        public string Email { get; set; }
    }
    internal class Task1
    {
        static List<Employee> employees = new List<Employee>();

        

        public static void task1()
        {
            while (true)
            {
                Console.WriteLine("Виберіть опцію:");
                Console.WriteLine("1 - Додати співробітника");
                Console.WriteLine("2 - Видалити співробітника");
                Console.WriteLine("3 - Змінити інформацію про співробітника");
                Console.WriteLine("4 - Пошук співробітників");
                Console.WriteLine("5 - Сортування співробітників");
                Console.WriteLine("6 - Вихід");

                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        AddEmployee();
                        break;
                    case 2:
                        RemoveEmployee();
                        break;
                    case 3:
                        UpdateEmployee();
                        break;
                    case 4:
                        SearchEmployee();
                        break;
                    case 5:
                        SortEmployees();
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Неправильна опція. Спробуйте ще раз.");
                        break;
                }
                Print(); Console.WriteLine();
            }
        }

        static void Print()
        {
            foreach (var emp in employees)
            {
                Console.WriteLine($"Name: {emp.PIB}\tPosition: {emp.Position}\tSalary: {emp.Salary}\tEmail: {emp.Email}");
            }
        }

        static void AddEmployee()
        {
            Console.WriteLine("Додавання співробітника");
            Console.Write("Введіть П.І.Б.: ");
            string pib = Console.ReadLine();
            Console.Write("Введіть посаду: ");
            string position = Console.ReadLine();
            Console.Write("Введіть зарплату: ");
            double salary = double.Parse(Console.ReadLine());
            Console.Write("Введіть корпоративний email: ");
            string email = Console.ReadLine();

            Employee employee = new Employee
            {
                PIB = pib,
                Position = position,
                Salary = salary,
                Email = email
            };

            employees.Add(employee);

            Console.WriteLine("Співробітник успішно доданий.");
        }

        static void RemoveEmployee()
        {
            Console.WriteLine("Видалення співробітника");
            Console.Write("Введіть П.І.Б. співробітника: ");
            string pib = Console.ReadLine();

            Employee employee = employees.FirstOrDefault(e => e.PIB == pib);

            if (employee != null)
            {
                employees.Remove(employee);
                Console.WriteLine("співробітник успішно видалений.");
            }
            else
            {
                Console.WriteLine("Співробітника не знайдено.");
            }
        }

        static void UpdateEmployee()
        {
            Console.WriteLine("Редагування співробітника");
            Console.Write("Введіть П.І.Б. співробітника: ");
            string pib = Console.ReadLine();

            Employee employee = employees.FirstOrDefault(e => e.PIB == pib);

            if (employee != null)
            {
                Console.Write("Введіть нову посаду (або натисніть Enter, щоб пропустити): ");
                string position = Console.ReadLine();

                if (!string.IsNullOrEmpty(position))
                {
                    employee.Position = position;
                }

                Console.Write("Введіть нову зарплату (або натисніть Enter, щоб пропустити): ");
                string salaryString = Console.ReadLine();

                if (!string.IsNullOrEmpty(salaryString))
                {
                    double salary = double.Parse(salaryString);
                    employee.Salary = salary;
                }

                Console.Write("Введіть новий email (або натисніть Enter, щоб пропустити): ");
                string email = Console.ReadLine();

                if (!string.IsNullOrEmpty(email))
                {
                    employee.Email = email;
                }

                Console.WriteLine("Інформація про співробітника успішно оновлена.");
            }
            else
            {
                Console.WriteLine("Співробітника не знайдено.");
            }
        }

        static void SearchEmployee()
        {
            Console.WriteLine("Пошук співробітників");

            Console.WriteLine("Введіть параметри пошуку:");

            Console.Write("П.І.Б. (або частину П.І.Б.): ");
            string pib = Console.ReadLine();

            Console.Write("Посада: ");
            string position = Console.ReadLine();

            Console.Write("Зарплата від (або натисніть Enter, щоб пропустити): ");
            string minSalaryString = Console.ReadLine();

            Console.Write("Зарплата до (або натисніть Enter, щоб пропустити): ");
            string maxSalaryString = Console.ReadLine();

            double? minSalary = null;
            double? maxSalary = null;

            if (!string.IsNullOrEmpty(minSalaryString))
            {
                minSalary = double.Parse(minSalaryString);
            }

            if (!string.IsNullOrEmpty(maxSalaryString))
            {
                maxSalary = double.Parse(maxSalaryString);
            }

            var searchResults = employees.Where(e =>
                (string.IsNullOrEmpty(pib) || e.PIB.Contains(pib)) &&
                (string.IsNullOrEmpty(position) || e.Position == position) &&
                (minSalary == null || e.Salary >= minSalary) &&
                (maxSalary == null || e.Salary <= maxSalary)
            );

            Console.WriteLine("Результати пошуку:");

            foreach (var result in searchResults)
            {
                Console.WriteLine($"{result.PIB} - {result.Position} - {result.Salary} - {result.Email}");
            }
        }

        static void SortEmployees()
        {
            Console.WriteLine("Сортування співробітників");
            Console.WriteLine("Виберіть параметр для сортування:");

            Console.WriteLine("1. П.І.Б.");
            Console.WriteLine("2. Посада");
            Console.WriteLine("3. Зарплата");

            Console.Write("Введіть номер параметра: ");
            int sortParam = int.Parse(Console.ReadLine());

            switch (sortParam)
            {
                case 1:
                    employees.Sort((e1, e2) => e1.PIB.CompareTo(e2.PIB));
                    break;
                case 2:
                    employees.Sort((e1, e2) => e1.Position.CompareTo(e2.Position));
                    break;
                case 3:
                    employees.Sort((e1, e2) => e1.Salary.CompareTo(e2.Salary));
                    break;
                default:
                    Console.WriteLine("Некоректний вибір параметра.");
                    return;
            }

            Console.WriteLine("Список співробітників, відсортований за вибраним параметром:");

            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.PIB} - {employee.Position} - {employee.Salary} - {employee.Email}");
            }
        }

    }

}

