﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Window : MonoBehaviour , IPointerClickHandler, IPointerDownHandler  {

	[SerializeField] Button closeButton = null;
    [SerializeField] Transform content = null;
    RectTransform mRectTrans = null;
    [SerializeField] WindowSystem windowSystem = null;

    public Transform Content {
        get { return content; }
    }

	void Awake(){
		if (null != closeButton) {
			closeButton.onClick.AddListener (CloseWindow);
		}
		mRectTrans = GetComponent<RectTransform> ();
		mRectTrans.anchorMin = new Vector2 (0.0f, 1.0f);
		mRectTrans.anchorMax = new Vector2 (0.0f, 1.0f);
	}

    private void Start() {
        windowSystem = GetComponentInParent<WindowSystem>();
    }

    public void SetPosition(Vector2 position) {
        mRectTrans.anchoredPosition = position;
    }

	private void CloseWindow(){
		GameObject.Destroy (gameObject);
	}
		
	public void OnPointerClick(PointerEventData data){
		Debug.Log ("clic");
	}

	public void OnPointerDown(PointerEventData data){
        if(null != windowSystem)
            windowSystem.BringToFront (this);
	}

}