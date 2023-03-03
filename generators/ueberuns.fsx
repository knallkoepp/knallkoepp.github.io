#r "../_lib/Fornax.Core.dll"
#load "layout.fsx"

open Html

// let about = ""

// let generate' (ctx : SiteContents) (_: string) =
//   let siteInfo = ctx.TryGetValue<Globalloader.SiteInfo> ()
//   let desc =
//     siteInfo
//     |> Option.map (fun si -> si.description)
//     |> Option.defaultValue ""


//   Layout.layout ctx "ueberuns" [
//     section [Class "hero is-info is-medium is-bold"] [
//       div [Class "hero-body"] [
//         div [Class "container has-text-centered"] [
//           h1 [Class "title"] [!!desc]
//         ]
//       ]
//     ]
//     div [Class "container"] [
//       section [Class "articles"] [
//         div [Class "column is-8 is-offset-2"] [
//             div [Class "card article"] [
//                 div [Class "card-content"] [
//                     div [Class "content article-body"] [
//                         !! about
//                     ]
//                 ]
//             ]
//         ]
//       ]
//     ]]

// let generate (ctx : SiteContents) (projectRoot: string) (page: string) =
//   generate' ctx page
//   |> Layout.render ctx

let generate' (ctx : SiteContents) (_: string) =
  let text :Statictextloader.StaticText = 
    ctx.TryGetValues<Statictextloader.StaticText> ()
    |> Option.defaultValue Seq.empty
    |> Seq.find (fun n -> n.title = "Wie alles begann")

  let siteInfo = ctx.TryGetValue<Globalloader.SiteInfo> ()
  let _ =
      siteInfo
      |> Option.map (fun si -> si.description)
      |> Option.defaultValue ""
  let desc = "Über Uns"

  Layout.layout ctx text.title [
      section [Class "hero is-info is-small is-bold"] [
          div [Class "hero-body"] [
              div [Class "container has-text-centered"] [
                  h1 [Class "title"] [!!desc]
              ]
          ]
      ]
      div [Class "container"] [
          section [Class "articles"] [
              div [Class "column is-8 is-offset-2"] [
                  Layout.textLayout false text
              ]
          ]
      ]
  ]

let generate (ctx : SiteContents) (projectRoot: string) (page: string) =
  generate' ctx page
  |> Layout.render ctx