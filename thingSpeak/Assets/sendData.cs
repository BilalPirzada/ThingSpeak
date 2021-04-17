using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class sendData : MonoBehaviour
{
    int randomTempValue;
    int randomHumdityValue;


    void Start()
    {
        StartCoroutine(GetRequest("https://api.thingspeak.com/update?api_key=COZF3VWIZ0J02MAL&field1="));
        StartCoroutine(GetRequest2("https://api.thingspeak.com/update?api_key=COZF3VWIZ0J02MAL&field2="));
    }

    IEnumerator GetRequest2(string uri)
    {
        randomHumdityValue = (int)Random.Range(0f, 100f);
        UnityWebRequest uwr = UnityWebRequest.Get(uri + randomHumdityValue);
        yield return uwr.SendWebRequest();



        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            Debug.Log("Received: " + uwr.downloadHandler.text);
        }
        yield return new WaitForSeconds(10);
        StartCoroutine(GetRequest2("https://api.thingspeak.com/update?api_key=COZF3VWIZ0J02MAL&field2="));


    }

    IEnumerator GetRequest(string uri)
    {
        randomTempValue = (int)Random.Range(0f, 100f);
        UnityWebRequest uwr = UnityWebRequest.Get(uri+randomTempValue);
        yield return uwr.SendWebRequest();
        


        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            Debug.Log("Received: " + uwr.downloadHandler.text);
        }
        yield return new WaitForSeconds(10);
        StartCoroutine(GetRequest("https://api.thingspeak.com/update?api_key=COZF3VWIZ0J02MAL&field1="));


    }
}

