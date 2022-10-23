using TMPro;
using UnityEngine;

public class Hiding_Mechanic : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hideText;
    private Movement hiding;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player")) {
            hiding = other.gameObject.GetComponent<Movement>();
            if (hideText != null)
                hideText.enabled = true;
            hiding.setHiding(true);
            Debug.Log("hiding");
            
        }
            
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player")) {
            if (hideText != null)
                hideText.enabled = false;
            hiding.setHiding(false);
            Debug.Log("not hiding");
        }
    }

}
