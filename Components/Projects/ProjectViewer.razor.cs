/*---------------------------------------------
    
    Copyright (c) 2025 Santiago Mora Pacheco

    This file is under the MIT license.
    See the LICENSE file for more details.

---------------------------------------------*/

using Microsoft.AspNetCore.Components;

namespace PortfolioMora.Components.Projects {
    public partial class ProjectViewer {

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
