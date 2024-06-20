using System;
using UnityEngine;
using UnityEngine.Events;

public class ButtonPressManager : MonoBehaviour
{
    [SerializeField] private CheckDistanceWithOther distanceWithCharacter;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float activationDistance;

    [Header("Sprites")]
    [SerializeField] private Sprite offSprite;
    [SerializeField] private Sprite onSprite;

    private bool _isActive;

    public UnityEvent<bool> buttonActivationChange;

    private void Update()
    {
        var currentDistance = distanceWithCharacter.getDistance();

        if (currentDistance < activationDistance)
        {
            activateButton();
        }
        else
        {
            deactivateButton();
        }
    }

    private void activateButton()
    {
        if (_isActive) return;

        _isActive = true;
        spriteRenderer.sprite = onSprite;
        buttonActivationChange.Invoke(_isActive);
    }

    private void deactivateButton()
    {
        if (!_isActive) return;

        _isActive = false;
        spriteRenderer.sprite = offSprite;
        buttonActivationChange.Invoke(_isActive);
    }
}