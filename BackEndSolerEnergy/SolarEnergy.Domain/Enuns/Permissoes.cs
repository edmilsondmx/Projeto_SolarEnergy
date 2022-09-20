using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace SolarEnergy.Domain.Enuns;

public enum Permissoes
{
    [Display(Name = "Admin")]
    Admin = 1,
    [Display(Name = "User")]
    User
}

public static class EnumExtensions
{
    public static string GetName(this Enum enumValue)
    {
        string displayName;
        displayName =  enumValue.GetType()
        .GetMember(enumValue.ToString())
        .First()
        ?.GetCustomAttribute<DisplayAttribute>()
        ?.GetName();
        
        if (String.IsNullOrEmpty(displayName))
        {
            displayName = enumValue.ToString();
        }
        return displayName;
    }
}