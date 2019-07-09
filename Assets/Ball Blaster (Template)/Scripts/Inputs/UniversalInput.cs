using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace BallBlast
{
    [RequireComponent(typeof(Image))]
    public class UniversalInput : MonoBehaviour, IPlayerInput, IDragHandler, IPointerUpHandler, IPointerDownHandler
    {
        private Camera _camera;
        private float _touchPositionX;
        private bool _isPressed;
        private bool _isPointerDown;
        private bool _isPointerUp;
        private void Awake()
        {
            _camera = Camera.main;
            if(!gameObject.CompareTag(Tags.Input))
            {
                Debug.Log("This Needs To be Tagged Input!");
            }
            GetComponent<Image>().raycastTarget = true;
        }
        private void UpdatePositionX()
        {
            _touchPositionX = _camera.ScreenToWorldPoint(Input.mousePosition).x;
            Debug.Log(_touchPositionX);
        }
        #region Interface_Implementation
        public float GetTouchPointX()
        {
            return _touchPositionX;
        }
        public bool IsPointerDown()
        {
            if (_isPointerDown)
            {
                _isPointerDown = false;
                return true;
            }
            return false;
        }
        public bool IsPointerUp()
        {
            if (_isPointerUp)
            {
                _isPointerUp = false;
                return true;
            }
            return false;
        }
        public bool IsShooterPressed()
        {
            return _isPressed;
        }
        public void OnDrag(PointerEventData eventData)
        {
            UpdatePositionX();
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            _isPressed = true;
            _isPointerDown = true;
            Debug.Log("Down");
            UpdatePositionX();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _isPressed = false;
            _isPointerUp = true;
            Debug.Log("Up");
            UpdatePositionX();
        }
        #endregion
    }
}

