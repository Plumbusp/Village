using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { play, paused, gameOver }
public class GameManager: MonoBehaviour
{
        public delegate void OnStateChangeHandler();
        public event OnStateChangeHandler OnStateChange;

        public static GameManager Instance = null;

        public GameState gameState { get; private set; }

        private void Awake()
        {

           if (Instance == null)
           {
               Instance = this;
           }
           else
           {
               Destroy(this.gameObject);
               return;
           }

           DontDestroyOnLoad(this.gameObject);
        }
    private void Start()
        {
             gameState = GameState.play;
        }
        public void SetGameState(GameState state)
        {
            this.gameState = state;
            OnStateChange?.Invoke();
        }

        public void OnApplicationQuit()
        {
              GameManager.Instance = null;
        }
}
