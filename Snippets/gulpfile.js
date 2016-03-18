/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp'),
    contact = require('gulp-concat'),
    cssmin = require('gulp-cssmin'),
    uglufy = require('gulp-uglify');


var paths = {
    webroot : "./wwwroot/"
}


paths.bootstrap = "./bower_components/bootstrap/dist/css/bootstrap.css";
paths.fontAwesome = "./bower_components/font-awesome/css/font-awesome.css";
paths.jquery = "./bower_components/jquery/dist/jquery.js";
paths.jqueryValidation = "./bower_components/jquery-validation/dist/jquery.validate.js";

paths.fonts = "./bower_components/font-awesome/fonts/*";

paths.jsDest = paths.webroot + "js";
paths.cssDest = paths.webroot + "css";
paths.fontDest = paths.webroot + "fonts";



gulp.task('min:js', function () {
    return gulp.src([paths.jquery, paths.jqueryValidation])
        .pipe(contact(paths.jsDest + "/min/site.min.js"))
        .pipe(uglufy())
        .pipe(gulp.dest("."));
});


gulp.task('copy:js', function () {
    return gulp.src([paths.jquery, paths.jqueryValidation])
        .pipe(gulp.dest(paths.jsDest));
});



gulp.task('min:css', function () {
    return gulp.src([paths.bootstrap, paths.fontAwesome])
        .pipe(contact(paths.cssDest + "/min/site.min.css"))
        .pipe(cssmin())
        .pipe(gulp.dest("."));
});


gulp.task('copy:css', function () {
    return gulp.src([paths.bootstrap, paths.fontAwesome])
        .pipe(gulp.dest(paths.cssDest));
});


gulp.task('copy:fonts', function () {
    return gulp.src([paths.fonts])
        .pipe(gulp.dest(paths.fontDest));
});


gulp.task("min", ["min:js", "min:css"]);

gulp.task("copy", ["copy:js", "copy:css", "copy:fonts"]);