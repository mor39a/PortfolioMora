namespace PortfolioMora.Components.Layout {
    public partial class NavMenu {

        #region Private Declarations

        private string? activeAboutMe;
        private string? activeProjects;
        private string? activeSkills;
        private string? activeCurriculum;
        private string? activeContact;

        private readonly string componentName = "NavMenu";
        private string selectedLanguage = "en";
        private string SelectedLanguage { get => selectedLanguage; set { Task.Run(() => Language.ChangeLanguage(value)); selectedLanguage = value; } }
        private List<string> availableLanguages = new List<string> { "en", "es" };

        #endregion

        #region Protected Override Proceedures

        protected override void OnInitialized() {
            Language.LanguageChanged += () => { selectedLanguage = Language.Lang; InvokeAsync(StateHasChanged); };
            base.OnInitialized();
        }

        #endregion

        #region Private Procedures

        private void _active(string elemento) {
            string active = "active";
            activeAboutMe = activeProjects = activeSkills = activeContact = "";
            switch (elemento) {
                case "about":
                    activeAboutMe = active;
                    break;
                case "projects":
                    activeProjects = active;
                    break;
                case "skills":
                    activeSkills = active;
                    break;
                case "curriculum":
                    activeCurriculum = active;
                    break;
                case "contact":
                    activeContact = active;
                    break;
            }
        }

        private string GetValueByKey(string key) {
            return Language.GetValueByKey(componentName, key);
        }

        #endregion

    }
}
