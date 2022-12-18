using UnityEngine;

public class Fixmove : MonoBehaviour
{
    public float xIndex = 3.5f;
    public float xIndex2 = 5.7f;
    void Update()
    {
        if (transform.position.x < -xIndex)
        {
            transform.position = new Vector3(-xIndex, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xIndex2)
        {
            transform.position = new Vector3(xIndex2, transform.position.y, transform.position.z);
        }

    }
}
