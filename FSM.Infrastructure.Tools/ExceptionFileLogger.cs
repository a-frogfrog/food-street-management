using FSM.Infrastructure.Attribute;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace FSM.Infrastructure.Tools
{
    /// <summary>
    /// This class is used to log exceptions to a file.
    /// </summary>
    [Provider, Inject]
    public class ExceptionFileLogger
    {
        public void LogAsync(string filePath, Exception exception)
        {
            string info = Format(exception);
            // Log to file
            WriteToFileAsync(filePath, info);

        }

        private static string Format(Exception exception)
        {
            var sb = new StringBuilder();
            sb.AppendLine("------------------------ Log Start ------------------------");
            sb.AppendLine($"Date: {DateTime.Now}");
            sb.AppendLine($"Type: {exception.GetType()}");
            sb.AppendLine($"Message: {exception.Message}");
            sb.AppendLine($"Source: {exception.Source}");
            sb.AppendLine($"Stack Trace: {exception.StackTrace}");
            sb.AppendLine("------------------------ Log End ------------------------\n\n");
            return sb.ToString();
        }

        private static void WriteToFileAsync(string filePath, string content)
        {
            File.WriteAllTextAsync($"{filePath}.txt", content);
        }
    }
}
