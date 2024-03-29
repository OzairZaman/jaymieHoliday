﻿using UnityEngine;

namespace BallBlast
{

    public class GameStartedAppearingObject : MonoBehaviour
    {

        private void Start()
        {
            GameObject.FindWithTag(Tags.GameManager).GetComponent<GameManager>().GameStartedEvent += () => gameObject.SetActive(true);

            gameObject.SetActive(false);
        }

    }

}