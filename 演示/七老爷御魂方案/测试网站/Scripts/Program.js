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
    var blob = new Blob([String.fromCharCode(0xFEFF), blobBody], { type: "text/csv;charset=" + charset })
    window.saveAs(blob, fileName)
}