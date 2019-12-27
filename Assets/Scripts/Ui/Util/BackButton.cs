﻿using System.Collections;
using System.Collections.Generic;
using HexCardGame.UI;
using Tools.Patterns.Singleton;
using UnityEngine;

public interface IBackHandler
{
    void Show();
    void Back();
}

public class BackButton : SingletonMB<BackButton>
{
    readonly Stack<IBackHandler> _windows = new Stack<IBackHandler>();
    
    [SerializeField] UiMenu uiMenu;

    public void Push(IBackHandler window) => _windows?.Push(window);

    public void Clear() => _windows.Clear();
    
    public void Pop()
    {
        if (_windows.Count < 1)
            return;
        var window = _windows.Pop();
        window.Back();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_windows.Count < 1)
                uiMenu.Show();
            else
                Pop();
        }
    }
}