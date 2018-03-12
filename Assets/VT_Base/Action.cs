[System.Serializable]
public class Action : IState
{
    public string Name { get; set; }
    public string Mode { get; set; }

    public Action() { }
    public Action(string name, string mode)
    {
        Name = name;
        Mode = mode;
    }

    string IState.Param1
    {
        get { return this.Mode; }
        set { this.Mode = value; }
    }
}
