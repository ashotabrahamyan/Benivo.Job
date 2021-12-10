using System.ComponentModel;

namespace BenivoJob.Application.Enums
{
    public enum EmploymentType
    {
        [Description("Full Time")]
        FullTime,
        [Description("Part Time")]
        PartTime,
        [Description("Contractor")]
        Contractor,
        [Description("Intern")]
        Intern,
        [Description("Seasonal/Temp")]
        Seasonal
    }
}
