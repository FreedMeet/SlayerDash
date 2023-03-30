using UnityEngine;
using System.Collections.Generic;

namespace Assets
{
    public static class DictionarySerializer
    {
        [System.Serializable]
        private class SerializableVector2Int
        {
            public int x;
            public int y;

            public SerializableVector2Int(Vector2Int vector)
            {
                x = vector.x;
                y = vector.y;
            }

            public Vector2Int ToVector2Int()
            {
                return new Vector2Int(x, y);
            }
        }

        [System.Serializable]
        private class SerializableKeyValuePair
        {
            public string key;
            public List<SerializableVector2Int> value;

            public SerializableKeyValuePair(KeyValuePair<string, List<Vector2Int>> pair)
            {
                key = pair.Key;
                value = new List<SerializableVector2Int>();

                foreach (var vector in pair.Value)
                {
                    value.Add(new SerializableVector2Int(vector));
                }
            }

            public KeyValuePair<string, List<Vector2Int>> ToKeyValuePair()
            {
                var vectorList = new List<Vector2Int>();
                foreach (var serializableVector in value)
                {
                    vectorList.Add(serializableVector.ToVector2Int());
                }

                return new KeyValuePair<string, List<Vector2Int>>(key, vectorList);
            }
        }

        [System.Serializable]
        private class SerializableDictionary
        {
            public List<SerializableKeyValuePair> keyValuePairs = new();

            public SerializableDictionary(Dictionary<string, List<Vector2Int>> dictionary)
            {
                foreach (var pair in dictionary)
                {
                    keyValuePairs.Add(new SerializableKeyValuePair(pair));
                }
            }

            public Dictionary<string, List<Vector2Int>> ToDictionary()
            {
                var dictionary = new Dictionary<string, List<Vector2Int>>();

                foreach (var serializablePair in keyValuePairs)
                {
                    dictionary.Add(serializablePair.key, serializablePair.ToKeyValuePair().Value);
                }

                return dictionary;
            }
        }

        public static string Serialize(Dictionary<string, List<Vector2Int>> dictionary)
        {
            var serializableDict = new SerializableDictionary(dictionary);

            return JsonUtility.ToJson(serializableDict);
        }

        public static Dictionary<string, List<Vector2Int>> Deserialize(string json)
        {
            var serializableDict = JsonUtility.FromJson<SerializableDictionary>(json);
            return serializableDict.ToDictionary();
        }
    }
}