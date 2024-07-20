using UnityEngine;
namespace TestCode
{
    public class ColorGem : MonoBehaviour
    {
        [SerializeField] private int id;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                ColorManager.Instance.AddColorGem(id);
                Destroy(gameObject);
            }
        }
    }
}
