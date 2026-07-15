using UnityEngine;

public class BrushTeeth : MonoBehaviour
{
    [SerializeField]
    private int brushedCount = 0; //counts how many times a spot has been brushed

    [SerializeField]
    private int dirtCount = 3; //Sets the amount of dirty spots in the scene

    public static int totalDirtCount = 0; //Count of how many dirt spots have been cleaned

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Toothbrush"))
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f); //makes the dirt to half its original size
        }
    }
}
