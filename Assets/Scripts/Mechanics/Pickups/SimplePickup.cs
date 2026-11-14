using UnityEngine;

public class SimplePickup : MonoBehaviour
{
    public enum PickupType 
    {
        Health,
        JumpBoost,
        AccessKey
    }

    [SerializeField] private PickupType type;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController controller = collision.GetComponent<PlayerController>();

            switch (type)
            {

                case PickupType.Health:
                    controller.lives++;
                    break;


                case PickupType.JumpBoost:
                    controller.JumpForceChange();
                    break;

                case PickupType.AccessKey:
                    controller.hasAccessKey = true;
                    break;
            }

            Destroy(gameObject);
        }

    }
}