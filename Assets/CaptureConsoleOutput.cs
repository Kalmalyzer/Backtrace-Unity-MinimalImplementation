using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class CaptureConsoleOutput : MonoBehaviour {

    private Text text;

    void Awake()
    {
        text = GetComponent<Text>();
        Assert.IsNotNull(text);

        text.text = "";
    }

    void OnEnable()
    {
        Application.logMessageReceived += OnMessageReceived;
    }

    void OnDisable()
    {
        Application.logMessageReceived -= OnMessageReceived;
    }

    private void OnMessageReceived(string condition, string stackTrace, LogType type)
    {
        string message = string.Format("{0}: {1}: {2}\n", Time.realtimeSinceStartup, type, condition);

        text.text += message;

        while (text.preferredHeight > 1000)
        {
            int firstNewlinePosition = text.text.IndexOf('\n');
            if (firstNewlinePosition == -1)
                break;

            text.text.Remove(0, firstNewlinePosition + 1);
        }
    }
}
