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