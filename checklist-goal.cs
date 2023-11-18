using System;

class Checklist : Goal {
    private int _spTimesDone;
    private int _spTimesToDo;
    private int _spBonusPointValue;
    private bool _spIsComplete;

    public Checklist(string goalType, string description, int difficultyLevel, int timesToDo, int timesDone, bool isComplete) : base(goalType, description, difficultyLevel){
        _spTimesToDo = timesToDo;
        _spTimesDone = timesDone;
        _spIsComplete = isComplete;
    }

    private void SpCountTimesDone(){
        _spTimesDone = _spTimesDone +1;

    }

    private void SpSetIsComplete(){
        if (_spTimesDone == _spTimesToDo){
            _spIsComplete = true;
            SpDetermineBonusPoints();
            base._spPointsEarned = _spPointsEarned + _spBonusPointValue;
        }

    }

    private void SpDetermineBonusPoints(){
        _spBonusPointValue = 2 * base._spGoalValue;

    }

    public override void SpRecordEvent(){
        SpCountTimesDone();
        base._spPointsEarned += base._spGoalValue;

    }

    public override string ToString()
    {
        return ($"{base._spGoalType}: {base._spDescription}, {base._spDifficultyLevel}, {base._spPointsEarned}, {_spTimesToDo}, {_spTimesDone}, {_spIsComplete}");
    }


    public override string SpDisplayFormat(){
        string spDisplayCompletion = ($"{_spTimesDone}/{_spTimesToDo}");
        
        return ($"Your goal to {base._spDescription} has a difficulty of {base._spDifficultyLevel} and is {spDisplayCompletion} completed. ");
    }




}
