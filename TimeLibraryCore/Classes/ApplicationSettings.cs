using System.Collections.Generic;

namespace TimeLibraryCore.Classes
{
    public class ApplicationSettings
    {
        /// <summary>
        /// Defines which connection to use, development or production.
        /// In some cases there should be a test environment too.
        /// </summary>
        public string DefaultConnection { get; set; }
        public List<DatabaseConnection> Connections;
        public MailSettings MailSettings { get; set; }

    }
}