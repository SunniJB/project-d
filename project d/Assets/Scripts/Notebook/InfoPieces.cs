using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System.Diagnostics;

public class InfoPieces : MonoBehaviour
{
    private Vector3 worldPosition, startPosition;
    public bool touchedABox;
    public GameObject currentBox;
    public string infoText;

    private void Start()
    {
        startPosition = transform.position;
        gameObject.GetComponentInChildren<TextMeshProUGUI>().text = infoText;
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("box"))
        {
            currentBox = other.gameObject;
            touchedABox = true;
            other.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("box"))
        {
            touchedABox = false;
            currentBox = null;
            other.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Drag information here";
        }
    }

    public void EndDrag()
    {
        if (touchedABox)
        {
            gameObject.GetComponent<Collider>().enabled = false;
            currentBox.GetComponentInChildren<TextMeshProUGUI>().text = infoText;
            transform.position = startPosition;
            gameObject.GetComponent<Collider>().enabled = true;
        } else
        {
            UnityEngine.Debug.Log("Ended drag, didn't touch a box");
            transform.position = startPosition;
        }
    }
}
