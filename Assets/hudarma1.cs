using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityEngine.UI
{

    public class hudarma1 : MonoBehaviour
    {
        [SerializeField] private Image customImage;
        public PlayerController playerController;
        void Update()
        {
            if (playerController.disparo1)
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



