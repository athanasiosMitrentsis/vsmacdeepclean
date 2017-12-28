﻿using MonoDevelop.Components.Commands;
using MonoDevelop.Ide;

namespace VSMacDeepClean
{
    public abstract class BaseDeepCleanHandler : CommandHandler
    {
        protected ProjectOperations ProjectOperations => IdeApp.ProjectOperations;

        // Shoud be enabled only when the workspace is opened
        protected bool IsCommandEnabled() => IdeApp.Workspace.IsOpen;

        protected bool IsItSafeToExecuteTheCommand()
        {
            var isBuild = ProjectOperations.IsBuilding(ProjectOperations.CurrentSelectedSolution);
            var isRun = ProjectOperations.IsRunning(ProjectOperations.CurrentSelectedSolution);

            return !isBuild && !isRun && IdeApp.ProjectOperations.CurrentBuildOperation.IsCompleted
                         && IdeApp.ProjectOperations.CurrentRunOperation.IsCompleted;
        }
    }
}