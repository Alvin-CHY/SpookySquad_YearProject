using UnityEngine;
using TMPro;

public class InteractionUI : MonoBehaviour
{
    public float interactDistance = 1.5f;
    public LayerMask interactMask;

    public TextMeshProUGUI interactText;

    void Update()
    {
        CheckForInteractable();
    }

    void CheckForInteractable()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, interactDistance, interactMask))
        {
            ItemController item = hit.collider.GetComponent<ItemController>();

            if (item != null)
            {
                interactText.gameObject.SetActive(true);
                interactText.text = item.itemName;
                return;
            }
        }

        interactText.gameObject.SetActive(false);
    }
}