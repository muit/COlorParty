﻿var texture1 : Texture2D;
var texture2 : Texture2D;
var change : boolean = true;
 
function Start() {
        changeTexture();
}
 
function Update () {
 
}
 
function changeTexture () {
 
        while(change) {
                yield WaitForSeconds(0.5);
                GetComponent.<Renderer>().material.mainTexture = texture1;      
                yield WaitForSeconds(0.5);
                GetComponent.<Renderer>().material.mainTexture = texture2;
        }
}