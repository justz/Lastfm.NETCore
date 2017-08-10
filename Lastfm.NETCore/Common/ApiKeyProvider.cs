using System;
using System.Collections.Generic;

namespace Lastfm.NETCore.Common
{
    public class ApiKeyProvider
    {
        #region [Fields]

        private List<string> _apiKeys;
        private readonly Random _random = new Random();
        private static readonly object SyncRoot = new object();
        private static ApiKeyProvider _instance;

        #endregion [Fields]

        #region [Ctor]

        public ApiKeyProvider()
        {
            InitApiKeys();
        }

        #endregion

        #region [Properties]

        public string ApiKey => _apiKeys[_random.Next(0, _apiKeys.Count)];

        public int Count => _apiKeys.Count;


        #endregion
        
        #region [Methods]
        
        public static ApiKeyProvider Instance()
        {
            if (_instance == null)
            {
                lock (SyncRoot)
                {
                    if (_instance == null)
                    {
                        _instance = new ApiKeyProvider();
                    }
                }
            }

            return _instance;
        }

        private void InitApiKeys()
        {
            _apiKeys = new List<string>()
            {
                "26cc2ebf6da38bc646733f661bfc6268",
                "99df89b893d80bf7f57962b6cbd6c427",
                "59439c172a218535ed2b062bbe94cd52",
                "12bfe6b4f23875ae63dd2716aab88a67",
                "73dcb69ae592d67147da5ade22d37a24",
                "5fb7cff2da79909c580d4348f99e098c",
                "874d9335062f51ad55f6818c1ac4d48d",
                "7037e94cca6b74ba5272e9227c85bba9",
                "30e977e41ab312d9c8cb77fb3e4d5a52",
                "b5af3c79a01b0b1e20138419a876165f",
                "26cc2ebf6da38bc646733f661bfc6268",
                "3187e48eb47ec4e0bbcf8fbb2d53e404",
                "0f52b573c525c14ddc67f0e18aadb2a5",
                "2899809627dd7fe6fbec495d4f11a184",
                "a58050308e32caa5cdff253562f1b939",
                "244d56c4a6c5a995f58bfaa09573210d",
                "748a7b91b0c4ed8681da34beddbc9660",
                "62578e00bc4d7cc9fbb47987831ef0a3",
                "d0b887616096402a1b392e7afdcd09a3",
                "da215a2a55af8bf3213a3486328a84ef",
                "01317674dc761512eb0e25d0c1b814af",
                "b859182479678e20bb44eb9c81b7c1bf",
                "82a0b7c862915fa7d8380de2ddab6be8",
                "df4abe4108df3d0be6c32367924f292f",
                "4bea01aa12be4a28294f6b28a5a7259b",
                "6bba6f296efedbaa121f4f54f3e1099a",
                "c53f26b2448e65f8f47d0a47ea3dbe66",
                "244217c1ba68b99f4bf84d789fe4d2d6",
                "5f20b32bd80fe207438b7cb6ea9c8a65",
                "0dd3078cb216607ea60815b96ae83ba4",
                "a6e52edda16884bc06ce78ad06b3e4b6",
                "ce883c238ab8c41a32bb3f9c11cb31a7",
                "0a5f5337ba896684a8eab44f81320403"
            };
        }

        #endregion
    }
}