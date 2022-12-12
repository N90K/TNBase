using System.IO;

namespace TNBase
{
    public class ResourceManager
    {
        private readonly string resourceDirectory;

        public ResourceManager(string resourceDirectory)
        {
            this.resourceDirectory = resourceDirectory;
        }

        public string ListenersImportTemplatePath => Path.Combine(resourceDirectory, "ListenersImportSample.csv");

        public string HelpFilePath => Path.Combine(resourceDirectory, "TNBase.chm");
    }
}
