using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void CursorInGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void CursorOutGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
