# CSharpApiImageConverter
Rest API example for real-time image conversion from "base64" codes.

## Usage
### General
Currently this project is an image converter example, being able to accept a Base64 code of any type and convert it to the 
following types:

- png
- jpg
- bmp

**POST - From direct base 64 code**

Use `dotnet run` and access the endpoint `/convert/` with a POST request providing the
`file` and `output` arguments as Base64 and output type.

**GET - From url**

Use `dotnet run` and access the endpoint `/convert/` with a GET request providing the
`file` and `output` arguments as URL path and output type.

### Manual Testing

To test the API you might go to the endpoint `/test/` and paste the "ManualTests/ConversionTest.js" in the console, by the default code
you will be redirected to a Lore Picsum image converted by the AspImageConverter.

### Unit Tests
The project uses XUnit to setup unit tests, currently passing in the tests:

- ImageConversionIntegrity (More info in the test)
