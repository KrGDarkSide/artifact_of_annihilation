using UnityEngine;
using TMPro;
using System;

public class OpenDoorByCODE : MonoBehaviour
{
    private Animator anim_bt;
    public Animator anim_door;
    public Renderer rend;

    public GameObject codePanelUI;
    public TMP_Text displayCode;
    private string enteredCode = "";
    public string correctCode = "8738";

    private bool playerInRange;

    public MonoBehaviour playerController;

    // ====================================================================================


    void Start()
    {
        playerInRange = false;
        anim_bt = GetComponent<Animator>();
        CloseCodePanel();
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!codePanelUI.activeSelf)
            {
                OpenCodePanel();
            }
        }

        // ACCESS INSTANTLY ----------------------
        if (Input.GetKeyDown(KeyCode.C))
        { enteredCode = "8738"; UpdateDisplay(); }
        if (Input.GetKeyDown(KeyCode.V))
        { EneterCode(); }
        // ---------------------------------------

        if (codePanelUI.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
           CloseCodePanel();
        }

        if (codePanelUI.activeSelf)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0f;
        }
    }


    // =====================================================================================


    private void OnTriggerEnter(Collider obj)
    {
        if (obj.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider obj)
    {
        if (obj.CompareTag("Player"))
        {
            playerInRange = false;
            CloseCodePanel();
        }
    }



    public void AddCodeDigit(string digit)
    {
        if (enteredCode.Length < 4)
        {
            enteredCode += digit;
            UpdateDisplay();
        }
    }

    public void DelDigits()
    {
        // Remove the last digit from the entered code
        if (enteredCode.Length > 0)
        {
            enteredCode = enteredCode.Substring(0, enteredCode.Length - 1);
            UpdateDisplay();
        }
    }

    public void EneterCode()
    {
        Material mat = rend.material;

        if (enteredCode == correctCode)
        {
            anim_door.SetTrigger("open");
            anim_bt.SetTrigger("Pressed");

            mat.DisableKeyword("_EMISSION");
            mat.SetColor("_EmissionColor", Color.black);

            CloseCodePanel();
        }
        else
        {
            mat.SetColor("_EmissionColor", Color.blue);

            enteredCode = "";
            UpdateDisplay();
        }
    }

    private void OpenCodePanel()
    {
        codePanelUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }

    private void CloseCodePanel()
    {
        codePanelUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
        enteredCode = "";
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        displayCode.text = enteredCode;
    }
}
