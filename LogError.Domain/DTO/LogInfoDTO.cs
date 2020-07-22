using System.Collections.Generic;

namespace LogError.Domain.DTO
{
    public class LogInfoDTO
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Level { get; set; }
        public string TokenSource { get; set; }
        public string Source { get; set; }
        public  List<LogDetailDTO> LogDetails { get; set; }
    }
}
