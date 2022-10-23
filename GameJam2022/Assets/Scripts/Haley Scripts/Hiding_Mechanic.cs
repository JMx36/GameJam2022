using TMPro;
using UnityEngine;

public class Hiding_Mechanic : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hideText;
    private Movement hiding;
    //private float hideCD = 2;
    //private float hideTime = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player")) {
            hiding = other.gameObject.GetComponent<Movement>();
            hideText.enabled = true;
            hiding.setHiding(true);
            Debug.Log("hiding");
            
        }
            
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player")) {
            hideText.enabled = false;
            hiding.setHiding(false);
            Debug.Log("not hiding");
        }
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    // || Input.GetKeyDown(key) || Input.GetKey(key)
    //    var key = KeyCode.Space;
    //    //Debug.Log("staying" + "Player: " + other.gameObject.tag.Equals("Player") + "\nKey: " + (Input.GetKey(key) || Input.GetKeyDown(key) || Input.GetKey(key)));
        
    //    if (other.gameObject.tag.Equals("Player") && (Input.GetKey(key) /*|| Input.GetKeyDown(key) || Input.GetKey(key)*/)) {
    //        Movement hiding = other.gameObject.GetComponent<Movement>();
    //        //if(hideTime < Time.realtimeSinceStartup) {
    //            if (hiding.getHiding()) {
    //                Debug.Log("no longer hiding");
    //                //other.gameObject.transform.SetParent(null);
    //                hiding.setHiding(false);
    //                hideText.text = "Press space to hide";
    //            } else {
    //                Debug.Log("now is hiding");
    //                //other.gameObject.transform.SetParent(gameObject.transform);
    //                hiding.setHiding(true);
    //                hideText.text = "Press space to leave spot";
    //            }
    //            //hideTime = hideCD + Time.realtimeSinceStartup;
    //        //}
            
    //    }
    //}

}
