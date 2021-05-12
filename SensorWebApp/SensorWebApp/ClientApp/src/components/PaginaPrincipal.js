import React, { Component } from 'react';
import GraficoTotalSensores from './Graficos/GraficoTotalSensores';
import GraficoTotalRegiao from './Graficos/GraficoQntdSensorPorRegiao';

export class PaginaInicial extends Component {
    displayName = PaginaInicial.name

  render() {
    return (
      <div>
            <h1>Sensores Radix</h1>
            <GraficoTotalSensores />
            <GraficoTotalRegiao />

      </div>
    );
  }
}
