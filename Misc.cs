namespace BlazorWEB;
public enum Lang { Spanish, English, Norwegian, German, French };
public enum LangT
{
    SpanishNorwegian, NorwegianSpanish, EnglishSpanish,
    SpanishEnglish, GermanNorwegian, NorwegianGerman,
    FrenchNorwegian, NorwegianFrench
};


static public class Defs
{
    public const string keySetup = "__setup__";
    public const string keySetupTest = "__setupTest__";
    public const string keyCache = "__get_cache_version__";
    public const string keySelectedWords = "__selectedWords__";
    public const string keyProgramVersion = "__get_version_gloser__";
    public const string keyProgramData = "program_data";
    public const string keyProgramBaseData = "__program_base_data";

    public const string keyLevel = "__words_level";
}
static public class Misc
{
    static public Lang LangFromLangT(LangT langT)
    {
        var lang = langT switch
        {
            LangT.SpanishNorwegian or LangT.NorwegianSpanish => Lang.Spanish,
            LangT.EnglishSpanish or LangT.SpanishEnglish => Lang.Spanish,
            LangT.GermanNorwegian or LangT.NorwegianGerman => Lang.German,
            LangT.FrenchNorwegian or LangT.NorwegianFrench => Lang.French,
            _ => default
        };
        return lang;

    }

    public static string MyDateStr(this DateTime dt)
    {
        return $"{(dt.Year % 100)}-{dt.Month}-{dt.Day} {dt.Hour}:{dt.Minute.ToString().PadLeft(2, '0')}";
    }

    public static bool IsEmpty(this string s)
    {
        return s.Length == 0;
    }


    public static bool IsEmpty<T>(this List<T> lst) => lst.Count == 0;

    public static bool IsNullOrEmpty<T>(this List<T> lst)
    {
        if (lst == null)
            return true;
        return !lst.Any();
    }

    public static T GetAtSafe<T>(this T[] arr, int i)
    {
        if (arr == null)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return default;

        }

        int cz = arr.Length;
        if (i >= 0 && i < cz)
        {
            return arr[i];
        }

        return default;
#pragma warning restore CS8603 // Possible null reference return.
    }

    public static List<T> Add<T>(this List<T> lstD, List<T> lstS)
    {
        int idxLast = lstS.Count - 1;
        for (int i = 0; i <= idxLast; i++)
        {
            lstD.Add(lstS[i]);
        }

        return lstD;
    }

    public static List<T> Copy<T>(this List<T> lstS)
    {
        List<T> lstD = new();
        int idxLast = lstS.Count - 1;
        for (int i = 0; i <= idxLast; i++)
        {
            lstD.Add(lstS[i]);
        }

        return lstD;
    }

    public static List<T> AddMany<T>(this List<T> lstD, List<T> lstS, int idxFirst = 0, int idxLast = int.MaxValue)
    {
        idxLast = Math.Min(idxLast, lstS.Count - 1);
        for (int i = idxFirst; i <= idxLast; i++)
        {
            lstD.Add(lstS[i]);
        }

        return lstD;
    }

    //public static List<T> CopyMany<T>(this List<T> lstS, int idxFirst = 0, int idxLast = int.MaxValue)
    //{
    //    List<T> lstD = new List<T>();
    //    idxLast = Math.Min(idxLast, lstS.Count - 1);
    //    for (int i = idxFirst; i <= idxLast; i++)
    //    {
    //        lstD.Add(lstS[i]);
    //    }

    //    return lstD;
    //}
    public static List<TWord> CopyMany(this List<TWord> lstS, int idxFirst = 0, int idxLast = int.MaxValue)
    {
        List<TWord> lstD = new List<TWord>();
        idxLast = Math.Min(idxLast, lstS.Count - 1);
        for (int i = idxFirst; i <= idxLast; i++)
        {
            var obj = lstS[i] with { };
            lstD.Add(obj);
        }
        return lstD;
    }

    public static int ForEach<T>(this T[] array, Func<T, int, T> fn)
    {
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = fn(array[i], i);
        }

        return 0;
    }

    public static bool _in<T>(this T e, IEnumerable<T> lst)
    {
        return lst.Contains(e);
    }


    public static TWord? FindRandomNotInList(this List<TWord> lstS, List<TWord> lstB)
    {
        // Find a random element which is not in list B
        List<TWord> lstNot = new();
        foreach (var w in lstS)
        {
            if (!lstB.Contains(w))
            {
                lstNot.Add(w);
            }
        }

        if (lstNot.Count == 0)
        {
            return default;
        }

        Random r = new Random();
        int idx = r.Next(lstNot.Count);
        return lstS[idx];
    }

    public static List<TWord> FindRandomWords(this List<TWord> lstS, int num)
    {
        if (lstS.Count == 0)
        {
            return lstS;
        }

        var lstD = new List<TWord>();
        Random r = new Random();
        while (lstD.Count < num)
        {
            var idx = r.Next(lstS.Count);
            var w = lstS[idx];
            if (lstD.Exists(o => o == w))
            {
                continue;
            }

            lstD.Add(w);
            if (lstD.Count >= lstS.Count)
            {
                break;
            }
        }
        return lstD;
    }


    //    static public List<TWord> FillWordsLang(List<TWord> lst, LangT langT)
    //    {
    //#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
    //        lst = langT switch
    //        {
    //            //LangT.SpanishEnglish or LangT.EnglishSpanish => Dictionaries.SpanishEng(lst),
    //            //LangT.GermanNorwegian or LangT.NorwegianGerman => Dictionaries.GermanNor(lst),
    //            //LangT.SpanishNorwegian or LangT.NorwegianSpanish => Dictionaries.SpanishNor(lst),
    //            //LangT.FrenchNorwegian or LangT.NorwegianFrench => Dictionaries.FrenchNor(lst),
    //            _ => default
    //        };
    //#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

    //        // Temporary solution
    //        if (langT == LangT.EnglishSpanish ||
    //            langT == LangT.NorwegianGerman ||
    //            langT == LangT.NorwegianSpanish ||
    //            langT == LangT.NorwegianFrench)
    //        {
    //            lst.ForEach(w => (w.FromWord, w.ToWord) = (w.ToWord, w.FromWord));
    //        }

    //        return lst;
    //    }
}
