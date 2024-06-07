using System;
using UnityEngine;

namespace AsteroidSpace
{
    public class DestroyExitObject : MonoBehaviour
    {
        private void OnTriggerExit(Collider other)
        {
            Destroy(other.gameObject);
        }
    }
}
