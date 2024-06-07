using System.Collections.Generic;
using UnityEngine;
using PlayerSpace;

public class AsteroidGenerator : MonoBehaviour
{
        [SerializeField] private GameObject[] _asteroids;
        [SerializeField] private GameObject _spawnPlace;
        [SerializeField] private int _initialPoolSize;
        [SerializeField] private float _spawnInterval;
        [SerializeField] private AsteroidBoundary _boundary;
        private List<GameObject> _pooledBolt;
        private float _timer;

        private void Start()
        {
            _pooledBolt = new List<GameObject>();
            _timer = _spawnInterval;

            for (int asteroid = 0; asteroid < _initialPoolSize; asteroid++)
            {
                GameObject newAsteroid = Instantiate(_asteroids[Random.Range(0, _asteroids.Length)]);
                newAsteroid.SetActive(false);
                _pooledBolt.Add(newAsteroid);
            }
        }

        private void Update()
        {
            _timer += Time.deltaTime;

            if (_timer >= _spawnInterval)
            {
                SpawnAsteroid();
                _timer = 0;
            }
        }

        internal GameObject GetPoolAsteroid()
        {
            foreach (var asteroid in _pooledBolt)
            {
                if (!asteroid.activeInHierarchy)
                {
                    return asteroid;
                }
            }
            GameObject newBolt = Instantiate(_asteroids[Random.Range(0, _asteroids.Length)]);
            newBolt.SetActive(false);
            _pooledBolt.Add(newBolt);
            return newBolt;
        }

        private void SpawnAsteroid()
        {
            GameObject asteroid = GetPoolAsteroid();

            if (asteroid != null)
            {
                asteroid.transform.position = new Vector3(Random.Range(_boundary._xMin, _boundary._xMax),
                    _spawnPlace.transform.position.y, _spawnPlace.transform.position.z);
                asteroid.transform.rotation = _spawnPlace.transform.rotation;
                asteroid.SetActive(true);
            }
        }

        internal static void ReturnAsteroidToPool(GameObject bolt)
        {
            bolt.SetActive(false);
        }
}
