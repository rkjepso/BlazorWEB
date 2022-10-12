
namespace BlazorWEB;

public static class Functions
{
    public static string GetSmiley(int level)
    {
        return Smileys[GetSmileyIndex(level)];
    }

    public static int GetSmileyIndex(int level) =>
    level switch
    {
        >= 0 and <= 10 => 0,
        >= 10 and <= 20 => 1,
        >= 21 and <= 34 => 2,
        >= 35 and <= 50 => 3,
        >= 51 and <= 65 => 4,
        _ => 5
    };

    public static string[] Smileys = new string[]
    {
         "Img/Smiley_Dead.png",
         "Img/Smiley_SadM.png",
         "Img/Smiley_Orange.png",
         "Img/Smiley_Neutral.png",
         "Img/Smiley_Happy.png",
         "Img/Smiley_Green.png"
    };


    public static string GetEnumAsString<T>(T e)
    {
        var enumDisplayStatus = e;
        string? str = enumDisplayStatus?.ToString();
        return str ?? "";
    }
    public static string GetLangFlag(Lang lang)
    {
        return lang switch
        {
            Lang.Spanish => @"Img/Spain.jpg",
            Lang.English => @"Img/Uk.jpg",
            Lang.Norwegian => @"Img/Norway.jpg",
            Lang.German => @"Img/Germany.jpg",
            Lang.French => @"Img/French.png",
            _ => ""
        };
    }

    public static string GetToLangFlag(LangT langT)
    {
        return GetLangFlag(GetToLangFromLangT(langT));
    }

    public static string GetFromLangFlag(LangT langT)
    {
        return GetLangFlag(GetFromLangFromLangT(langT));
    }


    public static Lang GetToLangFromLangT(LangT langT)
    {
        return langT switch
        {
            LangT.SpanishEnglish => Lang.English,
            LangT.EnglishSpanish or LangT.NorwegianSpanish => Lang.Spanish,
            LangT.SpanishNorwegian => Lang.Norwegian,
            LangT.GermanNorwegian => Lang.Norwegian,
            LangT.NorwegianGerman => Lang.German,
            LangT.FrenchNorwegian => Lang.Norwegian,
            LangT.NorwegianFrench => Lang.French,
            _ => Lang.English
        };
    }

    public static Lang GetFromLangFromLangT(LangT langT)
    {
        return langT switch
        {
            LangT.EnglishSpanish => Lang.English,
            LangT.SpanishEnglish or LangT.SpanishNorwegian => Lang.Spanish,
            LangT.NorwegianSpanish or LangT.NorwegianGerman => Lang.Norwegian,
            LangT.GermanNorwegian => Lang.German,
            LangT.FrenchNorwegian => Lang.French,
            _ => Lang.English
        };
    }

    public static string StrToLang
    {
        get
        {
            Lang lang = GetToLangFromLangT(Program.BaseDataObj.LangT);
            return GetEnumAsString(lang);
        }
    }
    public static string StrFromLang
    {
        get
        {
            Lang lang = GetFromLangFromLangT(Program.BaseDataObj.LangT);
            return GetEnumAsString(lang);
        }
    }

    public static string StrToLangN
    {
        get
        {
            Lang lang = GetToLangFromLangT(Program.BaseDataObj.LangT);
            return LangInNorwegian(lang);
        }
    }
    public static string StrFromLangN
    {
        get
        {
            Lang lang = GetFromLangFromLangT(Program.BaseDataObj.LangT);
            return LangInNorwegian(lang);
        }
    }


    public static string LangInNorwegian(Lang lang)
    {
        return lang switch
        {
            Lang.English => "Engelsk",
            Lang.Norwegian => "Norsk",
            Lang.German => "Tysk",
            Lang.Spanish => "Spansk",
            Lang.French => "Fransk",
            _ => "Ukjent språk"
        };

    }


    //public static string StrStyleRichard2
    //{
    //    get => AppendRnd("css/Richard2.css");
    //}

    // Append a random number to force reload....
    //private static string AppendRnd(string sf)
    //{
    //    Random r = new ();
    //    string str = sf + @"?xxx=" + r.Next(DateTime.Now.Millisecond);
    //    return str;
    //}



}

