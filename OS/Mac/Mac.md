# Mac

##OSX.Admin

###Create ~/.bash_profile 

```
sudo nano ~/.bash_profile
```

###Create Terminal Aliases to show/hide hidden files in Finder

```
alias showFiles='defaults write com.apple.finder AppleShowAllFiles YES; killall Finder /System/Library/CoreServices/Finder.app'
alias hideFiles='defaults write com.apple.finder AppleShowAllFiles NO; killall Finder /System/Library/CoreServices/Finder.app'
```

Ctrl-O
Ctrl-X

Refresh your profile
```
source ~/.bash_profile
```

Now when you want to show hidden files, all you need type in Terminal is **showFiles**, then **hideFiles** when you want to hide them.

Reference:

[http://ianlunn.co.uk/articles/quickly-showhide-hidden-files-mac-os-x-mavericks/](http://ianlunn.co.uk/articles/quickly-showhide-hidden-files-mac-os-x-mavericks/)

##