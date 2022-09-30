using Microsoft.JSInterop;
using BlazorWEB.Shared;
using System.Text.Json;

namespace BlazorWEB.Services;


public interface IStorage
{
    public string Test();
    void LoadParams();

    T GetItem<T>(string key);
    void SetItem<T>(string key, T value);
    void RemoveItem(string key);
    void SetItemSync<T>(string key, T value);

    Data _GetData();
    void _SetData(Data dt);

    void Reset();
}

public class Storage : IStorage
{
    private readonly IJSInProcessRuntime _jsr;


    public Storage(IJSRuntime jsRuntime)
    {
        _jsr = (IJSInProcessRuntime)jsRuntime;
        LoadParams();
    }
    public string Test() => "Hello World";

    public void LoadParams()
    {
        try
        {
            //if (StorageCleared())
            //{

            //    return;
            //}

        }
        catch (Exception)
        {

        }
    }

    public void Reset()
    {
        _jsr.Invoke<string>("localStorage.clear");
    }

    public T GetItem<T>(string key)
    {
        try
        {
            string json = _jsr.Invoke<string>("localStorage.getItem", _p(key));
#pragma warning disable CS8603 // Possible null reference return.
            return JsonSerializer.Deserialize<T>(json);

        }
        catch (Exception) { return default; }
#pragma warning restore CS8603 // Possible null reference return.
    }

    private static string _p(string s)
    {
        if (s == Defs.keyProgramBaseData)
        {
            return s;
        }
        if (s == Defs.keyProgramVersion)
        {
            return s;
        }
        if (s == Defs.keyLevel)
        {
            return $"{Misc.LangFromLangT(Program.BaseDataObj.LangT)}{s}";
        }
        return $"{Program.BaseDataObj.LangT}{s}";
    }

    public Data _GetData()
    {
        return GetItem<Data>(Defs.keySetup);
    }


    public void _SetData(Data dt)
    {
        /*await*/
        SetItem(Defs.keySetup, dt);
    }

    public void SetItem<T>(string key, T value)
    {
        string jsonStr = JsonSerializer.Serialize(value);
        _jsr.InvokeVoid("localStorage.setItem", _p(key), jsonStr);
    }
    public void SetItemSync<T>(string key, T value)
    {
        string jsonStr = JsonSerializer.Serialize(value);
        _jsr.InvokeVoid("localStorage.setItem", _p(key), jsonStr);
    }

    public void RemoveItem(string key)
    {
        _jsr.InvokeVoid("localStorage.removeItem", _p(key));
    }
}

