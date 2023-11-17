using System;

class Simple : Goal {
    bool _spIsComplete;

    public Simple(string goalType, string description, int difficultyLevel, bool isComplete) : base(goalType, description, difficultyLevel){
        _spIsComplete = isComplete;
    }

    public override void SpRecordEvent(){
        _spIsComplete = true;
        base._spPointsEarned += base._spGoalValue;
    }

    public override string ToString(){
         return ($"{base._spGoalType}: {base._spDescription}, {base._spDifficultyLevel}, {base._spPointsEarned}, {_spIsComplete}");
    }



}
