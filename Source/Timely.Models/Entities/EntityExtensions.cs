namespace Timely.Models.Entities
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public static class EntityExtensions
    {
        public static T Clone<T>(this T source) where T : Entity, new()
        {
            T clone = new T();
            foreach (PropertyInfo property in GetProperties(source))
            {
                object sourceValue = property.GetValue(source);
                property.SetValue(clone, sourceValue);
            }
            return clone;
        }

        private static IEnumerable<PropertyInfo> GetProperties(object target)
        {
            return target.GetType().GetProperties().Where(p => p.CanRead && p.CanWrite);
        }
    }
}