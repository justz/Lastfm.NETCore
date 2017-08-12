# Lastfm.NETCore

### About

This library allows to fetch information like:
* artist top tracks
* artist top albums
* artist top tags
* similar artists 
* similar songs by song name
* search artist by name
* get correction for artist name
* charts top tracks
* charts top artists
* charts top tags

### Implemented methods

#### Artist section

* Artist.GetInfoAsync
* Artist.SearchAsync
* Artist.GetCorrectionAsync
* Artist.GetSimilarAsync
* Artist.GetTopTracksAsync
* Artist.GetTopAlbumsAsync
* Artist.GetTopTagsAsync

#### Auth section

* Auth.GetTokenAsync

#### Chart section

* Chart.GetTopArtistsAsync
* Chart.GetTopTracksAsync
* Chart.GetTopTagsAsync

#### Track section

* Track.SearchAsync
* Track.SimilarAsync

You can find all api methods on [last.fm/api](https://www.last.fm/api)

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

etc
