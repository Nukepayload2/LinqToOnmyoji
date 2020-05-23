window.setProperty = function (element, property, value) {
    element[property] = value
}
window.getProperty = function (element, property) {
    return element[property]
}
window.clickElement = function (element) {
    element.click()
}
window.saveAsBlob = function (blobBody, fileName, charset) {
    var needBom = charset === "utf-8"
    var blobData = needBom ? [String.fromCharCode(0xFEFF), blobBody] : [blobBody]
    var blob = new Blob(blobData, { type: "text/plain;charset=" + charset + ";" })
    window.saveAs(blob, fileName)
}