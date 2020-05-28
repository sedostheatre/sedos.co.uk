# Sedos

The new site for [Sedos](www.sedos.co.uk), built using Wyam.

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

On any platform the site should then be available on [localhost:5080](localhost:5080).

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
