using UnityEngine;

public class GenerateException2 : MonoBehaviour
{
    public class Exception2 : System.Exception
    {
        public Exception2(string message) : base(message) { }
    }

    public void OnClick()
    {
        throw new Exception2("Exception 2");
    }
}
