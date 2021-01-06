// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const homeLink = "https://localhost:44301/"
const form = document.querySelector("#searchForm")
const result = document.querySelector("#result")
if (form != null && form != undefined) {
    form.addEventListener('submit', function (e) {
        e.preventDefault()
        result.innerHTML = "recherche en cours..."
        const searchValue = document.querySelector("input[name='search']").value
        fetch(e.target.getAttribute("action") + "?ajax=true&search=" + searchValue).then(res => res.text()).then((response) => {
            result.innerHTML = response
        })
    })
}

const formUpload = document.querySelector("#formAnnonce")

if (formUpload != null && formUpload != undefined) {
    formUpload.addEventListener('submit', function (e) {
        e.preventDefault()
        const data = new FormData()
        data.append("titre", document.querySelector('input[name="titre"]').value)
        data.append("prix", document.querySelector('input[name="prix"]').value)
        data.append("description", document.querySelector('textarea[name="description"]').value)
        data.append("images", document.querySelector('input[name="images"]').files[0])
        axios.post(e.target.getAttribute("action"), data).then(res => {
            if (res.data.error == false) {
                window.location = homeLink
            }
        })
    })
}


