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
    static string SpGetFilePath(string spFileName){
        string spFilePath = " ";
        do{
            Console.WriteLine("Is your file on your desktop?(y/n) ");
            Console.Write("> ");
            string spPathChoice = Console.ReadLine();
            if (spPathChoice.ToLower() == "y" || spPathChoice.ToLower() == "yes"){
                spFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), spFileName);
            }else if (spPathChoice.ToLower() == "n" || spPathChoice.ToLower() == "no"){
                spFilePath = spFileName;
            }else{
                Console.WriteLine("That was not an option. Please try again. ");
            }
        }while(spFilePath == " ");

        return spFilePath;
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
            string spFilePath = SpGetFilePath(spFilename);

            // write the goals the file
                File.WriteAllLines(spFilePath, spNewGoalStrings);
            

            Console.WriteLine($"Goals saved to file {spFilename}.");
        }





    static void LoadGoals(string spFileName, GoalSheet spGoalsheet)
    {
    // Get the user-provided file path
    string spFilePath = SpGetFilePath(spFileName);
    // Check if the file exists
    if (File.Exists(spFilePath))
    {
        // Read all lines from the file
        string[] spGoalStrings = File.ReadAllLines(spFilePath);



        // Create goals based on the loaded strings
        foreach (string spGoalString in spGoalStrings)
        {
           
            string[] spSeparatedGoalType = spGoalString.Split(":");
            string[] spGoalComponents = spSeparatedGoalType[1].Split(",");
            

            // Ensure that the goal string has the minimal number of components
            if (spGoalComponents.Length >= 4)
            {
                string spGoalType = spSeparatedGoalType[0];
                string spDescription = spGoalComponents[0];
                int spDifficultyLevel = int.Parse(spGoalComponents[1]);
                //int spPointsEarned = int.Parse(spGoalComponents[2]);
                

                
                // Create a goal based on the goal type
                Goal spCreatedGoal;
                if (spGoalType == "simple")
                {
                    bool spIsComplete = bool.Parse(spGoalComponents[3]);
                    spCreatedGoal = new Simple(spGoalType, spDescription, spDifficultyLevel, spIsComplete);
                    
                    
                }
                else if (spGoalType == "checklist")
                {
                        if (spGoalComponents.Length >= 6)
                    {
                        int spTimesToDo = int.Parse(spGoalComponents[3]); 
                        int spCurrentCount = int.Parse(spGoalComponents[4]); 
                        bool spIsComplete = bool.Parse(spGoalComponents[5]);

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
                Console.WriteLine($"Invalid goal format: {spGoalString}");
            }
        }

        Console.WriteLine($"Your goals have been loaded {spGoalsheet.GetGoalList().Count}.");
        
    }
    else
    {
        Console.WriteLine($"No goals file found at {spFilePath}.");
    }
}






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

                            // string goalType, string description, int difficultyLevel, bool isComplete
                            Console.WriteLine("What is your new Eternal goal?");
                            Console.Write("> ");
                            string spDescription = Console.ReadLine();



                            Console.WriteLine();
                            Console.WriteLine("On a scale of 1 to 10, how difficult will it be to complete this goal? ");
                            Console.Write("> ");
                            int spDifficultyLevel = int.Parse(Console.ReadLine());
                            
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



    static public void SpDisplayAllGoals(List<Goal> spGoalList){
        
                int i = 1;
                foreach (Goal goal in spGoalList){
                    Console.WriteLine(i + ": " + goal.SpDisplayFormat());
                    i += 1;
                }
                Thread.Sleep(2000);
    }

    static public void SpUpdateGoal(GoalSheet spGoalsheet, List<Goal> spGoalList){

        bool spGotChoice = false;

        do{
            Console.WriteLine("which goal did you complete?");
            Console.Write("> ");
            if (int.TryParse(Console.ReadLine(), out int spGoalChoice)){
                if (spGoalChoice >= 1 && spGoalChoice <= spGoalList.Count){
    
                    Goal spChosenGoal = spGoalList[spGoalChoice -1];
                    // string spChosenGoalString = spGoalList[spGoalChoice].ToString();
                    // string[] spGoalSplit = spChosenGoalString.Split(":");
                    // string[] spGoalDetails = spGoalSplit[1].Split(",");
                    // string spGoalType = spGoalSplit[0];

                    spChosenGoal.SpRecordEvent();
                    spGoalsheet.SpGetScore();
                    
                    spGotChoice = true;
                } else{
                    Console.WriteLine("This number is not in the range of the list. Try again.");
                }
            }else{
                    Console.WriteLine("Your response must be a number in the list of goals. Please try again. ");
            }

        }while(spGotChoice == false);
    }


        
        static void Main(string[] args) {
            StartingMessage();

            GoalSheet spGoalsheet = new GoalSheet();
            List<string> spFilesLoaded = new List<string>();
            bool spFinished = false;
            do{

            Menu();
            int SpChoice = GetUserChoice();

            if (SpChoice == 1)
            {
             //Create a New Goal 
                
                Goal spNewGoal = CreateGoal();
                spGoalsheet.AddToList(spNewGoal);

                
            } else if (SpChoice == 2)
            {
                //List existing goals
                List<Goal> spGoalList = spGoalsheet.GetGoalList();
                SpDisplayAllGoals(spGoalList);


                Console.WriteLine();
                int spTotalScore = spGoalsheet.SpGetScore();
                Console.WriteLine($"Your current score is: {spTotalScore} points!");



            } else if (SpChoice == 3)
            {
                Console.Write("Which file would you like to save your goals to? ");
                string spFilename = Console.ReadLine();
                List<Goal> SpNewGoalList = spGoalsheet.GetGoalList();
                //check to see if data from that file has been loaded
                if (spFilesLoaded.Contains(spFilename)){
                    //Save goals logic
                    SaveGoals(SpNewGoalList, spFilename);
                    
                }else{
                    Console.WriteLine("The goals in this file have not been loaded yet. If you save to this file, all previous data will be lost. ");
                    Thread.Sleep(500);
                    Console.WriteLine("WOULD YOU STILL LIKE TO SAVE?(n/y) ");
                    Console.Write(">");
                    string spUserResponse = Console.ReadLine();
                    string spResponse = spUserResponse.ToLower();
                    if (spResponse == "y" || spResponse == "yes"){
                        SaveGoals(SpNewGoalList, spFilename);
                    }
                }

            } else if (SpChoice == 4)
            {
                //Load Goals logic
                Console.Write("Which file would you like to load your goals from? ");
                string spFilename = Console.ReadLine();
                if (spFilesLoaded.Contains(spFilename)){
                    Console.WriteLine("This file has already been loaded. ");

                }else{
                    LoadGoals(spFilename, spGoalsheet);
                    spFilesLoaded.Add(spFilename);
                    Console.WriteLine(spFilesLoaded.Count() + " files have been loaded. ");
            
                }
                Console.WriteLine();
                int spTotalScore = spGoalsheet.SpFindScore();
                Console.WriteLine($"Your current score is: {spTotalScore} points!");
                
            } else if (SpChoice == 5)
            {
                List<Goal> spGoalList = spGoalsheet.GetGoalList();
                Console.WriteLine("Here is a list of your goals: ");
                SpDisplayAllGoals(spGoalList);
                Console.WriteLine();
                SpUpdateGoal(spGoalsheet, spGoalList);
                
                
                

                //record new event logic
            } else if (SpChoice == 6)
            {
                int spTotalScore = spGoalsheet.SpGetScore();
                Console.WriteLine("End Program. ");
                Console.WriteLine($"Your current score is: {spTotalScore} points!");
                spFinished = true;
                
            } else 
            {
                Console.WriteLine("Invalid Input, try again..");
                GetUserChoice();
            }
            Thread.Sleep(2000);
            }while(spFinished == false);

            EndingMessage();
        }
}
