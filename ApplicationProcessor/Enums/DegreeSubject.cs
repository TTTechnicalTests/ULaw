namespace ULaw.ApplicationProcessor.Enums
{
    using System.ComponentModel;

    public enum DegreeSubjectEnum : int
    {
        [DescriptionAttribute("Law")]
        law,
        [DescriptionAttribute("Law and Business")]
        lawAndBusiness,
        [DescriptionAttribute("Maths")]
        maths,
        [DescriptionAttribute("English")]
        English
    }
}
