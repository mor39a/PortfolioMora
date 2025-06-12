/*---------------------------------------------
    
    Copyright (c) 2025 Santiago Mora Pacheco

    This file is under the MIT license.
    See the LICENSE file for more details.

---------------------------------------------*/

using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;

namespace PortfolioMora.Components.Technologies {
    public partial class TechnologiesButton {

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
                logger.LogError($"Path {path} dont found.");
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
