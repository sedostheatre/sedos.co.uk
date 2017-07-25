const fs = require('fs');
const gulp = require('gulp');
const spawn = require('child_process').spawn;
const toml = require('toml');
const path = require('path');
const sass = require('gulp-sass');

const THEME_NAME = toml.parse(fs.readFileSync('./config.toml', 'utf8')).theme;
const THEME_PATH = path.join(__dirname, 'themes', THEME_NAME);
const THEME_SCSS = path.join(THEME_PATH, 'src', 'css', '**', '*.scss');

gulp.task('sass', function () {
  return gulp.src(THEME_SCSS)
    .pipe(sass({outputStyle: 'compressed'}).on('error', sass.logError))
    .pipe(gulp.dest(path.join(THEME_PATH, 'static', 'css')));
});
 
gulp.task('sass:watch', function () {
  gulp.watch(THEME_SCSS, gulp.series('sass'));
});

gulp.task('hugo', (cb) => {
  spawn('hugo', ['server'], { stdio: 'inherit' }, (err) => {
    if (err) {
      return cb(err);
    }
    cb();
  });
});

gulp.task('default', gulp.parallel('hugo', 'sass', 'sass:watch'));
