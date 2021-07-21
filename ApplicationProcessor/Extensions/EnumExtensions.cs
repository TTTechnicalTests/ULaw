namespace ULaw.ApplicationProcessor
{
    using System;
    using System.ComponentModel;
    using System.Linq;

    static class EnumExtensions
    {
        public static string ToDescription(this Enum enumeration)
        {
            var enumerationType = enumeration.GetType();
            var enumerationName = Enum.GetName(enumerationType, enumeration);

            var memberInfo = enumerationType.GetMember(enumerationName).FirstOrDefault();

            if (memberInfo != null)
            {
                var descriptionAttribute = (DescriptionAttribute)memberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault();

                if (descriptionAttribute != null)
                {
                    return descriptionAttribute.Description;
                }
            }

            return enumerationName;
        }
    }
}
