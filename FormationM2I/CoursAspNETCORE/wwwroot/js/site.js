// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
//$("#form").on('submit', function (e) {
//    e.preventDefault();
//    $.ajax({
//        url
//    })
//})

const menu = document.querySelector(".menu")
const result = document.querySelector(".result")
const form = new FormData()
form.append("nom", "abadi")
const data = {
    'firstName' : 'abadi',
}
menu.addEventListener("click", function (e) {
    e.preventDefault();
    //alert(e.target.getAttribute("href"))
    fetch(e.target.getAttribute("href"),
        {
            method: "POST",
            body: JSON.stringify(data),
            headers: {"Content-type" : "application/json"}
        }
    ).then(res => {
        return res.text()
    }).then(response => {
        result.innerHTML = response
    })
})

const formUpload = document.querySelector("#upload")
const progress = document.querySelector("#progress")
const config = {
    onUploadProgress : (progressEvent) => {
        let completed = Math.round((progressEvent.loaded * 100) / progressEvent.total)
        progress.style.width = completed + "%"
    }
}
formUpload.addEventListener('submit', function (e) {
    e.preventDefault()
    const dataUpload = new FormData()
    //for (let image of document.querySelector("input[type='file']").files) {
    //    dataUpload.append("image", image)
    //}
    dataUpload.append("image", document.querySelector("input[type='file']").files[0])
    dataUpload.append("titre" ,"titre 1")
    //fetch(e.target.getAttribute("action"),
    //    {
    //        method: "POST",
    //        body: dataUpload,
    //    }
    //).then(res => {
    //    return res.text()
    //}).then(response => {
    //    console.log(response)
    //})

    axios.post(e.target.getAttribute("action"), dataUpload, config).then(res => {
        console.log(res)
    })
})
