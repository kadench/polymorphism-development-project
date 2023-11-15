using System;
using System.ComponentModel.Design;
using System.Xml.Schema;

class Program {

        static void StartingMessage() {
                Console.WriteLine("Welcome to your Goal Tracker!");
                Console.WriteLine("----------------------------------");
                Console.WriteLine("This program allows you to create goals and track your progress on them.");
                Console.WriteLine("There are three types of goals available:");
                Console.WriteLine("----------------------------------");
                Console.WriteLine("Simple Goals, which are one and done goals.");
                Console.WriteLine("Checklist Goals, which allow you to set a number of times you would like to complete the goal.");
                Console.WriteLine("Eternal Goals, which are goals you will work on forever, we will count how many times you do it.");
                Console.WriteLine("----------------------------------");
        }
        static void EndingMessage() {
                Console.WriteLine("We hope you enjoyed using the Goal tracker, keep up the good work! See you soon!");
        }
        static void Menu() {
  
                Console.WriteLine();
                Console.WriteLine("             Actions:            ");
                Console.WriteLine("----------------------------------");
                Console.WriteLine("Enter 1 to Create a New Goal");
                Console.WriteLine("Enter 2 to List Your Goals");
                Console.WriteLine("Enter 3 to Save Your Goals");
                Console.WriteLine("Enter 4 to Load Your Goals");
                Console.WriteLine("Enter 5 to Record a New Event");
                Console.WriteLine("Enter 0 to Exit");
                Console.WriteLine("----------------------------------");
        }
        static int GetUserChoice() {
            Console.Write("Enter your choice: ");
            string SpInitialInput = Console.ReadLine();
            if (SpInitialInput == "1")
            {
                int SpChoice = int.Parse(SpInitialInput);
                return SpChoice;
            } else if (SpInitialInput == "2")
            {
                int SpChoice = int.Parse(SpInitialInput);
                return SpChoice;
            }else if (SpInitialInput == "3")
            {
                int SpChoice = int.Parse(SpInitialInput);
                return SpChoice;
            }else if (SpInitialInput == "4")
            {
                int SpChoice = int.Parse(SpInitialInput);
                return SpChoice;
            }else if (SpInitialInput == "5")
            {
                int SpChoice = int.Parse(SpInitialInput);
                return SpChoice;
            }else
            {
                Console.WriteLine("Invalid Input, Please enter: 0, 1, 2, 3, 4, or 5");
                Console.Write("Enter your choice: ");
                int SpChoice = int.Parse(Console.ReadLine());
                return SpChoice;
            }
        }
        public static void SaveGoals(List<string> newGoals) 
        {
                // Get the user's desktop path
                string SpDesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                // Combine the desktop path with the file name
                string SpFilePath = Path.Combine(SpDesktopPath, "GoalsFromGoalTracker.txt");

                // Check if the file exists
                if (File.Exists(SpFilePath))
                {
                // Read existing goals from the file
                List<string> SpExistingGoals = File.ReadAllLines(SpFilePath).ToList();

                // get method of goalLIst
                var spGoalList = new GoalSheet(newGoals);
                spGoalList.GetGoalList();

                // Add new goals without duplicates
                foreach (string goal in newGoals)
                {
                        if (!SpExistingGoals.Contains(goal))
                        {
                        SpExistingGoals.Add(goal);
                        }
                }

                // Write the updated goals back to the file
                File.WriteAllLines(SpFilePath, SpExistingGoals);
                }
                else
                {
                // Create a new file and write the goals to it
                File.WriteAllLines(SpFilePath, newGoals);
                }

                Console.WriteLine("Goals saved to file.");
        }
        static void LoadGoals(fileName)
        {
                // Get the user's desktop path
                string SpDesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                // Combine the desktop path with the file name
                string SpFilePath = Path.Combine(SpDesktopPath, "GoalsFromGoalTracker.txt");

                // Check if the file exists
                if (File.Exists(SpFilePath))
                {
                // Read all lines from the file
                string[] SpGoals = File.ReadAllLines(SpFilePath);

                // Display each goal on the console
                Console.WriteLine("Loaded Goals:");
                foreach (string goal in SpGoals)
                {
                        Console.WriteLine(goal);
                        string[] spGoalTypeFinder = goal.Split(":");
                        string spNewGoalType = spGoalTypeFinder[0];
                        string[] goalDescriptors = spGoalTypeFinder[1].Split(",");
                        if (spNewGoalType == "CheckList"){
                            Checklist spNewChecklist = new Checklist(spGoalTypeFinder[0], goalDescriptors[0], int.Parse(goalDescriptors[1]), int.Parse(goalDescriptors[2]), int.Parse(goalDescriptors[3]), int.Parse(goalDescriptors[4]), bool.Parse(goalDescriptors[5]));
                            //                           ($"{base._spGoalType}: {base._spDescription}, {base._spDifficultyLevel}, {_spTimesToDo}, {_spTimesDone}, {base._spPointsEarned}, {_spIsComplete}")
                        }else if (spNewGoalType == "Simple"){
                            Simple spNewSimple = new Simple(spNewGoalType, goalDescriptors[0], int.Parse(goalDescriptors[1]), int.Parse(goalDescriptors[2]), bool.Parse(goalDescriptors[3]));
                            //                          ($"{base._spGoalType}: {base._spDescription}, {base._spDifficultyLevel}, {base._spPointsEarned}, {_spIsComplete}")
                        }else{
                            Eternal spNewEternal = new Eternal(string goalType, string description, int diffiucltyLevel, int timesDone);
                            //
                        }
                }
                }
                else
                {
                Console.WriteLine("No goals file found.");
                }
        }
        static void Main(string[] args) {
            StartingMessage();
            Menu();
            int SpChoice = GetUserChoice();

            if (SpChoice == 1)
            {
                //Create goal logic logic
            } else if (SpChoice == 2)
            {
                //List goals logic
            } else if (SpChoice == 3)
            {
                //Save goals logic
                SaveGoals(SpNewGoals);
            } else if (SpChoice == 4)
            {
                //Load Goals logic
                LoadGoals(fileName);
            } else if (SpChoice == 5)
            {
                //record new event logic
            } else if (SpChoice == 0)
            {
                Console.WriteLine("End Program.");
                Environment.Exit(1);
            } else 
            {
                Console.WriteLine("Invalid Input, try again..");
                GetUserChoice();
            }

            EndingMessage();
        }
}
