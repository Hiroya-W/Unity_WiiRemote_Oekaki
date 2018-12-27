using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WiimoteApi;

public class GUICreater : MonoBehaviour {
	//wiimoteDemo Script
	public WiimoteDemo wiimoteDemo;
	//Menu Gameobject
	public GameObject Menuobj;
	//Wiimote found text
	public Text wmfoundtxt;
	//Extention text
	public Text Extentiontxt;

	//WMP Attached text
	public Text WMPtxt;


	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		//Wiimote取得状態表示
		wmfoundtxt.text = "Wiimote Found: " + WiimoteManager.HasWiimote();
		//メニュー表示
		if (wiimoteDemo.wiimote != null)
			Menuobj.SetActive(true);
		else{
			Menuobj.SetActive(false);
			return;
		}

		//コントローラの種類
		Extentiontxt.text = "Extension: " + wiimoteDemo.wiimote.current_ext.ToString();

		//Wii Motion Plus Attachedテキスト
		WMPtxt.text = "WMP Attached: " + wiimoteDemo.wiimote.wmp_attached;
		
	}

	//Find WiimoteBtnが押されたとき
	public void OnFindBtn(){
		WiimoteManager.FindWiimotes();
	}

	//CleanupBtnが押されたとき
	public void OnCleanupBtn(){
		WiimoteManager.Cleanup(wiimoteDemo.wiimote);
		wiimoteDemo.wiimote = null;
	}
	//LEDTextBtnが押されたとき
	public void OnLEDTestBtn(int num){
		int x = num;
		wiimoteDemo.wiimote.SendPlayerLED(x == 0, x == 1, x == 2, x == 3);
	}

	//Send ReportBtnが押されたとき
	//But/Acc
	public void OnButAccBtn(){
		wiimoteDemo.wiimote.SendDataReportMode(InputDataType.REPORT_BUTTONS_ACCEL);
	}
	//But/Ext8
	public void OnButExt8Btn(){
		wiimoteDemo.wiimote.SendDataReportMode(InputDataType.REPORT_BUTTONS_EXT8);
	}
	//B/A/Ext16
	public void OnButBAExt16Btn(){
		wiimoteDemo.wiimote.SendDataReportMode(InputDataType.REPORT_BUTTONS_ACCEL_EXT16);
	}
    //Ext21
	public void OnExt21Btn(){
		wiimoteDemo.wiimote.SendDataReportMode(InputDataType.REPORT_EXT21);	
	}            
	//Request Status Report Btnが押されたとき
	public void OnRequestStatusReportBtn(){
		wiimoteDemo.wiimote.SendStatusInfoRequest();
	}
	//IR Setup Sequence Btnが押されたとき
	//Basic
	public void OnBasicBtn(){
		wiimoteDemo.wiimote.SetupIRCamera(IRDataType.BASIC);
	}
	//Extended
	public void OnExtendedBtn(){
		wiimoteDemo.wiimote.SetupIRCamera(IRDataType.EXTENDED);
	}
	//Full
	public void OnFullBtn(){
		wiimoteDemo.wiimote.SetupIRCamera(IRDataType.FULL);
	}
    //Calibrate Accelerometer Btn
	public void OnCAccelerometerBtn(int x){
		AccelCalibrationStep step = (AccelCalibrationStep)x;
		wiimoteDemo.wiimote.Accel.CalibrateAccel(step);
	}

}
