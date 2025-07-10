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

namespace PortfolioMora.Components.Technologies {
    public partial class TechnologiesButton : ComponentBase {

        #region Parameters

        [Parameter]
        public string TechnologyName { get; set; } = "Technology Name";

        [Parameter]
        public string? TechnologyLink { get; set; }

        #endregion

        #region Private Declarations

        private string? IconPath;

        #endregion

        #region Private Procedures

        private bool ExistPath() {
            bool res = false;
            string nameFile = $"{TechnologyName.Replace("#", "sharp").Trim().ToLower().Replace(' ', '-')}.svg";
            string path = Path.Combine(env.WebRootPath, "Resources", "Technologies", nameFile);
            if (File.Exists(path)) {
                IconPath = $"./Resources/Technologies/{nameFile}";
                res = true;
            } else {
                logger.LogWarning($"Path {path} dont found. The technology will be displayed without a logo.");
            }
            return res;
        }

        private async Task OpenLink() {
            if (string.IsNullOrEmpty(TechnologyLink)) return;
            await jsRuntime.InvokeVoidAsync("window.open", TechnologyLink, "_blank", "noopener");
        }

        #endregion

    }
}
