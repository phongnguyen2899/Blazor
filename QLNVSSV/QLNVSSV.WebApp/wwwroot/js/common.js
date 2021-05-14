

function GetAPI(url,callback) {
    var obj
    fetch(url)
        .then(response => response.json())
        .then(data => {
            obj = JSON.parse(JSON.stringify(data))
            callback(this.obj);
        })
}