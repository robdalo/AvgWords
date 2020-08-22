# AvgWords

## How to run

* Open a terminal and cd to the AvgWords.Api directory `cd "D:\Bob\Source\AvgWords\AvgWords.Api"`
* Launch the web api `dotnet run`
* cd to the client app directory `cd "D:\Bob\Source\AvgWords\AvgWords.Web\avgwords"`
* Launch the web app `ng serve --open`

## Testing the app

* Enter an artist name and click go or press enter to search.
* Searching for some well known artists such as "Coldplay", "The Smiths" or "The Stone Roses" should display a report.
* Searching for an unknown artist, such as "sdfsafsdf", should display an artist not found message.

## Troubleshooting

* The web api should be listening on https port 5001.
* You can verify this by hitting the endpoint with a GET request in Postman. `https://localhost:5001/api/artist/Coldplay`

## Known Issues

* The third party lyrics api appears to return different versions of lyrics for the same song when called multiple times.
* This is probably because users have submitted different lyric variants to the database. Currently no known fix / workaround for this inconsistency.
* Artists with large numbers of records result in crash due to throttling. Going forward, pause and retry mechanism will be required to resolve.
