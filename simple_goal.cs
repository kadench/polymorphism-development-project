using System;

class Simple : Goal {
    bool _spIsComplete;

    public Simple(string goalType, string description, int difficultyLevel, bool isComplete) : base(goalType, description, difficultyLevel){
        _spIsComplete = isComplete;
    }

    public override void SpRecordEvent(){
        _spIsComplete = true;
        Console.WriteLine($"Congratulations! You earned {_spPointsEarned} points! ");
        
        
    }

   

    public override string ToString(){
         return ($"{base._spGoalType}: {base._spDescription}, {base._spDifficultyLevel}, {base._spPointsEarned}, {_spIsComplete}");
    }

    public override string SpDisplayFormat(){
        string spDisplayComplete;
        if (_spIsComplete == false){
            spDisplayComplete = "is not";
        }else{
            spDisplayComplete = "is";
        }
        return ($"Your goal to \"{base._spDescription}\" has a difficulty of {base._spDifficultyLevel} and {spDisplayComplete} completed. ");
    }



}
