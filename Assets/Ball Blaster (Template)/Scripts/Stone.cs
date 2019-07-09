using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BallBlast
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Collider2D), typeof(Animator))]
    public class Stone : MonoBehaviour
    {
        [Header("- AnimatorParams -")]
        [SerializeField]
        private string _hitTriggerParameter = "Hit";

        [Header("- Setting -")]
        [SerializeField]
        private Vector2 _startFlyingVelocity;

        [Header("- HP -")]
        [SerializeField] private int _hp = 20;
        [SerializeField] private Text _hpText;

        [Header("- Coins -")]
        [SerializeField] private Coin[] _coins;

        [Header("- Sounds -")]
        [SerializeField]
        private AudioSource _crashAudioSource;

        [Header("- Child Stones")]
        [SerializeField]
        private Stone[] _childStones;

        private Rigidbody2D _rb2D;
        private Collider2D _collider2D;
        private Animator _animator;
        private GameManager _gameManager;

        public Stone[] childStones { get { return _childStones;  } }

        public delegate void OnBroken();
        public event OnBroken OnBrokenEvent;

        public delegate void OnBulletHit(float damgae);
        public event OnBulletHit OnBulletHitEvent;

        #region MonoBehavior
        private void Awake()
        {
            if (!gameObject.CompareTag(Tags.Stone))
            {
                Debug.LogError("Tag your stone Stone!");
            }

            _rb2D = GetComponent<Rigidbody2D>();
            _collider2D = GetComponent<Collider2D>();
            _animator = GetComponent<Animator>();

            _gameManager = GameObject.FindWithTag(Tags.GameManager).GetComponent<GameManager>();
        }

        private void Start()
        {
            foreach (Stone childStone in _childStones)
            {
                childStone.gameObject.SetActive(false);
                childStone.DisableMovement();
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag(Tags.Bullet) && !_gameManager.IsGameFinished)
            {
                int newHp = _hp - collision.GetComponent<Bullet>().ShootPower;
                if (OnBulletHitEvent != null)
                {
                    if (newHp < 0)
                        OnBulletHitEvent(_hp);
                    else
                        OnBulletHitEvent(collision.GetComponent<Bullet>().ShootPower);
                    
                }
                UpdateHp(newHp);
                _animator.SetTrigger(_hitTriggerParameter);
                if (_hp <= 0)
                    StoneBroken();
            }
        }
        #endregion

        public void EnableMovement()
        {
            _collider2D.isTrigger = false;
            _rb2D.isKinematic = false;
            _rb2D.velocity = _startFlyingVelocity;
        }

        public void DisableMovement()
        {
            _collider2D.isTrigger = true;
            _rb2D.isKinematic = true;
            _rb2D.velocity = Vector2.zero;
            _rb2D.angularVelocity = 0;
        }

        private void StoneBroken()
        {
            DropChildStone();
            DropCoin();

            if (_crashAudioSource)
                _crashAudioSource.Play();

            if (OnBrokenEvent != null)
                OnBrokenEvent();

            Destroy(gameObject);
        }

        public void DropChildStone()
        {
            foreach (Stone childStone in _childStones)
            {
                childStone.gameObject.SetActive(true);
                childStone.transform.parent = null;
                childStone.EnableMovement();
            }
        }
        public void DropCoin()
        {
            foreach (Coin coin in _coins)
            {
                coin.ThrowThisCoin();
            }
        }

        public void UpdateHp(int newHp)
        {
            _hp = newHp;
            _hpText.text = NumberFomatter.ToKMB(_hp);
        }



    }
}


