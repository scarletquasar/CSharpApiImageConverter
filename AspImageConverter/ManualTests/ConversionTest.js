//Manual test passing to jpg and png base64 sources

function toDataURL(url, callback) {
    var xhr = new XMLHttpRequest();
    xhr.onload = function() {
      var reader = new FileReader();
      reader.onloadend = function() {
        callback(reader.result);
      }
      reader.readAsDataURL(xhr.response);
    };
    xhr.open('GET', url);
    xhr.responseType = 'blob';
    xhr.send();
}

toDataURL('https://picsum.photos/200/300', (img) => {
    console.log(img);
    fetch("/convert", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(
            {
                base64: img
                .replaceAll("data:image/png;base64,", "")
                .replaceAll("data:image/jpeg;base64,", "")
                .replaceAll("data:image/jpg;base64,", ""),
                output: "png"
            }
        )
    })
    .then(response => response.blob())
    .then(imageBlob => {
        const imageObjectURL = URL.createObjectURL(imageBlob);
        window.location.href = (imageObjectURL);
    });
})
