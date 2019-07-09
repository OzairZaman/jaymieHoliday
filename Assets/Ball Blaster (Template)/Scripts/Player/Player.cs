using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BallBlast
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class Player : MonoBehaviour
    {
        #region Variables
        [SerializeField] private float _movementSpeed = 8f;

        [Header("- Bounds -")]
        [SerializeField] private float _boundOffset = 0.6f;

        [Header("- Sounds -")]
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioSource _PickUpCoinAudioSource;
        [SerializeField] private AudioClip _shotClip;
        [SerializeField] private AudioClip _gameOverClip;

        [Header("- Shooting setting -")]
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private int _generateBulletCOunt = 500;
        [SerializeField] private Transform[] _bulletPosions;

        [Header("- Shooting speed/power -")]
        [SerializeField] private float _shootSpeed = 0.6f;
        [SerializeField] private int _shootPower = 1;
        [SerializeField] private bool _useInspectorValue;

        private Queue<Transform> _bullets = new Queue<Transform>();
        //used for not going out of camera bounds
        private Vector2 _cameraBOunds;
        private IPlayerInput _input;
        private GameManager _gameManager;

        public float shootSpeed { get { return _shootSpeed; } }
        public float shootPower { get { return _shootPower; } }
        public delegate void OnCoinPickedUp(Coin coinValue);
        public event OnCoinPickedUp CoinPickedEvent;
        private bool _canShoot = true;
        #endregion

        #region Monobehavior
        #endregion

        #region Methods
        private void OngameStarted()
        {
            if (!_useInspectorValue)
            {

            }
            if (GetComponent<Animator>())
                GetComponent<Animator>().enabled = false;
            foreach (Transform bullet in _bullets)
                bullet.GetComponent<Bullet>().ShootPower = _shootPower;
        }
        private void Finishgame()
        {
            PlaySound(_gameOverClip);
            _gameManager.FinishGame();
        }
        private void CheckBounds()
        {
            if (transform.position.x < _cameraBOunds.x)
                transform.position = new Vector3(_cameraBOunds.x, transform.position.y, transform.position.z);
            else if (transform.position.x > _cameraBOunds.y)
                transform.position = new Vector3(_cameraBOunds.y, transform.position.y, transform.position.z);

        }
        private void Shoot()
        {
            if (_canShoot)
            {
                StartCoroutine(CanShoot(_shootSpeed));

                PlaySound(_shotClip);

                if (_bullets.Count >= _bulletPosions.Length)
                {
                    for (int i = 0; i < _bulletPosions.Length; i++)
                    {
                        Transform bullet = _bullets.Dequeue();
                        bullet.position = _bulletPosions[i].position;
                        bullet.GetComponent<Bullet>().EnableMovement();
                    }
                }
                else
                {
                    Debug.LogError("Player: GeneratedBulletsCount was too small");
                }
            }
        }
        private IEnumerator CanShoot(float time)
        {
            while (time > 0)
            {
                time -= Time.deltaTime;
                yield return null;
            }

            _canShoot = true;
        }
        private void AddBulletToQueue(Transform bullet)
        {
            _bullets.Enqueue(bullet);
        }
        private void PlaySound(AudioClip clip)
        {
            _audioSource.clip = clip;
            _audioSource.Play();
        }
        #endregion



    }
}


