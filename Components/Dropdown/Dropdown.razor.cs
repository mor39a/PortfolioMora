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

namespace PortfolioMora.Components.Dropdown {
    public partial class Dropdown<T> : ComponentBase where T : notnull {

        #region Parameters

        #region Select

        [Parameter]
        public List<(T, string)>? Options { get; set; }

        [Parameter]
        public EventCallback<T> OnSelected { get; set; }

        [Parameter]
        public string? ItemSelected { get; set; }

        #endregion

        #region Body

        [Parameter]
        public string Width { get; set; } = "fit-content";

        [Parameter]
        public string Height { get; set; } = "fit-content";

        [Parameter]
        public string PaddingBlock { set; get; } = "0px";

        [Parameter]
        public string PaddingInline { get; set; } = "10px";

        #endregion

        #endregion

        #region Private Declarations

        private bool open = false;

        #endregion

        #region Override Procedures

        protected override void OnParametersSet() {
            if (Options != null && ItemSelected == null)
                ItemSelected = Options.FirstOrDefault().Item2;
            base.OnParametersSet();
        }

        #endregion

        #region Private Procedures

        private async Task OnItemSelecte((T, string) Item) {
            ItemSelected = Item.Item2;
            open = false;
            await OnSelected.InvokeAsync(Item.Item1);
            StateHasChanged();
        }

        #endregion

    }
}
