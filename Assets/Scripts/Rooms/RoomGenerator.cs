using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Rooms
{
    public class RoomGenerator : MonoBehaviour
    {
        private Room _room;
        private List<List<char>> _miniatureRoom;
        private Dictionary<string, List<Vector2Int>> _chunkCoords;

        [SerializeField] private Text miniMapText;
        [SerializeField] private Transform parent;

        private Dictionary<string, GameObject> _wallPrefabs;

        private void Start()
        {
            _room = new Room(8, 8, 32);
            var roomTuple = _room.GenerateRoom();
            _miniatureRoom = roomTuple.Item1;
            _chunkCoords = roomTuple.Item2;

            _wallPrefabs = new Dictionary<string, GameObject>();

            _wallPrefabs.Add("U", Resources.Load<GameObject>("Map/ChunkU"));
            _wallPrefabs.Add("D", Resources.Load<GameObject>("Map/ChunkD"));
            _wallPrefabs.Add("L", Resources.Load<GameObject>("Map/ChunkL"));
            _wallPrefabs.Add("R", Resources.Load<GameObject>("Map/ChunkR"));
            _wallPrefabs.Add("UL", Resources.Load<GameObject>("Map/ChunkUL"));
            _wallPrefabs.Add("UR", Resources.Load<GameObject>("Map/ChunkUR"));
            _wallPrefabs.Add("DL", Resources.Load<GameObject>("Map/ChunkDL"));
            _wallPrefabs.Add("DR", Resources.Load<GameObject>("Map/ChunkDR"));
            _wallPrefabs.Add("UDL", Resources.Load<GameObject>("Map/ChunkLDU"));
            _wallPrefabs.Add("UDR", Resources.Load<GameObject>("Map/ChunkRDU"));
            _wallPrefabs.Add("DRL", Resources.Load<GameObject>("Map/ChunkDRL"));
            _wallPrefabs.Add("URL", Resources.Load<GameObject>("Map/ChunkURL"));
            _wallPrefabs.Add("RL", Resources.Load<GameObject>("Map/ChunkRL"));
            _wallPrefabs.Add("UD", Resources.Load<GameObject>("Map/ChunkUD"));
            _wallPrefabs.Add("Empty", Resources.Load<GameObject>("Map/ChunkEmpty"));


            PrintCharListsToString();
            CreateRoomFormFromList(_chunkCoords, _miniatureRoom);
        }

        private void CreateRoomFormFromList(Dictionary<string, List<Vector2Int>> chunkCoords, IList<List<char>> map)
        {
            foreach (var chunk in chunkCoords)
            {
                var prefab = GetCurrentPrefab(chunk.Value[1].x, chunk.Value[1].y, map);
                
                var instance = Instantiate(prefab, new Vector3(chunk.Value[0].x, chunk.Value[0].y, 0),
                    Quaternion.identity);
                instance.transform.parent = parent;
            }
        }
        
        private GameObject GetCurrentPrefab(int row, int coll, IList<List<char>> map)
        {
            var numRows = map.Count;
            var numCols = map[0].Count;
            var wallPos = "";

            if (row == 0 || map[row - 1][coll] != '#')
                wallPos += "U";
            if (row == numRows - 1 || map[row + 1][coll] != '#')
                wallPos += "D";
            if (coll == numCols - 1 || map[row][coll + 1] != '#')
                wallPos += "R";
            if (coll == 0 || map[row][coll - 1] != '#')
                wallPos += "L";

            if (wallPos == "") return _wallPrefabs["Empty"];
            
            return _wallPrefabs[wallPos];  
        }

        private void PrintCharListsToString()
        {
            var text = "";
            foreach (var row in _miniatureRoom)
            {
                string charListAsString = string.Join(" ", row);
                text += charListAsString + "\n";
            }

            miniMapText.text = text;
        }
    }
}