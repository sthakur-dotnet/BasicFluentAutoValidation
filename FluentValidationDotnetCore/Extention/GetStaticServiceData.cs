namespace FluentValidationDotnetCore.Extention;

public static class GetStaticServiceData
{
    public static List<string> GetSummary(this IServiceProvider serviceProvider)
    {
       return serviceProvider.GetService<List<string>>();
    }
}