using UnityEngine;
using TMPro;
public class GateController : MonoBehaviour
{
    [SerializeField] private TMP_Text gateNumberText;
    [SerializeField] private int gateIndex;
    [SerializeField]
    public enum GateType
    {
        numberGate,
        smallyear,
        middleyear,
        bigyear
    }
    public GateType gateType;

   

    void Start()
    {
        RandomGateNumber();       
    }
    public int getGateNumber()
    {
        return gateIndex;     
    }
    private void RandomGateNumber()
    {
        switch (gateType)
        {
            case GateType.numberGate:
                gateIndex = Random.Range(1, 5);
                gateNumberText.text = "+" + gateIndex.ToString() + "  man";
                break;
            case GateType.smallyear:
                gateIndex = (100);
                gateNumberText.text = "+" + gateIndex.ToString() + "  year";
                break;
            case GateType.middleyear:
                gateIndex = (300);
                gateNumberText.text = "+" + gateIndex.ToString() + "  year";
                break;
            case GateType.bigyear:
                gateIndex = (500);
                gateNumberText.text = "+" + gateIndex.ToString() + "  year";
                break;
        }
    }
}
