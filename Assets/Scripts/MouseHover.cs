using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Animator _animator;
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        _animator.SetBool("IsHover", true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _animator.SetBool("IsHover", false);
    }
}
