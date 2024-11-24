using UnityEngine;

public class BlinkMonster : MonoBehaviour
{
    public float Speed = 5.0f;
    public float range = 5.0f;
    private float startingPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startingPosition = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > startingPosition + range)
        {
            Speed = -Mathf.Abs(Speed);
        }
        else if(transform.position.y < startingPosition - range)
        {
            Speed = Mathf.Abs(Speed);
        }
        transform.Translate(Vector3.up * Speed * Time.deltaTime);
    }
}
