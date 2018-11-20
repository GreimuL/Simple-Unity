using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleVisualizer : MonoBehaviour {
    public AudioSource music;
    public GameObject visual;
    public Transform visP;
    public RectTransform[] visuals = new RectTransform[64];
    public float[] spectrum = new float[64];
    // Use this for initialization
    void Start () {
        float angle = 0;
        for(int i = 0; i < 64; i++){
            visuals[i] = Instantiate(visual).GetComponent<RectTransform>();
            visuals[i].localPosition = new Vector2(3*Mathf.Cos(angle), 3*Mathf.Sin(angle));
            visuals[i].localRotation = Quaternion.Euler(0,0,angle);
            visuals[i].parent = visP;
            visuals[i].sizeDelta = new Vector2(1, 1);
            angle += 360 / 64;
        }
	}
	
	// Update is called once per frame
	void Update () {
        music.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);
       
        for(int i = 0; i < 64; i++){
            if (spectrum[i] * 5 > 0.5f){
                visuals[i].sizeDelta = new Vector2(0.2f, 0.5f);
            }
            else{
                visuals[i].sizeDelta = new Vector2(0.2f, spectrum[i] * 10);
            }
        }
    }
}
