/*---------------------------------------------
    
    Copyright (c) 2025 Santiago Mora Pacheco

    This file is under the MIT license.
    See the LICENSE file for more details.

---------------------------------------------*/

using Microsoft.JSInterop;
using PortfolioMora.Components.Projects;

namespace PortfolioMora.Components.Pages {
    public partial class Home {

        #region Private Declarations

        private readonly string componentName = "Home";
        private Components.Projects.Projects? projects;

        #endregion

        #region Protected Override Procedures

        protected override void OnInitialized() {
            projects = ProjectManager.GetProjects(Language.Lang);
            Language.LanguageChanged += () => { projects = ProjectManager.GetProjects(Language.Lang); InvokeAsync(StateHasChanged); };
            base.OnInitialized();
        }

        #endregion

        #region Public Procedures

        public void Dispose() {
            Language.LanguageChanged -= () => InvokeAsync(StateHasChanged);
        }

        #endregion

        #region Private Procedures

        private string GetValueByKey(string key) {
            return Language.GetValueByKey(componentName, key);
        }

        #endregion

    }
}
