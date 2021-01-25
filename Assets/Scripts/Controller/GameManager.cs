using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using View;

namespace Controller{
    public class GameManager : MonoBehaviour{
        [SerializeField] int goalAmount = 2;
        int currentCoins;
        [SerializeField] UnityEvent<bool> gameMenuDisplayed;
        [SerializeField] UnityEvent<string> menuTextChanged;
        bool isGameOver;
        bool isPause;
        void Start(){
            MessageHandler.instance.SubscribeTo<CoinMessage>(AddCoin);
            MessageHandler.instance.SubscribeTo<PlayerHealthMessage>(ChangePlayerHealth);
        }

        void Update(){
            if (Input.GetKeyDown(KeyCode.Escape)){
                OnPause();
            }
        }

        void ChangePlayerHealth(PlayerHealthMessage playerHealthMessage){
            if(playerHealthMessage.Value > 0) return;
            GameOver("You died");
        }
        void AddCoin(CoinMessage coinMessage){
            currentCoins += coinMessage.Value;
            if (currentCoins < goalAmount) return;
            GameOver("Level completed!");
        }

        void GameOver(string gameOverText){
            Time.timeScale = 0;
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
        void OnPause(){
            if(isGameOver)
                return;
            isPause = !isPause;
            gameMenuDisplayed?.Invoke(isPause);
            Time.timeScale = isPause ? 0 : 1;
            menuTextChanged?.Invoke("Pause!");
        }
    }
}