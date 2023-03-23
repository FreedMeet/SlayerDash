using UnityEngine;
using System.Collections.Generic;

namespace Rooms
{
    public class Room
    {
        private readonly int _rows;
        private readonly int _cols;
        private int _numOfChunk;

        public Room(int rows, int cols, int numOfChunk)
        {
            _rows = rows;
            _cols = cols;
            _numOfChunk = numOfChunk;
        }

        public (List<List<char>>, Dictionary<string, List<Vector2Int>>) GenerateRoom()
        {
            var miniatureRoom = new List<List<char>>();
            var chunkCoordinates = new Dictionary<string, List<Vector2Int>>();

            for (var i = 0; i < _rows; i++)
            {
                var row = new List<char>();

                for (var j = 0; j < _cols; j++)
                {
                    row.Add('.');
                }

                miniatureRoom.Add(row);
            }

            var centerRow = _rows / 2;
            var centerCol = _cols / 2;

            miniatureRoom[centerRow][centerCol] = '#';
            chunkCoordinates.Add("MainChunk", new List<Vector2Int>
            {
                new(0, 0),
                new(centerRow, centerCol)
            });

            while (_numOfChunk > 1)
            {
                int row, col;
                do
                {
                    row = Random.Range(0, _rows);
                    col = Random.Range(0, _cols);
                } while (miniatureRoom[row][col] != '#');

                var directions = new List<Vector2Int>
                {
                    new(0, 1),
                    new(0, -1),
                    new(1, 0),
                    new(-1, 0),
                };
                Shuffle(directions);
                foreach (var direction in directions)
                {
                    var newRow = row + direction.x;
                    var newCol = col + direction.y;
                    if (newRow >= 0 && newRow < _rows && newCol >= 0 && newCol < _cols &&
                        miniatureRoom[newRow][newCol] == '.')
                    {
                        miniatureRoom[newRow][newCol] = '#';
                        chunkCoordinates.Add($"DefaultChunk_{_numOfChunk}",
                            new List<Vector2Int>
                            {
                                new((newCol - centerCol) * 5, (centerRow - newRow) * 5),
                                new(newRow, newCol)
                            });
                        _numOfChunk--;
                        break;
                    }
                }
            }

            return (miniatureRoom, chunkCoordinates);
        }

        private static void Shuffle<T>(IList<T> list)
        {
            var n = list.Count;

            while (n > 1)
            {
                n--;
                var k = Random.Range(0, n + 1);
                (list[k], list[n]) = (list[n], list[k]);
            }
        }
    }
}