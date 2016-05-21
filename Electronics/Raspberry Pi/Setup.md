#RPi.Setup

##Setup

* Mac SDFormatter
* Copy NOOBS
* Make sure select US on the bottom of the setup screen
* sudo Raspi-config
	* Change User Passwords
	* Change International Options -> Timezone
	* Enable Camera
	* Advanced -> Hostname
	* Advanced -> Enable SPI
	* Advanced -> Enable I2C

##Setup WiFi

`Startx`

* Setup WiFi via top right hand corner

```
sudo reboot
ifconfig #find the ip address of wlan0
```

##Remoting Console WITH network connection using SSH

Open Terminal in Mac, and run:

`ssh pi@ip_address`

If getting ** WARNING: REMOTE HOST IDENTIFICATION HAS CHANGED! **, try reset RSA key on host using:

`ssh-keygen -R ip_address`

##Remoting Console WITHOUT network connection(e.g outdoor) using a USB to TTL Console Cable

###Hardware Connection

* The black lead to GND, 
* The white lead to TXD.
* The green lead to RXD.
* If plan to use WiFi adapter (which draw high current)
  * **DO NOT CONNECT THE RED LEAD** 
  * Attach the AC->USB Power Adapter

###USB Console Cable Driver Download for Mac/Windows

[http://www.prolific.com.tw/US/ShowProduct.aspx?pcid=41&showlevel=0041-0041](http://www.prolific.com.tw/US/ShowProduct.aspx?pcid=41&showlevel=0041-0041)

###Connect to the Pi from Mac using TTL

`screen /dev/cu.usbserial 115200`

[Details here](https://learn.adafruit.com/adafruits-raspberry-pi-lesson-5-using-a-console-cable?view=all)

##Get Latest Packages

```
sudo apt-get update
sudo apt-get upgrade
```

##Setup VNC Server for Network GUI Desktop Remoting

```
sudo apt-get install tightvncserver
vncserver :1  #first time will prompt for a 'VNC Server' password
```

##Start VNC Server Manually from Mac using SSH

Open Terminal in Mac, and run:

```
ssh pi@ip_address
vncserver :1  #if not already started
```

###Run VNC Server at Startup - DOESN'T WORK!!!

*Create a file called vncboot and make it run at Startup*

```
cd /etc/init.d
#sudo nano vncboot
sudo wget https://raw.githubusercontent.com/vincenthome/RPi.Setup/master/vncboot
```

File: [vncboot](vncboot)

####Make file executable

`sudo chmod 755 vncboot`

####Enable dependency-based boot sequencing:

```
sudo update-rc.d /etc/init.d/vncboot defaults
sudo reboot
```

##Install VNC Viewer Client

* [Desktop](https://www.realvnc.com/download/viewer/)
* [iOS](https://www.realvnc.com/products/ios/)
* [Android](https://www.realvnc.com/products/android/)

###Run VNC Viewer Client

Use the ip address with the port # in the 'VNC Server' edit box.

** 192.168.x.x:1 **


##Setup Ftp

###Install FTP Server.

`sudo apt-get install vsftpd`

###Config FTP Server

`sudo nano /etc/vsftpd.conf`

####Disable Anonymous Login, change to 'NO'

`anonymous_enable=NO`

####Support non-anonymous login, specify user ftp folder

Add the following to the end of file:

```
local_enable=YES
write_enable=YES
local_umask=022
chroot_local_user=YES
user_sub_token=$USER
local_root=/home/$USER/ftp
```

####Create FTP Folders, Set Permission

```
mkdir /home/pi/ftp
mkdir /home/pi/ftp/files #folder where the upload/download happens
chmod a-w /home/pi/ftp   #root is not allowed to have write permission
```

###Restart FTP Server. 

`sudo service vsftpd restart`

###FTP Client

####In Mac/Linux

[Download](https://filezilla-project.org/download.php?type=client) FTP Client FileZilla

####In Windows

[Download](https://filezilla-project.org/download.php?type=client) FTP Client FileZilla

####Login

Host: ip_address
Username: pi
Password: ****
 
*p.s. file transfer happens inside the 'files' folder* 
 
##Setup GPIO

```
sudo apt-get install python-dev
sudo apt-get install python-rpi.gpio
```

##Setup PyFirmata

* Install Firmata sketch onto Arduino
* Install PyFirmata onto RPi

###Firmata on Arduino

From the Arduino IDE, Upload sketch:

File -> Examples -> Firmata -> StandardFirmata

###PyFirmata on Raspberry Pi

```
sudo apt-get install python-setuptools
git clone https://github.com/tino/pyFirmata.git
cd pyFirmata
sudo python setup.py install
```

###Testing

```
sudo python

>>> import pyFirmata
>>> board = pyfirmata.Arduino('/dev/ttyACM0')
>>> pin13 = board.get_pin('d:13:o')
>>> pin13.write(1)
>>> pin13.write(0)
>>> board.exit()
```

###Arduino UNO Serial Port(aka UART)

* USB interface: /dev/ttyACM0
* GPIO pins (RXD, TXD) interface: /dev/ttyAMA0
	* require level converter or resistors for changing 5V to 3V. Read RaspberryPi Cookbook 14.5

##Setup I2C

`sudo nano /etc/modules`

Add the following lines to the end of it:

```
i2c-bcm2708
i2c-dev
```

```
sudo apt-get install python-smbus
sudo reboot
```

###Using I2CTools to check the address of attached device

```
sudo apt-get install i2c-tools
sudo i2cdetect -y 1
```

###I2C with Arduino

####Raspberry Python
```
import smbus
import time

bus = smbus.SMBus(1)
# This must match in the Arduino Sketch
SLAVE_ADDRESS = 0x04

while True:
	#Write to Arduino
	bus.write_byte(SLAVE_ADDRESS, ord('l'))

	#Read from Arduino
	resultString = bus.read_byte(SLAVE_ADDRESS)
	resultInt = int(resultString)
	
	time.sleep(1)
```

####Arduion C++

[Arduino Wire Library](https://www.arduino.cc/en/reference/wire)
```
#include <Wire.h>
int SLAVE_ADDRESS = 0x04; 
int ledPin = 13;

int analogPin = A0;
boolean ledOn = false;

void setup() {
	/* Arduino Setup */
	pinMode(ledPin, OUTPUT);
	
	/* I2C Setup */
	Wire.begin(SLAVE_ADDRESS);
	Wire.onReceive(readFromRPi);
	Wire.onRequest(sendToRPi);		
}

void loop() {
}

void readFromRPi(int n) {
	/* Read from RPi */
	char ch = Wire.read(); 
	if (ch == 'l')
	{
		ledOn = !ledOn
		
		/* Arduino Ops - Write */
		digitalWrite(ledPin, ledOn);
	}
}

void sendToRPi() {
	/* Arduino Ops - Read */
	int reading = analogRead(analogPin);
	
	/* Write to RPi */
	Wire.write(reading >> 2);
}

```


##Setup SPI

`sudo nano /etc/modules`

Add the following lines to the end of it:

`spidev`

###Install Python Library

```
cd ~
git clone https://github.com/Gadgetoid/py-spidev
cd py-spidev/
sudo python setup.py install
```
##Install/Remove Software

`sudo apt-get install name`

```
sudo apt-get remove name
sudo apt-get autoremove name
sudo apt-get clean
```

##Download file from Web without using browser

`wget https://github.com/vincenthome/RPi.Setup/blob/master/README.md`

##Clone Git

```
sudo apt-get install git
git clone https://github.com/vincenthome/RPi.Setup.git
```

##Run script/app at Startup

###1. Create an init script

```
cd /etc/init.d
sudo nano startup_script
```
[Sample Script](startup_script)

###2. Make the script file executable

`sudo chmod 755 startup_script`

###3. Add Service to system:

`sudo update-rc.d startup_script defaults`
