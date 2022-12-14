using Microsoft.JSInterop;
namespace BlazorWEB.Services;

public class BrowserService
{
    private readonly IJSRuntime _js;
    public BrowserService(IJSRuntime js)
    {
        _js = js;
    }
    public BrowserDimension GetDimensions()
    {
        return ((IJSInProcessRuntime)_js).Invoke<BrowserDimension>("getDimensions");
    }

    public string GetTitle()
    {
        // return "HELLO";
        return ((IJSInProcessRuntime)_js).Invoke<string>("getTitle");
    }
}

public class BrowserDimension
{
    public int Width { get; set; }
    public int Height { get; set; }
}

