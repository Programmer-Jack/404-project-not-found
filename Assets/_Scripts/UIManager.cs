using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _winText;

    private void OnEnable()
    {
        FinishLine.OnWin += Temp_GameWinUI;
    }

    private void OnDisable()
    {
        FinishLine.OnWin -= Temp_GameWinUI;
    }

    private void Start()
    {
        _winText.SetActive(false);
    }

    private void Temp_GameWinUI()
    {
        _winText.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
