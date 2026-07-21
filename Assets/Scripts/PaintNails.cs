using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using System.Collections;

public class PaintNails : MonoBehaviour
{
    [SerializeField]
    private int paintedNailCount = 0; //counts how many nails have already been painted

    [SerializeField]
    private Material greenColour;

    [SerializeField]
    private Material redColour;

    public static bool isGreen = false;

    public static bool isRed = false;

    [SerializeField]
    private bool paintedNail = false;
    
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

    void Start()
    {
        originalRotation = transform.rotation;
        originalPosition = transform.position;

        grab = GetComponent<XRGrabInteractable>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Paintbrush") && isGreen && !paintedNail)
        {
            Renderer renderer = GetComponent<Renderer>();
            renderer.material = greenColour;
            paintedNailCount++;
            paintedNail = true;
            if (paintedNailCount >= 3)
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
        else if (other.CompareTag("Paintbrush") && isRed && !paintedNail)
        {
            Renderer renderer = GetComponent<Renderer>();
            renderer.material = redColour;
            paintedNailCount++;
            paintedNail = true;
            if (paintedNailCount >= 3)
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
            else if (other.CompareTag("RedPaintbottle"))
            {
                isRed = true;
                isGreen = false;
            }
            else if (other.CompareTag("GreenPaintbottle"))
            {
                isRed = false;
                isGreen = true;
            }
        }
    }

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
