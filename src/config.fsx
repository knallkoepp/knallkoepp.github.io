#r "_lib/Fornax.Core.dll"

open Config
open System.IO

let postPredicate (projectRoot: string, page: string) =
    let fileName = Path.Combine(projectRoot,page)
    let ext = Path.GetExtension page
    let dir = Path.GetFullPath page
    if ext = ".md" && dir.Contains("posts") then
        let ctn = File.ReadAllText fileName
        page.Contains("_public") |> not
        && ctn.Contains("layout: post")
    else
        false

let staticTextPredicate (projectRoot: string, page: string) =
    let fileName = Path.Combine(projectRoot,page)
    let ext = Path.GetExtension page
    let dir = Path.GetFullPath page
    if ext = ".md" && dir.Contains("statictexts") then
        let ctn = File.ReadAllText fileName
        page.Contains("_public") |> not
        && ctn.Contains("layout: post")
    else
        false

let staticPredicate (projectRoot: string, page: string) =
    let ext = Path.GetExtension page
    let fileShouldBeExcluded =
        ext = ".fsx" ||
        ext = ".md"  ||
        page.Contains "_public" ||
        page.Contains "_bin" ||
        page.Contains "_lib" ||
        page.Contains "_data" ||
        page.Contains "_settings" ||
        page.Contains "_config.yml" ||
        page.Contains ".sass-cache" ||
        page.Contains ".git" ||
        page.Contains ".ionide"
    fileShouldBeExcluded |> not


let config = {
    Generators = [
        {Script = "less.fsx"; Trigger = OnFileExt ".less"; OutputFile = ChangeExtension "css" }
        {Script = "sass.fsx"; Trigger = OnFileExt ".scss"; OutputFile = ChangeExtension "css" }
        {Script = "post.fsx"; Trigger = OnFilePredicate postPredicate; OutputFile = ChangeExtension "html" }
        {Script = "staticfile.fsx"; Trigger = OnFilePredicate staticPredicate; OutputFile = SameFileName }
        {Script = "index.fsx"; Trigger = Once; OutputFile = MultipleFiles id }
        {Script = "ueberuns.fsx"; Trigger = Once; OutputFile = NewFileName "ueberuns.html" }
        {Script = "kontakt.fsx"; Trigger = Once; OutputFile = NewFileName "kontakt.html" }
        {Script = "mitgliedwerden.fsx"; Trigger = Once; OutputFile = NewFileName "mitgliedwerden.html" }
        {Script = "hymne.fsx"; Trigger = Once; OutputFile = NewFileName "hymne.html" }
        {Script = "galerie1.fsx"; Trigger = Once; OutputFile = NewFileName "galerie1.html" }
        {Script = "galerie2.fsx"; Trigger = Once; OutputFile = NewFileName "galerie2.html" }
        // {Script = "galerie3.fsx"; Trigger = Once; OutputFile = NewFileName "galerie3.html" }
        // {Script = "hymne.fsx"; Trigger = OnFilePredicate staticTextPredicate; OutputFile = NewFileName "hymne.html" }
        // {Script = "contact.fsx"; Trigger = Once; OutputFile = NewFileName "contact.html" }
    ]
}
