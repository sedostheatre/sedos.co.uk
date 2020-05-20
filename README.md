# Sedos

The new site for [Sedos](www.sedos.co.uk), built using Wyam.

## Developing

To run locally (on Windows), run

```powershell
build.ps1 -Target Preview
```

and then browse the site on [localhost:5080](localhost:5080).

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


-- forcing a rerun