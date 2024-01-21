using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpawnSystem
{
    [Serializable]
    public struct NormalEnemyType
    {
        public GameObject enemyPrefab;
        public int number;
    }

    [Serializable]
    public struct HeavyEnemyType
    {
        public GameObject enemyPrefab;
        public int number;
    }

    public class EnemySpawner : MonoBehaviour
    {
        [Header("Phase_1")]
        [SerializeField] NormalEnemyType normalEnemyType;
        [SerializeField] HeavyEnemyType heavyEnemyType;

        [Header("SpawnSettings")]
        [SerializeField] List<Transform> spawnPoints;
        [SerializeField] float SpawnRate = 1f;
        [SerializeField] RoomManager roomManager;


        float _timer;

        private void Start()
        {
            roomManager.IncreaseEnemyNumber(normalEnemyType.number + heavyEnemyType.number);
        }

        private void Update()
        {
            SpawnEnemiesAtRate();
        }

        void SpawnEnemiesAtRate()
        {
            _timer += Time.deltaTime;
            if(_timer > SpawnRate) 
            {
                int maxNormalEnemyBurst = 0;
                if (normalEnemyType.number > 4)
                {
                    maxNormalEnemyBurst = 4;
                }
                else
                {
                    maxNormalEnemyBurst = normalEnemyType.number;
                }

                    int maxHeavyEnemyBurst = 0;
                if (heavyEnemyType.number > 4)
                {
                    maxHeavyEnemyBurst = 4;
                }
                else
                {
                    maxHeavyEnemyBurst = heavyEnemyType.number;
                }


                int normalEnemiesBurst = UnityEngine.Random.Range(0, maxNormalEnemyBurst);
                int heavyEnemiesBurst = UnityEngine.Random.Range(0, maxHeavyEnemyBurst);

                if (normalEnemyType.number == 1)
                    normalEnemiesBurst = 1;

                if (heavyEnemyType.number == 1)
                    heavyEnemiesBurst = 1;

                if (normalEnemyType.number > 0)
                {
                    for (int i = 0; i < normalEnemiesBurst; i++)
                    {
                        int spawnPointindex = UnityEngine.Random.Range(0, spawnPoints.Count);
                        Instantiate(normalEnemyType.enemyPrefab, spawnPoints[spawnPointindex].position, Quaternion.identity);
                    }
                }

                if (heavyEnemyType.number > 0)
                {
                    for (int i = 0; i < heavyEnemiesBurst; i++)
                    {
                        int spawnPointindex = UnityEngine.Random.Range(0, spawnPoints.Count);
                        Instantiate(heavyEnemyType.enemyPrefab, spawnPoints[spawnPointindex].position, Quaternion.identity);
                    }
                }

                normalEnemyType.number -= normalEnemiesBurst;
                heavyEnemyType.number -= heavyEnemiesBurst;

                _timer = 0;
            }
        }
    }
}