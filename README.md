# Lastfm.NETCore

### About

This library allows to fetch information about artist like:
* top tracks
* top tags
* top albums
* similar artists
* images

as well as get correction for artist and search artist from last fm database

### Usage

~~~
var artists = await Artist.SearchAsync("rammstein", 40);
~~~

~~~
var artist = await Artist.GetCorrectionAsync("ramstain");
~~~

~~~
var tracks = await Artist.GetTopTracksAsync("rammstein");
~~~
