using System.Collections.Generic;
using UnityEngine;
using GameData.Plane;

namespace Gameplay.Plane
{
    public class PlaneManager : MonoBehaviour
    {        
        private static bool _itIsFirstPlane = false;
        [SerializeField] private GameObject _spawnPoint;

        [SerializeField] private PlaneSpawnConfig _configCars;
        [SerializeField] private PlaneSpawnConfig _configLoots;

        private List<List<GameObject>> _spawnPoints;
        private float[] _distX = new float[3]{-8, 1, 10};

        private PlaneLootGenerator _lootGenerator;
        private PlaneLootGenerator.NameElementsToSpawn[][] _spawnMap;

        private void Awake()
        {
            if(_itIsFirstPlane)
            {
                InitializeListPoints(3, 220/20);
                _lootGenerator = new PlaneLootGenerator(_spawnPoints, _configCars.PrefabsToSpawn, _configLoots.PrefabsToSpawn);
                _spawnMap = _lootGenerator.GenerateMap();
                SpawnObjects();
            }
            else
            {
                _itIsFirstPlane = true;
            }
        }   

        private void Start()
        {
        }

        private void InitializeListPoints(int amountColumns, int amountRows)
        {
            _spawnPoints = new List<List<GameObject>>();

            for(int i = 0; i < amountColumns; i++)
            {
                _spawnPoints.Add(new List<GameObject>());
            }
            
            for(int i = 0; i < amountColumns; i++)
            {
                float distZ = 10;
                for(int j = 0; j < amountRows; j++)
                {
                    _spawnPoints[i].Add(Instantiate(_spawnPoint, transform));
                    _spawnPoints[i][j].transform.position = new Vector3(_distX[i], 0,  distZ);                    
                    distZ += 20;
                }                
            }
        }

        private void SpawnObjects()
        {
            for(int i = 0; i < _spawnPoints.Count; i++)
            {
                for(int j = 0; j < _spawnPoints[0].Count; j++)
                {
                    var obj = _lootGenerator.GetRandomItem(_spawnMap[i][j]);
                    Instantiate(obj, _spawnPoints[i][j].transform);
                }
            }
        }
    }
}