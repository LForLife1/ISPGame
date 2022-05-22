using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomTransfer : MonoBehaviour
{
    public Vector2 playerPosition;
    public Vector2 cameraChangeMaxBounds;
    public Vector2 cameraChangeMinBounds;
    public Vector3 playerChange;
    public VectorValue playerStorage;

    public GameObject fadeInPanel;
    public GameObject fadeOutPanel;
    public float fadeWait;

    private CameraMovement cam;

    void Awake()
    {
        if(fadeInPanel != null)
        {
            GameObject panel = Instantiate(fadeInPanel, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, 1);
        }
    }

    void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            cam.minPosition.x = cameraChangeMinBounds.x;
            cam.minPosition.y = cameraChangeMinBounds.y;
            cam.maxPosition.x = cameraChangeMaxBounds.x;
            cam.maxPosition.y = cameraChangeMaxBounds.y;
            other.transform.position += playerChange;
        }
    }
}
