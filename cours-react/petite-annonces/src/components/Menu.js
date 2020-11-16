import React, { Component } from 'react';
import { Link } from 'react-router-dom';

// class Menu extends Component {
//     constructor(props) {
//         super(props);
//         this.state = {}
//     }
//     changeSelectTheme = (e) => {
//         this.props.changeTheme(e.target.value)
//     }
//     render() {
//         return (
//             <div className="navbar navbar-expand-lg navbar-light bg-light">
//                 <ul className="navbar-nav mr-auto">
//                     <li className="nav-item m-2">
//                         <Link to='/'>Home</Link>
//                     </li>
//                     <li className="nav-item m-2">
//                         <Link to='/addAnnonce'>Ajouter une annonce</Link>
//                     </li>
//                     <li className="nav-item m-2">
//                         <Link to='/favoris'>Favoris</Link>
//                     </li>
//                     <li className="nav-iem m-2">
//                         <select onChange={this.changeSelectTheme}><option>light</option><option>dark</option></select>
//                     </li>
//                 </ul>
//             </div>
//         );
//     }
// }
const Menu = (props) => {
    const changeSelectTheme = (e) => {
        props.changeTheme(e.target.value)
    }
    return (
        <div className="navbar navbar-expand-lg navbar-light bg-light">
            <ul className="navbar-nav mr-auto">
                <li className="nav-item m-2">
                    <Link to= {
                        {
                            pathname : "/" 
                        }
                    }>Home</Link>
                </li>
                <li className="nav-item m-2">
                    <Link to='/addAnnonce'>Ajouter une annonce</Link>
                </li>
                <li className="nav-item m-2">
                    <Link to='/favoris'>Favoris</Link>
                </li>
                <li className="nav-iem m-2">
                    <select onChange={changeSelectTheme}><option>light</option><option>dark</option></select>
                </li>
            </ul>
        </div>
    )
}
export default Menu;