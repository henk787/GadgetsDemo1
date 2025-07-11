namespace Gadgets.Domain;

public enum GadgetType
{    
    Unknown = 0,
    Tricorder,


}

public class Gadget
{
    private Gadget()
    {
        SerialNo = "<new>";
    }

    public Gadget(GadgetType type, string serialNo)
    {
        Type = type;
        SerialNo = serialNo;
    }

    public int GadgetId { get; private set; }

    public GadgetType Type { get; private set; }

    public string SerialNo { get; private set; }    

}
