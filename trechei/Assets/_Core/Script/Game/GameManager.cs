using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Timer timer;
    
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
