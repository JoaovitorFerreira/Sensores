import React, { Component } from 'react'
import axios from 'axios';
import { Doughnut } from 'react-chartjs-2';

export class GraficoTotalSensores extends Component {
    constructor(props) {
        super(props);
        this.state = { Data: {}, loading: true };
    }
    componentDidMount() {
        axios.get(`http://localhost:20020/api/sensor/graficos/total`)
            .then(res => {
                const results = res.data;
                this.setState({
                    Data: {
                        labels: ['total de sensores cadastrados'],
                        datasets: [
                            {
                                label: 'total de sensores',
                                data: [results],
                                backgroundColor: [
                                    'rgba(255, 99, 132, 0.2)'
                                ], borderColor: [
                                    'rgba(255, 99, 132, 1)',
                                ],
                                borderWidth: 1,

                            }
                        ]
                    },
                    loading: false
                });
            })
    }
    render() {

        const options = {
            responsive: true,
        };
        let contents = this.state.loading
            ? <p><em>Carregando...</em></p>
            : <div>
                <Doughnut data={this.state.Data}
                    options={options} />
            </div>
        return (

            <div>{contents}</div>


        )
    }
}

export default GraficoTotalSensores
