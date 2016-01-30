# MyClippingsAPIApp

My Clippings API App is a wrapper around the excellent [EdRyan/KindleClippings](https://github.com/EdRyan/KindleClippings) (.NET parser for the Amazon Kindle's "My Clippings.txt" file)
That will make the library accessible to [Azure LogicApp](https://azure.microsoft.com/en-us/services/app-service/logic/).

Next Release:
 - GetKindleClippingsAfter(string filename, string StartDate)
 - SaveClippingAfterToJson(string filename, string StartDate)
