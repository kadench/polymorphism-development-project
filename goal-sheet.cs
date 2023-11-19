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
}
// take this list from here and for each of the goals in this list add them to the file if they dont exist