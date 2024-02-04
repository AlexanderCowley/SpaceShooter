using UnityEngine;

public class PickUp : MonoBehaviour
{
    public delegate void OnItemPickUp(Collider collider);
    public OnItemPickUp PickUpHandler;
    void OnTriggerEnter(Collider other)
    {
        StatHolder temp;
        if(other.TryGetComponent<StatHolder>(out temp))
            PickUpHandler?.Invoke(other);

        DestroyPickUp();
    }

    void DestroyPickUp()
    {
        Destroy(this.gameObject, 0.1f);
    }
}