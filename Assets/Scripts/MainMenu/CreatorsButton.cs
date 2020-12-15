using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreatorsButton : MonoBehaviour
{
    [SerializeField] private CanvasGroup _creatorsPanelCanvasGroup;
    [SerializeField] private Button _backToMenuButton;
    [SerializeField] private float _fadeTime;

    private bool _isClickOnBackButton = false;
    private float _elapsedTime = 0;

    public void OnButtonClick ()
    {
        _creatorsPanelCanvasGroup.gameObject.SetActive(true);
        _creatorsPanelCanvasGroup.DOFade(1, _fadeTime);
    }

    public void OnBackButtonClick ()
    {
        _creatorsPanelCanvasGroup.DOFade(0, _fadeTime);
        _isClickOnBackButton = true;
    }

    private void FixedUpdate ()
    {
        if (_isClickOnBackButton)
        {
            _elapsedTime += Time.fixedDeltaTime;

            if (_elapsedTime >= _fadeTime)
            {
                _creatorsPanelCanvasGroup.gameObject.SetActive(false);

                _elapsedTime = 0;
                _isClickOnBackButton = false;
            }
        }
    }
}
