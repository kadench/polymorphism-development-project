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
        static void LoadGoals(string fileName)
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
                            Checklist spNewChecklist = new Checklist(spGoalTypeFinder[0], goalDescriptors[0], int.Parse(goalDescriptors[1]), int.Parse(goalDescriptors[2]), int.Parse(goalDescriptors[3]), bool.Parse(goalDescriptors[5]));
                            //                           ($"{base._spGoalType}: {base._spDescription}, {base._spDifficultyLevel}, {_spTimesToDo}, {_spTimesDone}, {base._spPointsEarned}, {_spIsComplete}")
                        }else if (spNewGoalType == "Simple"){
                            Simple spNewSimple = new Simple(spNewGoalType, goalDescriptors[0], int.Parse(goalDescriptors[1]), bool.Parse(goalDescriptors[3]));
                            //                          ($"{base._spGoalType}: {base._spDescription}, {base._spDifficultyLevel}, {base._spPointsEarned}, {_spIsComplete}")
                        }else{
                            Eternal spNewEternal = new Eternal(spNewGoalType, goalDescriptors[0], int.Parse(goalDescriptors[1]), int.Parse(goalDescriptors[3]));
                            //                                 _spGoalType      _spDescription        _spDifficultyLevel   /_spPointsEarned/  _spTimesDone
                        }
                }
                }
                else
                {
                Console.WriteLine("No goals file found.");
                }
        }

        static Goal CreateGoal(){
            //Get the user's goal choice
            string spUserResponse;
            int spUserChoice = 0;
            bool spCreatedGoal = false;

            while (spCreatedGoal == false){
                try{
                Console.WriteLine("Choose the number for one of the Following types of goals: "); 
                Console.WriteLine("1. Simple goal: A goal that is completed once with no repititions. ");
                Console.WriteLine("2. CheckList goal: Must be done a chosen number of times before it is complete. ");
                Console. WriteLine("3. Eternal Goal: Changes lifestyle by creating a permanent goal. ");

                spUserResponse = Console.ReadLine();
                spUserChoice = int.Parse(spUserResponse);
                }catch (Exception ){

                    Console.WriteLine("That is not a number. Please choose a number between 1 and 3. ");
                    
            
                }
                
                if (spUserChoice == 1){
                    //string goalType, string description, int difficultyLevel, bool isComplete
                    Console.WriteLine("What is your new Simple goal?");
                    Console.Write(">");
                    string spDescription = Console.ReadLine();
                    
                    Console.WriteLine("On a scale of 1 to 10, how difficult will it be to complete this goal? ");
                    Console.Write(">");
                    int spDifficultyLevel = int.Parse(Console.ReadLine());

                    Simple spNewGoal = new Simple("Simple", spDescription, spDifficultyLevel, false);
                    spCreatedGoal = true;
                    return spNewGoal;



                }else if (spUserChoice == 2){
                    Console.WriteLine("What is your new Checklist goal?");
                    Console.Write(">");
                    string spDescription = Console.ReadLine();
                    
                    Console.WriteLine("On a scale of 1 to 10, how difficult will it be to complete this goal? ");
                    Console.Write(">");
                    int spDifficultyLevel = int.Parse(Console.ReadLine());
                    Console.WriteLine("How many times does this goal need to be completed?");
                    Console.Write(">");
                    int spTimesToDo = int.Parse(Console.ReadLine());

                    Checklist spNewGoal = new Checklist("Checklist", spDescription, spDifficultyLevel, spTimesToDo, 0, false);
                    spCreatedGoal = true;
                    return spNewGoal;
                    

                }else if (spUserChoice == 3){
                    Console.WriteLine("What is your new Eternal goal?");
                    Console.Write(">");
                    string spDescription = Console.ReadLine();
                    
                    Console.WriteLine("On a scale of 1 to 10, how difficult will it be to complete this goal? ");
                    Console.Write(">");
                    int spDifficultyLevel = int.Parse(Console.ReadLine());

                    Eternal spNewGoal = new Eternal("Eternal", spDescription, spDifficultyLevel, 0);
                    spCreatedGoal = true;
                    return spNewGoal;


                }else{
                    Console.WriteLine("Your choice is not a valid response. Please choose a number between 1 and 3. ");
                    
                }
            
            }


        }
        static void Main(string[] args) {
            StartingMessage();

            var spGoalsheet = new GoalSheet();

            Menu();
            int SpChoice = GetUserChoice();

            if (SpChoice == 1)
            {
             //Create a New Goal 
                Goal spGoalInstance = CreateGoal();
                spGoalsheet.AddToList(spGoalInstance);


                
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
                Console.Write("Which file would you like to load your goals from?");
                string spFilename = Console.ReadLine();
                LoadGoals(spFilename);
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