using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityEngine.UI
{

    public class hudarma2 : MonoBehaviour
    {
        [SerializeField] private Image customImage;
        public PlayerController playerController;
        void Update()
        {
            if (playerController.disparo2)
            {
                customImage.enabled = true;
            }
            else
            {
                customImage.enabled = false;
            }
        }
    }
}
