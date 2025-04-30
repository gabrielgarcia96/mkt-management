using System.Resources;

public static class Loc
{
    public static string Get(string key, string culture)
    {
        var cultureInfo = new System.Globalization.CultureInfo(culture);
        var resourceManager = new ResourceManager("Marketing.App.Resources.SharedResources", typeof(Loc).Assembly);
        return resourceManager.GetString(key, cultureInfo) ?? key;
    }
}
