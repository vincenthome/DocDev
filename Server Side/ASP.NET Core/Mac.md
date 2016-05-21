#ASP.NET5 for OSX

ASP.NET 5 and DNX on OSX

[https://github.com/aspnet/home](https://github.com/aspnet/home)

1. Install Homebrew
2. 'tab' aspnet/dnx
3. Install dnvm
4. source dnvm.sh or put it in ~/.bash_profile
4. dnvm upgrade
5. Select dnx version to use
6. Console App: dnx . run
7. Web App: dnx . kestrel
8. Browse your localhost:5004 or 5001
9. May need to put export MONO_MANAGED_WATCHER=false in ~/.bash_profile
 
##New Project

1. npm install -g bower gulp yo
2. npm install -g generator-aspnet
3. Generate asp.net project with gulp tasks: yo aspnet --gulp
4. dnu restore (VSCode ⌘ P -> dnx: dnu restore)
4. dnx . kestrel (VSCode dnx: dnx: kestrel)

####References

* [Running Asp.Net 5 on OSX - Part 1
Setup and Troubleshooting](http://hjgraca.github.io/2015/05/12/AspNet5-OSX-Setup-Troubleshoot/)

