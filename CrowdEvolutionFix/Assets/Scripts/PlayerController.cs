using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private float horSpeed;
    [SerializeField] private float moveSpeed;
    [SerializeField] private TMP_Text yearText;
    [SerializeField] public int yearInt;

    private float hor;
    public List<GameObject> Players = new List<GameObject>();

    public static PlayerController instance;
    public static Action<int> YearChanged;

    private void OnEnable()
    {
        if (instance == null)
        {
            instance = this;
        }
        EventManager.manDown += manDown;
    }
    private void OnDisable()
    {
        EventManager.manDown -= manDown;
    }
    private int gateIndex;
    void Update()
    {
        yearText.SetText($"{yearInt} Year");
        ForwardPlayer();
        HorizontalMove();

        var data = GetComponent<BoxFormation>().EvaluatePoints().ToList();


        for (int i = 0; i < Players.Count; i++)
        {
            Players[i].transform.position = data[i] + transform.position;
        }
    }
    private void HorizontalMove()
    {

        float _newX;

        if (Input.GetMouseButton(0))
        {
            hor = Input.GetAxisRaw("Mouse X");
        }

        _newX = transform.position.x + hor * horSpeed * Time.deltaTime;
        _newX = Mathf.Clamp(_newX, 0.4f, 9.2f);

        transform.position = new Vector3(
            _newX,
            transform.position.y,
            transform.position.z
           );

    }
    private void ForwardPlayer()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
    void IncresePlayer()
    {
        for (int i = 0; i < gateIndex; i++)
        {
            GameObject newplayer = Instantiate(playerPrefab);
            Players.Add(newplayer);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Gate"))
        {

            gateIndex = other.gameObject.GetComponent<GateController>().getGateNumber();
            if (gateIndex > 0)
            {
                IncresePlayer();
            }

        }
        if (other.gameObject.CompareTag("YearGate"))
        {
            if (other.GetComponent<GateController>().gateType == GateController.GateType.smallyear)
            {
                yearInt += 100;
            }
            else if (other.GetComponent<GateController>().gateType == GateController.GateType.middleyear)
            {
                yearInt += 300;
            }
            else
            {
                yearInt += 500; 
            }
            YearChanged?.Invoke(yearInt);
        }
    }
    private void manDown(GameObject man)
    {
        Players.Remove(man);
        if (Players.Count<1)
        {
            print("game over");
            Time.timeScale = 0;// game over
        }
    }
}
