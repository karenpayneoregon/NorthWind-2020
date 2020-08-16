namespace TimeLibraryCore.Classes
{
    /// <summary>
    /// Email settings
    /// </summary>
    public class MailSettings
    {
        public string From { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public override string ToString() => Host;
    }
}