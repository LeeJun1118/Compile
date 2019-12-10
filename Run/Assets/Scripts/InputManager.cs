using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");        
    }
    void CheckClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if(Physics.Raycast(ray,out hit))
            {
                if(hit.collider.gameObject.name == "Floor1" ||
                    hit.collider.gameObject.name == "Floor2" ||
                    hit.collider.gameObject.name == "Floor3" ||
                    hit.collider.gameObject.name == "Floor4" ||
                    hit.collider.gameObject.name == "Floor5" ||
                    hit.collider.gameObject.name == "Floor6" ||
                    hit.collider.gameObject.name == "Floor7" 
                    )
                {
                    player.GetComponent<PlayerFSM>().MoveTo(hit.point);
                }
            }
        }
    }

    void Update()
    {
        CheckClick();        
    }
}
