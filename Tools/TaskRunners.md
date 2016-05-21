#Task Runners

##gulp - task runner

[Quick Start](http://markgoodyear.com/2014/01/getting-started-with-gulp)

```
npm install gulp-ruby-sass gulp-autoprefixer gulp-minify-css gulp-jshint gulp-concat gulp-uglify gulp-imagemin gulp-notify gulp-rename gulp-livereload gulp-cache del --save-dev
```

###gulp.js sample

[https://github.com/vincenthome/Build/blob/master/src/gulpfile.js](https://github.com/vincenthome/Build/blob/master/src/gulpfile.js)

([A bigger sample](https://gist.github.com/markgoodyear/8497946#file-gulpfile-js))

###gulp run specific task

```
gulp <taskname>
```


##Publish Package

###Node

[https://docs.npmjs.com/getting-started/publishing-npm-packages](https://docs.npmjs.com/getting-started/publishing-npm-packages)

##Bower

```
bower register <my-package-name> <git-endpoint>
// e.g.
bower register myPackage git://github.com/user/myPackage

// Remove
curl -X DELETE "https://bower.herokuapp.com/packages/<my-package-name>?access_token=<token>"
curl -X DELETE "http://bower.herokuapp.com/packages/<my-package-name>?access_token=<token>"
```

* Where <package> is the package name you want to delete and <token> is GitHub’s Personal Access Token that you can fetch from [GitHub settings](https://github.com/settings/applications)
* A default GitHub Personal Access Token will work – no permissions necessary
* You need to be an owner or collaborator of the repo and URL needs to be OK.

##gulp Reference

* [Getting Started](https://github.com/gulpjs/gulp/blob/master/docs/getting-started.md)
* [API Programming](https://github.com/gulpjs/gulp/blob/master/docs/API.md)
* [CLI Run Task](https://github.com/gulpjs/gulp/blob/master/docs/CLI.md)