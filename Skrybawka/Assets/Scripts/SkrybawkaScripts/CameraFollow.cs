using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float cameraSpeed;
    public float distance; // How far can we move away from camera center before moving the camera towards the player
    public bool panCamera;

    Vector3 cameraOffset;

    private void Start() // Executed before LateUpdate()
    {
        cameraOffset = transform.position;
    }

    private void LateUpdate() // Executed at the end of the frame
    {
        if(panCamera == true)
            PanCamera();
        else
            CenterCamera();
    }

    void PanCamera()
    {
        Vector3 playerPosition = player.position;
        Vector3 direction = playerPosition - gameObject.transform.position;

        float magnitude = Mathf.Sqrt((direction.x * direction.x) + (direction.y * direction.y));

        if(magnitude >= distance)
        {
            gameObject.transform.Translate(new Vector2(direction.x, direction.y) * cameraSpeed * Time.deltaTime);
        }
    }

    void CenterCamera()
    {
        // Place camera at X and Y of the player, remain at Z of the camera
        gameObject.transform.position = new Vector3(player.position.x + cameraOffset.x, player.position.y + cameraOffset.y, transform.position.z) ;
    }
}
