using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BallBlast
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class Player : MonoBehaviour
    {
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

        private Queue<Transform> bullets = new Queue<Transform>();
        //used for not going out of camera bounds
        private Vector2 _cameraBOunds;
        private IPlayerInput _input;
        private GameManager _gameManager;

    }
}


