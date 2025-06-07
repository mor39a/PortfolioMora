/*---------------------------------------------
    
    Copyright (c) 2025 Santiago Mora Pacheco

    This file is under the MIT license.
    See the LICENSE file for more details.

---------------------------------------------*/

namespace PortfolioMora.Components.Pages {
    public partial class Curriculum {

        #region Private Declarations

        private readonly string componentName = "CV";
        private string pathName = "./Resources/PDFs/CV.en.pdf";
        private int viewer = 0;

        #endregion

        #region Protected Override Procedures

        protected override async Task OnInitializedAsync() {
            Language.LanguageChanged += () => { pathName = $"./Resources/PDFs/CV.{Language.Lang}.pdf"; InvokeAsync(StateHasChanged); };
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
