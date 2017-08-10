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

#### Search
~~~
var artists = await Artist.SearchAsync("rammstein", 40);
~~~

#### Correction
~~~
var artist = await Artist.GetCorrectionAsync("ramstain");
~~~

#### Top tracks
~~~
var tracks = await Artist.GetTopTracksAsync("rammstein");
~~~

#### Similar artists
~~~
var similar = await Artist.GetSimilarAsync("rammstein");
~~~

#### Top albums
~~~
var albums = await Artist.GetTopAlbumsAsync("rammstein");
~~~

#### Top tags
~~~
var tags = await Artist.GetTopTagsAsync("rammstein");
~~~
