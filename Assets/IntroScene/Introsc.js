#pragma strict

var CubeRenderer : Renderer;
public var buttonWidth : int = 200;
public var buttonHeight : int = 650;
public var spacing : int = 50; 

function Start () {

}

function Update () {

}

function OnGUI() {
	 GUILayout.BeginArea(Rect(900, 230, 250, 700));
     
    if(GUILayout.Button("Start",GUILayout.Height(buttonHeight))) {
        Application.LoadLevel("title");
    }
     

    GUILayout.Space(spacing);

  
    if(GUILayout.Button("Exit", GUILayout.Height(buttonHeight))) {
        Application.Quit();
    }
     
 
    GUILayout.EndArea();
}
