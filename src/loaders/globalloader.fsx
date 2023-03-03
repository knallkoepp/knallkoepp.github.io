#r "../_lib/Fornax.Core.dll"

type SiteInfo = {
    title: string
    description: string
    postPageSize: int
}

let loader (projectRoot: string) (siteContent: SiteContents) =
    let siteInfo =
        { title = "KnallKöpp";
          description = "Willkommen bei den Wallenborner Knallköpp!"
          postPageSize = 5 }
    siteContent.Add(siteInfo)

    siteContent
