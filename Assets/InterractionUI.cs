using UnityEngine;
using TMPro;

public class InteractionUI : MonoBehaviour
{
    [Header("Interaction")]
    public float interactDistance = 3f;
    public LayerMask interactMask;

    public TextMeshProUGUI interactText;

    [Header("References")]
    public Camera playerCamera;

    void Start()
    {
        interactText.gameObject.SetActive(false);
    }

    void Update()
    {
        CheckForInteractable();
    }

    void CheckForInteractable()
    {
        Ray ray = new Ray(
            playerCamera.transform.position,
            playerCamera.transform.forward
        );

        Debug.DrawRay(
            playerCamera.transform.position,
            playerCamera.transform.forward * interactDistance,
            Color.red
        );

        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance, interactMask))
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