using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Reflection;

namespace App.Common.Classes.Helpers
{
    public static class GenerericHelpers
    {
        public static object? GetPropertyValue(this object entity, string propertyName)
        {
            PropertyInfo propertyInfo = entity.GetType().GetProperties().FirstOrDefault((PropertyInfo c) => c.Name.Equals(propertyName));

            if (propertyInfo != null)
            {
                return propertyInfo.GetValue(entity, null);
            }

            return null;
        }

        public static object? GetPrimaryKeyValue(this object entity)
        {
            return entity.GetPropertyValue("Id");
        }


    } 
}