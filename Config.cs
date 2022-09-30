namespace BlazorWEB;
public enum Order { Alfabetic, Sequental, Random, Artif_Int };
public enum Auto { Auto500ms = 500, Auto1s = 1000, Auto2s = 2000, Auto3s = 3000, Auto5s = 5000, Manual = 0 };
public enum Mode { Scrolling, OneByOne, All_Time, All_Now, All_Man };
public enum WordSource { LocalStore, Server, Default };

// State variables 
[Serializable]
public struct Data
{
    public Mode Mode { get; set; }
    public Mode ModeTest { get; set; }

    public Order Order { get; set; }
    public Order OrderTest { get; set; }
    public Auto Auto { get; set; }
    public int MsTest { get; set; }
    public int MsPugg { get; set; }
    public int MsBlink { get; set; }
    public int NumBatch { get; set; }
    public int TotalWords { get; set; }
    public int IdxStart { get; set; }
    public int Step { get; set; }

    public string Info { get; set; }

    public char Letter { get; set; }

    public int NumPanels { get; set; }

    public int SmileyIndex { get; set; }

    public void Default()
    {
        Mode = (Mode.All_Now);
        Order = (Order.Sequental);
        ModeTest = (Mode.OneByOne);
        OrderTest = (Order.Sequental);
        Auto = (Auto.Auto2s);
        MsTest = 2000;
        MsPugg = 2000;
        MsBlink = 2000;
        NumBatch = 6;
        NumPanels = 1;
        TotalWords = 250;
        IdxStart = 0;
        Step = 10;
        SmileyIndex = 5;
        Letter = 'A';
    }

}


