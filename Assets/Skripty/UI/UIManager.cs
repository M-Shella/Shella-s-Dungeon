using System;
using System.Collections;
using System.Collections.Generic;
//using Unity.UNetWeaver;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    private static UIManager instance;
    [SerializeField]private GameObject toolTip;
    public static bool pauznuto;
    private Button[] tlacitka;
    public GameObject DeathScreen;
    public GameObject pauzeMenuUI;
    public GameObject menuUloz;
    public GameObject konecUloz;
    public GameObject menuNastaveni;
    private float manaRegen;
    public static UIManager MojeInstance {
        get {
            if (instance == null) instance = FindObjectOfType<UIManager>();
            return instance;
        }
    }

    private void Start() {
        tlacitka = pauzeMenuUI.GetComponentsInChildren<Button>();
        manaRegen = Time.time + 2f;
    }

    private void Update() {
        //ManaRegen
        if (Time.time > manaRegen) {
            if (Hrac.MojeInstance.mana < Hrac.MojeInstance.manaMax) {
                Hrac.MojeInstance.mana += 1;
                Hrac.MojeInstance.ChangeMana(0);
            }
            manaRegen = Time.time + 10f;
        }
        //Otevřít inventář
        if (Input.GetKeyDown(KeyCode.E)) {
            if (pauznuto) return;
            InventarSkript.MojeInstance.OtveritZavrit();
        }
        //Pauza
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Pauza(pauznuto);
        }
    }
    
    public void Pauza(bool onOff) {
        pauzeMenuUI.SetActive(!onOff);
        Time.timeScale = !onOff ? 0f : 1f;
        pauznuto = !onOff;
    }
    public void ShowToolTip(bool onOff,Vector3 pozice,string popis) {
        toolTip.SetActive(onOff);
        if (!onOff) return;
        toolTip.transform.position = pozice;
        toolTip.GetComponentInChildren<Text>().text = popis;
    }
    public void OptionsBack() {
        menuNastaveni.SetActive(false);
        pauzeMenuUI.SetActive(true);
    }
    public void Options() {
        menuNastaveni.SetActive(true);
        pauzeMenuUI.SetActive(false);
    }
    public void zpetDoMenuKliknuto() {
        foreach (Button tlacitko in tlacitka) {
            tlacitko.interactable = false;
        }
        menuUloz.SetActive(true);
    }
    public void konecHryKliknuto() {
        foreach (Button tlacitko in tlacitka) {
            tlacitko.interactable = false;
        }
        konecUloz.SetActive(true);
    }
    public void konecHryNoSaveKliknuto() {
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }
    public void MenuNoSaveKliknuto() {
        Pauza(pauznuto);
        SceneManager.LoadScene(0);
    }

    public void cancel(GameObject objekt) {
        objekt.SetActive(false);
        foreach (Button tlacitko in tlacitka) {
            tlacitko.interactable = true;
        }
    }
}
