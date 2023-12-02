using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System.Diagnostics;

public class InfoPieces : MonoBehaviour
{
    private Vector3 worldPosition, startPosition, endPosition;
    public bool touchedABox;
    public GameObject currentBox;

    private void Start()
    {
        startPosition = transform.position;
    }
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 7.19f;
        worldPosition = Camera.main.ScreenToWorldPoint(mousePos);

        if (Input.GetKeyDown(KeyCode.F))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                UnityEngine.Debug.Log(hit.collider.gameObject.name);
            }
        }
    }
    public void OnDrag()
    {
        transform.position = worldPosition;
        UnityEngine.Debug.Log("Dragging should occur");
    }

    private void OnTriggerEnter(Collider other)
    {
        UnityEngine.Debug.Log("Entered a collider");
        if (other.gameObject.CompareTag("box"))
        {
            UnityEngine.Debug.Log("Entered the box's collider");
            currentBox = other.gameObject;
            touchedABox = true;
            endPosition = other.gameObject.transform.position;
            other.gameObject.GetComponent<Image>().enabled = false;
            other.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        UnityEngine.Debug.Log("Left a collider");
        if (other.gameObject.CompareTag("box"))
        {
            UnityEngine.Debug.Log("Left the box's collider");
            touchedABox = false;
            currentBox = null;
            other.gameObject.GetComponent<Image>().enabled = true;
            other.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Drag information here";
        }
    }

    public void EndDrag()
    {
        UnityEngine.Debug.Log("End Drag fired");
        if (touchedABox)
        {
            UnityEngine.Debug.Log("Ended drag, touched a box");
            transform.position = endPosition;
        } else
        {
            UnityEngine.Debug.Log("Ended drag, didn't touch a box");
            transform.position = startPosition;
        }
    }
}
