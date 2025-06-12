/*---------------------------------------------
    
    Copyright (c) 2025 Santiago Mora Pacheco

    This file is under the MIT license.
    See the LICENSE file for more details.

---------------------------------------------*/

using Microsoft.AspNetCore.Components;
using PortfolioMora.Components.Projects;

namespace PortfolioMora.Components.Pages {
    public partial class Project {

        #region Parameters

        [Parameter]
        public string? projectName { get; set; }

        #endregion

        #region Private Declarations

        private readonly string componentName = "Project";
        private Components.Projects.Project? project;

        #endregion

        #region Protected Override Procedures

        protected override void OnInitialized() {
            Language.LanguageChanged += () => { project = ProjectManager.GetProjects(Language.Lang).Get(projectName!); InvokeAsync(StateHasChanged); };
            base.OnInitialized();
        }

        protected override void OnAfterRender(bool firstRender) {
            if (firstRender) {
                if (string.IsNullOrEmpty(projectName)) {
                    Navigation.NavigateTo("/Projects");
                    return;
                }
                project = ProjectManager.GetProjects(Language.Lang).Get(projectName);
                StateHasChanged();
            }            
            base.OnAfterRender(firstRender);
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
