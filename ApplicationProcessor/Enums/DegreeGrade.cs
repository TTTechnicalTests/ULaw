namespace ULaw.ApplicationProcessor.Enums
{
    using System.ComponentModel;

    public enum DegreeGradeEnum : int
    {
        [DescriptionAttribute("1st")]
        first,
        [DescriptionAttribute("2:1")]
        twoOne,
        [DescriptionAttribute("2:2")]
        twoTwo,
        [DescriptionAttribute("3rd")]
        third
    }
}
