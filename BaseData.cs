using BlazorWEB.Services;

namespace BlazorWEB.Client;

// State variables 
[Serializable]
public record BaseData
{
    public LangT LangT { get; set; }

    public BaseData()
    {
        LangT = LangT.SpanishNorwegian;
    }


    public void SetData(LangT langT)
    {
        LangT = langT;
        Save();
    }

    public void Load(IStorage ls)
    {
        var x = ls.GetItem<BaseData>(Defs.keyProgramBaseData);

        // stupid !
        LangT = x.LangT;
    }






    private void Save()
    {
        Program.Storage?.SetItem(Defs.keyProgramBaseData, this);
    }
}
