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
    }

    public string ToString(){
        return ($"{base._spGoalType}: {base._spDescription}, {base._spDifficultyLevel}, {base._spPointsEarned}, {_spTimesDone}");
    }


}
