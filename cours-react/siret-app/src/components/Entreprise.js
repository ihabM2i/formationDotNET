import React from "react"

const Entreprise = (props) => {
    return (
        <div className="row">
            {props.entreprise != undefined ? (
                <div className="col">
                    <div className="row m-1">
                        <div className="col-2">Nom entreprise : </div>
                        <div className="col">{props.entreprise.uniteLegale.denominationUniteLegale}</div>
                    </div>
                    <div className="row m-1">
                        <div className="col-2">Date de création : </div>
                        <div className="col">{props.entreprise.dateCreationEtablissement}</div>
                    </div>
                    <div className="row m-1">
                        <div className="col-2">Adresse : </div>
                        <div className="col">
                            {props.entreprise.adresseEtablissement.numeroVoieEtablissement + ' '}
                            {props.entreprise.adresseEtablissement.typeVoieEtablissement + ' '}
                            {props.entreprise.adresseEtablissement.libelleVoieEtablissement + ' '}
                            {props.entreprise.adresseEtablissement.libelleCommuneEtablissement + ' '}
                            {props.entreprise.adresseEtablissement.codePostalEtablissement + ' '}
                        </div>
                    </div>
                </div>
            ) : null}
        </div>
    )
}

export default Entreprise