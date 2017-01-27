/// <reference path="node_modules/@types/knockout/index.d.ts" />

/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');
var less = require('gulp-less');
var path = require('path');

var browserify = require("browserify");
var browserifybower = require("browserify-bower");
var debowerify = require('debowerify');
var source = require('vinyl-source-stream');
var tsify = require("tsify");
var uglify = require('gulp-uglify');
var pump = require('pump');

gulp.task('default', function () {
    //return browserify({
    //    basedir: '.',
    //    debug: true,
    //    entries: ['wwwroot/script/main.ts'],
    //    cache: {},
    //    packageCache: {}
    //})
    //.plugin(tsify)
    //.bundle()
    //.pipe(source('bundle.js'))
    //.pipe(gulp.dest("wwwroot/dist"));

    return browserify({debug: true})
        //.add('node_modules/@types/knockout/index.d.ts')
        .add('wwwroot/script/index.ts')
        .plugin(tsify, { typescript: require('typescript') })
        //.plugin('browserify-bower', {
        //    require: ['*', '@types/knockout'],
        //    alias: ['wwwroot/lib/knockoutjs:knockout'], // or alias: { 'base62/lib/base62':'base62', ... } 
        //    mainfiles: { // specify the main file for packages without a bower.json 
        //        'knockout': 'dist/knockout.js'
        //    }
        //})
        .bundle()
        .on('error', function (error) { console.error(error.toString()); })
        .pipe(source('bundle.js'))
        .pipe(gulp.dest('wwwroot/script/'));
});

gulp.task('compress', function (cb) {
    pump([
          gulp.src('wwwroot/script/bundle.js'),
          uglify(),
          gulp.dest('wwwroot/script/')
    ],
      cb
    );
});

gulp.task('less', function () {
    return gulp.src('wwwroot/css/**/*.less')
   .pipe(less({
       paths: [path.join(__dirname, 'less', 'includes')]
   }))
   .pipe(gulp.dest('wwwroot/css/'));
});