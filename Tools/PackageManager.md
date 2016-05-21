#PackageManagers

Usage for package managers like npm bower nuget, task runners like gulp. Samples of package.json(npm), bower.json(bower), project.json(visual studio), gulp.js

# Package Managers

## Chocolatey Install Script

1. [Install Chocolatey Package Manager](https://chocolatey.org/)
2. Run Chocolatey Script on New Machine a: [https://gist.github.com/vincenthome/ebbe3c52ce7c65529341](https://gist.github.com/vincenthome/ebbe3c52ce7c65529341)

##Git Install - require by bower

* Install directly from git-scm.com
* Add git to path

##Nodejs Install

Install directly from nodejs.org

##npm - package manager for server-side components

###npm 'Manual' Install Global Package into user profile dir

```
npm install -g gulp  
npm install -g grunt-cli  
npm install -g bower      
npm install -g yo
```

###npm 'Manual' Install Local Package into ./node_modules

```
// goto local directory
npm install grunt  
```

###npm list what's installed globally

```
npm list -g --depth=0    
```

###npm get latest packages

Just **Run** npm install [-g] <package> **AGAIN** to update.

###npm create package.json from scratch

```
npm init
```

###package.json sample

[https://github.com/vincenthome/Build/blob/master/src/package.json](https://github.com/vincenthome/Build/blob/master/src/package.json)

###npm 'Auto' Install Local Package from dependencies found in package.json

```
// goto local directory
npm install
```


####Difference between tilde(~) and caret(^) in package.json
In the simplest terms, the tilde matches the most recent minor version (the middle number). ~1.2.3 will match all 1.2.x versions but will miss 1.3.0.

The caret, on the other hand, is more relaxed. It will update you to the most recent major version (the first number). ^1.2.3 will match any 1.x.x release including 1.3.0, but will hold off on 2.0.0.

##bower - package manager for client-side components

###bower.json sample

[https://github.com/vincenthome/Build/blob/master/src/bower.json](https://github.com/vincenthome/Build/blob/master/src/bower.json)

###bower (Preferred) 'Auto' Install Local Package from dependencies found in bower.json

```
// goto local directory
bower install
```

###bower 'Manual' Install Local Package into ./bower_components

```
// goto local directory
bower install angular  
```

###bower list packages what's installed

```
// goto local directory
bower list   
```

###bower create bower.json from scratch

```
bower init
```
