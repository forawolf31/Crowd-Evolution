using System.Collections;
using UnityEngine;

public class Throwbullet : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    public float bulletSpeed = 50000;

     void Start()
    {
        StartCoroutine(spawnBullet());
    }

    IEnumerator destroyBullet(GameObject obj)
    {
        yield return new WaitForSeconds(0.9f);
            
        Destroy(obj);
    }
    IEnumerator spawnBullet()
    {
        while (true)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, bulletPrefab.transform.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(0, 0, bulletSpeed);
            StartCoroutine(destroyBullet(bullet));

            yield return new WaitForSeconds(2.6f);
        }
    }

}
