/*---------------------------------------------
    
    Copyright (c) 2025 Santiago Mora Pacheco

    This file is under the MIT license.
    See the LICENSE file for more details.

---------------------------------------------*/

namespace PortfolioMora.Components.Projects {
    public class ProjectsManager {

        #region Private Declarations

        private readonly IWebHostEnvironment env;
        private readonly ILogger<ProjectsManager> logger;
        private Projects projects = new();
        private string _lang = "en";
        private bool first = true;

        #endregion

        #region Header

        public ProjectsManager(IWebHostEnvironment env, ILogger<ProjectsManager> logger) {
            this.env = env;
            this.logger = logger;
        }

        #endregion

        #region Public Procedures

        public Projects GetProjects(string lang) {
            if (lang != _lang || first) {
                _lang = lang;
                ReadFile();
            }
            return projects;
        }

        public Project GetProject(string name, string lang) {
            if (lang != _lang || first) {
                _lang = lang;
                ReadFile();
            }
            return projects.Get(name);
        }

        #endregion

        #region Private Procedures

        private void ReadFile() {
            try {
                string path = Path.Combine(env.WebRootPath, "Resources", "Projects", $"{_lang}.pjc");
                if(File.Exists(path)) {
                    using (StreamReader sr = new StreamReader(path)) {
                        string line;
                        projects.Clear();
                        first = false;
                        while ((line = sr.ReadLine()!) != null) {
                            logger.LogTrace("Reading: " + line);
                            string[] aLine = line.Split(";;");
                            if (aLine.Length < 5) continue;
                            Project project = new(aLine[0], Convert.ToBoolean(aLine[1]), aLine[2], aLine[3].Split(','), (aLine.Length > 4) ? aLine[4] : null!);
                            projects.Add(project, true);
                            logger.LogTrace($"Added {aLine[0]}");
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

    public class Projects {

        #region Private Declarations

        private Dictionary<string, Project> _projects = new();
        public Dictionary<string, Project> projects { get => _projects; }

        #endregion

        #region Public Procedures

        public bool Add(string name, bool active, string description, string[] technologies, string photoName, bool force = false) {
            if (name == null) return false;
            if (_projects.ContainsKey(name)) {
                if (!force) return false;
                Remove(name);
            }
            Project newProject = new(name, active, description, technologies, photoName);
            _projects.Add(name, newProject);
            return true;
        }

        public bool Add(Project project, bool force = false) {
            return Add(project.name, project.active, project.description, project.technologies, project.photoName, force);
        }

        public void Remove(string name) {
            if (name != null && _projects.ContainsKey(name)) {
                _projects.Remove(name);
            }
        }

        public void Clear() {
            _projects.Clear();
        }

        public void Edit(Project project) {
            if (_projects.ContainsKey(project.name)) {
                Remove(project.name);
            }
            Add(project);
        }

        public Project Get(string name) {
            if (name != null && _projects.ContainsKey(name)) return _projects[name];
            return null!;
        }

        #endregion

    }

    public class Project {

        #region Public Declarations

        public readonly string name;
        public readonly bool active;
        public readonly string description;
        public readonly string[] technologies;
        public readonly string photoName;

        #endregion

        #region Header

        public Project(string name, bool active, string description, string[] technologies, string photoName) {
            this.name = name;
            this.active = active;
            this.description = description;
            this.technologies = technologies;
            this.photoName = photoName;
        }

        #endregion

    }

}
