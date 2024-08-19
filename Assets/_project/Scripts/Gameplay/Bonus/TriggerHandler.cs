using UnityEngine;

public class TriggerHandler : MonoBehaviour
{
    // Этот метод вызывается, когда другой объект с коллайдером входит в триггер
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Object entered the trigger: " + other.name);
    }

    // Этот метод вызывается, когда другой объект с коллайдером остается в триггере
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Object is within the trigger: " + other.name);
    }

    // Этот метод вызывается, когда другой объект с коллайдером выходит из триггера
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Object exited the trigger: " + other.name);
    }
}
