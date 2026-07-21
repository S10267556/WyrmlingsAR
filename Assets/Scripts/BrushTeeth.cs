using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using System.Collections;

public class BrushTeeth : MonoBehaviour //script placed on all dirt spots in the scene
{
    [SerializeField]
    private int brushedCount = 0; //counts how many times a spot has been brushed

    [SerializeField]
    private int dirtCount = 3; //Sets the amount of dirty spots in the scene

    public static int totalDirtCount = 0; //Count of how many dirt spots have been cleaned

    [SerializeField]
    private GameObject finishBrushUI; //UI for finishing brushing teeth - shows that the activity is complete and prevents the button from being pressed

    [SerializeField]
    private GameObject finishPaintUI; //UI for finishing painting nails - shows that the activity is complete and prevents the button from being pressed

    public static int helpGamesCompleted = 0; //Count of how many games that help daffodil have been done

    [SerializeField]
    private GameObject finishUI; //UI for when both activities are complete?

    [SerializeField]
    private GameObject selectGameGroup; //UI group for buttons of brush teeth and paint nails

    [SerializeField]
    private GameObject selectActivityGroup; //all objects in the activity
    
    private Quaternion originalRotation;
    private Vector3 originalPosition;

    private XRGrabInteractable grab;

    private float remainingDirtSize;

    private Vector3 originalScale;


    void Start()
    {
        originalRotation = transform.rotation;
        originalPosition = transform.position;
        originalScale = transform.localScale;
        Debug.Log(gameObject.name + " Saved: " + originalPosition);

        grab = GetComponent<XRGrabInteractable>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Toothbrush"))
        {
            brushedCount++; //adds 1 to how many times the teeth has been brushed
            
            remainingDirtSize = 1f - (brushedCount / 3f);
            transform.localScale = originalScale * remainingDirtSize; //makes the dirt to half its original size 
            
            Debug.Log(remainingDirtSize);
            Debug.Log(brushedCount);
            if(brushedCount >= 3) //if the teeth have been brushed more than 3 times
            {
                totalDirtCount++; //adds 1 to total dirt count
                Destroy(gameObject); //Destorys the dirt spot
                if(totalDirtCount >= dirtCount)
                {
                    finishBrushUI.SetActive(true);
                    selectGameGroup.SetActive(true);
                    helpGamesCompleted++; //adds 1 to how many games that help daffodil have been done
                    selectActivityGroup.SetActive(false); //disable activity
                    Destroy(gameObject);

                    //Bring the player back to the selection screen once all dirt spot have been cleaned + blanks out the activity
                    if (helpGamesCompleted >= 2)
                    {
                        finishUI.SetActive(true);
                    }
                }
            }
        }
    }

    /*public void holdingBrush()
    {
        transform.localRotation = Quaternion.Euler(0, 0, 90);
        Debug.Log("Holding brush");
    }*/ //not working

    public void letGoBrush()
    {
        grab.enabled = false;

        StartCoroutine(ReturnBrush());
    }

    private IEnumerator ReturnBrush()
    {
        yield return new WaitForEndOfFrame();

        transform.position = originalPosition;
        transform.rotation = originalRotation;

        yield return null;

        grab.enabled = true;
    }
}
