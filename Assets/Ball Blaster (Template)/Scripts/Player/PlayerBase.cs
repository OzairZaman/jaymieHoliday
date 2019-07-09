
using UnityEngine;

namespace BallBlast
{
    [RequireComponent(typeof(Animator))]
    public class PlayerBase : MonoBehaviour
    {

        [SerializeField] private string _isShootingParameterName = "isShooting";

        private Animator _animator;
        private IPlayerInput _input;
        private GameManager _gameManeger;

        #region MonoBehavior
        void Awake()
        {
            _animator = GetComponent<Animator>();

            _input = GameObject.FindWithTag(Tags.Input).GetComponent<IPlayerInput>();
            _gameManeger = GameObject.FindWithTag(Tags.GameManager).GetComponent<GameManager>();

            _gameManeger.GameFinishedEvent += () => _animator.SetBool(_isShootingParameterName, false);

        }


        void Update()
        {
            if (_gameManeger.IsGameStarted && !_gameManeger.IsGameFinished)
            {
                _animator.SetBool(_isShootingParameterName, _input.IsShooterPressed());
            }
        }
        #endregion


    }

}

