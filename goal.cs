// Sources:
// https://byui-cse.github.io/cse210-course-2023/unit05/develop.html
// https://www.w3schools.com/cs/cs_operators_logical.php 

public abstract class Goal {
    
    // The description of a given goal. (is this not needed???)
    protected string _spDescription;
    
    // Sets the goal type (name) as a string. Acceptable answers in list below.
    protected string _spGoalType;
    
    // Accepted answers for each goal type in a List<string>.
    protected List<string> spAcceptedAnswers = new List<string>{"eternal goal", "eternal", "checklist goal", "checklist", "simple goal", "simple", "1", "2", "3"};

    // The base point value of a given goal.
    protected int _spGoalValue;
    
    // The point value that is returned to the user for completing a goal.
    protected int _spPointsEarned;

    // A List<int> with the accepted difficulty levels for each goal.
    protected List<int> _spDifficultyList = new List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
    
    // The valid difficulty level that was chosen by the user.
    protected int _spDifficultyLevel;

    // Keeps the score to add to the txt document.
    protected int _spScore;

    
    

    // Setting the attributes for the new instance.
    // Input: User's goal type
    public Goal(string spGoalChoice, string spDescription, int spDifficultyLevel) {
        
        // Checks if the user's input is in the accepted goal list.
        if (spAcceptedAnswers.Contains(spGoalChoice)) {
            
            // If it is, set the goal type and description to the valid goal.
            _spGoalType = spGoalChoice.ToLower();
            if (_spGoalType == "eternal" || _spGoalType == "eternal goal" || _spGoalType == "1") {
                _spGoalType = "eternal";
                //_spDescription = spDescription;
            }
            else if (_spGoalType == "checklist" || _spGoalType == "checklist goal" ||  _spGoalType == "2") {
                _spGoalType = "checklist";
                //_spDescription = spDescription;
            }
            else if (_spGoalType == "simple" || _spGoalType == "simple goal" ||  _spGoalType == "3") {
                _spGoalType = "simple";
            }
            else {
                Console.WriteLine("An invalid goaltype was given.");
            }
            
            
            // Sets the goal difficulty
            _spDescription = spDescription;
            SpSetDifficultyLvl(spDifficultyLevel);
            SpSetGoalPointValue();
            SpSetPointsEarned();
            //SpSetScore();
        }
        // If it isn't write a response to the terminal (temporary)
        else {
            Console.WriteLine("Invalid goal name was given. Please try again.");
        }

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

    private int SpGetGoalPointValue() {
        return _spGoalValue;
    }

    // Sets the amount of points received when a goal is done. (Will be changed by checklist, so it's a virtual method.)
    protected virtual void SpSetPointsEarned() {
        _spPointsEarned = _spDifficultyLevel * _spGoalValue; 
    }

    public int SpGetPointsEarned() {
        return _spPointsEarned;
    }

    
    public abstract void SpRecordEvent();
    

    public virtual string SpDisplayFormat(){
        return ("");
    }
    
    // protected virtual void SpSetScore() {
    //     _spScore = _spGoalValue * _spDifficultyLevel; 
    // }

    // protected int SpGetScore() {
    //     return _spScore;
    // }

    public string SpGetGoalType(){
        return _spGoalType;
    }

    public virtual int SpUpdateTotalScore(int totalScore){
        totalScore = totalScore + _spPointsEarned;
        return totalScore;
    }

}

// Simple: 50
// Checklist: 30 (Double as well.)
// Eternal: 10