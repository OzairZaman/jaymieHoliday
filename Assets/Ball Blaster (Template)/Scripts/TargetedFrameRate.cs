using UnityEngine;

namespace BallBlast
{

    public class TargetedFrameRate : MonoBehaviour
    {

        [SerializeField] private int _targetedFrameRate = 60;

        private void Start()
        {
            Application.targetFrameRate = _targetedFrameRate;
        }

    }

}