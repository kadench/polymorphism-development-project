class GoalSheet 
{
    private List<string> _SpGoalsList;
    private int _SpScore;

    public GoalSheet (List<string> SpGoalsList, int SpScore)
    {
        _SpGoalsList = SpGoalsList;
        _SpScore = SpScore;
    }

    public void AddToList(string SpNewGoal) 
    {
        //get list and append
        _SpGoalsList.Add(SpNewGoal);
    }
}
