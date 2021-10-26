# asp-image-converter
Rest API example for real-time image conversion from "base64" codes. Under development.

## Usage
### General
Currently this project is an image converter example, being able to accept a Base64 code of any type and convert it to the 
following types:

- png
- jpg
- bmp

To get started just clone the repository, use `dotnet run` and access the endpoint `/convert/` with a POST request providing the
`file` and `output` arguments.

### Tests
The project uses XUnit to setup unit tests, currently passing in the tests:

- ImageConversionIntegrity
