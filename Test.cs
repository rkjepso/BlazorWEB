namespace BlazorWEB.Shared;

[Serializable]
public class Test
{
    public string Name { get; set; } = "";
    public DateTime Dt { get; set; }
    public int MaxScore { get; set; }
    public int Score { get; set; }
}
