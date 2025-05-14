using Microsoft.JSInterop;

namespace PortfolioMora.Components.Languages {
    public class LanguagesManager {

        #region Properties

        private string lang = "en";
        public string Lang { 
            get { return lang; }
        }

        #endregion

        #region Private Declarations

        private readonly IWebHostEnvironment env;
        private readonly ILogger<LanguagesManager> logger;
        private IJSRuntime jsRuntime;
        private LanguageValues languageValues;

        #endregion

        #region Public Events

        public event Action? LanguageChanged;

        #endregion

        #region Builder

        public LanguagesManager(IWebHostEnvironment env, ILogger<LanguagesManager> logger) {
            this.env = env;
            this.logger = logger;
            languageValues = new();
            jsRuntime = null!;
        }

        #endregion

        #region Public Procedures

        public async Task GetBrowserLanguage(IJSRuntime jsRuntime) {
            this.jsRuntime = jsRuntime;
            await ChangeLanguage((await jsRuntime.InvokeAsync<string>("getBrowserLanguage")).Split('-')[0].ToLower());
        }

        public async Task ChangeLanguage(string language) {
            lang = language;
            await ReadFile();
            logger.LogInformation($"Language changed to \"{lang}\".");
            LanguageChanged?.Invoke();
        }

        public string GetValueByKey(string componentName, string key) {
            if (jsRuntime == null) Task.Run(ReadFile).Wait();
            string value = languageValues.GetValue(componentName, key);
            return value;
        }

        #endregion

        #region Private Declarations

        private async Task ReadFile() { //ToDo async foreach
            try {
                string path = Path.Combine(env.WebRootPath, "Resources", "Languages", $"{Lang}.lng");
                if (jsRuntime != null) await jsRuntime.InvokeVoidAsync("setHtmlLang", Lang);
                if (File.Exists(path)) {
                    languageValues = new();
                    using (StreamReader sr = new StreamReader(path)) {
                        string line;
                        while ((line = sr.ReadLine()!) != null) {
                            logger.LogTrace("Reading: " + line);
                            string[] aLine = line.Split(";;");
                            if (aLine.Length < 3) continue;
                            languageValues.Add(aLine[0], aLine[1], aLine[2]);
                            logger.LogTrace($"Added {aLine[0]}.{aLine[1]} = \"{aLine[2]}\".");
                        }
                    }
                } else {
                    logger.LogError($"Path {path} dont found.");
                }              
            }
            catch (Exception e) {
                logger.LogError("Error: " + e.Message);
            }
        }

        #endregion

        #region Classes

        private class LanguageValues {
            private List<LanguageValue> languageValues;

            public LanguageValues() {
                languageValues = new();
            }

            public void Add(string componentName, string key, string value) {
                LanguageValue languageValue = new LanguageValue(componentName, key, value);
                languageValues.Add(languageValue);
            }

            public string GetValue(string componentName, string key) {
                foreach(LanguageValue languageValue in languageValues) {
                    if (languageValue.componentName == componentName && languageValue.key == key) {
                        return languageValue.value;
                    }
                }
                return key;
            }

            private class LanguageValue {
                internal string componentName;
                internal string key;
                internal string value;

                public LanguageValue(string componentName, string key, string value) {
                    this.componentName = componentName;
                    this.key = key;
                    this.value = value;
                }
            }
        }

        #endregion
    }    
}
