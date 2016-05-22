/// <binding Clean='clean' />

var gulp = require("gulp"),
  rimraf = require("rimraf"),
  fs = require("fs");

// Read project.json and returns a JSON object
eval("var project = " + fs.readFileSync("./project.json"));

// project.webroot has the value of the 'webroot' key of project.json file
var paths = {
  bower: "./bower_components/",
  lib: "./" + project.webroot + "/lib/"
};

gulp.task("clean", function (cb) {
  rimraf(paths.lib, cb);
});

gulp.task("copy", ["clean"], function () {
  // The format is 'destDir' : "srcDir"
  var bower = {
    "bootstrap": "bootstrap/dist/**/*.{js,map,css,ttf,svg,woff,eot}",
    "bootstrap-touch-carousel": "bootstrap-touch-carousel/dist/**/*.{js,css}",
    "hammer.js": "hammer.js/hammer*.{js,map}"
  }

  // paths.bower: source root path.
  // paths.lib: destination root path
  // bower[destDir]: source directory
  // destDir: destination directory
  // copy 'source root path + source directory' to 'destination root path + destination directory'
  for (var destDir in bower) {
    gulp.src(paths.bower + bower[destDir])
      .pipe(gulp.dest(paths.lib + destDir));
  }
});
