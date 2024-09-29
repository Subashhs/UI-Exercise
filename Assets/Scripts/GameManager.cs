using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button[] buttons; // Array of buttons to instantiate
    public Canvas menu;      // Assign your Canvas in the Inspector

    void Start()
    {
        foreach (Button button in buttons)
        {
            // Instantiate a new button from the prefab
            Button buttonInstance = Instantiate(button);

            // Set the parent to the specific child of the menu canvas
            buttonInstance.transform.SetParent(menu.transform.GetChild(1), false); // Ensure local scaling is maintained

            // Optionally, reset the button's position or other properties here
            buttonInstance.transform.localScale = Vector3.one; // Ensure scale is correct
        }
    }

    void Update()
    {
        // You can add logic here if needed
    }
}
