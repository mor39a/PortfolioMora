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

using Microsoft.JSInterop;
using PortfolioMora.Components.NavItems;

namespace PortfolioMora.Components.Layout {
    public partial class MainLayout {

        protected override void OnInitialized() {
            if (NavItems.Count == 0) {
                NavItems.Add(new NavItem("about", "#about-me", true));
                NavItems.Add(new NavItem("projects", "#projects"));
                NavItems.Add(new NavItem("skills", "#skills"));
                NavItems.Add(new NavItem("Curriculum", "/Curriculum"));
                //NavItems.Add(new NavItem("contact", "#contact"));
            }            
            base.OnInitialized();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender) {
            if (firstRender) {
                await Language.GetBrowserLanguage(jsRuntime);
                await jsRuntime.InvokeVoidAsync("initializeContainerHeight");
            }
            await base.OnAfterRenderAsync(firstRender);
        }

    }
}
