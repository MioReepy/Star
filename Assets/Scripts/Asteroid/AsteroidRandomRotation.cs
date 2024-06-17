using UnityEngine;
using Random = UnityEngine.Random;

namespace AsteroidSpace
{
    public class AsteroidRandomRotation : MonoBehaviour
    {
        [SerializeField] private float _tumbleMin;
        [SerializeField] private float _tumbleMax;
        private int _tumble;
        
        private void Start()
        {
            _tumble = (int)Random.Range(_tumbleMin, _tumbleMax);
            GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * _tumble;
        }
    }
}