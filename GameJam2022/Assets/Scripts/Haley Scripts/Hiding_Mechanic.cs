using TMPro;
using UnityEngine;

public class Hiding_Mechanic : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hideText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
            hideText.enabled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
            hideText.enabled = false;
    }

    private void OnTriggerStay(Collider other)
    {
        // || Input.GetKeyDown(key) || Input.GetKey(key)
        var key = KeyCode.Space;
        if (other.gameObject.tag.Equals("Player") && (Input.GetKeyUp(key))) {
            Movement hiding = other.gameObject.GetComponent<Movement>();

            if (hiding.getHiding()) {
                other.gameObject.transform.SetParent(null);
                hiding.setHiding(false);
                hideText.text = "Press space to hide";
            } else {
                other.gameObject.transform.SetParent(gameObject.transform);
                hiding.setHiding(true);
                hideText.text = "Press space to leave spot";
            }
        }
    }

}
