using System.Collections.Generic;

namespace Assets
{
    public static class ListSerializer
    {
        public static List<string> Serialize(List<List<char>> miniatureRoom)
        {
            var result = new List<string>();

            foreach (var row in miniatureRoom)
            {
                result.Add(new string(row.ToArray()));
            }

            return result;
        }

        public static List<List<char>> Parse(List<string> miniatureRoom)
        {
            var result = new List<List<char>>();

            foreach (var row in miniatureRoom)
            {
                result.Add(new List<char>(row.ToCharArray()));
            }

            return result;
        }
    }
}