import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { PaginaInicial } from './components/PaginaPrincipal';
import { SensoresCadastrados } from './components/SensoresCadastrados';
import { FiltroDeSensores } from './components/FiltroDeSensores';

export default class App extends Component {
    displayName = App.name

    render() {
        return (
            <Layout>
                <Route exact path='/' component={PaginaInicial} />
                <Route path='/SensoresCadastrados' component={SensoresCadastrados} />
                <Route path='/FiltroDeSensores' component={FiltroDeSensores} />
            </Layout>
        );
    }
}
