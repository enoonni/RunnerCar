using UnityEngine;

namespace Gameplay.Traffic
{
    public class TrafficCarManager : MonoBehaviour
    {      
        void OnTriggerEnter(Collider other)
        {
            Debug.Log("boom!");
            Debug.Break();
        }
    }
}
