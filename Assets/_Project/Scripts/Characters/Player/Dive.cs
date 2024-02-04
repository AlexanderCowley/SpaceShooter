using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

public class Dive : MonoBehaviour
{
    PlayerInput _playerActions;
    InputAction _currentAction;

    [SerializeField] float diveSpeed;
    float _battleArea = 0.0f;
    float _diveArea = 10.0f;

    Tween _diveForward;
    Tween _diveBack;

    bool _isDiving = false;

    void Awake() 
    {
        _playerActions = GetComponent<PlayerInput>();
    }

    void TweenInit()
    {
        DOTween.Init(false);

        _diveForward = transform.DOMoveZ(_diveArea, .25f).
                            SetAutoKill(true).
                            Pause().
                            SetRecyclable(false);
    }

    void InitDiveUp()
    {
        _diveBack = transform.DOMoveZ(_battleArea, .25f).
                    SetAutoKill(true).
                    Pause().
                    SetRecyclable(false);

        StopCoroutine(tweenWait(_diveForward));

        _diveBack.Play();
        StartCoroutine(tweenWait(_diveBack));
    }

    IEnumerator tweenWait(Tween tweenToKill)
    {
        yield return tweenToKill.WaitForKill(false);

        InitDiveUp();
        yield return null;
    }

    IEnumerator dive()
    {
        _isDiving = true;
        transform.DOMoveZ(_diveArea, .25f, true);
        yield return new WaitForSeconds(.25f);
        transform.DOMoveZ(_battleArea, .25f, true).OnComplete(() => _isDiving = false);
    }

    void OnEnable() => InitPlayerInput();

    void InitPlayerInput()
    {
        _currentAction = _playerActions.actions["Dive"];
        _currentAction.started += OnDive;
    }

    void OnDive(InputAction.CallbackContext context)
    {
        if (_isDiving)
            return;

        StartCoroutine(dive());
    }

    void OnDisable() => _currentAction.started -= OnDive;
}