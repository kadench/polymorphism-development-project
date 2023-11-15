using System;

class Simple : Goal {
    bool _spIsComplete;

    public Simple(string goalType, string description, int difficultyLevel, bool isComplete) : base(goalType, description, difficultyLevel){
        _spIsComplete = isComplete;
    }

    public override void RecordEvent(){
        _spIsComplete = true;
        base._spPointsEarned += base._spPointsValue;
    }

    public void ToString(){
         return ($"{base._spGoalType}: {base._spDescription}, {base._spDifficultyLevel}, {base._spPointsEarned}, {_spIsComplete}");
    }



}
