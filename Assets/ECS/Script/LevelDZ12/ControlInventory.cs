using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlInventory : MonoBehaviour
{
    [SerializeField] private Button openCanvasButton;
    [SerializeField] private Button closeCanvasButton;
    [SerializeField] private Canvas canvas;
    // Start is called before the first frame update
    
    
    void Start()
    {
        openCanvasButton.onClick.AddListener(OpenCanvas);
        closeCanvasButton.onClick.AddListener(CloseCanvas);
        canvas.gameObject.SetActive(false);
        openCanvasButton.gameObject.SetActive(true);
    }

    private void OpenCanvas()
    {
        canvas.gameObject.SetActive(true);
        openCanvasButton.gameObject.SetActive(false);
    }
    private void CloseCanvas()
    {
        canvas.gameObject.SetActive(false);
        openCanvasButton.gameObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
