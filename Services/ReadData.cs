namespace BlazorWEB.Services;

public static class ReadData
{
    static public async Task<List<TWord>> Read(LangT lang)
    {
        string file = "";
        List<TWord> lst = new();

        if (lang == LangT.SpanishNorwegian)
            file = "SPANSK_NORSK_V1.CSV";
        if (lang == LangT.GermanNorwegian)
            file = "TYSK_NORSK_V2.CSV";
        if (lang == LangT.FrenchNorwegian)
            file = "FRANSK_NORSK.CSV";

        if (file.IsEmpty())
            return lst;

        int nError;

        HttpClient? http = Program._Http;
        if (http == null)
            return lst;
        try
        {
            var str = await http.GetStringAsync(file);
            var reader = new StringReader(str);
            nError = -1;
            string? s;
            while ((s = reader.ReadLine()) != null)
            {
                var a = s.Split(",");
                try
                {
                    TWord tw = new
                    (
                        int.Parse(a[0]),
                        _T(a[1]),
                        _T(a[2]),
                        _T(a.GetAtSafe(3)),
                        _T(a.GetAtSafe(4)),
                        _T(a.GetAtSafe(5))
                    );

                    lst.Add(tw);
                }
                catch (Exception)
                {
                    nError++;
                }
            }
        }
        catch (Exception)
        {
        }
        return lst;
        static string _T(string s)
        {
            return s?.Trim(' ', '"', '_', '%') ?? "";
        }
    }

}
