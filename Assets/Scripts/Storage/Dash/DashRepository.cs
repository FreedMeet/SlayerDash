using System.Collections.Generic;
using System.IO;
using Assets;
using UnityEngine;

namespace Storage.Dash
{
    public class DashRepository : Repository
    {
        private const string FileName = "dash_data.json";

        public float DashDistance { get; set; }
        public float DashCooldown { get; set; }
        public int MaxDashCount { get; set; }
        public int CurrentDashCount { get; set; }
        public bool CanDash { get; set; }

        public override void Initialize()
        {
            var path = Path.Combine(Application.persistentDataPath, FileName);
            if (File.Exists(path))
            {
                var json = File.ReadAllText(path);
                var data = JsonUtility.FromJson<DashData>(json);
                DashDistance = data.DashDistance;
                DashCooldown = data.DashCooldown;
                MaxDashCount = data.MaxDashCount;
                CurrentDashCount = MaxDashCount;
                CanDash = true;
            }
            else
            {
                DashDistance = 5f;
                DashCooldown = 10f;
                MaxDashCount = 2;
                CurrentDashCount = MaxDashCount;
                CanDash = true;
                
                var data = new DashData
                {
                    DashDistance = DashDistance,
                    DashCooldown = DashCooldown,
                    MaxDashCount = MaxDashCount
                };
                var json = JsonUtility.ToJson(data);
                File.WriteAllText(path, json);
            }
        }

        public override void Save()
        {
            var data = new DashData
            {
                DashDistance = DashDistance,
                DashCooldown = DashCooldown,
                MaxDashCount = MaxDashCount
            };
            var json = JsonUtility.ToJson(data);
            var path = Path.Combine(Application.persistentDataPath, FileName);
            File.WriteAllText(path, json);
        }

        private class DashData
        {
            public float DashDistance;
            public float DashCooldown;
            public int MaxDashCount;
        }
    }
}