using UnityEngine;
using UnityEngine.Assertions;

public class BacktraceClientCreator : MonoBehaviour {

    public string ConfigFileName;

    void Awake()
    {
        Assert.IsNotNull(ConfigFileName);
        Assert.AreNotEqual("", ConfigFileName);
    }

    void Start () {

        string serverUrl = "";
        string accessToken = "";

        try
        {
            using (System.IO.StreamReader configFile = new System.IO.StreamReader(ConfigFileName))
            {
                serverUrl = configFile.ReadLine();
                accessToken = configFile.ReadLine();
            }
        }
        catch (System.Exception e)
        {
            Debug.LogErrorFormat("Unable to read from config file {0}: {1}", ConfigFileName, e);
            return;
        }

        Backtrace.Unity.Model.BacktraceConfiguration backtraceConfiguration = ScriptableObject.CreateInstance<Backtrace.Unity.Model.BacktraceConfiguration>();

        backtraceConfiguration.ServerUrl = serverUrl;
        backtraceConfiguration.Token = accessToken;

        backtraceConfiguration.HandleUnhandledExceptions = true;

        backtraceConfiguration.Enabled = false;
        backtraceConfiguration.CreateDatabase = false;
        backtraceConfiguration.AutoSendMode = true;

        backtraceConfiguration.ReportPerMin = 0;
        backtraceConfiguration.RetryLimit = 3;
        backtraceConfiguration.RetryOrder = Backtrace.Unity.Types.RetryOrder.Stack;

        gameObject.SetActive(false);
        Backtrace.Unity.BacktraceClient backtraceClient = gameObject.AddComponent<Backtrace.Unity.BacktraceClient>();
        backtraceClient.Configuration = backtraceConfiguration;
        gameObject.SetActive(true);

        Debug.LogFormat("Added Backtrace client with serverUrl = {0} and token = {1}", serverUrl, accessToken);
    }
}
