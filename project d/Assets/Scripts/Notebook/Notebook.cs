using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Notebook : MonoBehaviour, IDragHandler
{
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject[] infoPieces;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }
 
}
