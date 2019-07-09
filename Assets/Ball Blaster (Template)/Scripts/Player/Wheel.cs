using UnityEngine;

namespace BallBlast
{
    public class Wheel : MonoBehaviour
    {

        [SerializeField] private Transform _player;
        private float _lastPlayerPositionX;
        private float _wheelDiameter;


        #region Monobehavior
        private void Awake()
        {
            _lastPlayerPositionX = _player.position.x;
            _wheelDiameter = GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        }


        private void Update()
        {
            float differenceBetweenPositionX = _player.position.x - _lastPlayerPositionX;
            _lastPlayerPositionX = _player.position.x;
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, (transform.localEulerAngles.z - 360 * differenceBetweenPositionX / (Mathf.PI * _wheelDiameter)));
        }
        #endregion

    }
}

