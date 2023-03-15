using System.IO;
using UnityEngine;

namespace Storage.Player
{
    public class PlayerRepository : Repository
    {
        private const string FileName = "player_data.json";
        public float MoveSpeed { get; set; }

        public override void Initialize()
        {
            var path = Path.Combine(Application.persistentDataPath, FileName);
            if (File.Exists(path))
            {
                var json = File.ReadAllText(path);
                var data = JsonUtility.FromJson<PlayerData>(json);
                MoveSpeed = data.MoveSpeed;
            }
            else
            {
                MoveSpeed = 5f;
                
                var data = new PlayerData
                {
                    MoveSpeed = MoveSpeed,
                };
                var json = JsonUtility.ToJson(data);
                File.WriteAllText(path, json);
            }
        }

        public override void Save()
        {
            var data = new PlayerData
            {
                MoveSpeed = MoveSpeed,
            };
            var json = JsonUtility.ToJson(data);
            var path = Path.Combine(Application.persistentDataPath, FileName);
            File.WriteAllText(path, json);
        }

        private class PlayerData
        {
            public float MoveSpeed;
        }
    }
}