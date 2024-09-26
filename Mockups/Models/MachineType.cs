namespace Mockups.Models
{
    [Flags]
    public enum MachineType
    {
        Router = 0x01,
        Saw = 0x02,
        HDrill = 0x04,

        Sheet = 0x1000,
        Part = 0x2000
    }
}
