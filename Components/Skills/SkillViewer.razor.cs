/*---------------------------------------------
    
    Copyright (c) 2025 Santiago Mora Pacheco

    This file is under the MIT license.
    See the LICENSE file for more details.

---------------------------------------------*/

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR;
using Microsoft.JSInterop;

namespace PortfolioMora.Components.Skills {
    public partial class SkillViewer {

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
