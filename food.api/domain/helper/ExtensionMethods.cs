using System;
using System.ComponentModel;
using System.Linq;

namespace domain.helper
{
    public static class ExtensionMethods
    {
        public static string ToDescription(this Enum en)
        {
            var type = en.GetType();

            var memInfo = type.GetMember(en.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                var attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false).ToList();

                if (attrs != null && attrs.Count > 0)
                    return ((DescriptionAttribute)attrs[0]).Description.ToLower();
            }

            return en.ToString();
        }
    }
}
