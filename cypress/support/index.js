// ***********************************************************
// This example support/index.js is processed and
// loaded automatically before your test files.
//
// This is a great place to put global configuration and
// behavior that modifies Cypress.
//
// You can change the location of this file or turn off
// automatically serving support files with the
// 'supportFile' configuration option.
//
// You can read more here:
// https://on.cypress.io/configuration
// ***********************************************************

// Import commands.js using ES2015 syntax:
import './commands'

// The name of the cookie holding whether the user has accepted
// the cookie policy
const CONSENT_COOKIE_NAME = "CookieControl";
// The value meaning that user has accepted the cookie policy
const CONSENT_COOKIE_VALUE = '{"necessaryCookies":[],"optionalCookies":{"analytics":"revoked"},"statement":{},"consentExpiry":90,"interactedWith":true}';

Cypress.on("window:before:load", window => {
  window.document.cookie = `${CONSENT_COOKIE_NAME}=${CONSENT_COOKIE_VALUE}`;
});
