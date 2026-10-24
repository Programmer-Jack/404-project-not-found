using UnityEngine;
using System.Collections;

public class CrashOnFall : MonoBehaviour
{
    public enum CrashMode
    {
        AppQuit,
        LoopCrash,
        InstanceCrash,
    }

    private readonly string _playerTag = "Player";
    [SerializeField] private CrashMode _crashMode = CrashMode.AppQuit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_playerTag))
        {
            switch (_crashMode)
            {
                case CrashMode.AppQuit:
                    AppQuit();
                    break;
                case CrashMode.LoopCrash:
                    LoopCrash();
                    break;
                case CrashMode.InstanceCrash:
                    StartCoroutine(InstanceCrashRoutine());
                    break;
                default:
                    break;
            }
        }
    }

    private void AppQuit()
    {
        print("Quitting application...");
        Application.Quit();
    }

    private void LoopCrash()
    {
        print("Entering loop...");
        while (true)
        {
            print("67");
        }
    }

    IEnumerator InstanceCrashRoutine()
    {
        print("Beginning instantiation loop...");
        int i = 1;
        while (true)
        {
            int j = (int)Mathf.Pow(i, 2);
            for (int k = 0; k < j; k++)
            {
                GameObject instance = GameObject.CreatePrimitive(PrimitiveType.Cube);
                instance.transform.position = new(i, j, k);
            }
            i++;
            yield return null;
        }
    }
}
