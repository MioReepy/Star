using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSpace
{
    public class EnemyWeapon : Bolt
    {
        [SerializeField] private float _fireRate;
        [SerializeField] private float _delay;
        
        private List<GameObject> _pooledEnemyBolt;

        private void Start()
        {
            InvokeRepeating("Fire", _delay, _fireRate);
        }

        private void Fire()
        {
            SpawnBolt();
        }
    }
}
