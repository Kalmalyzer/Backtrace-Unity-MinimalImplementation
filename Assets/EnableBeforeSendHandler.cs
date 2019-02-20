using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class EnableBeforeSendHandler : MonoBehaviour {

    private Button button;
    public BacktraceBeforeSendHandler BacktraceBeforeSendHandler;

    void Awake()
    {
        button = GetComponent<Button>();
        Assert.IsNotNull(button);
        Assert.IsNotNull(BacktraceBeforeSendHandler);
    }

    void Update()
    {
        button.interactable = !BacktraceBeforeSendHandler.isActiveAndEnabled;
    }

    public void EnableHandler()
    {
        BacktraceBeforeSendHandler.enabled = true;
    }
}
