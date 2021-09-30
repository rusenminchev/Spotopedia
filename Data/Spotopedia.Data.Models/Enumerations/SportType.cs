namespace Spotopedia.Data.Models.Enumerations
{
    using System.ComponentModel;

    public enum SportType
    {
        Rollerblading = 1,
        [Description("Inline Skating")] InlineSkating = 2,
        BMX = 3,
        Skateboarding = 4,
        Longboarding = 5,
        Scooter = 6,
    }
}
