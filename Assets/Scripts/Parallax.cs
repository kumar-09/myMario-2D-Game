using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform mainCamera;
    public Transform mainBackground;
    public Transform sideBackground;
    float length = 48.0f;
    // Update is called once per frame
    void Update()
    {
        if(mainCamera.position.x>mainBackground.position.x)
        {
            sideBackground.position = mainBackground.position + Vector3.right * length;
        }
        if(mainCamera.position.x<mainBackground.position.x)
        {
            sideBackground.position = mainBackground.position + Vector3.left * length;
        }
        if(mainCamera.position.x>sideBackground.position.x || mainCamera.position.x<sideBackground.position.x)
        {
            Transform temp = mainBackground;
            mainBackground = sideBackground;
            sideBackground = temp;
        }
    }
}
