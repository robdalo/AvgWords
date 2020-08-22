# AvgWords

## How to run

* Open a terminal and cd to the AvgWords.Api directory e.g. `cd "D:\Bob\Source\AvgWords\AvgWords.Api"`
* Launch the web api e.g. `dotnet run`

## Troubleshooting

* The web api should be listening on https port 5001.
* You can verify this by hitting the endpoint with a GET request in Postman. `https://localhost:5001/api/artist/Coldplay`

## Known Issues

* The third party lyrics api appears to return different versions of lyrics for the same song when called multiple times.
* This is probably because users have submitted different lyric variants to the database. Currently no known fix / workaround for this inconsistency.