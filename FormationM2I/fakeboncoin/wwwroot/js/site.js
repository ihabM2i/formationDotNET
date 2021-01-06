// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const form = document.querySelector("#searchForm")
const result = document.querySelector("#result")
form.addEventListener('submit', function (e) {
    e.preventDefault()
    result.innerHTML = "recherche en cours..."
    const searchValue = document.querySelector("input[name='search']").value
    fetch(e.target.getAttribute("action") + "?ajax=true&search=" + searchValue).then(res => res.text()).then((response) => {
        result.innerHTML = response
    })
})