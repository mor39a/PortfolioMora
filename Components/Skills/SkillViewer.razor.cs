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

namespace PortfolioMora.Components.Skills {
    public partial class SkillViewer : ComponentBase {

        #region Parameters

        [Parameter]
        public string SkillType { get; set; } = "Skill";

        [Parameter]
        public List<Skill> Skills { get; set; } = new();

        #endregion

        #region Private Procedures

        private string GetIconPath(string iconName) => $"./Resources/Skills/Images/{GetIconFileName(iconName)}.png";
        private string GetIconFileName(string iconName) => iconName.Trim().Replace(' ', '-').Replace("#", "sharp").ToLower();

        private async Task OpenLink(string url) {
            if (string.IsNullOrEmpty(url)) return;
            await jsRuntime.InvokeVoidAsync("window.open", url, "_blank", "noopener");
        }

        #endregion

    }
}
