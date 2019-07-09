using UnityEngine;

namespace BallBlast
{

    public class GameStartedDisappearingObject : MonoBehaviour
    {

        private void Start()
        {
            GameObject.FindWithTag(Tags.GameManager).GetComponent<GameManager>().GameStartedEvent += () => gameObject.SetActive(false);
        }

    }

}