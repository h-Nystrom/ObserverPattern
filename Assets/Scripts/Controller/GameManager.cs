using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Controller{
    public class GameManager : MonoBehaviour, ICoinChange{
        [SerializeField] int goalAmount = 2;
        int currentCoins;
        [SerializeField] UnityEvent<bool> gameMenuDisplayed;
        [SerializeField] UnityEvent<string> menuTextChanged;
        bool isGameOver;
        bool isPause;
        void Awake(){
            CoinObserver.SubscribeToCoinChange(this);
        }

        void Update(){
            if (Input.GetKeyDown(KeyCode.Escape)){
                OnPause();
            }
        }

        public void AddCoin(int amount){
            currentCoins += amount;
            if (currentCoins < goalAmount) return;
            Time.timeScale = 0;
            GameOver("Level completed!");
        }

        void GameOver(string gameOverText){
            gameMenuDisplayed?.Invoke(true);
            menuTextChanged?.Invoke(gameOverText);
            isGameOver = true;
        }

        public void OnPlay(){
            if (isGameOver){
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            gameMenuDisplayed?.Invoke(false);
            isPause = false;
            Time.timeScale = 1;
        }
        public void OnPause(){
            if(isGameOver)
                return;
            isPause = !isPause;
            gameMenuDisplayed?.Invoke(isPause);
            Time.timeScale = isPause ? 0 : 1;
            menuTextChanged?.Invoke("Pause!");
        }
    }
}