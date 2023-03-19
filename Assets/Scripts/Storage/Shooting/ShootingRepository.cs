using System.IO;
using UnityEngine;

namespace Storage.Shooting
{
    public class ShootingRepository : Repository
    {
        private const string FileName = "shoot_data.json";
        public float FireRate { get; set; }
        public int CountOfAmmo { get; set; }
        public float ReloadTime { get; set; }
        public int CurrentCountOfAmmo { get; set; }
        public bool CanShoot { get; set; }

        public override void Initialize()
        {
            var path = Path.Combine(Application.persistentDataPath, FileName);
            if (File.Exists(path))
            {
                var json = File.ReadAllText(path);
                var data = JsonUtility.FromJson<ShootingData>(json);
                FireRate = data.FireRate;
                CountOfAmmo = data.CountOfAmmo;
                ReloadTime = data.ReloadTime;
                CurrentCountOfAmmo = CountOfAmmo;
                CanShoot = true;
            }
            else
            {
                FireRate = 0.2f;
                CountOfAmmo = 6;
                ReloadTime = 5f;
                CurrentCountOfAmmo = CountOfAmmo;
                CanShoot = true;
                
                var data = new ShootingData
                {
                    FireRate = FireRate,
                    CountOfAmmo = CountOfAmmo,
                    ReloadTime = ReloadTime
                };
                var json = JsonUtility.ToJson(data);
                File.WriteAllText(path, json);
            }
        }

        public override void Save()
        {
            var data = new ShootingData
            {
                FireRate = FireRate,
                CountOfAmmo = CountOfAmmo,
                ReloadTime = ReloadTime
            };
            var json = JsonUtility.ToJson(data);
            var path = Path.Combine(Application.persistentDataPath, FileName);
            File.WriteAllText(path, json);
        }

        private class ShootingData
        {
            public float FireRate;
            public int CountOfAmmo;
            public float ReloadTime;
        }
    }
}