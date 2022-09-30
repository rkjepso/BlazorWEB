namespace BlazorWEB;

[Serializable]
public class TWordBase
{

}
public record TWord(int ID, 
                    string FromWord, 
                    string ToWord, 
                    string ToWordEnglish,
                    string FromSentence,
                    string ToSentence)
{

    //public int ID { get; set; }

    //public string FromWord { get; set; }
    //public string ToWord { get; set; }

    //public string ToWordEnglish { get; set; }

    public string ToWordAns { get; set; } = "";
    public bool IsCorrect { get; set; }

    // For AI usage level.
    public int Level { get; set; }

    public bool IsDeleted { get; set; }

    public int Counter { get; set; }

    // For Sorting purposes
    public int Sort { get; set; }
}

public class TWordItemComparer : IEqualityComparer<TWord>
{

#pragma warning disable CS8767 // Nullability of reference types in type of parameter doesn't match implicitly implemented member (possibly because of nullability attributes).
    public bool Equals(TWord x, TWord y)
#pragma warning restore CS8767 // Nullability of reference types in type of parameter doesn't match implicitly implemented member (possibly because of nullability attributes).
    {

        if (x == null || y == null)
            return false;

        return x.FromWord?.Trim() == y.FromWord?.Trim() &&
                x.ToWord?.Trim() == y.ToWord?.Trim();


    }

    public int GetHashCode(TWord obj)
    {
        return obj.FromWord.Trim().GetHashCode();
    }
}



