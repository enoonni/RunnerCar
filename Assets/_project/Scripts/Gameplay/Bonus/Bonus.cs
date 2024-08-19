using UnityEngine;

namespace Gameplay.Bonus
{
    public class Bonus : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {            
            //Debug.Log($"{other.name} entered the trigger.");
            Destroy(this.gameObject);            
        }   
    }
}
