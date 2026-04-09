using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PRG_182_MILESTONE
{

    internal abstract class Program
    {



        private enum Options
        {
            Capture = 1,
            Check,
            Stats,
            Exit
        }

        // Dictionary to capture the data
        private static Dictionary<string, string> collectData()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            string employmentStatus;


            // These variables will be stored into the dictionary
            string QAge;
            string QHighScoreRank;
            string QNumberOfPizzas;
            string QBowlingHighScore;
            string QNumberOfSlushies;

            // Capture the data
            Console.Write("What's your name: ");
            string name = Console.ReadLine();
            Console.Write("How old are you: ");
            int age = Convert.ToInt32(Console.ReadLine());
            while (age < 5)
            {
                Console.Write("You seem to have entered an invalid age. Please enter your age (It should above 5 years old): ");
                age = Convert.ToInt32(Console.ReadLine());
            }
            Console.Write("What is your high score rank: ");
            int highScoreRank = Convert.ToInt32(Console.ReadLine());
            Console.Write("When did you start being a loyal customer (YYYY-MM-DD): ");
            string startDate = Console.ReadLine();
            Console.Write("How many pizzas have you eaten since you've started being a customer: ");
            int numberOfPizzas = Convert.ToInt32(Console.ReadLine());
            Console.Write("What is your bowling high score: ");
            int bowlingHighScore = Convert.ToInt32(Console.ReadLine());
            if (age >= 18)
            {
                Console.Write("Are you employed (Y/N): ");
                employmentStatus = Console.ReadLine();

                while (employmentStatus.ToUpper() != "Y" || employmentStatus.ToUpper() != "N")
                {
                    if (employmentStatus.ToUpper() == "Y" || employmentStatus.ToUpper() == "N") break;
                    Console.Write("Are you employed (Y/N): ");
                    employmentStatus = Console.ReadLine();
                }

            }
            else
            {
                Console.Write("Are your parents/guardians employed (Y/N): ");
                employmentStatus = Console.ReadLine();
                while (employmentStatus.ToUpper() != "Y" || employmentStatus.ToUpper() != "N")
                {
                    if (employmentStatus.ToUpper() == "Y" || employmentStatus.ToUpper() == "N") break;
                    Console.Write("Are your parents/guardians employed (Y/N): ");
                    employmentStatus = Console.ReadLine();
                }
            }
            Console.Write("What is your slush-puppy flavour preference: ");
            string slushy = Console.ReadLine();
            Console.Write("How many slushies have you drank since you've started being a customer: ");
            int numberOfSlushies = Convert.ToInt32(Console.ReadLine());



            QAge = Convert.ToString(age);
            QHighScoreRank = Convert.ToString(highScoreRank);
            QNumberOfPizzas = Convert.ToString(numberOfPizzas);
            QBowlingHighScore = Convert.ToString(bowlingHighScore);
            QNumberOfSlushies = Convert.ToString(numberOfSlushies);

            // Store the data in the dictionary
            data["Name"] = name.ToLower();
            data["Age"] = QAge.ToLower();
            data["Date Started"] = startDate;
            data["High Score Rank"] = QHighScoreRank.ToLower();
            data["Number of Pizzas"] = QNumberOfPizzas.ToLower();
            data["Bowling High Score"] = QBowlingHighScore.ToLower();
            data["Employment Status"] = employmentStatus.ToLower();
            data["Slushy"] = slushy.ToLower();
            data["Number of Slushies"] = QNumberOfSlushies.ToLower();

            return data;
        }

        // Check the qualification
        private static bool CheckQualifications(Dictionary<string, string> data)
        {
            bool qualifies = false;


            if (
                data["Employment Status"] == "y" &&
                (Convert.ToInt32(data["Date Started"].Substring(0, 4)) - 2024 >= 2) &&
                (Convert.ToInt32(data["High Score Rank"]) > 2000 || Convert.ToInt32(data["Bowling High SCore"]) > 1500 || (Convert.ToInt32(data["High Score Rank"]) + Convert.ToInt32(data["Bowling High Score"]) / 2 > 1200)) &&
                Convert.ToInt32(data["Number of Pizzas"]) / 12 >= 3
                ) { qualifies = true; }


            if (
                Convert.ToInt32(data["Number of Slushies"]) / 12 < 4 ||
                data["Slushy"] == "gooey gulp galore"
                ) { qualifies = false; }


            return qualifies;
        }

        public static void Main()
        {

            List<string> qualified = new List<string>();


            List<string> notQualified = new List<string>();

            Dictionary<string, int> Ranks = new Dictionary<string, int>();
            Dictionary<string, int> Bowling = new Dictionary<string, int>();




            Console.WriteLine(@"Welcome to RetroSlice");

            Options choice = Options.Capture;

            while (choice != Options.Exit)
            {
                ;
                foreach (var option in Enum.GetValues(typeof(Options)))
                {
                    Console.WriteLine($"{(int)option}. {option}");
                }
                Console.Write("Choose an option: ");
                int selectedOption;
                while (!int.TryParse(Console.ReadLine(), out selectedOption) || !Enum.IsDefined(typeof(Options), selectedOption))
                {
                    Console.Write("Invalid choice. Please choose a correct choice: ");
                }
                choice = (Options)selectedOption;

                // Use the enum to display the options
                switch (choice)
                {
                    case Options.Capture:

                        Dictionary<string, string> data = collectData();
                        bool qualifies = CheckQualifications(data);



                        if (qualifies) qualified.Add(data["Name"]);
                        else notQualified.Add(data["Name"]);


                        Ranks[data["Name"]] = Convert.ToInt32(data["High Score Rank"]);
                        Bowling[data["Name"]] = Convert.ToInt32(data["Bowling High Score"]);
                        break;
                    case Options.Check:


                        Console.WriteLine("Qualified:");
                        foreach (var name in qualified) Console.WriteLine(name);
                        Console.WriteLine("Not Qualified:");
                        foreach (var name in notQualified) Console.WriteLine(name);

                        break;
                    case Options.Stats:

                        Console.WriteLine("Bowling stats:");
                        foreach (var stat in Bowling) Console.WriteLine($"{stat.Key}: {stat.Value}");
                        Console.WriteLine("High Score Rank:");
                        foreach (var stat in Ranks) Console.WriteLine($"{stat.Key}: {stat.Value}");
                        break;
                    case Options.Exit:
                        Console.WriteLine(" Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please choose a correction option.");
                        break;
                }
            }
        }
    }
}