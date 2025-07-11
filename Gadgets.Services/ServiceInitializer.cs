using Gadgets.Domain;
using Gadgets.Persistence;

namespace Gadgets.Services;

public class ServiceInitializer(GadgetsDbContext GadgetsContext)
{
    public void InitializeData(int numberOfGadgets)
    {
        GadgetType[] types = Enum.GetValues<GadgetType>();

        char[] PrefixChars = ['A', 'B', 'C', 'D', 'K', 'P', 'Q', 'X', 'Z'];

        for (int i = 0; i < numberOfGadgets; i++)
        {
            GadgetType type = types[Random.Shared.Next(1, types.Length)];

            string serial = $"{Prefix()}{Prefix()}{Random.Shared.Next(100, 654321):D6}";

            Gadget gadget = new(type, serial);

            GadgetsContext.Add(gadget);
        }

        GadgetsContext.SaveChanges();

        char Prefix() => PrefixChars[Random.Shared.Next(PrefixChars.Length)];
    }

}
