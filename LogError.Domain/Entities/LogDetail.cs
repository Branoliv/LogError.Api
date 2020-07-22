namespace LogError.Domain.Entities
{
    public class LogDetail : EntityBase
    {
        protected LogDetail() { }
        public LogDetail(string detail,LogInfo logInfo)
        {
            Detail = detail;
            LogInfo = logInfo;
        }

        public string Detail { get; private set; }

        public LogInfo LogInfo { get; private set; }
    }
}
