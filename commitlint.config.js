module.exports = {
    extends: ['@commitlint/config-conventional'],
  
    // https://github.com/conventional-changelog/commitlint/blob/master/docs/reference-rules.md
    rules: {
      'header-max-length': [1, 'always', 72],
    }
  }