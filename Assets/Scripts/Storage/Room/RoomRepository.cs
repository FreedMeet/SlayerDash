using System.Collections.Generic;
using System.IO;
using Assets;
using UnityEngine;

namespace Storage.Room
{
    public class RoomRepository : Repository
    {
        private const string FileName = "room_data.json";

        public List<List<char>> MiniatureRoom { get; set; }
        public Dictionary<string, List<Vector2Int>> ChunkCoords { get; set; }

        public override void Initialize()
        {
            var path = Path.Combine(Application.persistentDataPath, FileName);
            if (File.Exists(path))
            {
                var json = File.ReadAllText(path);
                var data = JsonUtility.FromJson<RoomData>(json);

                MiniatureRoom = ListSerializer.Parse(data.MiniatureRoom);
                ChunkCoords = DictionarySerializer.Deserialize(data.ChunkCoords);
            }
            else
            {
                var room = new RoomGenerator(8, 8, 32);
                (MiniatureRoom, ChunkCoords) = room.GenerateRoom();

                var data = new RoomData
                {
                    MiniatureRoom = ListSerializer.Serialize(MiniatureRoom),
                    ChunkCoords = DictionarySerializer.Serialize(ChunkCoords)
                };
                var json = JsonUtility.ToJson(data);
                File.WriteAllText(path, json);
            }
        }

        public override void Save()
        {
            var data = new RoomData
            {
                MiniatureRoom = ListSerializer.Serialize(MiniatureRoom),
                ChunkCoords = DictionarySerializer.Serialize(ChunkCoords)
            };
            var json = JsonUtility.ToJson(data);
            var path = Path.Combine(Application.persistentDataPath, FileName);
            File.WriteAllText(path, json);
        }

        private class RoomData
        {
            public List<string> MiniatureRoom;
            public string ChunkCoords;
        }
    }
}