using UnityEngine;
using UnityEngine.SceneManagement;
namespace BallBlast
{
    public class GameManager : MonoBehaviour
    {
        public bool IsGameStarted { get; private set; }
        public bool IsGameFinished { get; private set; }
        public delegate void OnGameStarted();
        public delegate void OnGameFinished();
        public event OnGameStarted GameStartedEvent;
        public event OnGameFinished GameFinishedEvent;
        private IPlayerInput _input;
        private bool _onceWasUp;
        #region MonoBehaviour
        private void Start()
        {
            if (!gameObject.CompareTag(Tags.GameManager))
            {
                Debug.LogError("GameManager: has to be tagged as GameManager.");
            }
            _input = GameObject.FindWithTag(Tags.Input).GetComponent<IPlayerInput>();
        }
        private void Update()
        {
            if (_input.IsPointerDown() && !IsGameStarted && !IsGameFinished)
            {
                StartGame();
            }
            else if (_input.IsPointerUp() && IsGameStarted && IsGameFinished)
            {
                if (_onceWasUp)
                    LoadLevel(1);
                else
                    _onceWasUp = true;
            }
        }
        #endregion
        private void StartGame()
        {
            IsGameStarted = true;

            if(GameStartedEvent != null)
            {
                GameStartedEvent();
            }
        }
        private void FinishGame()
        {
            IsGameFinished = true;

            if (GameFinishedEvent != null)
            {
                GameFinishedEvent();
            }
            //GameOver Thing Here Later!
        }
        private void LoadLevel(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
