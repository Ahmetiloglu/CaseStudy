using System;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    
    [Header("Elements")] 
    [SerializeField] private GameObject restartPanel;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        restartPanel.SetActive(false);
    }

    public void ActivateRestartButton()
    {
        restartPanel.SetActive(true);
    }
}
