import React, { Component } from 'react';
import axios from 'axios';

export class SensoresCadastrados extends Component {
    displayName = "Lista de Sensores"
    constructor(props) {
        super(props);
        this.state = {
            SensorData: [],
            loading: true
        }
    }
    componentDidMount() {
        axios.get("http://localhost:20020/api/sensor").then(response => {
            this.setState({
                SensorData: response.data,
                loading: false
            });
        });
    }

    render() {
    let contents = this.state.loading
        ? <p><em>Carregando...</em></p>
        : <table className='table'>
            <thead>
                <tr>
                    <th>Id</th>
                    <th>Tag</th>
                    <th>Status</th>
                    <th>Valor</th>
                    <th>Data</th>
                </tr>
            </thead>
            <tbody>
                {
                    this.state.SensorData.map((p, index) => {
                        return (<tr key={index}>
                            <td>{p.Id}</td>
                            <td>{p.Tag}</td>
                            <td>{p.Status == 0 && "Erro"}
                                {p.Status == 1 && "Processado"}</td>
                            <td>{p.Valor}</td>
                            <td>{p.Timestamp}</td>
                        </tr>)
                    })
                }
            </tbody>
        </table>

        return (
            <div>
                <h1>Sensores cadastrados</h1>
                {contents}
            </div>
        );
    }
}
