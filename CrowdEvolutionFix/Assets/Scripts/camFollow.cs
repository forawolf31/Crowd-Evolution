using UnityEngine;

public class camFollow : MonoBehaviour
{
    [SerializeField] private GameObject target;
    public Vector3 offset;
    public float followspeed;

    void LateUpdate()
    {
        Vector3 back = Vector3.Lerp(this.transform.position, target.transform.position + offset, followspeed);
        this.transform.position = new Vector3(1.3f, back.y, back.z);
    }
}
