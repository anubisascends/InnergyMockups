namespace Mockups.Models
{
    [Flags]
    public enum ToolType
    {
        Router = 0x01,
        Saw = 0x02,
        Drill = 0x04,

        Flat = 0x100,
        BallEnd = 0x200,
        Shaped = 0x400,

        Vertical = 0x1000,
        Horizontal = 0x2000
    }
}
