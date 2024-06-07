using UnityEngine;

public class PickUp : MonoBehaviour
{
    public delegate void OnItemPickUp(Collider collider);
    public OnItemPickUp PickUpHandler;
    void OnTriggerEnter(Collider other)
    {
        CombatHealth temp;
        if(other.TryGetComponent<CombatHealth>(out temp))
            PickUpHandler?.Invoke(other);

        DestroyPickUp();
    }

    void DestroyPickUp()
    {
        Destroy(this.gameObject, 0.1f);
    }
}