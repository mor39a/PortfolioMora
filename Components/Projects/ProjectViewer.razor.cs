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

namespace PortfolioMora.Components.Projects {
    public partial class ProjectViewer : ComponentBase {

        #region Parameters

        [Parameter]
        public string ProjectName { get; set; } = "Project Name";

        [Parameter]
        public string? ProjectState { get; set; } = null;

        [Parameter]
        public string ProjectDescription { get; set; } = "Project Description";

        [Parameter]
        public string[] ProjectTechnologies { get; set; } = { "Project Technologies" };

        [Parameter]
        public string ProjectPhotoName { get; set; } = "Project Photo Path";

        #endregion        

    }
}
