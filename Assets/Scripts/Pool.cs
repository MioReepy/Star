using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerSpace
{
    public class Pool : MonoBehaviour
    {
        [SerializeField] private GameObject _bolt;
        [SerializeField] private GameObject _barrel;
        [SerializeField] private int _initialPoolSize;
        [SerializeField] private float _spawnInterval;
        private List<GameObject> _pooledBolt;
        private float _timer;
        internal static bool _isPoof;

        private void Start()
        {
            _pooledBolt = new List<GameObject>();

            for (int bolt = 0; bolt < _initialPoolSize; bolt++)
            {
                GameObject newBolt = Instantiate(_bolt);
                newBolt.SetActive(false);
                _pooledBolt.Add(newBolt);
            }
        }

        private void Update()
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
            GameObject newBolt = Instantiate(_bolt);
            newBolt.SetActive(false);
            _pooledBolt.Add(newBolt);
            return newBolt;
        }

        private void SpawnBolt()
        {
            GameObject bolt = GetPoolBolt();

            if (bolt != null)
            {
                _isPoof = false;
                bolt.transform.position = _barrel.transform.position;
                bolt.transform.rotation = _barrel.transform.rotation;
                bolt.SetActive(true);
            }
        }

        internal static void ReturnBoltToPool(GameObject bolt)
        {
            bolt.SetActive(false);
        }
    }
}