using Backtrace.Unity.Model;
using UnityEngine;
using UnityEngine.Assertions;

public class BacktraceBeforeSendHandler : MonoBehaviour
{
    void OnEnable()
    {
        Backtrace.Unity.BacktraceClient backtraceClient = FindObjectOfType<Backtrace.Unity.BacktraceClient>();
        Assert.IsNotNull(backtraceClient);

        backtraceClient.BeforeSend += AddAttributes;

        Debug.Log("Added BeforeSend handler");
    }

    void OnDisable()
    {
        Backtrace.Unity.BacktraceClient backtraceClient = FindObjectOfType<Backtrace.Unity.BacktraceClient>();
        Assert.IsNotNull(backtraceClient);

        backtraceClient.BeforeSend -= AddAttributes;

        Debug.Log("Removed BeforeSend handler");
    }

    private BacktraceData AddAttributes(BacktraceData data)
    {
#if UNITY_EDITOR
        bool isEditor = true;
#else
        bool isEditor = false;
#endif
        data.Attributes.Add("IsEditor", isEditor);
        data.Attributes.Add("BuildJob", "buildjob 123");
        data.Attributes.Add("ChangeSetId", 12345);
        data.Attributes.Add("OnlineBackend", "Backend type X");
        return data;
    }
}
