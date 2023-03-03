#r "../_lib/Fornax.Core.dll"

type Page = {
    title: string
    link: string
}

let loader (projectRoot: string) (siteContent: SiteContents) =
    siteContent.Add({title = "Aktuelles"; link = "/"})
    siteContent.Add({title = "Über Uns"; link = "/ueberuns.html"})
    siteContent.Add({title = "Hymne"; link = "/hymne.html"})
    siteContent.Add({title = "Mitglied werden"; link = "/mitgliedwerden.html"})
    siteContent.Add({title = "Kontakt"; link = "/kontakt.html"})
    siteContent.Add({title = "Galerie Kappensitzung 2023"; link = "/galerie1.html"})
    siteContent.Add({title = "Galerie Kinderkappensitzung 2023"; link = "/galerie2.html"})
    siteContent
