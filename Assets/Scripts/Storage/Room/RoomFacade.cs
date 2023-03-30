using System;
using System.Collections.Generic;
using UnityEngine;

namespace Storage.Room
{
    public static class RoomFacade
    {
        public static event Action OnRoomInitializedEvent;

        public static List<List<char>> MiniatureRoom
        {
            get
            {
                CheckClass("MiniatureRoom");
                return _iterator.MiniatureRoom;
            }
        }

        public static Dictionary<string, List<Vector2Int>> ChunkCoords
        {
            get
            {
                CheckClass("ChunkCoords");
                return _iterator.ChunkCoords;
            }
        }

        private static RoomIterator _iterator;
        private static bool IsInitialized { get; set; }

        public static void Initialize(RoomIterator iterator)
        {
            _iterator = iterator;
            IsInitialized = true;

            OnRoomInitializedEvent?.Invoke();
        }

        public static void AddObserver(IRoomObserver observer)
        {
            CheckClass("AddObserver");
            _iterator.AddObserver(observer);
        }

        public static void RemoveObserver(IRoomObserver observer)
        {
            CheckClass("RemoveObserver");
            _iterator.RemoveObserver(observer);
        }

        public static void SetNewMiniature(object sender, List<List<char>> value)
        {
            CheckClass("SetNewMiniature");
            _iterator.SetNewMiniature(sender, value);
        }

        public static void SetNewChunkCoords(object sender, Dictionary<string, List<Vector2Int>> value)
        {
            CheckClass("SetNewChunkCoords");
            _iterator.SetNewChunkCoords(sender, value);
        }

        private static void CheckClass(object sender)
        {
            if (!IsInitialized)
                throw new Exception($"Room is not initialized yet {sender}");
        }
    }
}