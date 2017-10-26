﻿using UnityEngine;
using UnityEngine.UI;

public abstract class GameUIManager : CoreComponent {

    [SerializeField] protected GameObject readyUI;
    [SerializeField] protected GameObject figthUI;
    [SerializeField] protected GameObject scoreUI;
    [SerializeField] protected GameObject pauseUI;

    [SerializeField] protected FadeUI fadeUIScript;

    // Activates the ready UI.
    public void ActivateReadyUI() {
        readyUI.SetActive(true);
        figthUI.SetActive(false);
        scoreUI.SetActive(false);
    }

    // Activates the figth UI.
    public void ActivateFigthUI() {
        readyUI.SetActive(false);
        figthUI.SetActive(true);
        scoreUI.SetActive(false);
    }

    // Activates the score UI.
    public void ActivateScoreUI() {
        readyUI.SetActive(false);
        figthUI.SetActive(false);
        scoreUI.SetActive(true);
    }

    // Activates or deactivates the pause UI.
    public void ActivatePauseUI(bool b) {
        pauseUI.SetActive(b);
    }

    // Converts seconds and minutes to text and adds extra 0 if needed.
    protected string TimeToString(int t) {
        string s = t.ToString();

        if (t < 0)
            return "00";
        else if (s.Length > 1)
            return s;
        else
            return "0" + s;
    }

    public void Fade(float min, float max, bool mustLigthen, float duration) {
        fadeUIScript.StartFade(min, max, mustLigthen, duration);
    }

    public abstract void SetColorAll(Color c);

}