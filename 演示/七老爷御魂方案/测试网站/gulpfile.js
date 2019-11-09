"use strict";
var gulp = require("gulp"),
    rimraf = require("rimraf"),
    concat = require("gulp-concat"),
    cssmin = require("gulp-cssmin"),
    uglify = require("gulp-uglify")

var paths = {
    webroot: "./wwwroot/"
};
paths.node_modules_libs = [
    'node_modules/iconv-lite/**/*.js',
    'node_modules/iconv-lite/**/*.ts',
    'node_modules/iconv-lite/**/*.json',
    'node_modules/safer-buffer/*.js'
]
paths.lib = paths.webroot + 'lib/*.js';
paths.js = "Scripts/*.js";
paths.minJs = paths.webroot + "js/**/*.min.js";
paths.concatJsDest = paths.webroot + "site.min.js";

gulp.task("compress", function () {
    // xcopy node_modules lib
    gulp.src(paths.node_modules_libs).
         pipe(gulp.dest(paths.webroot + 'lib'))
    // del min
    rimraf(paths.concatJsDest, function () { })
    // create min
    gulp.src([paths.js, "!" + paths.minJs, paths.lib], { base: "." }).
        pipe(concat(paths.concatJsDest)).
        pipe(uglify()).
        pipe(gulp.dest("."))
    // rd lib
    //rimraf(paths.webroot + 'lib/', function () { })
});