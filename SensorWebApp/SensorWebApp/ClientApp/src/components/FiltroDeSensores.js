import React, { Component } from 'react';
import axios from 'axios';
export class FiltroDeSensores extends Component {
    displayName = "Busca de sensores"
    constructor(props) {
        super(props);
        this.state = {
            TagToSearch: '',
            SensorData: [],
            totalResults: 0,
            loading: false
        }
    }


    onSearchChange = e => {
        console.log(e.target.value)
        this.setState({
            TagToSearch: e.target.value,
            loading: true
        });



    }


    handleOnInputChange = (event) => {
        const TagToSearch = event.target.value;
        if (!TagToSearch) {
            this.setState({ TagToSearch });
        } else {
            this.setState({ TagToSearch, loading: true }, () => {
                this.fetchSearchResults(TagToSearch);
            });
        }
    };

    fetchSearchResults = (TagToSearch) => {
        const searchUrl = `http://localhost:20020/api/sensor/tag/${TagToSearch}`;

        axios.get(searchUrl)
            .then(res => {
                console.log(res.data.length)
                const total = res.data.length;
                this.setState({
                    SensorData: res.data,
                    totalResults: total,
                    loading: false
                })
            })
    }




    render() {

        const { TagToSearch, loading, totalResults } = this.state;

        let contents = loading
            ? <p><em>Carregando...</em></p>
            : <table className='table'>
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Tag</th>
                        <th>Status</th>
                        <th>Valor</th>
                        <th>Data Sensor</th>

                    </tr>
                </thead>
                <tbody>
                    {
                        this.state.SensorData.map((p, index) => {
                            return (<tr key={index}>
                                <td>{p.Id}</td>
                                <td>{p.Tag}</td>
                                <td>{p.Status}</td>
                                <td>{p.Valor}</td>
                                <td>{p.Timestamp}</td>
                            </tr>)
                        })
                    }
                </tbody>
            </table>

        return (
            <div>
                <div>
                    <h1>Procure seu sensor, por regiao ou pais</h1>
                    <label className="search-label" htmlFor="search-input">
                        <input
                            type="text"
                            name="query"
                            value={TagToSearch}
                            id="search-input"
                            placeholder="Escreva aqui..."
                            onChange={this.handleOnInputChange}
                        />
                    </label>
                    {totalResults > 0 ? <h2> Total de sensores encontrados: {totalResults} </h2> : <p></p>}
                </div>
                {contents}
            </div>
        );
    }
}
