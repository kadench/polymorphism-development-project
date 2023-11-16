class Goal {
    
    // The description of a given goal. (is this not needed???)
    protected string _spDescription;
    
    // Sets the goal type (name) as a string. Acceptable answers in list below.
    protected string _spGoalType;
    
    // Accepted answers for each goal type in a List<string>.
    protected List<string> spAcceptedAnswers = new List<string>{"eternal goal", "eternal", "checklist goal", "checklist", "simple goal", "simple", "1", "2", "3"};

    // The base point value of a given goal.
    protected int _spGoalValue;
    
    // The point value that is returned to the user for completing a goal.
    protected int _spUserPointsEarned;

    // A List<int> with the accepted difficulty levels for each goal.
    protected List<int> _spDifficultyList = new List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
    
    // The valid difficulty level that was chosen by the user.
    protected int _spDifficultyLevel;
    

    // Building the constuctor
    // Input: User's goal type
    public Goal(string spGoalChoice) {
        
        // Checks if the user's input is in the accepted goal list.
        if (spAcceptedAnswers.Contains(spGoalChoice)) {
            
            // If it is, set the goal type to the valid goal.
            _spGoalType = spGoalChoice.ToLower();
        }
        // If it isn't write a response to the terminal (temporary)
        else {
            Console.WriteLine("Invalid goal name was given. Please try again.");
        }
        SpSetGoalPointValue();
    }
    // Sets the difficulty level of the complete goal from the user's chosen difficulty level.
    protected void SpSetDifficultyLvl(int spUserSetDifficulty) {
        if (_spDifficultyList.Contains(spUserSetDifficulty)) {
            _spDifficultyLevel = spUserSetDifficulty;
        }
        else {
            Console.WriteLine("You've entered an invalid difficulty level. Choose a number 1-10");
        }
    }

    // Sets the base amount of points a goal can give.
    private void SpSetGoalPointValue() {
        if (_spGoalType == "simple") {
            _spGoalValue = 50;
        }
        else if (_spGoalType =="checklist") {
            _spGoalValue = 30;
        }
        else if (_spGoalType == "eternal") {
            _spGoalValue = 10;
        }
    }

    // Sets the amount of points received when a goal is done. (Will be changed by checklist, so it's a virtual method.)
    protected virtual void SpSetGivenPoints() {
        _spUserPointsEarned = _spDifficultyLevel * _spGoalValue; 
    }
    // Not sure what this one does??
    protected virtual void SpRecordEvent() {

    }
}

// Simple: 50
// Checklist: 30 (Double as well.)
// Eternal: 10