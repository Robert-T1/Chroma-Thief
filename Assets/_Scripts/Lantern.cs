using UnityEngine;

public class Lantern : MonoBehaviour
{
    [SerializeField] private GameObject lantern;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            TurnOnLanturn();
        }
    }

    private void TurnOnLanturn()
    {
        lantern.SetActive(true);
    }
}
