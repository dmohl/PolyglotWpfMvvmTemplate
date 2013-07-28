﻿namespace FSCSWpfTemplateWizard

open System
open System.Collections.Generic
open System.Collections
open EnvDTE
open Microsoft.VisualStudio.TemplateWizard
open VSLangProj

[<AutoOpen>]
module TemplateWizardMod =
    let AddProjectReference (target:Option<Project>) (projectToReference:Option<Project>) =
        if ((Option.isSome target) && (Option.isSome projectToReference)) then
            let vsControllerProject = target.Value.Object :?> VSProject
            let existingProjectReference = 
                vsControllerProject.References.Find(projectToReference.Value.Name) 
            if (existingProjectReference <> null) then existingProjectReference.Remove() 
            vsControllerProject.References.AddProject(projectToReference.Value) |> ignore

    let BuildProjectMap (projectEnumerator:IEnumerator) =
        let rec buildProjects (projectMap:Map<string,Project>) = 
            match projectEnumerator.MoveNext() with
            | true -> let project = projectEnumerator.Current :?> Project
                      projectMap 
                      |> Map.add project.Name project
                      |> buildProjects 
            | _ -> projectMap
        buildProjects Map.empty

type TemplateWizard() =
    let projectRefs = [("View", "App")]
    [<DefaultValue>] val mutable Dte : DTE
    interface IWizard with
        member x.RunStarted (automationObject:Object, replacementsDictionary:Dictionary<string,string>, 
                             runKind:WizardRunKind, customParams:Object[]) =
            x.Dte <- automationObject :?> DTE
        member x.ProjectFinishedGenerating (project:Project) =
            try
                let projects = BuildProjectMap (x.Dte.Solution.Projects.GetEnumerator())
                projectRefs 
                |> Seq.iter (fun (target,source) -> 
                             do AddProjectReference (projects.TryFind target) (projects.TryFind source))
            with 
            | ex -> ex.Message |> ignore
        member x.ProjectItemFinishedGenerating projectItem = "Do Nothing" |> ignore
        member x.ShouldAddProjectItem filePath = true
        member x.BeforeOpeningFile projectItem = "Do Nothing" |> ignore
        member x.RunFinished() = "Do Nothing" |> ignore
