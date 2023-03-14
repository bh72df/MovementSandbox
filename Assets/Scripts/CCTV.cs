using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.AppleTV;
using UnityEngine;

public class CCTV : MonoBehaviour
{
    [SerializeField]
    float MaxPlayerDistancce = 12f;
    [SerializeField]
    float PlayerDistance;
    float tick;
    float delayTimer = 2f;
    bool scanready = true;
    [SerializeField]
    Transform CCTVTransform;
    [SerializeField]
    Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        tick = delayTimer;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Detect();
        
    }

    bool IsReadyToScan()
    {
        if (tick < delayTimer)
        {
            tick += Time.deltaTime;
            return false;
        }

        return true;
    }

    void Detect()
    {

        PlayerDistance = Vector3.Distance(playerTransform.position, CCTVTransform.position);
        scanready = IsReadyToScan();

        if (scanready == true)
        {
            if (PlayerDistance <= MaxPlayerDistancce)
            {
                Debug.Log("You have been detected");

            }

        }



    }
}
