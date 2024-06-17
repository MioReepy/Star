using System.Collections.Generic;
using UnityEngine;

namespace WeaponSpace
{
    public class Bolt : MonoBehaviour
    {
        [SerializeField] internal GameObject _shot;
        [SerializeField] internal Transform _shotSpawn;
        [SerializeField] private float _spawnInterval;
        [SerializeField] protected int _initialPoolSize;
        
        private List<GameObject> _pooledBolt;
        private float _timer = 0;
        internal static bool _isPoof;

        private void Awake()
        {
            _pooledBolt = new List<GameObject>();
        }
        
        private void Start()
        {
            for (int bolt = 0; bolt < _initialPoolSize; bolt++)
            {
                GameObject newBolt = Instantiate(_shot);
                newBolt.SetActive(false);
                _pooledBolt.Add(newBolt);
            }
        }

        private void FixedUpdate()
        {
            _timer += Time.deltaTime;

            if (_timer >= _spawnInterval && _isPoof)
            {
                SpawnBolt();
                _timer = 0;
            }
        }

        internal GameObject GetPoolBolt()
        {
            foreach (var bolt in _pooledBolt)
            {
                if (!bolt.activeInHierarchy)
                {
                    return bolt;
                }
            }
            GameObject newBolt = Instantiate(_shot);
            newBolt.SetActive(false);
            _pooledBolt.Add(newBolt);
            return newBolt;
        }

        internal void SpawnBolt()
        {
            GameObject bolt = GetPoolBolt();

            if (bolt != null)
            {
                bolt.transform.position = _shotSpawn.position;
                bolt.transform.rotation = _shotSpawn.rotation;
                bolt.SetActive(true);
                _isPoof = false;
            }
        }

        protected internal static void ReturnBoltToPool(GameObject bolt)
        {
            bolt.SetActive(false);
        }
    }
}