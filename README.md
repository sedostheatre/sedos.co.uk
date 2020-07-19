# Sedos

The new site for [Sedos](https://www.sedos.co.uk), built using Wyam.

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

- Wyam as a static site generator
  - Very flexible, allows a lot of configuration and supports nice templating languages (e.g. razor)
- Cake as a build tool
  - Makes it easy to get up and running, doesn't need any special tools and handles bootstrapping itself
- Sass for styling
  - Supported by wyam, nice syntax to work with
- Bootstrap for framework
  - Because it's easy :)
- GitHub actions for CI
- Netlify for hosting

## Local Netlify Dev
- run `npx netlify-cms-proxy-server`
- add `local_backend: true` to `config.yml`
- visit [](http://localhost:5080/admin/#/)