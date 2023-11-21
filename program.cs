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
            Console.WriteLine("Enter 6 to Exit");
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
            }else if (SpInitialInput == "6")
            {
                int SpChoice = int.Parse(SpInitialInput);
                return SpChoice;
            }else
            {
                Console.WriteLine("Invalid Input, Please enter: 1, 2, 3, 4, 5 or 6.");
                Console.Write("Enter your choice: ");
                int SpChoice = int.Parse(Console.ReadLine());
                return SpChoice;
            }
        }
        public static void SaveGoals(List<Goal> spNewGoals, string spFilename) 
        {
            // Create a list that holds the ToString() string for each goal
            List<string> spNewGoalStrings = new List<string>();
            foreach (Goal goal in spNewGoals)
            {
                spNewGoalStrings.Add(goal.ToString());
            }

            // Get the user's desktop path
            string spDesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // Combine the desktop path with the file name
            string spFilePath = Path.Combine(spDesktopPath, spFilename);

            // Check if the file exists
            if (File.Exists(spFilePath))
            {
                // Append new goals to the existing file
                File.AppendAllLines(spFilePath, spNewGoalStrings);
            }
            else
            {
                // Create a new file and write the goals to it
                File.WriteAllLines(spFilePath, spNewGoalStrings);
            }

            Console.WriteLine($"Goals saved to file {spFilename}.");
        }

    static void LoadGoals(string spFileName, GoalSheet spGoalsheet)
    {
    // Get the user-provided file path
    string spFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), spFileName);

    // Check if the file exists
    if (File.Exists(spFilePath))
    {
        // Read all lines from the file
        string[] spGoalStrings = File.ReadAllLines(spFilePath);

        // Create goals based on the loaded strings
        foreach (string spGoalString in spGoalStrings)
        {
            string[] spGoalComponents = spGoalString.Split(",");

            // Ensure that the goal string has the expected number of components
            if (spGoalComponents.Length >= 4)
            {
                string spGoalType = spGoalComponents[0];
                string spDescription = spGoalComponents[1];
                int spDifficultyLevel = int.Parse(spGoalComponents[2]);

                // Try parsing the boolean value
                if (bool.TryParse(spGoalComponents[3].Trim(), out bool spIsComplete))
                {
                    // Create a goal based on the goal type
                    Goal spCreatedGoal;
                    if (spGoalType == "simple")
                    {
                        spCreatedGoal = new Simple(spGoalType, spDescription, spDifficultyLevel, spIsComplete);
                    }
                    else if (spGoalType == "checklist")
                    {
                         if (spGoalComponents.Length >= 6)
                        {
                            int spTimesToDo = int.Parse(spGoalComponents[3]); 
                            int spCurrentCount = int.Parse(spGoalComponents[4]); 

                            spCreatedGoal = new Checklist(spGoalType, spDescription, spDifficultyLevel, spTimesToDo, spCurrentCount, spIsComplete);
                        }
                        else
                        {
                            Console.WriteLine($"Invalid format for checklist goal: {spGoalString}");
                            continue;
                        }
                    }
                    else if (spGoalType == "eternal")
                    {
                       
                        int spCount = int.Parse(spGoalComponents[3]); 
                        spCreatedGoal = new Eternal(spGoalType, spDescription, spDifficultyLevel, spCount);
                    }
                    else
                    {
                        Console.WriteLine($"{spGoalType}");
                        continue;
                    }

                    // Add the goal to the GoalSheet
                    spGoalsheet.AddToList(spCreatedGoal);
                }
                else
                {
                    Console.WriteLine($"Error parsing boolean value: {spGoalComponents[3].Trim()}");
                    continue; // Skip this iteration to avoid adding an invalid goal
                }
            }
            else
            {
                Console.WriteLine($"Invalid goal format: {spGoalString}");
            }
        }

        Console.WriteLine("Your goals have been loaded.");
    }
    else
    {
        Console.WriteLine($"No goals file found at {spFilePath}.");
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
                Console.Write("which goal did you complete?");
                //record new event logic
            } else if (SpChoice == 6)
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
