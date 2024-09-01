using UnityEngine;
using UnityEngine.UI;

public class ScrollbarHandler : MonoBehaviour
{
    public Scrollbar scrollbar;

    void Start()
    {
        // Set the initial value of the scrollbar if needed
        scrollbar.value = 0.5f;
        
        // Add a listener to handle scrollbar value changes
        scrollbar.onValueChanged.AddListener(OnScrollbarValueChanged);
    }

    void OnScrollbarValueChanged(float value)
    {
        // Perform actions based on the scrollbar value
        Debug.Log("Scrollbar Value: " + value);
    }
}
