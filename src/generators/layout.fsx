#r "../_lib/Fornax.Core.dll"
#load "../globals.fsx"
open Globals
#if !FORNAX
#load "../loaders/statictextloader.fsx"
#load "../loaders/postloader.fsx"
#load "../loaders/pageloader.fsx"
#load "../loaders/globalloader.fsx"
#endif
open Html

let layout (ctx : SiteContents) active bodyCnt =
    let pages = ctx.TryGetValues<Pageloader.Page> () |> Option.defaultValue Seq.empty
    let siteInfo = ctx.TryGetValue<Globalloader.SiteInfo> ()
    let ttl =
      siteInfo
      |> Option.map (fun si -> si.title)
      |> Option.defaultValue ""

    let menuEntries =
      pages
      |> Seq.filter (fun p -> p.title.Contains("Aktuelles") || p.title.Contains("Kontakt") || p.title.Contains("Mitglied werden"))
      |> Seq.map (fun p ->
        let cls = if p.title = active then "navbar-item is-active" else "navbar-item"
        a [Class cls; Href (Globals.prefixUrl p.link)] [!! p.title ])
      |> Seq.toList

    let menuEntriesVersch =
      pages
      |> Seq.filter (fun p -> p.title.Contains("Über Uns") || p.title.Contains("Hymne"))
      |> Seq.map (fun p ->
        let cls = if p.title = active then "navbar-item is-active" else "navbar-item"
        a [Class cls; Href (Globals.prefixUrl p.link)] [!! p.title ])
      |> Seq.toList
    let verschDropDrown = 
      // div [Class (if pages |> Seq.exists (fun x -> x.title = active) then "navbar-item has-dropdown is-hoverable is-active" else "navbar-item has-dropdown is-hoverable") ] [
      div [Class "navbar-item has-dropdown is-hoverable"] [
        a [Class "navbar-link"] [!!"Verschiedenes"]
        div [Class "navbar-dropdown"] menuEntriesVersch
      ]  

    let menuEntriesGallery =
      pages
      |> Seq.filter (fun p -> p.title.Contains("Galerie"))
      |> Seq.map (fun p ->
        let cls = if p.title = active then "navbar-item is-active" else "navbar-item"
        a [Class cls; Href (Globals.prefixUrl p.link)] [!! p.title ])
      |> Seq.toList

    let galleryDropDrown = 
      // div [Class (if pages |> Seq.exists (fun x -> x.title = active) then "navbar-item has-dropdown is-hoverable is-active" else "navbar-item has-dropdown is-hoverable") ] [
      div [Class "navbar-item has-dropdown is-hoverable"] [
        a [Class "navbar-link"] [!!"Galerie"]
        div [Class "navbar-dropdown"] menuEntriesGallery
      ]
    let instagram = 
      a [Class "navbar-item"; Href "https://www.instagram.com/wallenbornerknallkoepp/"] [
        img [Src (Globals.prefixUrl "images/Instagram_icon.png"); Alt "Logo";]
      ]
    let facebook = 
      a [Class "navbar-item"; Href "https://www.facebook.com/profile.php?id=100068512331490"] [
        img [Src (Globals.prefixUrl "images/Facebook_Logo_(2019).png"); Alt "Logo";]
      ] 
    html [] [
        head [] [
            meta [CharSet "utf-8"]
            meta [Name "viewport"; Content "width=device-width, initial-scale=1"]
            title [] [!! ttl]
            link [Rel "icon"; Type "image/png"; Sizes "32x32"; Href (Globals.prefixUrl "images/logoCut.png")]
            link [Rel "stylesheet"; Href "https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css"]
            link [Rel "stylesheet"; Href "https://fonts.googleapis.com/css?family=Open+Sans"]
            link [Rel "stylesheet"; Href "https://unpkg.com/bulma@0.8.0/css/bulma.min.css"]
            link [Rel "stylesheet"; Type "text/css"; Href (Globals.prefixUrl "style/style.css")]
            script [Src (Globals.prefixUrl "js/navbar.js");] []//[!! "async"]
        ]
        body [] [
          nav [Class "navbar"] [
            div [Class "container"] [
              div [Class "navbar-brand"] [
                a [Class "navbar-item"; Href "/"] [
                  img [Src (Globals.prefixUrl "images/logoCut_Large5.png");]// Alt "Logo";Width "112";Height "28"]
                ]
                span [Class "navbar-burger burger"; HtmlProperties.Custom ("data-target", "navbarMenu")] [
                  span [] []
                  span [] []
                  span [] []
                ]
                
              ]
              div [Id "navbarMenu"; Class "navbar-menu"] (menuEntries@[verschDropDrown;galleryDropDrown]@[instagram;facebook])
            ]
          ]
          yield! bodyCnt
        ]
    ]

// let render (ctx : SiteContents) cnt =
//   let disableLiveRefresh = ctx.TryGetValue<Postloader.PostConfig> () |> Option.map (fun n -> n.disableLiveRefresh) |> Option.defaultValue false
//   cnt
//   |> HtmlElement.ToString
//   |> fun n -> if disableLiveRefresh then n else injectWebsocketCode n
let render (ctx : SiteContents) cnt =
    cnt
    |> HtmlElement.ToString
    #if WATCH
    |> injectWebsocketCode 
    #endif

let published (post: Postloader.Post) =
    post.published
    |> Option.defaultValue System.DateTime.Now
    |> fun n -> n.ToString("yyyy-MM-dd")

let postLayout (useSummary: bool) (post: Postloader.Post) =
    div [Class "card article"] [
        div [Class "card-content"] [
            div [Class "media-content has-text-centered"] [
                p [Class "title article-title"; ] [ a [Href (Globals.prefixUrl post.link)] [!! post.title]]
                p [Class "subtitle is-6 article-subtitle"] [
                a [Href "#"] [!! (defaultArg post.author "")]
                !! (sprintf "on %s" (published post))
                ]
            ]
            div [Class "content article-body"] [
                !! (if useSummary then post.summary else post.content)

            ]
        ]
    ]

let published' (post:  Statictextloader.StaticText) =
    post.published
    |> Option.defaultValue System.DateTime.Now
    |> fun n -> n.ToString("yyyy-MM-dd")

let textLayout (useSummary: bool) (post: Statictextloader.StaticText) =
    div [Class "card article"] [
        div [Class "card-content"] [
            div [Class "media-content has-text-centered"] [
                p [Class "title article-title"; ] [a [] []]//[!! post.title]]
                p [Class "subtitle is-6 article-subtitle"] [
                a [Href "#"] [!! (defaultArg post.author "")]
                !! (sprintf "on %s" (published' post))
                ]
            ]
            div [Class "content article-body"] [
                !! (if useSummary then post.summary else post.content)

            ]
        ]
    ]