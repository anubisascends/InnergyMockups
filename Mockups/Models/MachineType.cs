namespace Mockups.Models
{
    [Flags]
    public enum MachineType
    {
        Router = 0x01,
        Saw = 0x02,

        Sheet = 0x10,
        Part = 0x20
    }
}
