using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasControl : MonoBehaviour
{
    [SerializeField] private GameObject HiCanvas;
    [SerializeField] private GameObject SkillCanvas;
    [SerializeField] private GameObject WerkhoudingCanvas;
    [SerializeField] private GameObject LeerdoelCanvas;
    [SerializeField] private GameObject SHMUPCanvas;


    private void Start()
    {
        HiCanvas.SetActive(true);
        SkillCanvas.SetActive(false);
        WerkhoudingCanvas.SetActive(false);
        LeerdoelCanvas.SetActive(false);
        SHMUPCanvas.SetActive(false);
    }

    public void ClickSkillButton()
    {
        HiCanvas.SetActive(false);
        SkillCanvas.SetActive(true);
        WerkhoudingCanvas.SetActive(false);
        LeerdoelCanvas.SetActive(false);
        SHMUPCanvas.SetActive(false);
    }

    public void ClickWerkhoudingButton()
    {
        HiCanvas.SetActive(false);
        SkillCanvas.SetActive(false);
        WerkhoudingCanvas.SetActive(true);
        LeerdoelCanvas.SetActive(false);
        SHMUPCanvas.SetActive(false);
    }

    public void ClickLeerdoelButton()
    {
        HiCanvas.SetActive(false);
        SkillCanvas.SetActive(false);
        WerkhoudingCanvas.SetActive(false);
        LeerdoelCanvas.SetActive(true);
        SHMUPCanvas.SetActive(false);
    }

    public void ClickSHMUPButton()
    {
        HiCanvas.SetActive(false);
        SkillCanvas.SetActive(false);
        WerkhoudingCanvas.SetActive(false);
        LeerdoelCanvas.SetActive(false);
        SHMUPCanvas.SetActive(true);
    }

}
