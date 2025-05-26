using UnityEngine;
using TMPro;

public class OpenDoorByCODE : MonoBehaviour
{
    private Animator anim_bt;
    public Animator anim_door;
    public Renderer rend;

    [SerializeField]
    private TextMeshProUGUI codeText;
    private string codeTextValue = "";
    public string safeCode;
    public GameObject codePanel;

    public MonoBehaviour playerControler;
    public MonoBehaviour cameraController;
    public MonoBehaviour gameManager;

    private bool playerInRange;
    private bool isCodePanelOpen = false;


    // ====================================================================================


    void Start()
    {
        playerInRange = false;

        anim_bt = GetComponent<Animator>();
        codeText = codePanel.GetComponentInChildren<TextMeshProUGUI>();

        if (codeText == null)
            Debug.LogError("codeText not found in codePanel!");

        codePanel.SetActive(false);
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            OpenCodePanel();
        }

        if (playerInRange && Input.GetKeyDown(KeyCode.Escape))
        {
           CloseCodePanel();
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
        if (!codePanel.activeSelf) return;

        if (codeTextValue.Length < 4)
        {
            codeTextValue += digit;
            codeText.text = codeTextValue;
            Debug.Log("Current code: " + codeTextValue);
        }
    }

    public void DelDigits()
    {
        if (codeTextValue.Length > 0)
        {
            codeTextValue = codeTextValue.Substring(0, codeTextValue.Length - 1);
            codeText.text = codeTextValue;
        }
    }

    public void EneterCode()
    {
        if (codeTextValue == safeCode)
        {
            anim_door.SetTrigger("open");
            CloseCodePanel();

            anim_bt.SetTrigger("Pressed");

            if (rend != null)
            {
                Material mat = rend.material;
                mat.DisableKeyword("_EMISSION");
                mat.SetColor("_EmissionColor", Color.black);
            }
        }
        else
        {
            codeTextValue = "";
            codeText.text = codeTextValue;
        }
    }

    private void OpenCodePanel()
    {
        isCodePanelOpen = true;
        codePanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        playerControler.enabled = false;
        cameraController.enabled = false;
        gameManager.enabled = false;
    }

    private void CloseCodePanel()
    {
        isCodePanelOpen = false;
        codePanel.SetActive(false);
        codeTextValue = "";
        codeText.text = "";

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        playerControler.enabled = true;
        cameraController.enabled = true;
        gameManager.enabled = true;
    }
}
