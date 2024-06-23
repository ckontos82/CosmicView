# CosmicView

## Using the NASA Astronomy Picture of the Day API

The app is built as a modular monolith, consisting of three projects:

* **CosmicViewApi:** The local API.
* **CosmicViewMVC:** The MVC project.
* **CosmicViewSharedLib:** A shared library between the modules that includes interfaces and models.

The app uses the `DEMO_API` key. The setting is located in the `CosmicViewApi` project, within the `appsettings.json` file. If you want to use your own API key, you can request a new one on the <a href="https://api.nasa.gov/" target="_blank_">official NASA API webpage</a>.

**Disclaimer:** This is a personal project created for educational purposes only. It is not affiliated with NASA or the NASA API in any way.