using BlazorWEB.Shared;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;


namespace BlazorWEB.Services;

public interface IAccountService
{
    public Task<string> GetErrorString();
    public List<TWord> GetDictionary();

    public Task<int> Load(LangT lantT);
    //public Task<UserRecord> DoLogin(Login login);
    //public Task<UserRecord> Register(AddUser login);
    public bool IsServerDown { get; set; }
    //public WordSource WordSource { get; }
    //public string GetInfoString { get; }
}



class AccountService : IAccountService
{

    HttpClient? Http { get => Program._Http; }
    private string BaseUrl
    {
        get => Http?.BaseAddress?.ToString() + @"WeatherForecast/";
    }

    public bool IsServerDown { get; set; } = false;
    //public WordSource WordSource { get; set; } = WordSource.Default;

    public async Task<string> GetErrorString()
    {
        try
        {
            if (Http==null)
                return "";
            string uri = BaseUrl + @"GetErrorString";
            var s = await Http.GetStringAsync(uri);
            return s;
        }
        catch (Exception)
        {
            return "";
        }

    }

    private static   Dictionary<LangT, List<TWord>>  LstLang = new();

    public List<TWord> GetDictionary()
    {
        // New stuff
        List<TWord> lst = new ();
        LangT langT = Program.BaseDataObj.LangT;
        if (!LstLang.ContainsKey(langT))
            return lst;
        
        int max = Program.Storage?._GetData().TotalWords ?? 1000;
        lst = LstLang[langT].CopyMany(0, max);   
        return lst;
    }

    public async Task<int> Load(LangT langT)
    {
        if (LstLang.ContainsKey(langT) && LstLang[langT].Count > 0)
            return 0;
DateTime dt = DateTime.Now;
        LstLang[langT] = await GetDefaultDictionary(langT);
int ms = (DateTime.Now - dt).Milliseconds;
        return ms;
    }


    private static async Task<List<TWord>> GetDefaultDictionary(LangT langT)
    {
        var  lst = await ReadData.Read(langT);
        lst = lst.Where(w => !string.IsNullOrWhiteSpace(w.FromWord) &&
                             !string.IsNullOrWhiteSpace(w.ToWord)).ToList();
        lst = lst.Distinct(new TWordItemComparer()).ToList();
        NewID();

        return lst;

        void NewID()
        { 
            int _ID = 1;
            for (int idx = 0; idx < lst.Count; idx++)
                lst[idx] = lst[idx] with { ID = _ID++ };
        }
    }
}

 