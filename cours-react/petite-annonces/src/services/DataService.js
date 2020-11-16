import axios from "axios"
export const annonces = []
const urlBase = "http://localhost:3020"
export const getAnnonces = () => {
    // return new Promise((resolve, reject) => {
    //     setTimeout(() => {
    //         resolve(annonces)
    //     },3000)
    // })
    return axios.get(`${urlBase}/annonces`, {headers : {'Authorization' : 'Bearer a6c6890b-4841-391a-9868-eaee68711678'}})

}
let compteurAnnonce = 1



export const ajouterAnnonce = (annonce) => {
    // const tmpAnnonce = {
    //     ...annonce,
    //     id : compteurAnnonce
    // }
    // annonces.push(tmpAnnonce)
    // compteurAnnonce++
    return axios.post(`${urlBase}/annonce`, {...annonce})
}

export const search = (filter) => {
    // return new Promise((resolve, reject) => {
    //     const tmpAnnonces = annonces.filter(a => a.titre.includes(filtre) || a.description.includes(filtre))
    //     setTimeout(() => {
    //         resolve(tmpAnnonces)
    //     }, 3000)
    // })

    return axios.get(`${urlBase}/annonces/${filter}`)
}

export const getAnnonceById = (id) => {
    //return annonces.find(a => a.id == id)
    return axios.get(`${urlBase}/annonce/${id}`)
}


export let favoris = []

export const ajouterAuFavoris = (id) => {
    if(!dejaFavoris(id)) {
        const annonce = annonces.find(a=> a.id == id)
        favoris.push(annonce)
    }
}

export const retirerDesFavoris = (id) => {
    favoris = favoris.filter(a => a.id != id)
}

export const dejaFavoris = (id) => {
    const annonce = favoris.find(a => a.id == id)
    return annonce != undefined
}
const users = [
    {login : 'ihab', password : '1234567'}
]
export let isLogged = false
export const login = (login, password) => {
    const u = users.find(l => l.login == login && l.password == password)
    // if(u == undefined) {
    //     return false
    // } else {
    //     return false
    // }
    return u != undefined
}
export const changeIsLogged = (log) => {
    isLogged = log
}