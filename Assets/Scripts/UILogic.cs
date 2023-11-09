using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UILogic : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    private InputActions _playerInputActions; //Player's 
    private void OnEnable()
    {
        _playerInputActions = new InputActions();
        _playerInputActions.UI.Enable();
        _playerInputActions.UI.OpenPauseMenu.performed += OpenPauseMenu;
    }
    private void OnDisable()
    {
        _playerInputActions.UI.Disable();
    }
    private void OpenPauseMenu(InputAction.CallbackContext context)
    {
        if (GameManager.Instance.gameState == GameState.paused)
        {
            Time.timeScale = 1f;
            _playerInputActions.Player.Enable();
            _pauseMenu.SetActive(false);
            GameManager.Instance.SetGameState(GameState.play);
        }
        else
        {
            Time.timeScale = 0f;
            _playerInputActions.Player.Disable();
            _pauseMenu.SetActive(true);
            GameManager.Instance.SetGameState(GameState.paused);
        }
    }
}
