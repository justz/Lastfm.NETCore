# Lastfm.NETCore

### About

This library allows to fetch information about artist like:
* top tracks
* top tags
* top albums
* similar artists
* images

as well as get correction for artist and search artist from last fm database

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

#### What is done?

Already done artist section only
[api](https://4.downloader.disk.yandex.ru/preview/e35dd76f423189e6ea5776a4c201d5f9979b104e517e4462d55cd928c3e69c2c/inf/zf66CxvUEfB-T6UPvwSRT05s07L4yV37Uu8lFZsoGd_1YU4U-9BhchIiNeJbYE1DTrkvyD0qA_kF8V9CEWDFmw%3D%3D?uid=0&filename=api.jpg&disposition=inline&hash=&limit=0&content_type=image%2Fjpeg&tknv=v2&size=XXL&crop=0)
