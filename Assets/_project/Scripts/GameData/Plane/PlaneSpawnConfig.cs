using System.Collections.Generic;
using UnityEngine;

namespace GameData.Plane
{
    [CreateAssetMenu(fileName = "PlaneSpawnConfig", menuName = "Configs/Plane/SpawnConfig")]
    public class PlaneSpawnConfig : ScriptableObject
    {
        public string ListName;
        public List<GameObject> PrefabsToSpawn;
        public static List<PlaneSpawnConfig> AllLists {get; private set;} = new List<PlaneSpawnConfig>();
        public static List<string> AllListsNames {get; private set;} = new List<string>();

        public PlaneSpawnConfig()
        {
                AllLists.Add(this);
                AllListsNames.Add(this.ListName);
        }
    }
}