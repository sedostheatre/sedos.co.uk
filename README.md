# Sedos

The website for [Sedos](https://www.sedos.co.uk), built using Statiq.

## Dev environment setup

### VSCode/Devcontainers/Codespaces

Configuration files exist to automatically spin up a working dev environment, so the easiest option is to use those

### Alternatives

You'll need to have dotnet 6, and a recent version of nodejs installed.

## Running

To run locally:

```shell
dotnet run preview
```

## Testing

#### Pre-requisites
- `npm` is installed and executable
- `npx` is installed and executable (`npm install -g npx`)
- `cypress` is executable (`npx cypress verify`)

#### Run
- there's a small suite of Cypress tests, that can be run through
- `npm i`
- starting a dev server, either through the preview command, or with `npx serve -p 5080 output`, assuming the site has been built already
- `npx cypress run`

On any platform the site should then be available on [localhost:5080](http://localhost:5080).

Changes will be rebuilt and the page should update in sync.

## Tech stack/design choices

- Statiq as a static site generator
  - Very flexible, allows a lot of configuration and supports nice templating languages (e.g. razor)
  - Statiq is the evolution of Wyam, and splits out the build chain into separate files
- Sass for styling
  - Supported by Statiq, nice syntax to work with
- Bootstrap for framework
  - Because it's easy :)
- GitHub actions for CI
- [Netlify](https://www.netlify.com/) for hosting
- [DecapCMS](https://decapcms.org/) for content management (formerly known as NetlifyCMS)

### Sub-pages architecture
Basic process: cs file pipelines process md files.
Metadata in md files is used as variables in text, headers, navigation, etc.
Variables include things like title, times, venue.

#### Events
- md files from input/events/*.md processed by Pipelines/Events.cs
- maps to [schema.org PlayAction](https://schema.org/PlayAction)
- Metadata key, description : ordinality --> schema.org value
  - title, PlayAction/Name : 1  -->  PlayAction/Name
  - times : 1
    - time, the individual start times : 1..n --> for schema.org, see below
        - first time is PlayAction/startTime
        - all times are in PlayAction/event/eventSchedule (https://schema.org/eventSchedule)
  - image, the image in the page : 1
  - header-image, the image for the header, if different than the main image : 0..1
  - recurrence, when the event regularly recurs : 1
  - venue : 0..1
  - ticket-prices: 0..1

#### Show
TO DO - AllShows

#### News
TO DO

#### Venues
TO DO

#### RegularEvents
TO DO

## Local Netlify Dev
- run `npx netlify-cms-proxy-server`
- add `local_backend: true` to `config.yml`
- visit [](http://localhost:5080/admin/#/)

## Linting

### SCSS
`stylelint` is used to lint the `**/*.scss` files on build.

This can be run locally (and automatically fix errors) with `npx stylelint --fix **/*.scss`
