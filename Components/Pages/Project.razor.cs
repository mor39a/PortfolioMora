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
