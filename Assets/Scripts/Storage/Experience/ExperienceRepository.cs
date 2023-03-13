using UnityEngine;

namespace Storage.Experience
{
    public class ExperienceRepository : Repository
    {
        private const string Key = "EXPERIENCE_KEY";
        
        public int Exp { get; set; }
        
        public override void Initialize()
        {
            Exp = PlayerPrefs.GetInt(Key, 0);
        }

        public override void Save()
        {
            PlayerPrefs.SetInt(Key, Exp);
        }
    }
}