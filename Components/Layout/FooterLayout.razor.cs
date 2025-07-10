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
using Microsoft.JSInterop;

namespace PortfolioMora.Components.Layout {
    public partial class FooterLayout : ComponentBase {

        #region Private Declarations

        private readonly string componentName = "Footer";
        private string curriculumPathName = "./Resources/PDFs/CV.en.pdf";

        #endregion

        #region Override Procedures

        protected override async Task OnInitializedAsync() {
            Language.LanguageChanged += () => { curriculumPathName = $"./Resources/PDFs/CV.{Language.Lang}.pdf"; InvokeAsync(StateHasChanged); };
            await base.OnInitializedAsync();
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

        private async Task OpenPageNewWindows(string page) {
            await jsRuntime.InvokeVoidAsync("window.open", page, "_blank", "noopener");
        }

        #endregion

    }
}
