/*---------------------------------------------
    
    Copyright 2025 Santiago Mora Pacheco

    Licensed under the Apache License, Version 2.0 (the "License");
    you may not use this file except in compliance with the License.
    You may obtain a copy of the License at

        http://www.apache.org/licenses/LICENSE-2.0

    Unless required by applicable law or agreed to in writing, software
    distributed under the License is distributed on an "AS IS" BASIS,
    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
    See the License for the specific language governing permissions and
    limitations under the License.

---------------------------------------------*/

using Microsoft.AspNetCore.Components;

namespace PortfolioMora.Components.Layout {
    public partial class NavMenu : ComponentBase {

        #region Private Declarations

        private bool isToggler;
        private string? activeAboutMe = "active";
        private string? activeProjects;
        private string? activeSkills;
        private string? activeCurriculum;
        private string? activeContact;

        private readonly string componentName = "NavMenu";
        private string selectedLanguage = "en";
        private string SelectedLanguage { get => selectedLanguage; set { Task.Run(() => Language.ChangeLanguage(value)); selectedLanguage = value; } }
        private List<string> availableLanguages = new List<string> { "en", "es" };

        #endregion

        #region Override Procedures

        protected override void OnInitialized() {
            Language.LanguageChanged += () => { selectedLanguage = Language.Lang; InvokeAsync(StateHasChanged); };
            base.OnInitialized();
        }

        #endregion

        #region Private Procedures

        private void _active(string elemento) {
            string active = "active";
            activeAboutMe = activeProjects = activeSkills = activeCurriculum = activeContact = "";
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

        private void ChangeLanguage(string lang) {
            SelectedLanguage = lang;
        }

        #endregion

    }
}
