using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class InfoPieces : MonoBehaviour
{
    private Vector3 worldPosition, startPosition, endPosition;
    public Image thisImage;
    public bool touchedABox;

    private void Start()
    {
        thisImage = GetComponent<Image>();
        startPosition = gameObject.transform.position;
    }
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 7.19f;
        worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
    }
    public void OnDrag()
    {
        thisImage.transform.position = worldPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("box"))
        {
            touchedABox = true;
            endPosition = other.gameObject.transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("box"))
        {
            touchedABox = false;
            endPosition = startPosition;
        }
    }

    public void EndDrag()
    {
        if (touchedABox)
        {
            transform.position = endPosition;
        } else
        {
            transform.position = startPosition;
        }
    }
}
