import React, { Component } from 'react';


export interface SearchProps {
    search(value:String) : void
}

class Search extends Component<SearchProps, any> {
    constructor(props: SearchProps) {
        super(props);
    }
    render() { 
        return ( 
            <div className="row m-1">
                <input type="text" className="col form-control" placeholder="search" onChange={(e) => {
                    this.props.search(e.target.value)
                }} />
            </div>
         );
    }
}
 
export default Search;