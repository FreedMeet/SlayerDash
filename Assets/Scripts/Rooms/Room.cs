using System.Collections.Generic;
using Storage.Room;
using UnityEngine;

namespace Rooms
{
    public class Room
    {
        private readonly Dictionary<string, GameObject> _wallPrefabs;

        public Room(Transform container)
        {
            _wallPrefabs = new Dictionary<string, GameObject>
            {
                { "U", Resources.Load<GameObject>("Map/ChunkU") },
                { "D", Resources.Load<GameObject>("Map/ChunkD") },
                { "L", Resources.Load<GameObject>("Map/ChunkL") },
                { "R", Resources.Load<GameObject>("Map/ChunkR") },
                { "UL", Resources.Load<GameObject>("Map/ChunkUL") },
                { "UR", Resources.Load<GameObject>("Map/ChunkUR") },
                { "DL", Resources.Load<GameObject>("Map/ChunkDL") },
                { "DR", Resources.Load<GameObject>("Map/ChunkDR") },
                { "UDL", Resources.Load<GameObject>("Map/ChunkLDU") },
                { "UDR", Resources.Load<GameObject>("Map/ChunkRDU") },
                { "DRL", Resources.Load<GameObject>("Map/ChunkDRL") },
                { "URL", Resources.Load<GameObject>("Map/ChunkURL") },
                { "RL", Resources.Load<GameObject>("Map/ChunkRL") },
                { "UD", Resources.Load<GameObject>("Map/ChunkUD") },
                { "Empty", Resources.Load<GameObject>("Map/ChunkEmpty") }
            };

            CreateRoomFormFromList(RoomFacade.ChunkCoords, RoomFacade.MiniatureRoom, container);
        }

        private void CreateRoomFormFromList(Dictionary<string, List<Vector2Int>> chunkCoords, IList<List<char>> map,
            Transform parent)
        {
            foreach (var chunk in chunkCoords)
            {
                var prefab = GetCurrentPrefab(chunk.Value[1].x, chunk.Value[1].y, map);

                var instance = Object.Instantiate(prefab, new Vector3(chunk.Value[0].x, chunk.Value[0].y, 0),
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
    }
}