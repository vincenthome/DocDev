# RPi.StepperMotor

##Using 28BJY-48 with ULN2003 control board

###Interfacing With The Pi

The motor connects to the controller board with a pre-supplied connector. The controller board has  4+2 pins that need to be connected to the Pi header (P1).

* 5V (P1-02)
* GND (P1-06)
* Define GPIO signals to use
* Physical pins 11,15,16,18
* GPIO17,GPIO22,GPIO23,GPIO24

###Running
As with all Python scripts that use the GPIO library it needs to be run using “sudo”:

`
sudo python stepper.py
`

*Press Ctrl-C to quit.*

###Specify Wait time
To specify a different wait time you can pass a number of milliseconds as an argument on the command line using:

`sudo python stepper.py 20`

where 20 is the number of milliseconds.

###Step Sequences
The 4 step sequence is faster but the torque is lower. It’s easy to stop the rotation by holding the motor spindle. The 8 step sequence is slower but the torque is much higher. 


####Videos explains different kind of Steps Sequences

[Overview](https://youtu.be/Dc16mKFA7Fo?t=15s)

[Step Sequences](https://youtu.be/Dc16mKFA7Fo?t=5m11s)

#####Datasheet
[Stepper-Motor-28BJY-48-Datasheet.pdf](Stepper-Motor-28BJY-48-Datasheet.pdf)

#####Code
[stepper.py](stepper.py)

######3 types:

* SeqSinglePhase
* SeqFullDualPhase
* SeqHalfStep

######Direction (clockwise or anti-clockwise)

* StepDir = 1 or -1


