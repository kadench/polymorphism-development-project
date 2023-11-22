class Eternal : Goal{
    private int _spTimesDone;



    public Eternal(string goalType, string description, int diffiucltyLevel, int timesDone) : base(goalType, description, diffiucltyLevel){
        _spTimesDone = timesDone;
    }

    private void SpCountTimesDone(){
        _spTimesDone += 1;
    }
    public override void SpRecordEvent(){
        SpCountTimesDone();
        Console.WriteLine($"Congratulations! You earned {_spPointsEarned} points! ");
    }

    public override string ToString(){
        return ($"{base._spGoalType}: {base._spDescription}, {base._spDifficultyLevel}, {base._spPointsEarned}, {_spTimesDone}");
    }

    public override string SpDisplayFormat(){
        
        
        return ($"Your goal to \"{base._spDescription}\" has a difficulty of {base._spDifficultyLevel} and has been completed {_spTimesDone} times. ");
    }



}
