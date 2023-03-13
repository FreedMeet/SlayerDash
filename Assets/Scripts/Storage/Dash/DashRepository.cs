using UnityEngine;

namespace Storage.Dash
{
    public class DashRepository : Repository
    {
        private const string Key = "DASH_KEY";
        
        public float DashDistance { get; set; }
        public float DashCooldown { get; set; }
        public int MaxDashCount { get; set; }
        public int CurrentDashCount { get; set; }
        public bool CanDash { get; set; }
        
        public override void Initialize()
        {
            DashDistance = PlayerPrefs.GetFloat(Key, 5f);
            DashCooldown = PlayerPrefs.GetFloat(Key, 10f);
            MaxDashCount = PlayerPrefs.GetInt(Key, 5);
            CurrentDashCount = MaxDashCount;
            CanDash = true;
        }

        public override void Save()
        {
            PlayerPrefs.SetFloat(Key, DashDistance);
            PlayerPrefs.SetFloat(Key, DashCooldown);
            PlayerPrefs.SetInt(Key, MaxDashCount);
            PlayerPrefs.SetInt(Key, CurrentDashCount);
            PlayerPrefs.SetInt(Key, CanDash ? 1 : 0);
        }
    }
}