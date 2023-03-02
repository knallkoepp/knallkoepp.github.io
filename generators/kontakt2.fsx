#r "../_lib/Fornax.Core.dll"
#load "layout.fsx"
open Html

let generate' (ctx : SiteContents) (_: string) =
  let text :Statictextloader.StaticText = 
    ctx.TryGetValues<Statictextloader.StaticText> ()
    |> Option.defaultValue Seq.empty
    |> Seq.find (fun n -> n.title = "Kontakt")

  let siteInfo = ctx.TryGetValue<Globalloader.SiteInfo> ()
  let desc =
      siteInfo
      |> Option.map (fun si -> si.description)
      |> Option.defaultValue ""

  Layout.layout ctx text.title [
      section [Class "hero is-info is-medium is-bold"] [
          div [Class "hero-body"] [
              div [Class "container has-text-centered"] [
                  h1 [Class "title"] [!!desc]
              ]
          ]
      ]
      div [Class "container"] [
          section [Class "articles"] [
              div [Class "column is-8 is-offset-2"] [
                  script [Src "https://cdn.jsdelivr.net/npm/publicalbum@latest/embed-ui.min.js"; ] []//[!! "async"]
                  div [
                    Class "pa-gallery-player-widget"
                    HtmlProperties.Custom ("style", "width:100%; height:480px; display:none;")
                    HtmlProperties.Custom ("data-link", "https://photos.app.goo.gl/aAyjZQwxigpLhmHt7")
                    HtmlProperties.Custom ("data-title", "test")
                    HtmlProperties.Custom ("data-description", "3 new items added to shared album")
                    ] [
                        object [HtmlProperties.Custom ("data", "https://lh3.googleusercontent.com/4INZn2nRehtAoWMDm_7kI1NabMQ1Q63JVHgpbZTHoWjxgfvZPIHIPi9vQ6vggnc92Hgb7dnYozc7j3rfbiOKLMdqWOa70BGtw8aGLwm8hsEjyV9Gu-8mgsrhQJ4pFlxOXnUmcx_1mw=w1920-h1080")] []
                        object [HtmlProperties.Custom ("data", "https://lh3.googleusercontent.com/0OcApcKIit5p-nACNgfuNLFuI-qfoEdBp6tba5pIF--QGtGfGzi2KjWheLhfSixO3bx_Q7dpCoLJ7yL8TrfAx-TAKEPgEA2pzdVU606i5Tw7Lr-QXhgZy9Zu-yAK4xf5pTsoIJUooA=w1920-h1080")] []
                        object [HtmlProperties.Custom ("data", "https://lh3.googleusercontent.com/mIAhyCBw4Tx6MKz3C2wTzTHUpWVyKpl-dBKz6-9vGJUqR-MMViQcqbX3EqY1KnH1ucfQWHAhGUG8AI-XPB91w521nZhr1QOEmrypgokeoElK656Yg_UkSxUCg5ofgSq-2qv6wBZGaA=w1920-h1080")] []
                  ]
              ]
          ]
      ]
      
      ]

//  <script src="https://cdn.jsdelivr.net/npm/publicalbum@latest/embed-ui.min.js" async></script>
// <div class="pa-gallery-player-widget" 
//   style="width:100%; height:480px; display:none;"
//   data-link="https://photos.app.goo.gl/aAyjZQwxigpLhmHt7"
//   data-title="test"
//   data-description="3 new items added to shared album">
//   <object data="https://lh3.googleusercontent.com/4INZn2nRehtAoWMDm_7kI1NabMQ1Q63JVHgpbZTHoWjxgfvZPIHIPi9vQ6vggnc92Hgb7dnYozc7j3rfbiOKLMdqWOa70BGtw8aGLwm8hsEjyV9Gu-8mgsrhQJ4pFlxOXnUmcx_1mw=w1920-h1080"></object>
//   <object data="https://lh3.googleusercontent.com/0OcApcKIit5p-nACNgfuNLFuI-qfoEdBp6tba5pIF--QGtGfGzi2KjWheLhfSixO3bx_Q7dpCoLJ7yL8TrfAx-TAKEPgEA2pzdVU606i5Tw7Lr-QXhgZy9Zu-yAK4xf5pTsoIJUooA=w1920-h1080"></object>
//   <object data="https://lh3.googleusercontent.com/mIAhyCBw4Tx6MKz3C2wTzTHUpWVyKpl-dBKz6-9vGJUqR-MMViQcqbX3EqY1KnH1ucfQWHAhGUG8AI-XPB91w521nZhr1QOEmrypgokeoElK656Yg_UkSxUCg5ofgSq-2qv6wBZGaA=w1920-h1080"></object>
// </div>
 

let generate (ctx : SiteContents) (projectRoot: string) (page: string) =
  generate' ctx page
  |> Layout.render ctx
