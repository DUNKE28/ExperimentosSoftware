import Vue from 'vue'
import Router from 'vue-router'
import Home from './views/Home.vue'
import Paciente from './components/Paciente.vue'
import Orden from './components/Orden.vue'
import Ingreso from './components/Ingreso.vue'
import Servicio from './components/Servicio.vue'
import Tarifa from './components/Tarifa.vue'
import Parking from './components/Parking.vue'
import Espacio from './components/Espacio.vue'
import Vehiculo from './components/Vehiculo.vue'
import Administrador from './components/Administrador.vue'
import Cajero from './components/Cajero.vue'
import Login from './components/Login.vue'
import Comprobante from './components/Comprobante.vue'




Vue.use(Router)

export default new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/pacientes',
      name: 'pacientes',
      component: Paciente
    },
 
    {
      path: '/ordenes',
      name: 'ordenes',
      component: Orden
    },
    {
      path:'/ingresos',
      name:'ingresos',
      component: Ingreso
    },{
      path: '/servicios',
      name: 'servicios',
      component: Servicio
    },
    {
      path: '/tarifas',
      name: 'tarifas',
      component: Tarifa
    },
    {
      path: '/login',
      name: 'login',
      component: Login
    },
    {
      path: '/administradores',
      name: 'administradores',
      component: Administrador
    },
    {
      path: '/cajeros',
      name: 'cajeros',
      component: Cajero
    },
    {
      path: '/parkings',
      name: 'parkings',
      component: Parking
    },
    {
      path: '/espacios',
      name: 'espacios',
      component: Espacio
    },
    {
      path: '/comprobantes',
      name: 'comprobantes',
      component: Comprobante
    },
    {
      path: '/vehiculos',
      name: 'vehiculos',
      component: Vehiculo
    }
  ]
})
