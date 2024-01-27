using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Countdown(); 
    }

    [SerializeField]
    float maxTime = 10f;
    async void Countdown()
    {
        await Task.Delay(1000);
        maxTime -= 1;
        GetComponent<TextMeshProUGUI>().text = maxTime.ToString();
        if(maxTime<=0)
        { Debug.Log("Game over"); }
        else
        Countdown();
    }
}
