#r "../_lib/Fornax.Core.dll"
#load "layout.fsx"
open Html

let generate' (ctx : SiteContents) (_: string) =
  let text :Statictextloader.StaticText = 
    ctx.TryGetValues<Statictextloader.StaticText> ()
    |> Option.defaultValue Seq.empty
    |> Seq.find (fun n -> n.title = "Kontakt")

  let siteInfo = ctx.TryGetValue<Globalloader.SiteInfo> ()
  let _ =
      siteInfo
      |> Option.map (fun si -> si.description)
      |> Option.defaultValue ""
  let desc = "Kinderkappensitzung 2024"

  Layout.layout ctx text.title [
    //   section [Class "hero is-info is-small is-bold"] [
    //       div [Class "hero-body"] [
    //           div [Class "container has-text-centered"] [
    //               h1 [Class "title"] [!!desc]
    //           ]
    //       ]
    //   ]
      div [Class "container"] [
          section [Class "articles"] [
              div [Class "column is-8 is-offset-2"] [
                  !!"""<script src="https://cdn.jsdelivr.net/npm/publicalbum@latest/embed-ui.min.js" async></script>
<div class="pa-gallery-player-widget" style="width:100%; height:480px; display:none;"
  data-link="https://photos.app.goo.gl/TjFwLLCC7eLCjhnr8"
  data-title="Karneval2023"
  data-description="13 new items added to shared album">
  <object data="https://lh3.googleusercontent.com/BRHz10_1bLt5aUbFvvZhsMZIADUzdSvLIuXhJgrVnTy9FrUM3mWqhufl8J_IZx-mGadPsf5znXHPKVGPUHtn7rPp_WZNnEWzxjqQkkF53xil6wbUHOKfAJs07jAk9M7CI-VpZDpFPg=w1920-h1080"></object>
  <object data="https://lh3.googleusercontent.com/o5rkwddUgcxLeJ6qZblgxl9f5Y83YOM9ZEzuyDs3wiDbpDPbtw8Jsjpw6B0kH5D6aKwhaKTf9Jr5OG7EHK97ES5h7NhVIRHXuWZ-4_lNvGCRiuZZefpGp5oM5MCgy1VtBETAkoTV-g=w1920-h1080"></object>
  <object data="https://lh3.googleusercontent.com/nO-Vcv3kQfJSRPyIWO82IybPHAIoj9D8D8fLyeAqUd9K9Ty1pclJZrWBsabH9sPAth4yQtTRbOzy0ckAdXdJrytBKRKzC5xO44j4JcthDn5mldr6FA42b1UNXmjqGxoi7yqd0ZPZqQ=w1920-h1080"></object>
  <object data="https://lh3.googleusercontent.com/8-sezRjpNMqoZmfMAZ-ykbPfeB5-ru54ohoPHlbe-O_c0-1tqtyTf5qr6tFeW4nzgLr9ZP16uMFqcBELUWVUDPfSdfjC7CAhMBvzvqz19XwvXFummchdjHDAYW7ET1EldURUZRyGnQ=w1920-h1080"></object>
  <object data="https://lh3.googleusercontent.com/_RTzSBNQCkcKjIMhes10D9eLb1PZsR3xx1B2B1oT41iNmWZuqxicluSQG4IoE1Irg9NGgXhdwNzJ8yvzY0pAQvowsloaYMgpZ-0U3MejwajL-QJVUgM19taIaNZ7flH0bbE9uQo0Aw=w1920-h1080"></object>
  <object data="https://lh3.googleusercontent.com/YcGseZY5q6sat9qlSR4CYhGlTHcsE1qIbROVnBXnBdxHvitA4d_kFdWksavbhEMJZZcn87Qp1oKM1ZzA776mxxbBHnrmL4M8XmgwyYntK1elNlBIJqLpgIGNuB6zjqdRmlU7sKnvRA=w1920-h1080"></object>
  <object data="https://lh3.googleusercontent.com/HCyt_xkLX1vlEJf-KlsEhb4kc-rbjALnV0jIftReObQ0BTmtZJUUcovRBlX3y_iUDho7J2JtELUaVuP4OrobFf-d5B3dTinJNdlWS-twcfbdMHfRjeu8m7T1xCXJFlwoKAhH16Cd3w=w1920-h1080"></object>
  <object data="https://lh3.googleusercontent.com/_lPNPy2k4HU_M8h_WctYiRGdgExZqQoEjaUefoxNwrq-PN1GwjlwBbH-IhPP2lTIbiev0KbbXtOcqdT8HyeowQe8AkpVA1IHb2aJk7ErFmQJeymDntXc9hwFf7R513YucyA7qLHn6g=w1920-h1080"></object>
  <object data="https://lh3.googleusercontent.com/ps_wJGSWdk_seJQnhzTqTIb_GP2WVlYQu_wl_Ve1sC03GBv_aL7OX6At4WB0LMlhXfAis_YnKUWp0QNC4IQS65VqSBT1LdZyt9N6MAXCsX5gfaqjxUbkUJOwJNAGk56YVj61EW3dqg=w1920-h1080"></object>
  <object data="https://lh3.googleusercontent.com/ZwBdUY3x_vjfxZwvBqA9pUOneSMswiU5_GSjIqyfJPxu9tOqUYiP0Bo7FEDN0-D12mkwJjn4aZ3osCgoGwQxsMgOORoRK67mV9fvFGSttMcWfTl7_CtsFDwgjpatWbWzx6PY9K0Fng=w1920-h1080"></object>
  <object data="https://lh3.googleusercontent.com/HFgXqTkL6Kkgk3sKeS7kc5coEPOaTBRF-bHJlSHUw-T2oghNJuClEmybSA0EhT5rXCeaWKVukmX75W_xvqARzJmCuYxLRFWgQ4fRP7FdQUWuTzgvonBzdF7xbCLtrBjb9Jj84PDG-g=w1920-h1080"></object>
  <object data="https://lh3.googleusercontent.com/v70Qu40EchHE3U1THqT_iiNFjBrOoMNpXdQbGdOXf8C5Fbc0wa8jXtVSLmWbO649EuD9TLnH7LmjTRijiN-eXvGQObuodmCgYhmY9ptRPKjSanShlHYoDlg_hNuS50wLYKbLTYnGKg=w1920-h1080"></object>
  <object data="https://lh3.googleusercontent.com/3IHEmqjHHvxNeDN554aNrWMISsEsi6yej8h4bb5UCOVTi8SlMRUqmUcbR3usQQ740byG1iGq52EVtf_K8IqTZDC7J4wWegdZKx7_PXclOhBnxZKVg6gqW2z2eSHf5qPNTjy8zXCtAg=w1920-h1080"></object>
</div>
"""
              ]
          ]
      ]
      
      ]


 

let generate (ctx : SiteContents) (projectRoot: string) (page: string) =
  generate' ctx page
  |> Layout.render ctx
