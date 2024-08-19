using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameData.Plane;

namespace Gameplay.Plane
{
    public class PlaneLootGenerator
    {
        private List<List<GameObject>> _spawnPoints;

        private List<GameObject> _listCars;
        private List<GameObject> _listLoot;

        private NameElementsToSpawn[][] _spawnMap;

        public PlaneLootGenerator(List<List<GameObject>> spawnPoints, List<GameObject> listCars, List<GameObject> listLoot)
        {
            _spawnPoints = spawnPoints;
           
            _spawnMap = new NameElementsToSpawn[3][]
            {
                new NameElementsToSpawn[_spawnPoints[0].Count],
                new NameElementsToSpawn[_spawnPoints[0].Count],
                new NameElementsToSpawn[_spawnPoints[0].Count]                
            }; 

            _listCars = listCars;
            _listLoot = listLoot;           
        }

        public NameElementsToSpawn[][] GenerateMap()
        {
            for(int i = 0; i < _spawnPoints.Count; i++)
            {
                for(int j = 0; j < _spawnPoints[0].Count; j++)
                {
                    var randomValue = Random.Range(0, 100);

                    if(randomValue >= 30 && randomValue < 70)
                    {
                        _spawnMap[i][j] = NameElementsToSpawn.coin;
                    }
                    else if(randomValue >= 80 && randomValue < 97)
                    {
                        if(i == 2)
                        {
                            if(_spawnMap[1][j] != NameElementsToSpawn.car || _spawnMap[0][j] != NameElementsToSpawn.car)
                            {
                                _spawnMap[i][j] = NameElementsToSpawn.car;
                            }
                        }
                        else
                        {
                            _spawnMap[i][j] = NameElementsToSpawn.car;
                        }
                    }
                    else if(randomValue == 99)
                    {
                        _spawnMap[i][j] = NameElementsToSpawn.heart;
                    }
                    else
                    {
                        _spawnMap[i][j] = NameElementsToSpawn.empty;
                    }
                }
            }

            return _spawnMap;
        }
        
        public GameObject GetRandomItem(NameElementsToSpawn obj)
        {    
            switch(obj)
            {
                case NameElementsToSpawn.car:
                    var choice = Random.Range(0, _listCars.Count);
                    return _listCars[choice];

                case NameElementsToSpawn.heart:
                    return _listLoot[1];

                case NameElementsToSpawn.coin:
                    return _listLoot[0];

                case NameElementsToSpawn.empty:
                    return _listLoot[2];

                default:
                    return _listLoot[2];
            }
        }

        public enum NameElementsToSpawn
        {
            empty,
            car,
            coin,
            heart
        }
    }
}
