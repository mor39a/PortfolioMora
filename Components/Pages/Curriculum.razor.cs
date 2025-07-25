﻿/*---------------------------------------------
    
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

namespace PortfolioMora.Components.Pages {
    public partial class Curriculum : ComponentBase {

        #region Private Declarations

        private readonly string componentName = "CV";
        private string pathName = "/Resources/PDFs/CV.en.pdf";
        private int viewer = 0;

        #endregion

        #region Override Procedures

        protected override async Task OnInitializedAsync() {
            Language.LanguageChanged += () => { pathName = $"/Resources/PDFs/CV.{Language.Lang}.pdf"; InvokeAsync(StateHasChanged); };
            await base.OnInitializedAsync();
        }

        #endregion

        #region Private Procedures

        private string GetValueByKey(string key) {
            return Language.GetValueByKey(componentName, key);
        }

        private void ChangeViewer() {
            viewer++;
            if (viewer > 1) viewer = 0;
            StateHasChanged();
        }

        #endregion

    }
}
