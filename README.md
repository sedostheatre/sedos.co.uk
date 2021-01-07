# Sedos

The new site for [Sedos](https://www.sedos.co.uk), built using Statiq.

## Developing

### Windows
To run locally:

```powershell
build.ps1 -Target Preview
```

### Mac / Linux

#### Pre-requisites
.NET Core 2.1 is required - installers and binaries are available on the [official download page](https://dotnet.microsoft.com/download/dotnet-core/2.1)

#### Run
```shell
./build.sh --target=Preview
```

## Testing

#### Pre-requisites
- `npm` is installed an executable
- `npx` is installed (`npm install -g npx`)
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
- Cake as a build tool
  - Makes it easy to get up and running, doesn't need any special tools and handles bootstrapping itself
- Sass for styling
  - Supported by Statiq, nice syntax to work with
- Bootstrap for framework
  - Because it's easy :)
- GitHub actions for CI
- [Netlify](https://www.netlify.com/) for hosting
- [NetlifyCMS](https://www.netlifycms.org/) for content management

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
