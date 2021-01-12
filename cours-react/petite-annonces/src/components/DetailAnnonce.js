import React, { Component } from 'react';
import { ajouterAuFavoris, dejaFavoris, getAnnonceById, retirerDesFavoris } from '../services/DataService';
import { Carousel } from 'antd';

const contentStyle = {
    height: '200px',
    width : '700px',
    color: '#fff',
    lineHeight: '160px',
    textAlign: 'center',
    background: '#364d79',
  };

class DetailAnnonce extends Component {
    constructor(props) {
        super(props);
        this.state = {
            annonce: undefined,
            isFavoris: dejaFavoris(props.match.params.id)
        }
    }

    componentDidMount() {
        getAnnonceById(this.props.match.params.id).then(res => {
            if(!res.data.error) {
                this.setState({
                    annonce : res.data
                })
            }
            else {
                alert(res.data.message)
            }
        })
    }
    
    ajouterFavoris = () => {
        ajouterAuFavoris(this.state.annonce.id)
        this.setState({
            isFavoris: true
        })
    }

    retirerFavoris = () => {
        retirerDesFavoris(this.state.annonce.id)
        this.setState({
            isFavoris: false
        })
    }
    render() {
        return (
            <div className="container">
                {this.state.annonce != undefined ?
                    (
                        <div className="container">
                            <Carousel autoplay>
                                    {this.state.annonce.images.map((image, index) =>
                                        (<div key={index}><img style={contentStyle} src={image} /></div>)
                                    )}
                                </Carousel>
                            <div className="row m-1">
                                <h1 className="col">{this.state.annonce.titre}</h1>
                                <span className="col-2 h2">{this.state.annonce.prix} €</span>
                            </div>
                            <div className="row m-1">
                                <div className="col">
                                    {this.state.annonce.description}
                                </div>
                            </div>
                            <div className="row m-1">
                                {this.state.isFavoris ?
                                    (
                                        <button onClick={this.retirerFavoris} className="btn col btn-danger">Retirer des favoris</button>
                                    ) :
                                    (
                                        <button onClick={this.ajouterFavoris} className="btn col btn-warning">Ajouter aux favoris</button>
                                    )
                                }
                            </div>
                        </div>

                    ) :
                    (
                        <div> Aucune annonce avec cet id</div>
                    )
                }
            </div>);
    }
}

export default DetailAnnonce;