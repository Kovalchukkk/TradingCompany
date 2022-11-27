using AutoMapper;
using DAL.Services;
using DTO;
using System;

namespace TradingCompany
{
    class Menu
    {
        static IMapper Mapper = SetupMapper();

        private static IMapper SetupMapper()
        {
            MapperConfiguration config = new MapperConfiguration(
                cfg => cfg.AddMaps(typeof(CategoryDal).Assembly));
            return config.CreateMapper();
        }

        public void ShowMenu()
		{
			string input;
			string password;
			do
			{
				Console.WriteLine("Enter a password: ");
				password = Console.ReadLine();

			} while (password != "root");

			do
			{
				ShowMainMenu();

				input = Console.ReadLine();

				Selection(input);

			} while (input != "0");

		}


		void ShowMainMenu()
		{
			string menu = @"
TradingCompany

Choose an operation:
1 - To register account;
2 - To view all accounts;
3 - To delete a visitor by index;
4 - To register a trainer;
5 - To view registered trainers
6 - To delete a trainer by index;
C - To create a category of goods;
A - To view all categories of goods;
P - To view the most popular trainer;
0 - Exit;
";
			Console.WriteLine(menu);
		}

		void Selection(string input)
		{
			switch (input)
			{
                case "1":
                    MenuAccountAdd();
                    break;
                case "2":
                    MenuGetAllAccounts();
                    break;
                //case "3":
                //	Menu_Visitor_Delete();
                //	break;
                //case "4":
                //	Menu_Trainer_Add();
                //	break;
                //case "5":
                //	TrainerRepository.Show();
                //	break;
                //case "6":
                //	Menu_Trainer_Delete();
                //	break;
                case "C":
                    MenuCategoryAdd();
                    break;
                case "A":
                    MenuGetAllCategories();
                    break;
                //case "P":
                //	try
                //	{
                //		VisitorRepository.Show();
                //		Console.WriteLine(helper.ShowTheMostPopularTrainer());
                //	}

                //	catch (FormatException)
                //	{
                //		logger.Exception("The list of trainers is empty!");
                //		Console.WriteLine("The list of trainers is empty!");
                //	}
                //	break;
                default:
					break;
			}
		}

        void MenuAccountAdd()
        {
            Console.WriteLine("Enter first name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter last name: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter email: ");
            string email = Console.ReadLine();
            //Console.WriteLine("Enter password: ");
            //string password = Console.ReadLine();
            //int salt = 5;
            string role = "Receptionist";
            var dal = new AccountDal(Mapper);
            var account = new AccountDTO
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = "",
                Salt = 0,
                Role = role
            };
            account = dal.CreateAccount(account);
            Console.WriteLine($"New account ID: {account.AccountId}");
        }

        void MenuGetAllAccounts()
        {
            var dal = new AccountDal(Mapper);
            var accounts = dal.GetAllAccounts();

            Console.WriteLine($"Account ID\tEmail");
            foreach (var account in accounts)
            {
                Console.WriteLine($"{account.AccountId}\t{account.Email}");
            }
        }

        void MenuCategoryAdd()
        {
            Console.WriteLine("Enter name of category: ");
            string name = Console.ReadLine();
            var dal = new CategoryDal(Mapper);
            var category = new CategoryDTO
            {
                Name = name
            };
            category = dal.CreateCategory(category);
            Console.WriteLine($"New category ID: {category.CategoryId}");
        }

        void MenuGetAllCategories()
        {
            var dal = new CategoryDal(Mapper);
            var categories = dal.GetAllСategories();

            Console.WriteLine($"Category ID\tName");
            foreach (var category in categories)
            {
                Console.WriteLine($"{category.CategoryId}\t{category.Name}");
            }
        }

    }
}
