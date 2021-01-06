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
menu.addEventListener("click", function (e) {
    e.preventDefault();
    //alert(e.target.getAttribute("href"))
    fetch(e.target.getAttribute("href")).then(res => {
        return res.text()
    }).then(response => {
        result.innerHTML = response
    })
})