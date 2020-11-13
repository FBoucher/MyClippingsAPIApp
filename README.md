# MyClippingsAPIApp

My Clippings API App is a wrapper around the excellent [EdRyan/KindleClippings](https://github.com/EdRyan/KindleClippings) (.NET parser for the Amazon Kindle's "My Clippings.txt" file)
That will make the library accessible to [Azure LogicApp](https://azure.microsoft.com/services/app-service/logic/?WT.mc_id=dotnet-0000-frbouche).

## How to use

Two methodes are currently available:
 - AllKindleClippings(string filename)
 - KindleClippingsAfter(string filename, string StartDate)

### Sample

GET:
http://localhost:46905/KindleClippingsAfter?filename=C:\\temp\\My Clippings.txt&startdate=2016-02-08 6:59:30 AM


### Result 

    [
    {
        "BookName": "﻿GitHub Pages now faster and simpler with Jekyll 3.0",
        "Author": "",
        "ClippingType": 1,
        "Page": null,
        "Location": "40",
        "DateAdded": "2016-02-08T06:59:30",
        "Text": "important changes annonved for github and jerkel users. And alternatively a note to al Markdown users.[misc.markdown.jerkell.github.kramdown.rouge]",
        "BeginningPage": null,
        "BeginningLocation": 40
    },
    {
        "BookName": "﻿GitHub Pages now faster and simpler with Jekyll 3.0",
        "Author": "",
        "ClippingType": 0,
        "Page": null,
        "Location": "40-40",
        "DateAdded": "2016-02-08T06:59:30",
        "Text": "process,",
        "BeginningPage": null,
        "BeginningLocation": 40
    },
    {
        "BookName": "﻿Introducing Insiders Builds",
        "Author": "Chris Dias [MSFT]",
        "ClippingType": 1,
        "Page": null,
        "Location": "22",
        "DateAdded": "2016-02-08T07:09:39",
        "Text": "the Insider preview are back in a more convivial structure.[dev.vscode.visualstudio.insider]",
        "BeginningPage": null,
        "BeginningLocation": 22
    }
]
