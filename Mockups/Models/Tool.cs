using CommunityToolkit.Mvvm.ComponentModel;

namespace Mockups.Models
{
    public partial class Tool : ObservableObject
    {
        [ObservableProperty]
        private string _Name;
        [ObservableProperty]
        private int _Id;
        [ObservableProperty]
        private bool _IsDownShear;
        [ObservableProperty]
        private bool _IsUpShear;
        [ObservableProperty]
        private double _Diameter;
        [ObservableProperty]
        private double _Length;
        [ObservableProperty]
        private double _WorkingDepth;
        [ObservableProperty]
        private double _SpindleSpeed;
        [ObservableProperty]
        private ToolType _Type;
        [ObservableProperty]
        private bool _ClimbCut;
        [ObservableProperty]
        private bool _IsOutline;
        [ObservableProperty]
        private string _ToolNumber;
        [ObservableProperty]
        private int[] _MachineAssignments;

        public static IEnumerable<Tool> DefaultTools { get; } = [
            new Tool{
                Id = 0,
                Name = "3/8\" Compression Bit",
                ToolNumber = "1",
                IsDownShear = true,
                IsUpShear = true,
                Diameter = .375,
                Length = 3,
                WorkingDepth = 1.5,
                SpindleSpeed = 18000,
                Type = ToolType.Router | ToolType.Flat,
                IsOutline = true
            },
            new Tool{
                Id = 1,
                Name = "1/2\" Down Shear Bit",
                ToolNumber = "2",
                IsDownShear = true,
                IsUpShear = false,
                Diameter = .5,
                Length = 3,
                WorkingDepth = 1.5,
                SpindleSpeed = 18000,
                Type = ToolType.Router | ToolType.Flat,
                IsOutline = false
            },
            new Tool{
                Id = 3,
                Name = "5mm V Drill Bit",
                ToolNumber = "100",
                IsDownShear = false,
                IsUpShear = false,
                Diameter = 5/25.4,
                Length = 3,
                WorkingDepth = 1.5,
                SpindleSpeed = 18000,
                Type = ToolType.Drill | ToolType.Vertical,
                IsOutline = false
            },
            new Tool{
                Id = 4,
                Name = "8mm V Drill Bit",
                ToolNumber = "200",
                IsDownShear = false,
                IsUpShear = false,
                Diameter = 8/25.4,
                Length = 3,
                WorkingDepth = 1.5,
                SpindleSpeed = 18000,
                Type = ToolType.Drill | ToolType.Vertical,
                IsOutline = false
            },
            new Tool{
                Id = 5,
                Name = "5mm H Drill Bit",
                ToolNumber = "300",
                IsDownShear = false,
                IsUpShear = false,
                Diameter = 5/25.4,
                Length = 3,
                WorkingDepth = 1.5,
                SpindleSpeed = 18000,
                Type = ToolType.Drill | ToolType.Horizontal,
                IsOutline = false
            },
            new Tool{
                Id = 6,
                Name = "8mm H Drill Bit",
                ToolNumber = "400",
                IsDownShear = false,
                IsUpShear = false,
                Diameter = 8/25.4,
                Length = 3,
                WorkingDepth = 1.5,
                SpindleSpeed = 18000,
                Type = ToolType.Drill | ToolType.Horizontal,
                IsOutline = false
            },
            new Tool{
                Id = 7,
                Name = "Thin Kerf Saw",
                ToolNumber = "SAW1",
                IsDownShear = false,
                IsUpShear = false,
                Diameter = 0625,
                Length = 5,
                WorkingDepth = 2.5,
                SpindleSpeed = 18000,
                Type = ToolType.Saw,
                IsOutline = false
            },
            new Tool{
                Id = 8,
                Name = "Thick Kerf Saw",
                ToolNumber = "SAW1",
                IsDownShear = false,
                IsUpShear = false,
                Diameter = .125,
                Length = 5,
                WorkingDepth = 2.5,
                SpindleSpeed = 18000,
                Type = ToolType.Saw,
                IsOutline = false
            }
        ];
    }
}
