using UnityEngine;
public class FightController : MonoBehaviour
{
    public GameObject[] Levels;
    private void OnEnable()
    {
        PlayerController.YearChanged += YearChanged;
    }
    private void Start()
    {
        YearChanged(PlayerController.instance.yearInt);
    }
    private void OnDisable()
    {
        PlayerController.YearChanged -= YearChanged;
    }
    private void YearChanged(int obj)
    {
        foreach (var item in Levels)
        {
            item.SetActive(false);
        }
        if (obj < 100)
        {
            Levels[0].SetActive(true);
        }
        else if (obj < 600)
        {
            Levels[1].SetActive(true);

        }
        else if (obj < 200)
        {
            Levels[2].SetActive(true);
        }
        else if (obj < 1400)
        {
            Levels[3].SetActive(true);
        }
        else
        {
            Levels[2].SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            
            EventManager.Event_ManDown(this.gameObject);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }      
    }
}
