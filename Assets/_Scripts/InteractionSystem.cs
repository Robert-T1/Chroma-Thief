using TMPro;
using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    [SerializeField] private KeyCode interactionKey;
    [SerializeField] private float interactionDistance = 1f;
    private IInteraction closestInteraction;

    [Header("GUI")]
    [Space(15)]
    [SerializeField] private TMP_Text interactionName_Text;

    private void Update()
    {
        if(closestInteraction == null)
        {
            interactionName_Text.gameObject.SetActive(false);
            return;
        }
        interactionName_Text.gameObject.SetActive(true);

        interactionName_Text.text = closestInteraction.GetInteractionName() + " | " + interactionKey;

        if(Input.GetKeyDown(interactionKey))
        {
            closestInteraction.Interact();
        }
    }

    private void FixedUpdate()
    {
        IInteraction interaction = null;
        float lastDistance = 100 + interactionDistance;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, interactionDistance);

        foreach (Collider2D collider in colliders)
        {
            if (collider.TryGetComponent<IInteraction>(out IInteraction newInter))
            {
               float distance = Vector2.Distance(collider.transform.position, transform.position);
                if (distance < lastDistance)
                {
                    lastDistance = distance;
                    interaction = newInter;
                }
            }
        }

        closestInteraction = interaction;
    }
}
