using System;


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
        public static void SaveGoals(List<Goal> newGoals, string filename) 
        {

            // Create a list that holds the ToString() string for each goal
            List<string> newGoalStrings = new List<string>();
            foreach (Goal goal in newGoals){
                newGoalStrings.Add(goal.ToString());
            }

            // Get the user's desktop path
            string SpDesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // Combine the desktop path with the file name
            string SpFilePath = Path.Combine(SpDesktopPath, filename);

            // Check if the file exists
            if (File.Exists(SpFilePath))
            {
                // Read existing goals from the file
                List<string> SpExistingGoalStrings = File.ReadAllLines(SpFilePath).ToList();

                // get method of goalList
                // var spGoalList = new GoalSheet(newGoals);
                // spGoalList.GetGoalList();

                // Add new goals without duplicates
                foreach (string goal in newGoalStrings)
                {
                    if (!SpExistingGoalStrings.Contains(goal))
                    {
                        SpExistingGoalStrings.Add(goal);
                    }
                }

                // Write the updated goals back to the file
                File.WriteAllLines(SpFilePath, SpExistingGoalStrings);
            }
            else
            {
            // Create a new file and write the goals to it
                File.WriteAllLines(SpFilePath, newGoalStrings);
            }

            Console.WriteLine($"Goals saved to file {filename}.");
        }
        static void LoadGoals(string fileName, GoalSheet spGoalsheet)
        {
                // Get the user's desktop path
                //string SpDesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                // Combine the desktop path with the file name
                //string SpFilePath = Path.Combine(SpDesktopPath, "GoalsFromGoalTracker.txt");

                // Check if the file exists
                if (File.Exists(fileName))
                {
                // Read all lines from the file
                string[] SpGoals = File.ReadAllLines(fileName);

                // Display each goal on the console
                
                foreach (string goal in SpGoals)
                {
                        
                        string[] spGoalTypeFinder = goal.Split(":");
                        string spNewGoalType = spGoalTypeFinder[0];
                        string[] goalDescriptors = spGoalTypeFinder[1].Split(",");
                        if (spNewGoalType == "checkList"){
                            Checklist spNewChecklist = new Checklist(spGoalTypeFinder[0], goalDescriptors[0], int.Parse(goalDescriptors[1]), int.Parse(goalDescriptors[2]), int.Parse(goalDescriptors[3]), bool.Parse(goalDescriptors[5]));
                            spGoalsheet.AddToList(spNewChecklist);
                            
                        }else if (spNewGoalType == "simple"){
                            Simple spNewSimple = new Simple(spNewGoalType, goalDescriptors[0], int.Parse(goalDescriptors[1]), bool.Parse(goalDescriptors[3]));
                            spGoalsheet.AddToList(spNewSimple);

                        }else{
                            Eternal spNewEternal = new Eternal(spNewGoalType, goalDescriptors[0], int.Parse(goalDescriptors[1]), int.Parse(goalDescriptors[3]));
                            spGoalsheet.AddToList(spNewEternal);
                        }
                
                }
                Console.WriteLine("Your goals have been saved. ");
                }
                else
                {
                Console.WriteLine("No goals file found.");
                }
        }


    // public static int GetDifficulty(){
    //      int spDifficultyLevel = 11;
    //         do
    //         {
    //             try
    //             {
    //                 Console.WriteLine();
    //                 Console.WriteLine("On a scale of 1 to 10, how difficult will it be to complete this goal? ");
    //                 Console.Write("> ");
    //                 spDifficultyLevel = int.Parse(Console.ReadLine());

    //                 if (spDifficultyLevel <= 10)
    //                 {
    //                     return spDifficultyLevel;
    //                 }
    //                 else
    //                 {
    //                     Console.WriteLine("Invalid difficulty level. Please enter a number between 1 and 10.");
    //                 }
    //             }
    //             catch (FormatException)
    //             {
    //                 Console.WriteLine("Invalid input. Please enter a valid number between 1 and 10.");
    //             }
    //         } while (spDifficultyLevel > 10 && spDifficultyLevel < 1);
    //         }


        static Goal CreateGoal(){
        // Get the user's goal choice
        string spUserResponse;
        int spUserChoice;
        bool spCreatedGoal = false;

        do
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("Choose the number for one of the Following types of goals: ");
                Console.WriteLine("1. Simple goal: A goal that is completed once with no repetitions. ");
                Console.WriteLine("2. CheckList goal: Must be done a chosen number of times before it is complete. ");
                Console.WriteLine("3. Eternal Goal: Changes lifestyle by creating a permanent goal. ");
                Console.WriteLine();
                Console.Write("Please choose a goal to create: ");
                spUserResponse = Console.ReadLine();
                spUserChoice = int.Parse(spUserResponse);

                if (spUserChoice == 1)
                {
                    // string goalType, string description, int difficultyLevel, bool isComplete
                    Console.WriteLine("What is your new Simple goal?");
                    Console.Write("> ");
                    string spDescription = Console.ReadLine();
                    
                       
                            Console.WriteLine();
                            Console.WriteLine("On a scale of 1 to 10, how difficult will it be to complete this goal? ");
                            Console.Write("> ");
                            int spDifficultyLevel = int.Parse(Console.ReadLine());
                            
                                Simple spNewGoal = new Simple("simple", spDescription, spDifficultyLevel, false);
                                spCreatedGoal = true;
                                
                                return spNewGoal;
                        
                   
                }
                else if (spUserChoice == 2)
                {
                    // string goalType, string description, int difficultyLevel, bool isComplete
                    Console.WriteLine("What is your new Checklist goal?");
                    Console.Write("> ");
                    string spDescription = Console.ReadLine();

                   
                            Console.WriteLine();
                            Console.WriteLine("On a scale of 1 to 10, how difficult will it be to complete this goal? ");
                            Console.Write("> ");
                            int spDifficultyLevel = int.Parse(Console.ReadLine());
                                Console.WriteLine("How many times does this goal need to be completed?");
                                Console.Write(">");
                                int spTimesToDo = int.Parse(Console.ReadLine());

                                Checklist spNewGoal = new Checklist("checklist", spDescription, spDifficultyLevel, spTimesToDo, 0, false);
                                spCreatedGoal = true;
                                return spNewGoal;
                           
                }
                else if (spUserChoice == 3)
                {
                    
                            Console.WriteLine();
                            Console.WriteLine("On a scale of 1 to 10, how difficult will it be to complete this goal? ");
                            Console.Write("> ");
                            int spDifficultyLevel = int.Parse(Console.ReadLine());

                            // string goalType, string description, int difficultyLevel, bool isComplete
                            Console.WriteLine("What is your new Eternal goal?");
                            Console.Write("> ");
                            string spDescription = Console.ReadLine();

                            
                                Eternal spNewGoal = new Eternal("eternal", spDescription, spDifficultyLevel, 0);
                                spCreatedGoal = true;
                                return spNewGoal;

                }
                else
                {
                    Console.WriteLine("Your choice is not a valid response. Please choose a number between 1 and 3. ");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("That is not a number. Please choose a number between 1 and 3. ");
            }
        } while (!spCreatedGoal);

        // This part is reached if the loop exits without returning a goal
        // Handle the case where no valid goal is created
        return null;
    }


        
        static void Main(string[] args) {
            StartingMessage();

            GoalSheet spGoalsheet = new GoalSheet();
            bool spFinished = false;
            do{

            Menu();
            int SpChoice = GetUserChoice();

            if (SpChoice == 1)
            {
             //Create a New Goal 
                //Goal spGoalInstance = CreateGoal();
                Goal spNewGoal = CreateGoal();
                spGoalsheet.AddToList(spNewGoal);
                


                
            } else if (SpChoice == 2)
            {
                //List existing goals
                List<Goal> spGoalList = spGoalsheet.GetGoalList();
                foreach (Goal goal in spGoalList){
                    Console.WriteLine(goal.SpDisplayFormat());
                }



            } else if (SpChoice == 3)
            {
                Console.Write("Which file would you like to save your goals to?");
                string spFilename = Console.ReadLine();
                //Save goals logic
                List<Goal> SpNewGoalList = spGoalsheet.GetGoalList();
                SaveGoals(SpNewGoalList, spFilename);
            } else if (SpChoice == 4)
            {
                //Load Goals logic
                Console.Write("Which file would you like to load your goals from? ");
                string spFilename = Console.ReadLine();
                LoadGoals(spFilename, spGoalsheet);
                Thread.Sleep(1000);
            } else if (SpChoice == 5)
            {
                //record new event logic
            } else if (SpChoice == 0)
            {
                Console.WriteLine("End Program.");
                spFinished = true;
                Environment.Exit(1);
            } else 
            {
                Console.WriteLine("Invalid Input, try again..");
                GetUserChoice();
            }
            }while(spFinished == false);

            EndingMessage();
        }
}
