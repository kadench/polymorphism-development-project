class GoalSheet 
{
    private List<Goal> _spGoalsList = new List<Goal>();
    private int _spScore;


    public GoalSheet(){
        
    }

    // public GoalSheet (Goal name)
    // {
        
    
    // }
    public GoalSheet (int SpScore)
    {
        _spScore = SpScore;
    }

    public void AddToList(Goal SpNewGoal) 
    {   
        
        //get list and append
        _spGoalsList.Add(SpNewGoal);
    }
    public List<Goal> GetGoalList()
    {
        return _spGoalsList;
    }

    public int SpFindScore(){
        // finds the current score from the loaded goals
        foreach (Goal goal in _spGoalsList){
            SpUpdateScore(goal);
            
        }
        return _spScore;
    }
    public void SpUpdateScore(Goal goal){
        _spScore = goal.SpUpdateTotalScore(_spScore);
            
    }
    

    public int SpGetScore(){
        return _spScore;
    }
    
}
// take this list from here and for each of the goals in this list add them to the file if they dont exist