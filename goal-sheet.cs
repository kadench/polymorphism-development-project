class GoalSheet 
{
    private List<Goal> _SpGoalsList = new List<Goal>();
    private int _SpScore;


    public GoalSheet(){
        
    }

    public GoalSheet (Goal name)
    {
        
    
    }
    public GoalSheet (int SpScore)
    {
        _SpScore = SpScore;
    }

    public void AddToList(Goal SpNewGoal) 
    {   
        
        //get list and append
        _SpGoalsList.Add(SpNewGoal);
    }
    public List<Goal> GetGoalList()
    {
        return _SpGoalsList;
    }

    public int GetScore(){
        return _SpScore;
    }
    static string FindGoal()
    {
        try
        {
            Console.Write("Please enter the filepath of the file that holds your goals: ");
            string spFilePath = Console.ReadLine();

            if (File.Exists(spFilePath))
            {
                Console.Write("Please enter the goal you are looking for: ");
                string spGoalToFind = Console.ReadLine();

                string[] spGoalList = File.ReadAllLines(spFilePath);

                foreach (string spLine in spGoalList)
                {
                    if (spLine.Contains(spGoalToFind))
                    {
                        Console.WriteLine(spLine);
                        return spLine;
                    }
                }

                // If the loop completes without finding a match
                Console.WriteLine("Goal not found");
                return "Goal not found";
            }
            else
            {
                Console.WriteLine($"File not found at {spFilePath}");
                return "File not found";
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return "Error";
        }
    }
}
// take this list from here and for each of the goals in this list add them to the file if they dont exist