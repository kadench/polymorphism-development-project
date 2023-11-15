class Goal {
    protected string _spGoalType;
    protected int _spPointsEarned;
    private List<int> _spDifficultyList = new List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
    protected int _spDifficultyLevel;
    private List<string> spAcceptedAnswers = new List<string>{"eternal goal", "eternal", "checklist goal", "checklist", "simple goal", "simple", "1", "2", "3"};
    protected string _spDescription;

    public Goal(string spUserInput) {
        if (spAcceptedAnswers.Contains(spUserInput)) {
            _spGoalType = spUserInput;
        }
    }
    // Sets the difficulty level of the complete goal.
        private void SpSetDifficultyLvl(int spUserSetDifficulty) {
        if (_spDifficultyList.Contains(spUserSetDifficulty)) {
            _spDifficultyLevel = spUserSetDifficulty;
        }
        else {
            Console.WriteLine("You've entered an invalid difficulty level. Choose a number 1-10");
        }
    }

    // Sets the amount of points based on the goal and difficulty level 
    private void SpSetPointValue(string _spGoalType, int _spDifficultyLevel) {
        
    }
}

// Simple: 50
// Checklist: 30 (Double as well.)
// Eternal: 10