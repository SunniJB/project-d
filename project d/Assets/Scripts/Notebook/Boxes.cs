using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boxes : MonoBehaviour
{
    [SerializeField] GameObject currentInfoPiece, correctInfoPiece;
    public bool hasTheRightInfo;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision was detected");
        if (other.gameObject.CompareTag("infoPiece"))
        {
            Debug.Log("Collision with an info piece was detected");
            if (currentInfoPiece == null)
            {
                currentInfoPiece = other.gameObject;
                
            } else
            {
                if (currentInfoPiece.TryGetComponent<InfoPieces>(out InfoPieces oldInfo))
                {
                    oldInfo.isInTheRightPlace = false;
                    currentInfoPiece = other.gameObject;
                }
            }

            if (currentInfoPiece == correctInfoPiece)
            {
                hasTheRightInfo = true;
            } else if (currentInfoPiece != correctInfoPiece) 
            { 
                hasTheRightInfo = false; 
            }
        }
    }
}
