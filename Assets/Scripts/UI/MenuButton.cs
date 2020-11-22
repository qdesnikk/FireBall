using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class MenuButton : MonoBehaviour
{
    private Button _menuButton;

    private void Awake()
    {
        _menuButton = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _menuButton.onClick.AddListener(ExitToMenu);
    }

    private void OnDisable()
    {
        _menuButton.onClick.RemoveListener(ExitToMenu);
    }

    private void ExitToMenu()
    {
        SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
        Time.timeScale = 0;
    }
}
