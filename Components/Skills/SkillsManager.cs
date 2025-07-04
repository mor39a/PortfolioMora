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

namespace PortfolioMora.Components.Skills {

    public struct Skill {
        public string type;
        public Dictionary<string, string> typeTranslations;
        public string iconName;
        public string url;
    }

    public class SkillsManager {

        #region Private Declarations

        private readonly IWebHostEnvironment env;
        private readonly ILogger<SkillsManager> logger;
        private List<Skill> skills;

        #endregion

        #region Properties

        public List<Skill> Skills { get => skills; }
        public List<string> SkillTypes { get => skills.Select(t => t.type).Distinct().ToList(); }

        #endregion

        #region Header

        public SkillsManager(IWebHostEnvironment env, ILogger<SkillsManager> logger) {
            this.env = env;
            this.logger = logger;
            skills = new();
            ReadFile();
        }

        #endregion

        #region Private Procedures

        private void ReadFile() {
            try {
                string path = Path.Combine(env.WebRootPath, "Resources", "Skills", "Info.skl");
                if (File.Exists(path)) {
                    using (StreamReader sr = new StreamReader(path)) {
                        string line;
                        string skillsType = null!;
                        Dictionary<string, string> typeTranslations = new();
                        skills.Clear();
                        while ((line = sr.ReadLine()!) != null) {
                            if (line.StartsWith('#')) {
                                string[] aSkillType = line.Replace("#", null).Trim().Split(";;");
                                skillsType = aSkillType[0];
                                typeTranslations = new();
                                foreach (string t in aSkillType) {
                                    if (t == skillsType) continue;
                                    string[] translation = t.Split(':');
                                    if (translation.Length > 1) {
                                        typeTranslations.Add(translation[0], translation[1]);
                                    }
                                }
                                continue;
                            } else if (skillsType == null || string.IsNullOrWhiteSpace(line)) continue;
                            string[] aLine = line.Split('=');
                            Skill skill = new();
                            skill.type = skillsType;
                            if (typeTranslations.Count > 0) skill.typeTranslations = typeTranslations;
                            skill.iconName = aLine[0];
                            if (aLine.Length > 1) skill.url = aLine[1].Replace("\"", null);
                            skills.Add(skill);
                            logger.LogTrace($"Added {skill.iconName} to {skill.type}");
                        }
                    }
                } else {
                    logger.LogCritical($"Path {path} dont found.");
                }
            } catch (Exception e) {
                logger.LogCritical("Error: " + e.Message);
            }
        }

        #endregion

    }
}
