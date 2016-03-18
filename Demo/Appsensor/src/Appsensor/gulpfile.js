/// <binding AfterBuild='copy, min' />
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


paths.bootstrapCss = "./bower_components/bootstrap/dist/css/bootstrap.css";
paths.fontAwesomeCss = "./bower_components/font-awesome/css/font-awesome.css";

paths.bootstrapJs = "./bower_components/bootstrap/dist/js/bootstrap.js";
paths.jqueryJs = "./bower_components/jquery/dist/jquery.js";
paths.jqueryValidationJs = "./bower_components/jquery-validation/dist/jquery.validate.js";

paths.fonts = "./bower_components/font-awesome/fonts/*";

paths.jsDest = paths.webroot + "js";
paths.cssDest = paths.webroot + "css";
paths.fontDest = paths.webroot + "fonts";



gulp.task('min:js', function () {
    return gulp.src([paths.jqueryJs, paths.jqueryValidationJs])
        .pipe(contact(paths.jsDest + "/min/site.min.js"))
        .pipe(uglufy())
        .pipe(gulp.dest("."));
});


gulp.task('copy:js', function () {
    return gulp.src([paths.jqueryJs, paths.jqueryValidationJs, paths.bootstrapJs])
        .pipe(gulp.dest(paths.jsDest));
});



gulp.task('min:css', function () {
    return gulp.src([paths.bootstrapCss, paths.fontAwesomeCss])
        .pipe(contact(paths.cssDest + "/min/site.min.css"))
        .pipe(cssmin())
        .pipe(gulp.dest("."));
});


gulp.task('copy:css', function () {
    return gulp.src([paths.bootstrapCss, paths.fontAwesomeCss])
        .pipe(gulp.dest(paths.cssDest));
});


gulp.task('copy:fonts', function () {
    return gulp.src([paths.fonts])
        .pipe(gulp.dest(paths.fontDest));
});


gulp.task("min", ["min:js", "min:css"]);

gulp.task("copy", ["copy:js", "copy:css", "copy:fonts"]);