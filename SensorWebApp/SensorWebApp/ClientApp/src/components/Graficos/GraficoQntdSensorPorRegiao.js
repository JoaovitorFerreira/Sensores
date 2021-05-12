import React, { Component } from 'react'
import axios from 'axios';
import { Bar } from 'react-chartjs-2';





export class GraficoTotalRegiao extends Component {
    constructor(props) {
        super(props);
        this.state = {
            Data: {},
            loading: true
        };
    }

    componentDidMount() {
        axios.get("http://localhost:20020/api/sensor/graficos/regioes/total")
            .then(res => {
                const result = res.data;
                const valuesData = [];
                const labelsData = [];
                result.forEach(regions => {
                    valuesData.push(regions.Total);
                    labelsData.push(regions.Regiao);
                });
                this.setState({
                    Data: {
                        labels: labelsData,
                        datasets: [
                            {
                                label: ['total de sensores por regiao'],
                                data: valuesData,
                                backgroundColor: [
                                    'rgba(255, 99, 132, 0.2)',
                                    'rgba(54, 162, 235, 0.2)',
                                    'rgba(255, 206, 86, 0.2)',
                                    'rgba(75, 192, 192, 0.2)',
                                    'rgba(153, 102, 255, 0.2)',
                                ], borderColor: [
                                    'rgba(255, 99, 132, 1)',
                                    'rgba(54, 162, 235, 1)',
                                    'rgba(255, 206, 86, 1)',
                                    'rgba(75, 192, 192, 1)',
                                    'rgba(153, 102, 255, 1)',
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
            scales: {
                yAxes: [
                    {
                        ticks: {
                            beginAtZero: true,
                        },
                    },
                ],
            },
        };
        let contents = this.state.loading
            ? <p><em>Carregando...</em></p>
            : <div>
                <Bar data={this.state.Data}
                    options={options} />
            </div>
        return (

            <div>{contents}</div>


        )
    }
}

export default GraficoTotalRegiao
