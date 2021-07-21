namespace ULaw.ApplicationProcessor.Enums
{
    using System.ComponentModel;

    public enum DegreeSubject : byte
    {
        [Description("Law")]
        Law,
        [Description("Law and Business")]
        LawAndBusiness,
        [Description("Maths")]
        Maths,
        [Description("English")]
        English
    }
}
