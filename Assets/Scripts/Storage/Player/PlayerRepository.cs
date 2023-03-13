using UnityEngine;

namespace Storage.Player
{
    public class PlayerRepository : Repository
    {
        private const string Key = "PLAYER_KEY";
        
        public float MoveSpeed { get; set; }
        
        public override void Initialize()
        {
            MoveSpeed = PlayerPrefs.GetFloat(Key, 5f);
        }

        public override void Save()
        {
            PlayerPrefs.SetFloat(Key, MoveSpeed);
        }
    }
}