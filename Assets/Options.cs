using UnityEngine;

public class ScreenToggle : MonoBehaviour
{
    public GameObject screen;
    public KeyCode toggleKey = KeyCode.Tab;

    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            screen.SetActive(!screen.activeSelf);
        }
    }

    public void continueGame()
    {
        screen.SetActive(!screen.activeSelf);
    }
}