using System;

namespace CCMS.Infrastructure.Shared
{
    public static class EnumHelper
    {      
        public static T ToEnum<T>(this object stringOrInt) where T : struct, IConvertible
        {
            return (T)Enum.Parse(typeof(T), stringOrInt.ToString(), true);
        }
           
        public static bool TryToEnum<T>(string enumString, out T output) where T : struct, IConvertible
        {
            if (String.IsNullOrEmpty(enumString) || !typeof(T).IsEnum) throw new Exception("Type given must be an Enum");
            try
            {
                output = enumString.ToEnum<T>();
                return true;
            }
            catch
            {
                output = default(T);
                return false;
            }
        }
    }
}
