﻿using UnityEngine;
using UnityEngine.UI;

namespace HexCardGame.UI
{
    public class UiMenu : UiParentMenu
    {
        [SerializeField] Button[] buttons;
        [SerializeField] Slider zoomSlider;
        [SerializeField] Toggle flatToggle;
        [SerializeField] Toggle pointyToggle;
        Camera MainCamera { get; set; }

        protected override void Awake()
        {
            zoomSlider.onValueChanged.AddListener(OnZoomChanged);
            flatToggle.onValueChanged.AddListener(OnFlatTogglePressed);
            pointyToggle.onValueChanged.AddListener(OnPointyTogglePressed);
            foreach (var i in buttons) 
                i.onClick.AddListener(Hide);

            MainCamera = Camera.main;
            base.Awake();
        }

        void OnZoomChanged(float value) => MainCamera.orthographicSize = value;

        void OnPointyTogglePressed(bool isEnabled)
        {
            if (isEnabled) boardController.CreateBoardPointy();
        }

        void OnFlatTogglePressed(bool isEnabled)
        {
            if (isEnabled) boardController.CreateBoardFlat();
        }
    }
}