#AutoHotKey

[AutoHotkey](http://ahkscript.org)

##Create Script - *.ahk

* Save it in Startup folder 
* Folder location: `Win+R` `shell:startup`

##Hotkeys

* [Common](https://autohotkey.com/docs/Tutorial.htm#s21)
* [Complete](https://autohotkey.com/docs/KeyList.htm)

##Sending Key Strokes - prefer `SendInput`

* [Common](https://autohotkey.com/docs/Tutorial.htm#s3)
* [Complete](https://autohotkey.com/docs/commands/Send.htm)

###Example: Logitech Setpoint Keystroke Assignment to add `Win Key` 

```
; map Shift-Ctrl-Alt-LeftArrow to Ctrl-Win-LeftArrow
+^!Left::
	SendInput, ^#{Left}
Return

; map Shift-Ctrl-Alt-RightArrow to Ctrl-Win-RightArrow
+^!Right::
	SendInput, ^#{Right}
Return

; map Shift-Ctrl-Alt-x to Win-x
+^!x::
	SendInput, #x
Return
```
