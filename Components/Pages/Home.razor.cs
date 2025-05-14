using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace PortfolioMora.Components.Pages {
    public partial class Home {

        #region Private Declarations

        private readonly string componentName = "Home";

        #endregion

        #region Protected Override Procedures

        protected override async Task OnInitializedAsync() {
            Language.LanguageChanged += () => InvokeAsync(StateHasChanged);
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
