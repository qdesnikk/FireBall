using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _aboutButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private GameObject _menuPanel;
    [SerializeField] private GameObject _aboutPanel;

    private void OnEnable()
    {
        _startButton.onClick.AddListener(StartGame);
        _aboutButton.onClick.AddListener(ShowAboutPanel);
        _exitButton.onClick.AddListener(Exit);
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(StartGame);
        _aboutButton.onClick.RemoveListener(ShowAboutPanel);
        _exitButton.onClick.RemoveListener(Exit);
    }

    private void StartGame()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        Time.timeScale = 1;
    }

    private void ShowAboutPanel()
    {
        StartCoroutine(ShowWindowTimer());
    }

    private void Exit()
    {
        Application.Quit();
        Debug.Log("exit");
    }

    IEnumerator ShowWindowTimer()
    {
        _menuPanel.SetActive(false);
        _aboutPanel.SetActive(true);

        yield return new WaitForSeconds(2f);

        _aboutPanel.SetActive(false);
        _menuPanel.SetActive(true);
    }
}
