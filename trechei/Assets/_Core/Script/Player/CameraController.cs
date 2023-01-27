using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float sensX;
    [SerializeField] private float sensY;

    [SerializeField] private Transform player;
    [SerializeField] private Vector3 cameraPosition = new Vector3(0, .5f, 0);

    [SerializeField] private GameManager gameManager;

    private float xRotation;
    private float yRotation;

    void CameraMouvement()
    {
        float _mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float _mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += _mouseX;
        xRotation -= _mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);
        
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        player.transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    void CameraPosition()
    {
        transform.position = player.transform.position + cameraPosition;
    }

    private void Start()
    {
        gameManager.CursorInGame();
    }

    private void Update()
    {
        CameraPosition();
        CameraMouvement();
    }
}
