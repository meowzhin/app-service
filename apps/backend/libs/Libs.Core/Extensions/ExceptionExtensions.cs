namespace FwksLab.Libs.Core.Extensions;

public static class ExceptionExtensions
{
    public static IEnumerable<string> ExtractMessages(this Exception ex)
    {
        var messages = new List<string>();

        while (ex != null)
        {
            messages.Add(ex.Message);

            ex = ex.InnerException!;
        }

        return messages;
    }
}