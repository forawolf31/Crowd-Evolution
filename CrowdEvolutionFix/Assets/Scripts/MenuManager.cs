using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject startPanel;

    private void Start()
    {
        Time.timeScale = 0;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Time.timeScale = 1;
        }
        if (Input.GetMouseButtonDown(0))
        {
            startPanel.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            print("Level Completed");
            Time.timeScale = 0;
        }
    }
}
