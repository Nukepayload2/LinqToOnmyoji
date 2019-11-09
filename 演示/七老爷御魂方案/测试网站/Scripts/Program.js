window.setProperty = function (element, property, value) {
    element[property] = value
}
window.clickElement = function (element) {
    element.click()
}
window.saveAsBlob = function (blobBody, fileName) {
    var blob = new Blob([String.fromCharCode(0xFEFF), blobBody], { type: "text/csv;charset=utf-8" })
    window.saveAs(blob, fileName)
}