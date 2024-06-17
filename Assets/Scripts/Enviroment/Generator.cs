using System.Collections.Generic;
using UnityEngine;

namespace InviromentSpace
{
    public class Generator : MonoBehaviour
    {
        [SerializeField] private GameObject[] _asteroidsOrEnemy;
        [SerializeField] private GameObject _spawnPlace;
        [SerializeField] private int _initialPoolSize;
        [SerializeField] private float _spawnInterval;
        [SerializeField] private AsteroidBoundary _boundary;
        [SerializeField] private int _enemySpawnRate;
        private List<GameObject> _pooledBolt;
        private float _timer;

        private void Start()
        {
            _pooledBolt = new List<GameObject>();
            _timer = _spawnInterval;

            for (int asteroidOrEnemy = 0; asteroidOrEnemy < _initialPoolSize; asteroidOrEnemy++)
            {
                GameObject newAsteroidOrEnemy;

                if (_enemySpawnRate != 0 && _enemySpawnRate != null && asteroidOrEnemy % _enemySpawnRate == 0)
                {
                    newAsteroidOrEnemy = Instantiate(_asteroidsOrEnemy[_asteroidsOrEnemy.Length - 1]);
                }
                else
                {
                    newAsteroidOrEnemy = Instantiate(_asteroidsOrEnemy[Random.Range(0, _asteroidsOrEnemy.Length - 1)]);
                }

                newAsteroidOrEnemy.SetActive(false);
                _pooledBolt.Add(newAsteroidOrEnemy);
            }
        }

        private void Update()
        {
            _timer += Time.deltaTime;

            if (_timer >= _spawnInterval)
            {
                SpawnAsteroidOrEnemy();
                _timer = 0;
            }
        }

        internal GameObject GetPoolAsteroidOrEnemy()
        {
            foreach (var asteroidOrEnemy in _pooledBolt)
            {
                if (!asteroidOrEnemy.activeInHierarchy)
                {
                    return asteroidOrEnemy;
                }
            }

            GameObject newAsteroidOrEnemy = Instantiate(_asteroidsOrEnemy[Random.Range(0, _asteroidsOrEnemy.Length)]);
            newAsteroidOrEnemy.SetActive(false);
            _pooledBolt.Add(newAsteroidOrEnemy);
            return newAsteroidOrEnemy;
        }

        private void SpawnAsteroidOrEnemy()
        {
            GameObject asteroidOrEnemy = GetPoolAsteroidOrEnemy();

            if (asteroidOrEnemy != null)
            {
                asteroidOrEnemy.transform.position = new Vector3(Random.Range(_boundary._xMin, _boundary._xMax),
                    _spawnPlace.transform.position.y, _spawnPlace.transform.position.z);
                asteroidOrEnemy.transform.rotation = _spawnPlace.transform.rotation;
                asteroidOrEnemy.SetActive(true);
            }
        }

        internal static void ReturnAsteroidOrEnemyToPool(GameObject bolt)
        {
            bolt.SetActive(false);
        }
    }
}