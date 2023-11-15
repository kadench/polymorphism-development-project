class GoalSheet 
{
    private List<string> _SpGoalsList;
    private int _SpScore;

    public GoalSheet (List<string> SpGoalsList)
    {
        _SpGoalsList = SpGoalsList;
    }
    public GoalSheet (int SpScore)
    {
        _SpScore = SpScore;
    }

    public void AddToList(string SpNewGoal) 
    {
        //get list and append
        _SpGoalsList.Add(SpNewGoal);
    }
    public List<string> GetGoalList()
    {
        return _SpGoalsList;
    }
}
// take this list from here and for each of the goals in this list add them to the file if they dont exist