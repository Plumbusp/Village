using UnityEngine;
using UnityEngine.InputSystem;

public class UILogic : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _shop;
    private InputActions _playerInputActions; //Player's 
    private void OnEnable()
    {
        _playerInputActions = new InputActions();
        _playerInputActions.UI.Enable();
        _playerInputActions.UI.OpenPauseMenu.performed += HandlePauseMenu;
        _playerInputActions.UI.OpenShop.performed += HandleShop;
        _playerInputActions.UI.OpenShop.Disable();

        PauseMenuLogic.OnContinueButtonClick += HandlePauseMenu;
        PlayerInteractions.OnPlayerShopEnter += () => _playerInputActions.UI.OpenShop.Enable();
        PlayerInteractions.OnPlayerShopExit += () => _playerInputActions.UI.OpenShop.Disable();

        ResumeGame();
    }
    private void OnDisable()
    {
        _playerInputActions.UI.Disable();
        _playerInputActions.UI.OpenPauseMenu.performed -= HandlePauseMenu;
        _playerInputActions.UI.OpenShop.performed -= HandleShop;
    }
    private void HandlePauseMenu(InputAction.CallbackContext context)
    {
        if (GameManager.Instance.gameState == GameState.paused)
        {
            ResumeGame();
            _pauseMenu.SetActive(false);
        }
        else
        {
            Pausegame();
            _pauseMenu.SetActive(true);
        }
    }
    private void HandlePauseMenu()
    {
        if (GameManager.Instance.gameState == GameState.paused)
        {
            ResumeGame();
            _pauseMenu.SetActive(false);
        }
        else
        {
            Pausegame();
            _pauseMenu.SetActive(true);
        }
    }
    private void HandleShop(InputAction.CallbackContext context)
    {
        if (GameManager.Instance.gameState == GameState.paused)
        {
            ResumeGame();
            _shop.SetActive(false);
        }
        else
        {
            Pausegame();
            _shop.SetActive(true);
        }
    }
    private void Pausegame()
    {
        Time.timeScale = 0f;
        _playerInputActions.Player.Disable();
        GameManager.Instance.SetGameState(GameState.paused);
    }
    private void ResumeGame()
    {
        Time.timeScale = 1f;
        _playerInputActions.Player.Enable();
        GameManager.Instance.SetGameState(GameState.play);
    }
}
