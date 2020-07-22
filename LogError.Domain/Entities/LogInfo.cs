using System.Collections.Generic;

namespace LogError.Domain.Entities
{
    public class LogInfo : EntityBase
    {
        protected LogInfo() { }
        public LogInfo(string title, string level, string tokenSource, string source)
        {
            Title = title;
            Level = level;
            TokenSource = tokenSource;
            Source = source;
        }

        public string Title { get; set; }
        public string Level { get; set; }
        public string TokenSource { get; set; }
        public string Source { get; set; }
        public ICollection<LogDetail> LogDetails { get; set; }
    }
}
