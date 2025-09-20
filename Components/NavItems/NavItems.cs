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

using System.Collections.Specialized;

namespace PortfolioMora.Components.NavItems {

    public class NavItems : List<NavItem> {
        public void deactivateAll() => ForEach(item => item.Active = false);
    }

    public class NavItem {
        #region Properties

        public string Name { get; set; }

        private bool active = false;
        public bool Active {
            get => active;
            set {
                if (active = value == true) {
                    StateChanged?.Invoke();
                }
            }
        }

        public string href { get; set; }

        #endregion

        #region Public Events

        public event Action? StateChanged;

        #endregion

        #region Builder

        public NavItem(string name, string href, bool active = false) {
            Name = name;
            this.href = href;
            Active = active;
        }

        #endregion
    }
}
