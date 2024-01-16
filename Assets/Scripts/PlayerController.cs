using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Object;
using FishNet.Connection;

public class PlayerController : NetworkBehaviour
{
    private Camera playerCamera;
    public GameObject leftHand;
    public GameObject rightHand;
    public override void OnStartClient()
    {
        base.OnStartClient();
        if (base.IsOwner)
        {
            playerCamera = Camera.main;
            leftHand.GetComponent<CardManager>().isHidden = false;
            rightHand.GetComponent<CardManager>().isHidden = false;
        }
        else
        {
            rightHand.GetComponent<CardManager>().isHidden = true;
            leftHand.GetComponent<CardManager>().isHidden = true;
            GetComponent<PlayerController>().enabled = false;
            
        }
    } 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
