using UnityEngine;

public class PileGrow : MonoBehaviour
{
    [SerializeField]
    private GameObject nextPile; //Assign the next pile to be activated when the toys are added to the current pile

    [SerializeField]
    private GameObject finishedMessage; //Assign UI to display a congratulatory message when the activity is finished

    [SerializeField]
    private GameObject instructionMessage; //Assign a UI to display information when the activity starts

    [SerializeField]
    private bool isLastPile; //Check to determine whether the current pile is the last one

    /// <summary>
    /// When a toy enters the collider of the pile, it gets destroyed, and depending on whether it is the last pile or not, the pile will either grow, or a congratulatory message will be displayed
    /// </summary>
    /// <param name="collider"></param>
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Toy") && !isLastPile) //if a toy enters the pile and it is not the last pile
        {
            Destroy(collider.gameObject);
            gameObject.SetActive(false);
            nextPile.SetActive(true);
            Debug.Log("pile grows");
        }
        else //displays the finished message once a toy enters the last pile
        {
            Destroy(collider.gameObject);
            finishedMessage.SetActive(true);
            instructionMessage.SetActive(false);
            Debug.Log("pile done");
        }
    }
}
